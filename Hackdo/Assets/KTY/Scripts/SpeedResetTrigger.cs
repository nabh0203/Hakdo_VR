using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedResetTrigger : MonoBehaviour
{
    public PlayerForwardController playerController;
    public GameObject objectToUnparent; // �θ�-�ڽ� ���踦 ������ ������Ʈ

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // �ӵ��� ������� ����
            playerController.ResetSpeed();

            // ������ ������Ʈ�� �θ�-�ڽ� ���迡�� ����
            objectToUnparent.transform.SetParent(null);
        }
    }
}

