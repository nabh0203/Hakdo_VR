using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerForwardController : MonoBehaviour
{
    public float speedForward = 12f; //���� �ӵ�
    public float speedBackward = 6f; //���� �ӵ�
    public float speedSide = 12f; //������ �ӵ�
    public AudioSource audioSource; // Inspector���� ���� Ŭ���� �ִ� AudioSource�� �������ּ���.

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

        // ������ �ӵ��� ����
        originalSpeedBackward = speedBackward;
        originalSpeedSide = speedSide;

        // ����� �ҽ��� ���� ��� ����
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

        // �������� ������
        if (moveDir != Vector3.zero)
        {
            // ������� ������� �ʰ� �ִٸ� ������� ����մϴ�.
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else
        {
            // �������� ������ ������� ����ϴ�.
            audioSource.Stop();
        }
    }


    // �ӵ� ���� �Լ�
    public void ChangeSpeed(float newSpeedBackward, float newSpeedSide)
    {
        speedBackward = newSpeedBackward;
        speedSide = newSpeedSide;
    }

    // ������ �ӵ��� �����ϴ� �Լ�
    public void ResetSpeed()
    {
        speedBackward = originalSpeedBackward;
        speedSide = originalSpeedSide;
    }
}

