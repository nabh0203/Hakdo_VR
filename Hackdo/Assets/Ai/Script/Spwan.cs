using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spwan : MonoBehaviour
{
    /*
    public GameObject prefabToSpawn; // ������ ������
    private float spawnTimer = 0f; // ���� Ÿ�̸�
    private float lifeTime = 60f; // ������Ʈ ���� �ð�

    private bool moveRight = true; // ���������� �̵����� �������� �̵����� ����

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
                transform.position += new Vector3(5f, 0, 0); // ���������� 3��ŭ �̵��մϴ�.
            else
                transform.position -= new Vector3(10f, 0, 0); // �������� 2��ŭ �̵��մϴ�.

            moveRight = !moveRight; // ���� ������ �ݴ� �������� �����Դϴ�.

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