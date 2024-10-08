using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSpawner : MonoBehaviour
{
    public GameObject spawnPlane;// 생성오브젝트 
    public GameObject particlePrefab; // 파티클 프리팹
    public float spawnInterval = 1f; // 생성 간격 (초)
    public float planeWidth = 10f; // 평면의 너비
    public float planeHeight = 10f; // 평면의 높이
    public AudioClip sound; // 재생할 사운드 클립

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