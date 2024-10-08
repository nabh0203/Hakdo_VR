using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpot1 : MonoBehaviour
{
    public GameObject targetObject; // Ȱ��ȭ�� ������Ʈ�� Inspector���� �������־�� �մϴ�.
    public GunWithHands Gun;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Gun.GunObject.activeSelf)
        {
            targetObject.SetActive(true); // ������Ʈ�� Ȱ��ȭ��ŵ�ϴ�.
            gameObject.SetActive(false);
        }
    }
}
