using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackGroundSound : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject); // 씬 변경 시 파괴되지 않도록 설정

        audioSource = GetComponent<AudioSource>();

        // 씬이 로드될 때마다 호출되는 콜백 함수 등록
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // 씬이 로드될 때마다 호출되는 콜백 함수
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "EndingScene") // 씬 이름이 'EndingScene'인지 확인
        {
            StartCoroutine(FadeOut(audioSource, 0.1f)); // 1초 동안 서서히 소리 줄임
        }
        else
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play(); // 오디오 소스 재생
            }
        }
    }

    private IEnumerator FadeOut(AudioSource audioSource, float fadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / fadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }

    internal void StartFadeOut(float v)
    {
        throw new NotImplementedException();
    }
}
