using UnityEngine;
using OculusSampleFramework;

public class CustomGrabbable : OVRGrabbable
{
    public float customThrowForce = 10f;// throwForce -> customThrowForce

    // Grab ���� �� ȣ��Ǵ� �Լ�
    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(linearVelocity, angularVelocity);
        CapsuleCollider cc = GetComponent<CapsuleCollider>();
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            // linearVelocity�� ���� ������ ���� �ӵ��Դϴ�.
            // �� ���� Ȱ���Ͽ� "������" ȿ���� ������ �� �ֽ��ϴ�.
            rb.velocity = linearVelocity * customThrowForce; // throwForce -> customThrowForce
            cc.isTrigger = false;
            
            rb.useGravity = true;
        }
    }
}