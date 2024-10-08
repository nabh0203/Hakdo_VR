using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coiming : MonoBehaviour
{
    public GameObject ship; // 모형 배
    public float speed = 0.01f; // 배가 이동하는 속도
    private Vector3? shipDestination = null; // 배의 목적지

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) // 충돌한 오브젝트의 태그가 'Player'인 경우
        {
            Debug.Log("충돌");
            ship.SetActive(true);
            shipDestination = transform.position + new Vector3(-8f, -3f, -9f); // y축과 z축 방향으로 10m 떨어진 위치로 설정
        }
    }

    private void Update()
    {
        if (shipDestination != null)
        {
            // 배의 위치를 서서히 변경
            ship.transform.position = Vector3.Lerp(ship.transform.position, shipDestination.Value, Time.deltaTime * speed);

            // 배가 충분히 가까워지면 이동을 멈춤
            if (Vector3.Distance(ship.transform.position, shipDestination.Value) < 0.01f)
            {
                shipDestination = null;
            }
        }
    }
}