using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    public GameObject spawnPlane;// ����������Ʈ 
    public GameObject particlePrefab; // ��ƼŬ ������
    public float spawnInterval = 1f; // ���� ���� (��)
    public float planeWidth = 10f; // ����� �ʺ�
    public float planeHeight = 10f; // ����� ����
    public AudioClip sound; // ����� ���� Ŭ��

    void Start()
    {
        StartCoroutine(SpawnParticles());
    }

    IEnumerator SpawnParticles()
    {
        while (true)
        {
            float x = Random.Range(-planeWidth / 1, planeWidth / 1);
            float z = Random.Range(-planeHeight / 1, planeHeight / 1);

            Vector3 spawnPosition = spawnPlane.transform.position + new Vector3(x, 0f, z);

            GameObject particleInstance = Instantiate(particlePrefab, spawnPosition, Quaternion.identity);
            AudioSource audioSource = particleInstance.AddComponent<AudioSource>();
            audioSource.clip = sound;
            audioSource.Play();
            Destroy(particleInstance, 4f);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}