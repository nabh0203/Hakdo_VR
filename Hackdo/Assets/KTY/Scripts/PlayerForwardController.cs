using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForwardController : MonoBehaviour
{
    public float speedForward = 12f; //전진 속도
    public float speedBackward = 6f; //후진 속도
    public float speedSide = 12f; //옆걸음 속도
    public AudioSource audioSource; // Inspector에서 음성 클립이 있는 AudioSource를 지정해주세요.

    private float originalSpeedBackward;
    private float originalSpeedSide;
    private CharacterController characterController;
    private Transform vrCameraTransform; //Center Eye Camera transform

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        if (characterController == null)
        {
            Debug.LogError("Failed to find Character Controller.");
        }

        vrCameraTransform = GameObject.Find("CenterEyeAnchor").transform;
        if (vrCameraTransform == null)
        {
            Debug.LogError("Failed to find CenterEyeAnchor.");
        }

        // 원래의 속도값 저장
        originalSpeedBackward = speedBackward;
        originalSpeedSide = speedSide;

        // 오디오 소스가 없을 경우 생성
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }


    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float dirX = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x;
        float dirZ = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y;

        float speed = dirZ > 0 ? speedForward : speedBackward;
        Vector3 moveDir = new Vector3(dirX * speedSide, 0, dirZ * speed);

        moveDir = vrCameraTransform.TransformDirection(moveDir);

        characterController.SimpleMove(moveDir);

        // 움직임이 있으면
        if (moveDir != Vector3.zero)
        {
            // 오디오가 재생되지 않고 있다면 오디오를 재생합니다.
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            // 움직임이 없으면 오디오를 멈춥니다.
            audioSource.Stop();
        }
    }


    // 속도 변경 함수
    public void ChangeSpeed(float newSpeedBackward, float newSpeedSide)
    {
        speedBackward = newSpeedBackward;
        speedSide = newSpeedSide;
    }

    // 원래의 속도로 복구하는 함수
    public void ResetSpeed()
    {
        speedBackward = originalSpeedBackward;
        speedSide = originalSpeedSide;
    }
}

