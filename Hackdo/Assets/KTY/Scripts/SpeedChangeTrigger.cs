using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedChangeTrigger : MonoBehaviour
{
    public PlayerForwardController playerController;
    public Transform playerTransform;
    public GameObject objectToParent; // �ڽ����� ���� ������Ʈ
    public AudioClip newSound; // ���ο� ���� Ŭ��
    public SubtitleSystem subtitleSystem; // SubtitleSystem ��ũ��Ʈ ����

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // �ӵ��� 0���� ����
            playerController.ChangeSpeed(0, 0);

            // ������ ������Ʈ�� �ڽ����� ����
            objectToParent.transform.position = playerTransform.position;
            objectToParent.transform.parent = playerTransform;

            // ����� Ŭ���� ���ο� ����� ��ü
            playerController.audioSource.clip = newSound;

            // UI1 ��Ȱ��ȭ
            subtitleSystem.SetUI1Active(false);
            subtitleSystem.SetUI2Active(true);

        }
    }
}

