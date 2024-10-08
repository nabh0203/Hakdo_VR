using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speedForward = 12f; //전진 속도
    public float speedSide = 12f; //옆걸음 속도
    public AudioClip walkingSound; // 발걸음 소리

    private CharacterController characterController;
    private Transform vrCameraTransform; //Center Eye Camera transform
    private AudioSource audioSource;

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

        // AudioSource 컴포넌트를 가져오거나 추가
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        // 발걸음 소리 설정
        audioSource.clip = walkingSound;
        audioSource.loop = true; // 사운드를 반복재생
    }

    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        float dirX = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).x;
        float dirZ = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick).y;

        Vector3 moveDir = new Vector3(dirX * speedSide, 0, dirZ * speedForward);

        // Transform the movement vector to be relative to the VR camera's direction.
        moveDir = vrCameraTransform.TransformDirection(moveDir);

        characterController.SimpleMove(moveDir);

        // 플레이어가 움직이면 발걸음 소리 재생, 멈추면 멈춤
        if (moveDir != Vector3.zero && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
        else if (moveDir == Vector3.zero)
        {
            audioSource.Stop();
        }
    }
}
