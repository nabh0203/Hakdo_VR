using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerWalk : MonoBehaviour
{
    public Transform playerTransform; // Player Transform
                                      // 플레이어의 변형위치변수
    public Vector3 offset; // 카메라의 벡터3의 위치값
    //변수
    public float bobbingSpeed = 2f;
    //  카메라 움직임 값
    public float bobbingAmountY = 0.2f;
    // Y축 위치 값
    public float bobbingAmountX = 0.1f;
    //  X축 위치 값

    private Vector3 defaultPos;
    // 벡터3 의 초기값 변수

    private void Start()
    {
        // 초기값에 Public 설정한 값 할당
        defaultPos = offset;
        // y축은 0으로 설정하고 x축과 z축은 초기값 그대로 유지
        offset = new Vector3(offset.x, 1.8f, offset.z);
    }

    private void Update()
    {
        // Oculus 컨트롤러의 왼쪽 조이스틱 입력 값을 가져와
        Vector2 thumbstick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

        // 만약 조이스틱 y축이 0보다 클 시 즉 위로 향할 시 
        if (thumbstick.y > 0 || thumbstick.x > 0 || thumbstick.x < 0 || thumbstick.y < 0) // When the joystick of the left controller is pointed up
        {
            //Debug.Log("Moving joystick up");
            //Mathf.sin함수로 시간 과 스피드값을 y축으로 웨이브처럼 이동시킴과 동시에
            float wavesliceY = Mathf.Sin(Time.time * bobbingSpeed);
            // x축도 이동시킨다 추가로 0.5f를 곱하여 좀 더 빠르게 설정
            float wavesliceX = Mathf.Sin(Time.time * bobbingSpeed * 0.5f);
            // y,x 변형된 값들에서 waveslice 형태와 위치값을 곱함과 동시에 pos.y를 해서 위치할당 
            offset.y = Mathf.Abs(defaultPos.y + wavesliceY * bobbingAmountY);
            offset.x = defaultPos.x + wavesliceX * bobbingAmountX;
            //Debug.Log(offset);
        }
        else
        {
            // 만약 놓을 시 다시 원래 초기 위치 값으로 돌아옴
            offset = defaultPos;
        }

        // 마지막으로, 계산된 위치 값을 이 객체의 로컬 위치 값으로 설정
        transform.localPosition = offset;
        /*Debug.Log(transform.localPosition);*/
    }
}