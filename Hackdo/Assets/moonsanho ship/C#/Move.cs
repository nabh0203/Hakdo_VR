using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 0.5f; // 배의 움직임 속도
    public float height = 0.5f; // 배의 움직임 높이
    public float tiltAmount = 1f; // 배의 기울기 정도
    private Vector3 startPosition; // 배의 시작 위치

    void Start()
    {
        startPosition = transform.position; // 시작 위치 설정
    }

    void Update()
    {
        // Sin 함수를 이용해 배의 y 위치 변경
        float newY = Mathf.Sin(Time.time * speed) * height;
        transform.position = new Vector3(transform.position.x, startPosition.y + newY, transform.position.z);

        // Sin 함수를 이용해 배의 z축 회전 변경
        float tiltAngle = Mathf.Sin(Time.time * speed) * tiltAmount;
        transform.rotation = Quaternion.Euler(0, -88.257f, tiltAngle);
    }
}