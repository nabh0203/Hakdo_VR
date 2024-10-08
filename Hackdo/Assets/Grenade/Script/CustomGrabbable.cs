using UnityEngine;
using OculusSampleFramework;

public class CustomGrabbable : OVRGrabbable
{
    public float customThrowForce = 10f;// throwForce -> customThrowForce

    // Grab 종료 시 호출되는 함수
    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(linearVelocity, angularVelocity);
        CapsuleCollider cc = GetComponent<CapsuleCollider>();
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            // linearVelocity는 손이 놓았을 때의 속도입니다.
            // 이 값을 활용하여 "던지기" 효과를 구현할 수 있습니다.
            rb.velocity = linearVelocity * customThrowForce; // throwForce -> customThrowForce
            cc.isTrigger = false;
            
            rb.useGravity = true;
        }
    }
}