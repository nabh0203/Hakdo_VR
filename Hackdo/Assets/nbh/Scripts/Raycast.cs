using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] private GameObject firePos;  //총알 생성 위치
    public Transform FirePos;
    private LineRenderer laserLine; // 레이저 포인터
    public GameObject bullet; //발사할 총알이펙트
    public GameObject bullet2; //발사할 총알이펙트
    public GunWithHands LeftHand; //왼손 모델링
    public bool ReloadBullet = true;//장전여부
    private bool Hold = false;//잡기
    public int b = 0;//발사한 총알 갯수
    public AudioClip sound; // 재생할 사운드 클립
    public AudioSource audioSource; // AudioSource component를 참조하는 public 변수를 선언합니다. Unity Editor에서 이 변수에 AudioSource component를 연결해주세요.
    public AudioClip audioClip; // 재생하고 싶은 오디오 클립을 참조하는 public 변수를 선언합니다. Unity Editor에서 이 변수에 원하는 오디오 클립을 연결해주세요.




    void Start()
    {
        Hold = false;
        laserLine = GetComponent<LineRenderer>();
        if (laserLine == null)
        {
            laserLine = this.gameObject.AddComponent<LineRenderer>();
            laserLine.material = new Material(Shader.Find("Standard"));
            laserLine.startColor = Color.red;
            laserLine.endColor = Color.red;
            laserLine.startWidth = 0.01f;
            laserLine.endWidth = 0.01f;
        }
        laserLine.positionCount = 2;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("R"))
        {
            Debug.Log("잡다");
            Hold = true;
        }

        if (other.gameObject.CompareTag("Bullet") && b == 5)
        {
            Debug.Log("장전");
            ReloadBullet = true;
            Destroy(other.gameObject);
            audioSource.PlayOneShot(audioClip);
            StartCoroutine(Reload());
            //other.gameObject.SetActive(false);
            LeftHand.FalseLeftHand();

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("R"))
        {
            Debug.Log("놓다");
            Hold = false;
        }
    }
    void Update()
    {

        //trigger 누를 때
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && b <= 5 && Hold == true && ReloadBullet == true)
        {

            b++;
            TriggerShoot();
            //Invoke("TriggerShoot",0f);
            Debug.Log("누름");

            GameObject projectile = Instantiate(bullet2, FirePos.position, FirePos.rotation);

            Destroy(projectile, 0.1f); // Make sure to destroy the instantiated object not the original prefab.
            GameObject projectile2 = Instantiate(bullet, FirePos.position, FirePos.rotation);
            AudioSource audioSource = projectile2.AddComponent<AudioSource>();
            audioSource.clip = sound;
            audioSource.Play();
            Destroy(projectile2, 1f); // Make sure to destroy the instantiated object not the original prefab.
            if (b == 5)
            {
                Debug.Log("장전필요");
                ReloadBullet = false;
                LeftHand.ActiveLeftHand();
            }

        }
        DrawLaser(firePos.transform.position, firePos.transform.position + firePos.transform.forward * 100);
        // 함수는 지정된 위치에서 지정된 반경 내에 있는 모든 Collider를 반환합니다.이 결과를 순회하며 "Bullet" 태그가 있는지 확인
    }
    public IEnumerator Reload()
    {
        yield return new WaitForSeconds(1f);
        //ReloadBullet = true;
        b = 0;
    }

    public void TriggerShoot()
    {
        if (Hold && b < 6)
        {
            Ray ray = new Ray(firePos.transform.position, firePos.transform.forward);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.tag == "Anemy")
                {
                    Destroy(hitInfo.transform.gameObject);
                }

                DrawLaser(ray.origin, hitInfo.point);
            }
            else
            {
                DrawLaser(ray.origin, ray.origin + ray.direction * 100);
            }
        }
    }


    void DrawLaser(Vector3 startPosition, Vector3 endPosition)
    {
        laserLine.SetPosition(0, startPosition);
        laserLine.SetPosition(1, endPosition);
    }
}

