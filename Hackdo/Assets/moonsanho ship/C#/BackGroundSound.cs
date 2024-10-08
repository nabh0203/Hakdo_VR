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
        DontDestroyOnLoad(gameObject); // �� ���� �� �ı����� �ʵ��� ����

        audioSource = GetComponent<AudioSource>();

        // ���� �ε�� ������ ȣ��Ǵ� �ݹ� �Լ� ���
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // ���� �ε�� ������ ȣ��Ǵ� �ݹ� �Լ�
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "EndingScene") // �� �̸��� 'EndingScene'���� Ȯ��
        {
            StartCoroutine(FadeOut(audioSource, 0.1f)); // 1�� ���� ������ �Ҹ� ����
        }
        else
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play(); // ����� �ҽ� ���
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
