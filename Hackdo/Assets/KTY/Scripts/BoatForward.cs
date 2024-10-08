using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BoatForward : MonoBehaviour
{
    public Transform target; // 목표 지점
    public Transform Sit;
    private Rigidbody rb;
    private float speed = 1f; // 이동 속도

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 현재 위치와 목표 위치 사이의 거리 계산
            float distance = Vector3.Distance(transform.position, target.position);

            // 목표에 도착하지 않았다면 이동 처리
            if (distance > 0.1f)
            {
                // 방향 벡터 계산
                Vector3 direction = (target.position - transform.position).normalized;

                // Rigidbody에 힘을 가해 이동시킴
                rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
            }
        }
    }
    /*
    private void FixedUpdate()
    {

        // 현재 위치와 목표 위치 사이의 거리 계산
        float distance = Vector3.Distance(transform.position, target.position);

        // 목표에 도착하지 않았다면 이동 처리
        if (distance > 0.1f)
        {
            // 방향 벡터 계산
            Vector3 direction = (target.position - transform.position).normalized;

            // Rigidbody에 힘을 가해 이동시킴
            rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
        }
    }
    */
}
