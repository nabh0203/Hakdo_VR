using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMusicChanger : MonoBehaviour
{
    public AudioSource audioSource; // Inspector에서 음성 클립이 있는 AudioSource를 지정해주세요.
    public string nextSceneName; // 전환할 씬의 이름을 지정해주세요.
    public VR_Fade VRFade;
    public bool Change;

    void Start()
    {
        Change = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Change == false)
        {
            Change = true;
            audioSource.Play(); // 오디오 소스 재생
            VRFade.FadeOut();
            StartCoroutine(ChangeSceneAfterAudio());
        }
    }
    /*

    private void OnTriggerExit(Collider other)
    {
        Change = false;
    }
    */
    IEnumerator ChangeSceneAfterAudio()
    {
        // 음성 클립이 끝나면 씬을 전환합니다.
        if (Change == true)
        {
            yield return new WaitForSeconds(VRFade.fadeTime);
            // 음성 클립이 끝날 때까지 기다립니다.
            yield return new WaitForSeconds(audioSource.clip.length);

            SceneManager.LoadScene(nextSceneName);
        }
    }
}