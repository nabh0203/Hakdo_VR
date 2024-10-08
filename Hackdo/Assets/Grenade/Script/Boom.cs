using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    private bool isCollided = false;
    private float timer = 0f;
    public float disappearDelay = 5f;
    public GameObject explosionPrefab;
    public GameObject explosionPrefab2;
    public GameObject pin; // pin이라는 자식 오브젝트를 public으로 선언
    public AudioClip sound; // 재생할 사운드 클립

   
    void Update()
    {
        // 만약 pin이 자식에서 해제되었을 시
        if (pin.transform.parent == null)
        {
            isCollided = true; // isCollided를 true로 변경
        }

        if (isCollided)
        {
            timer += Time.deltaTime;

            if (timer >= disappearDelay)
            {
                Destroy(gameObject);
               
                GameObject explosionEffect = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                AudioSource audioSource = explosionEffect.AddComponent<AudioSource>();
                audioSource.clip = sound;
                audioSource.Play();
                Debug.Log(explosionEffect + "팡 터졌어");
                Destroy(explosionEffect, 5f);
                GameObject explosionEffect2 = Instantiate(explosionPrefab2, transform.position - new Vector3(0, 1, 0), Quaternion.identity);
                Destroy(explosionEffect2, 10f);
            }
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
           

                
                    Destroy(gameObject);

                    GameObject explosionEffect = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                    AudioSource audioSource = explosionEffect.AddComponent<AudioSource>();
                    audioSource.clip = sound;
                    audioSource.Play();
                    Debug.Log(explosionEffect + "팡 터졌어");
                    Destroy(explosionEffect, 5f);
                    GameObject explosionEffect2 = Instantiate(explosionPrefab2, transform.position - new Vector3(0, 1, 0), Quaternion.identity);
                    Destroy(explosionEffect2, 10f);
                
          
        }
    }
}
