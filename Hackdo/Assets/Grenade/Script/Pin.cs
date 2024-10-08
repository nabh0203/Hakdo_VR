using System.Collections;
using UnityEngine;
using OculusSampleFramework; // For OVRGrabbable

public class Pin : OVRGrabbable
{
    // 시작시 리지드바디용 변수 생성
    private Rigidbody rb;

    
    protected override void Start()
    {
        // 부모 클래스의 Start 메서드 호출
        base.Start();
        //리지드바디 컴파일을 가져와라
        rb = GetComponent<Rigidbody>();
    }
    //그랩했을시
    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        // 부모 클래스의 Start 메서드 호출
        base.GrabBegin(hand, grabPoint);

        // 이 게임 오브젝트의 부모를 null로 설정하여 부모와 분리
        transform.SetParent(null);

        
        
    }
    //그랩에서 해제될시(놨을시)
    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        // 부모 클래스의 GrabEnd가져와
        base.GrabEnd(linearVelocity, angularVelocity);

        // 파괴하는 코르틴함수 3초 후 실행
        StartCoroutine(DestroyAfterDelay(3f));
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        //현재오브젝트 리지드바디에서 키네틱을 끄고 중력을 활성화
        rb.isKinematic = false;
        rb.useGravity = true;
        // 지정된 시간만큼 대기
        yield return new WaitForSeconds(delay);

        // 파괴해라
        Destroy(gameObject);
        // If you want to trigger an explosion or something when the pin is pulled,
        // you could do it here.
    }
}
