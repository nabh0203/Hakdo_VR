using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ohshit : MonoBehaviour
{
    public GameObject[] spawnPoints; // ���� ����Ʈ �迭

    // Ʈ���ſ� �浹 �� ȣ��Ǵ� �Լ�
    private void OnTriggerEnter(Collider other)
    {
        // �浹�� ������Ʈ�� �±װ� "Player"�� ���
        if (other.gameObject.CompareTag("Player"))
        {
            // ��� ���� ����Ʈ�� Ȱ��ȭ
            foreach (GameObject spawnPoint in spawnPoints)
            {
                spawnPoint.SetActive(true);
            }
        }
    }
}
