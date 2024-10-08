using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerWalk : MonoBehaviour
{
    public Transform playerTransform; // Player Transform
                                      // �÷��̾��� ������ġ����
    public Vector3 offset; // ī�޶��� ����3�� ��ġ��
    //����
    public float bobbingSpeed = 2f;
    //  ī�޶� ������ ��
    public float bobbingAmountY = 0.2f;
    // Y�� ��ġ ��
    public float bobbingAmountX = 0.1f;
    //  X�� ��ġ ��

    private Vector3 defaultPos;
    // ����3 �� �ʱⰪ ����

    private void Start()
    {
        // �ʱⰪ�� Public ������ �� �Ҵ�
        defaultPos = offset;
        // y���� 0���� �����ϰ� x��� z���� �ʱⰪ �״�� ����
        offset = new Vector3(offset.x, 1.8f, offset.z);
    }

    private void Update()
    {
        // Oculus ��Ʈ�ѷ��� ���� ���̽�ƽ �Է� ���� ������
        Vector2 thumbstick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

        // ���� ���̽�ƽ y���� 0���� Ŭ �� �� ���� ���� �� 
        if (thumbstick.y > 0 || thumbstick.x > 0 || thumbstick.x < 0 || thumbstick.y < 0) // When the joystick of the left controller is pointed up
        {
            //Debug.Log("Moving joystick up");
            //Mathf.sin�Լ��� �ð� �� ���ǵ尪�� y������ ���̺�ó�� �̵���Ŵ�� ���ÿ�
            float wavesliceY = Mathf.Sin(Time.time * bobbingSpeed);
            // x�൵ �̵���Ų�� �߰��� 0.5f�� ���Ͽ� �� �� ������ ����
            float wavesliceX = Mathf.Sin(Time.time * bobbingSpeed * 0.5f);
            // y,x ������ ���鿡�� waveslice ���¿� ��ġ���� ���԰� ���ÿ� pos.y�� �ؼ� ��ġ�Ҵ� 
            offset.y = Mathf.Abs(defaultPos.y + wavesliceY * bobbingAmountY);
            offset.x = defaultPos.x + wavesliceX * bobbingAmountX;
            //Debug.Log(offset);
        }
        else
        {
            // ���� ���� �� �ٽ� ���� �ʱ� ��ġ ������ ���ƿ�
            offset = defaultPos;
        }

        // ����������, ���� ��ġ ���� �� ��ü�� ���� ��ġ ������ ����
        transform.localPosition = offset;
        /*Debug.Log(transform.localPosition);*/
    }
}