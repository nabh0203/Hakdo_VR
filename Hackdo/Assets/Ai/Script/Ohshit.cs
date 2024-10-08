using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ohshit : MonoBehaviour
{
    public GameObject[] spawnPoints; // 스폰 포인트 배열

    // 트리거와 충돌 시 호출되는 함수
    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 오브젝트의 태그가 "Player"인 경우
        if (other.gameObject.CompareTag("Player"))
        {
            // 모든 스폰 포인트를 활성화
            foreach (GameObject spawnPoint in spawnPoints)
            {
                spawnPoint.SetActive(true);
            }
        }
    }
}
