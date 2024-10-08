using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nav : MonoBehaviour
{
    public Transform target; // 타겟 위치 (Player 등)
    public string playerTag = "Player"; // 플레이어 태그
    public float speed = 5.0f; // AI 캐릭터의 속도
    public float stopDistance = 10.0f; // 멈춤 거리
    public float maxPlayerDistance = 30.0f; // 플레이어와 최대 거리

    private bool isMoving = true;

    void Update()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag); // 플레이어 태그로 게임 오브젝트 찾기

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