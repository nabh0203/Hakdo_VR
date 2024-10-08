using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string nextSceneName; // 전환할 씬의 이름을 지정해주세요.
    public VR_Fade VRFade;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
        VRFade.FadeOut();
        // 페이드아웃이 완료될 때까지 기다림
        yield return new WaitForSeconds(VRFade.fadeTime);



        // 음성 클립이 끝나면 씬을 전환합니다.
        SceneManager.LoadScene(nextSceneName);
    }
}
