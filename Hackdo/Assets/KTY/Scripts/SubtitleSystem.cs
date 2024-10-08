using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SubtitleSystem : MonoBehaviour
{
    public AudioSource[] audioClips1; // ����� Ŭ�� �迭 1
    public GameObject[] subtitles1; // �ڸ� UI �迭 1

    public AudioSource[] audioClips2; // ����� Ŭ�� �迭 2
    public GameObject[] subtitles2; // �ڸ� UI �迭 2

    private int currentClipIndex1 = 0; // ���� ��� ���� Ŭ���� �ε��� 1
    private int currentClipIndex2 = 0; // ���� ��� ���� Ŭ���� �ε��� 2

    private bool isPlaying1 = false; // ù ��° �ڷ�ƾ�� ���� ����
    private bool isPlaying2 = false; // �� ��° �ڷ�ƾ�� ���� ����

    private Coroutine coroutine1; // ù ��° �ڷ�ƾ�� ����
    private Coroutine coroutine2; // �� ��° �ڷ�ƾ�� ����

    public GameObject UI1; //ù��° �ڷ�ƾ ���� �� ��Ÿ���� UI
    public GameObject UI2; //�ι�° �ڷ�ƾ ���� �� ��Ÿ���� UI

    private void Start()
    {
        coroutine1 = StartCoroutine(PlayAudioAndShowSubtitle1());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TrigPlay")) // "TrigPlay" �±׿� �浹�ߴ��� �˻�
        {
            if (!isPlaying2) // �� ��° �ڷ�ƾ�� ���� ������ �ʴٸ�
            {
                coroutine2 = StartCoroutine(PlayAudioAndShowSubtitle2()); // �ڷ�ƾ ����
            }
        }
    }

    private IEnumerator PlayAudioAndShowSubtitle1()
    {
        isPlaying1 = true; // �ڷ�ƾ ���� �� ǥ��

        while (currentClipIndex1 < audioClips1.Length)
        {
            subtitles1[currentClipIndex1].SetActive(true); // �ڸ� UI Ȱ��ȭ
            audioClips1[currentClipIndex1].Play(); // ����� Ŭ�� ���

            yield return new WaitForSeconds(audioClips1[currentClipIndex1].clip.length); // ����� Ŭ���� ���� ������ ���

            subtitles1[currentClipIndex1].SetActive(false); // �ڸ� UI ��Ȱ��ȭ
            currentClipIndex1++; // ���� Ŭ������ �Ѿ
        }

        isPlaying1 = false; // �ڷ�ƾ ���� ���� ǥ��
        UI1.SetActive(true); //�ڷ�ƾ ���� ���� �� ��Ÿ���� UI
    }

    public IEnumerator PlayAudioAndShowSubtitle2()
    {
        currentClipIndex2 = 0; // �ڷ�ƾ ���� �� currentClipIndex2�� 0���� �ʱ�ȭ

        isPlaying2 = true; // �ڷ�ƾ ���� �� ǥ��

        UI1.SetActive(false); //���� �ڷ�ƾ�� �����ϱ� ���� UI false��Ŵ.

        while (currentClipIndex2 < audioClips2.Length)
        {
            subtitles2[currentClipIndex2].SetActive(true); // �ڸ� UI Ȱ��ȭ
            audioClips2[currentClipIndex2].Play(); // ����� Ŭ�� ���

            yield return new WaitForSeconds(audioClips2[currentClipIndex2].clip.length); // ����� Ŭ���� ���� ������ ���

            subtitles2[currentClipIndex2].SetActive(false); // �ڸ� UI ��Ȱ��ȭ
            currentClipIndex2++; // ���� Ŭ������ �Ѿ
        }

        isPlaying2 = false; // �ڷ�ƾ ���� ���� ǥ��
        UI2.SetActive(true); //�ڷ�ƾ ���� ���� �� ��Ÿ���� UI
    }

    public void SetUI1Active(bool value)
    {
        UI1.SetActive(value);
    }

    public void SetUI2Active(bool value)
    {
        UI2.SetActive(value);
    }

    public void StopCoroutineIfRunning(Coroutine coroutine)
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
    }

    public void OnDestroy()
    {
        StopCoroutineIfRunning(coroutine1);
        StopCoroutineIfRunning(coroutine2);
    }


}
