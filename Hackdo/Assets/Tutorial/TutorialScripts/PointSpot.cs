using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpot : MonoBehaviour
{
    public GameObject targetObject; // Ȱ��ȭ�� ������Ʈ�� Inspector���� �������־�� �մϴ�.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            targetObject.SetActive(true); // ������Ʈ�� Ȱ��ȭ��ŵ�ϴ�.
            gameObject.SetActive(false);
        }
    }
}
