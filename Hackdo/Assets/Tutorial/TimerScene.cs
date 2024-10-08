using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerScene : MonoBehaviour
{
    public string nextSceneName; // 전환할 씬의 이름을 지정해주세요.
    public VR_Fade VRFade;
    public float delayTime = 3f; // 페이드 아웃 후 대기할 시간 (초)

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
        VRFade.FadeOut();
        // 페이드아웃이 완료될 때까지 기다림
        yield return new WaitForSeconds(VRFade.fadeTime);
        // 페이드 아웃이 끝난 후 지정한 시간만큼 대기
        yield return new WaitForSeconds(delayTime);

        // 대기 시간이 끝나면 씬을 전환합니다.
        SceneManager.LoadScene(nextSceneName);
    }
}
