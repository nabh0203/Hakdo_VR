using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string nextSceneName; // ��ȯ�� ���� �̸��� �������ּ���.
    public VR_Fade VRFade;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
        VRFade.FadeOut();
        // ���̵�ƿ��� �Ϸ�� ������ ��ٸ�
        yield return new WaitForSeconds(VRFade.fadeTime);



        // ���� Ŭ���� ������ ���� ��ȯ�մϴ�.
        SceneManager.LoadScene(nextSceneName);
    }
}
