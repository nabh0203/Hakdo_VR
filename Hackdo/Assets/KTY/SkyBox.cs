using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBox : MonoBehaviour
{
    public Material skyboxMaterial;  // 변경하려는 스카이박스
    public float transitionSpeed = 1f;  // 전환 속도

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("배경전환");
        StartCoroutine(ChangeSkybox());
    }

    IEnumerator ChangeSkybox()
    {
        float t = 0;  // Lerp 파라미터

        Material initialSkybox = RenderSettings.skybox;  // 초기 스카이박스 저장
        Material targetSkybox = skyboxMaterial;  // 목표 스카이박스

        while (t < 1)
        {
            // 천천히 스카이박스 변경
            RenderSettings.skybox.Lerp(initialSkybox, targetSkybox, t);
            t += Time.deltaTime * transitionSpeed;

            yield return null;
        }

        // 완전히 목표 스카이박스로 변경
        RenderSettings.skybox = targetSkybox;
    }
}
