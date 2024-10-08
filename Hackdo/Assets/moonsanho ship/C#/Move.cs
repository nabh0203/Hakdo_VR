using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 0.5f; // ���� ������ �ӵ�
    public float height = 0.5f; // ���� ������ ����
    public float tiltAmount = 1f; // ���� ���� ����
    private Vector3 startPosition; // ���� ���� ��ġ

    void Start()
    {
        startPosition = transform.position; // ���� ��ġ ����
    }

    void Update()
    {
        // Sin �Լ��� �̿��� ���� y ��ġ ����
        float newY = Mathf.Sin(Time.time * speed) * height;
        transform.position = new Vector3(transform.position.x, startPosition.y + newY, transform.position.z);

        // Sin �Լ��� �̿��� ���� z�� ȸ�� ����
        float tiltAngle = Mathf.Sin(Time.time * speed) * tiltAmount;
        transform.rotation = Quaternion.Euler(0, -88.257f, tiltAngle);
    }
}