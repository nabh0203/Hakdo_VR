using System.Collections;
using UnityEngine;
using OculusSampleFramework; // For OVRGrabbable

public class Pin : OVRGrabbable
{
    // ���۽� ������ٵ�� ���� ����
    private Rigidbody rb;

    
    protected override void Start()
    {
        // �θ� Ŭ������ Start �޼��� ȣ��
        base.Start();
        //������ٵ� �������� �����Ͷ�
        rb = GetComponent<Rigidbody>();
    }
    //�׷�������
    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        // �θ� Ŭ������ Start �޼��� ȣ��
        base.GrabBegin(hand, grabPoint);

        // �� ���� ������Ʈ�� �θ� null�� �����Ͽ� �θ�� �и�
        transform.SetParent(null);

        
        
    }
    //�׷����� �����ɽ�(������)
    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        // �θ� Ŭ������ GrabEnd������
        base.GrabEnd(linearVelocity, angularVelocity);

        // �ı��ϴ� �ڸ�ƾ�Լ� 3�� �� ����
        StartCoroutine(DestroyAfterDelay(3f));
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        //���������Ʈ ������ٵ𿡼� Ű��ƽ�� ���� �߷��� Ȱ��ȭ
        rb.isKinematic = false;
        rb.useGravity = true;
        // ������ �ð���ŭ ���
        yield return new WaitForSeconds(delay);

        // �ı��ض�
        Destroy(gameObject);
        // If you want to trigger an explosion or something when the pin is pulled,
        // you could do it here.
    }
}
