using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video; // VideoPlayer를 사용하기 위해 추가

public class VIDEO : MonoBehaviour
{
    public VideoPlayer videoToPlay; // VideoPlayer 컴포넌트를 가진 게임오브젝트를 할당할 public 변수
    public ChangeCamer Tv;
    // Start is called before the first frame update

    void Start()
    {
        videoToPlay.loopPointReached += OnVideoEnd; // 비디오가 끝날 때 호출될 메소드를 등록합니다.
    }

    void Update()
    {
        if (Tv.TVON == true)
        {
            videoToPlay.Play(); // 비디오 재생 시작   
        }
    }

    // 비디오가 끝났을 때 호출될 메소드입니다.
    private void OnVideoEnd(VideoPlayer vp)
    {
        Debug.Log("Video Ended!"); // 디버그 로그를 출력하여 비디오가 끝났음을 확인합니다.
        Application.Quit(); // 게임을 종료합니다.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // 에디터에서 실행 중일 경우 에디터를 종료합니다.
#endif
    }
}