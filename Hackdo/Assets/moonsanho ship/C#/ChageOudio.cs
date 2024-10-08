using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChageOudio : MonoBehaviour
{
    public PlayerForwardController playerController; // PlayerForwardController ��ũ��Ʈ�� ������ public ������ �����մϴ�.
    public AudioClip newSound; // ���ο� ���� Ŭ���� �����ϴ� public ������ �����մϴ�.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("�浹");
            // ����� Ŭ���� ���ο� ����� ��ü
            playerController.audioSource.clip = newSound;
            playerController.audioSource.Play(); // ����� Ŭ���� ����մϴ�.
        }
    }
}
