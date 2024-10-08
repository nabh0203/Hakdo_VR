using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BoatForward : MonoBehaviour
{
    public Transform target; // ��ǥ ����
    public Transform Sit;
    private Rigidbody rb;
    private float speed = 1f; // �̵� �ӵ�

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // ���� ��ġ�� ��ǥ ��ġ ������ �Ÿ� ���
            float distance = Vector3.Distance(transform.position, target.position);

            // ��ǥ�� �������� �ʾҴٸ� �̵� ó��
            if (distance > 0.1f)
            {
                // ���� ���� ���
                Vector3 direction = (target.position - transform.position).normalized;

                // Rigidbody�� ���� ���� �̵���Ŵ
                rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
            }
        }
    }
    /*
    private void FixedUpdate()
    {

        // ���� ��ġ�� ��ǥ ��ġ ������ �Ÿ� ���
        float distance = Vector3.Distance(transform.position, target.position);

        // ��ǥ�� �������� �ʾҴٸ� �̵� ó��
        if (distance > 0.1f)
        {
            // ���� ���� ���
            Vector3 direction = (target.position - transform.position).normalized;

            // Rigidbody�� ���� ���� �̵���Ŵ
            rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
        }
    }
    */
}
