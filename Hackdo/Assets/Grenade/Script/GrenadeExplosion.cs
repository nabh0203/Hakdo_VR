using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExplosion : MonoBehaviour
{
    // ����ź ���� ����
    public float explosionRadius = 5.0f;

    // ����ź�� ������ �Լ�
    public void Explode()
    {
        // ���� ���� ���� ��� �ݶ��̴��� ������
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        // �� �ݶ��̴��� ���� ����� �޽����� ���
        foreach (Collider hit in colliders)
        {
            Debug.Log("���� ����Ʈ�� ���� ������Ʈ: " + hit.gameObject.name);
        }
    }
}
