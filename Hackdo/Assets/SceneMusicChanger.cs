using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMusicChanger : MonoBehaviour
{
    public AudioSource audioSource; // Inspector���� ���� Ŭ���� �ִ� AudioSource�� �������ּ���.
    public string nextSceneName; // ��ȯ�� ���� �̸��� �������ּ���.
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
            audioSource.Play(); // ����� �ҽ� ���
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
        // ���� Ŭ���� ������ ���� ��ȯ�մϴ�.
        if (Change == true)
        {
            yield return new WaitForSeconds(VRFade.fadeTime);
            // ���� Ŭ���� ���� ������ ��ٸ��ϴ�.
            yield return new WaitForSeconds(audioSource.clip.length);

            SceneManager.LoadScene(nextSceneName);
        }
    }
}