using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] private GameObject firePos;  //�Ѿ� ���� ��ġ
    public Transform FirePos;
    private LineRenderer laserLine; // ������ ������
    public GameObject bullet; //�߻��� �Ѿ�����Ʈ
    public GameObject bullet2; //�߻��� �Ѿ�����Ʈ
    public GunWithHands LeftHand; //�޼� �𵨸�
    public bool ReloadBullet = true;//��������
    private bool Hold = false;//���
    public int b = 0;//�߻��� �Ѿ� ����
    public AudioClip sound; // ����� ���� Ŭ��
    public AudioSource audioSource; // AudioSource component�� �����ϴ� public ������ �����մϴ�. Unity Editor���� �� ������ AudioSource component�� �������ּ���.
    public AudioClip audioClip; // ����ϰ� ���� ����� Ŭ���� �����ϴ� public ������ �����մϴ�. Unity Editor���� �� ������ ���ϴ� ����� Ŭ���� �������ּ���.




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
            Debug.Log("���");
            Hold = true;
        }

        if (other.gameObject.CompareTag("Bullet") && b == 5)
        {
            Debug.Log("����");
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
            Debug.Log("����");
            Hold = false;
        }
    }
    void Update()
    {

        //trigger ���� ��
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger) && b <= 5 && Hold == true && ReloadBullet == true)
        {

            b++;
            TriggerShoot();
            //Invoke("TriggerShoot",0f);
            Debug.Log("����");

            GameObject projectile = Instantiate(bullet2, FirePos.position, FirePos.rotation);

            Destroy(projectile, 0.1f); // Make sure to destroy the instantiated object not the original prefab.
            GameObject projectile2 = Instantiate(bullet, FirePos.position, FirePos.rotation);
            AudioSource audioSource = projectile2.AddComponent<AudioSource>();
            audioSource.clip = sound;
            audioSource.Play();
            Destroy(projectile2, 1f); // Make sure to destroy the instantiated object not the original prefab.
            if (b == 5)
            {
                Debug.Log("�����ʿ�");
                ReloadBullet = false;
                LeftHand.ActiveLeftHand();
            }

        }
        DrawLaser(firePos.transform.position, firePos.transform.position + firePos.transform.forward * 100);
        // �Լ��� ������ ��ġ���� ������ �ݰ� ���� �ִ� ��� Collider�� ��ȯ�մϴ�.�� ����� ��ȸ�ϸ� "Bullet" �±װ� �ִ��� Ȯ��
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

