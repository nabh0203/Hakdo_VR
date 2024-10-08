using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBox : MonoBehaviour
{
    public Material skyboxMaterial;  // �����Ϸ��� ��ī�̹ڽ�
    public float transitionSpeed = 1f;  // ��ȯ �ӵ�

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("�����ȯ");
        StartCoroutine(ChangeSkybox());
    }

    IEnumerator ChangeSkybox()
    {
        float t = 0;  // Lerp �Ķ����

        Material initialSkybox = RenderSettings.skybox;  // �ʱ� ��ī�̹ڽ� ����
        Material targetSkybox = skyboxMaterial;  // ��ǥ ��ī�̹ڽ�

        while (t < 1)
        {
            // õõ�� ��ī�̹ڽ� ����
            RenderSettings.skybox.Lerp(initialSkybox, targetSkybox, t);
            t += Time.deltaTime * transitionSpeed;

            yield return null;
        }

        // ������ ��ǥ ��ī�̹ڽ��� ����
        RenderSettings.skybox = targetSkybox;
    }
}
