using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodEffect : MonoBehaviour
{
    public GameObject myGameObject; // 할당할 게임 오브젝트
    private Renderer myRenderer; // 게임 오브젝트의 렌더러

    private GameObject enemy; // 적 오브젝트
    private float hitTime = 0f; // hitinfo 당한 시간

    void Start()
    {
        myRenderer = myGameObject.GetComponent<Renderer>(); // 렌더러 컴포넌트 가져오기
    }

    void Update()
    {
        // 'Anemy' 태그를 가진 모든 오브젝트를 찾습니다.
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Anemy");

        // 만약 적이 없으면, 설정을 초기화하고 함수를 종료합니다.
        if (enemies.Length == 0)
        {
            ResetSettings();
            return;
        }

        // 모든 적에 대해 처리
        foreach (GameObject enemy in enemies)
        {
            // 적과의 거리를 계산
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            // 25미터 이내일 때
            if (distance <= 25f)
            {
                if (!myGameObject.activeSelf)
                {
                    myGameObject.SetActive(true);
                }

                hitTime += Time.deltaTime; // 실제 시간으로 계산
                /*
                if (hitTime >= 3f)
                {
                    Vector2 tiling = myRenderer.material.mainTextureScale;
                    tiling.x = 0.4f;
                    myRenderer.material.mainTextureScale = tiling;
                    hitTime = 0f; // 재설정하여 계속해서 텍스처 스케일을 바꿀 수 있게 합니다.
                }
                */
                // 적과의 거리가 25미터 이내라면 루프를 빠져나옵니다.
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