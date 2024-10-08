using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwan : MonoBehaviour
{
    /*
    public GameObject prefabToSpawn; // 생성할 프리팹
    private float spawnTimer = 0f; // 스폰 타이머
    private float lifeTime = 60f; // 오브젝트 생존 시간

    private bool moveRight = true; // 오른쪽으로 이동할지 왼쪽으로 이동할지 결정

    void Start()
    {
        StartCoroutine(SpawnRoutine());
        StartCoroutine(DestroyAfterTime(lifeTime));
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            for (int i = 0; i < 1; i++)
            {
                Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
            }

            if (moveRight)
                transform.position += new Vector3(5f, 0, 0); // 오른쪽으로 3만큼 이동합니다.
            else
                transform.position -= new Vector3(10f, 0, 0); // 왼쪽으로 2만큼 이동합니다.

            moveRight = !moveRight; // 다음 번에는 반대 방향으로 움직입니다.

            yield return new WaitForSeconds(5f);
        }
    }

    IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        StopCoroutine(SpawnRoutine());

        Destroy(gameObject);
    }
    */
}