using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coiming : MonoBehaviour
{
    public GameObject ship; // ���� ��
    public float speed = 0.01f; // �谡 �̵��ϴ� �ӵ�
    private Vector3? shipDestination = null; // ���� ������

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // �浹�� ������Ʈ�� �±װ� 'Player'�� ���
        {
            Debug.Log("�浹");
            ship.SetActive(true);
            shipDestination = transform.position + new Vector3(-8f, -3f, -9f); // y��� z�� �������� 10m ������ ��ġ�� ����
        }
    }

    private void Update()
    {
        if (shipDestination != null)
        {
            // ���� ��ġ�� ������ ����
            ship.transform.position = Vector3.Lerp(ship.transform.position, shipDestination.Value, Time.deltaTime * speed);

            // �谡 ����� ��������� �̵��� ����
            if (Vector3.Distance(ship.transform.position, shipDestination.Value) < 0.01f)
            {
                shipDestination = null;
            }
        }
    }
}