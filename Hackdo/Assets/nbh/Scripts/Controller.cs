using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float speedForward = 12f; //���� �ӵ�
    public float speedSide = 12f; //������ �ӵ�
    public AudioClip walkingSound; // �߰��� �Ҹ�

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

        // AudioSource ������Ʈ�� �������ų� �߰�
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        // �߰��� �Ҹ� ����
        audioSource.clip = walkingSound;
        audioSource.loop = true; // ���带 �ݺ����
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

        // �÷��̾ �����̸� �߰��� �Ҹ� ���, ���߸� ����
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
