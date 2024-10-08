using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodEffect : MonoBehaviour
{
    public GameObject myGameObject; // �Ҵ��� ���� ������Ʈ
    private Renderer myRenderer; // ���� ������Ʈ�� ������

    private GameObject enemy; // �� ������Ʈ
    private float hitTime = 0f; // hitinfo ���� �ð�

    void Start()
    {
        myRenderer = myGameObject.GetComponent<Renderer>(); // ������ ������Ʈ ��������
    }

    void Update()
    {
        // 'Anemy' �±׸� ���� ��� ������Ʈ�� ã���ϴ�.
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Anemy");

        // ���� ���� ������, ������ �ʱ�ȭ�ϰ� �Լ��� �����մϴ�.
        if (enemies.Length == 0)
        {
            ResetSettings();
            return;
        }

        // ��� ���� ���� ó��
        foreach (GameObject enemy in enemies)
        {
            // ������ �Ÿ��� ���
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            // 25���� �̳��� ��
            if (distance <= 25f)
            {
                if (!myGameObject.activeSelf)
                {
                    myGameObject.SetActive(true);
                }

                hitTime += Time.deltaTime; // ���� �ð����� ���
                /*
                if (hitTime >= 3f)
                {
                    Vector2 tiling = myRenderer.material.mainTextureScale;
                    tiling.x = 0.4f;
                    myRenderer.material.mainTextureScale = tiling;
                    hitTime = 0f; // �缳���Ͽ� ����ؼ� �ؽ�ó �������� �ٲ� �� �ְ� �մϴ�.
                }
                */
                // ������ �Ÿ��� 25���� �̳���� ������ �������ɴϴ�.
                break;
            }
            else
            {
                ResetSettings();
            }
        }
    }

    private void ResetSettings()
    {
        if (myGameObject.activeSelf)
        {
            myGameObject.SetActive(false);
        }

        // reset the timer and texture scale when not hitting the enemy.
        hitTime = 0f;
        Vector2 resetTiling = new Vector2(1, 1);
        myRenderer.material.mainTextureScale = resetTiling;
    }
}