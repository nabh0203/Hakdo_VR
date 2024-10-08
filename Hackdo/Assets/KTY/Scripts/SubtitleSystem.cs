using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SubtitleSystem : MonoBehaviour
{
    public AudioSource[] audioClips1; // 오디오 클립 배열 1
    public GameObject[] subtitles1; // 자막 UI 배열 1

    public AudioSource[] audioClips2; // 오디오 클립 배열 2
    public GameObject[] subtitles2; // 자막 UI 배열 2

    private int currentClipIndex1 = 0; // 현재 재생 중인 클립의 인덱스 1
    private int currentClipIndex2 = 0; // 현재 재생 중인 클립의 인덱스 2

    private bool isPlaying1 = false; // 첫 번째 코루틴의 실행 여부
    private bool isPlaying2 = false; // 두 번째 코루틴의 실행 여부

    private Coroutine coroutine1; // 첫 번째 코루틴의 참조
    private Coroutine coroutine2; // 두 번째 코루틴의 참조

    public GameObject UI1; //첫번째 코루틴 끝날 시 나타나는 UI
    public GameObject UI2; //두번째 코루틴 끝날 시 나타나는 UI

    private void Start()
    {
        coroutine1 = StartCoroutine(PlayAudioAndShowSubtitle1());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TrigPlay")) // "TrigPlay" 태그에 충돌했는지 검사
        {
            if (!isPlaying2) // 두 번째 코루틴이 실행 중이지 않다면
            {
                coroutine2 = StartCoroutine(PlayAudioAndShowSubtitle2()); // 코루틴 실행
            }
        }
    }

    private IEnumerator PlayAudioAndShowSubtitle1()
    {
        isPlaying1 = true; // 코루틴 실행 중 표시

        while (currentClipIndex1 < audioClips1.Length)
        {
            subtitles1[currentClipIndex1].SetActive(true); // 자막 UI 활성화
            audioClips1[currentClipIndex1].Play(); // 오디오 클립 재생

            yield return new WaitForSeconds(audioClips1[currentClipIndex1].clip.length); // 오디오 클립이 끝날 때까지 대기

            subtitles1[currentClipIndex1].SetActive(false); // 자막 UI 비활성화
            currentClipIndex1++; // 다음 클립으로 넘어감
        }

        isPlaying1 = false; // 코루틴 실행 종료 표시
        UI1.SetActive(true); //코루틴 실행 종료 시 나타나는 UI
    }

    public IEnumerator PlayAudioAndShowSubtitle2()
    {
        currentClipIndex2 = 0; // 코루틴 시작 시 currentClipIndex2를 0으로 초기화

        isPlaying2 = true; // 코루틴 실행 중 표시

        UI1.SetActive(false); //다음 코루틴이 시작하기 위해 UI false시킴.

        while (currentClipIndex2 < audioClips2.Length)
        {
            subtitles2[currentClipIndex2].SetActive(true); // 자막 UI 활성화
            audioClips2[currentClipIndex2].Play(); // 오디오 클립 재생

            yield return new WaitForSeconds(audioClips2[currentClipIndex2].clip.length); // 오디오 클립이 끝날 때까지 대기

            subtitles2[currentClipIndex2].SetActive(false); // 자막 UI 비활성화
            currentClipIndex2++; // 다음 클립으로 넘어감
        }

        isPlaying2 = false; // 코루틴 실행 종료 표시
        UI2.SetActive(true); //코루틴 실행 종료 시 나타나는 UI
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
