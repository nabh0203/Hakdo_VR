using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nav : MonoBehaviour
{
    public Transform target; // Ÿ�� ��ġ (Player ��)
    public string playerTag = "Player"; // �÷��̾� �±�
    public float speed = 5.0f; // AI ĳ������ �ӵ�
    public float stopDistance = 10.0f; // ���� �Ÿ�
    public float maxPlayerDistance = 30.0f; // �÷��̾�� �ִ� �Ÿ�

    private bool isMoving = true;

    void Update()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag); // �÷��̾� �±׷� ���� ������Ʈ ã��

        if (playerObject == null || target == null) return;

        float distanceToTarget = Vector3.Distance(target.position, transform.position);
        float distanceToPlayer = Vector3.Distance(playerObject.transform.position, transform.position);

        if (distanceToPlayer > maxPlayerDistance)
        {
            isMoving = false;
        }

        if (distanceToPlayer < maxPlayerDistance && distanceToTarget > stopDistance)
        {
            isMoving = true;

            Vector3 dir = target.position - transform.position;
            dir.Normalize();

            transform.LookAt(target);

            transform.position += dir * speed * Time.deltaTime;
        }
    }
}