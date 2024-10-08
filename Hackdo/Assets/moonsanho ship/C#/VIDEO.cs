using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video; // VideoPlayer�� ����ϱ� ���� �߰�

public class VIDEO : MonoBehaviour
{
    public VideoPlayer videoToPlay; // VideoPlayer ������Ʈ�� ���� ���ӿ�����Ʈ�� �Ҵ��� public ����
    public ChangeCamer Tv;
    // Start is called before the first frame update

    void Start()
    {
        videoToPlay.loopPointReached += OnVideoEnd; // ������ ���� �� ȣ��� �޼ҵ带 ����մϴ�.
    }

    void Update()
    {
        if (Tv.TVON == true)
        {
            videoToPlay.Play(); // ���� ��� ����   
        }
    }

    // ������ ������ �� ȣ��� �޼ҵ��Դϴ�.
    private void OnVideoEnd(VideoPlayer vp)
    {
        Debug.Log("Video Ended!"); // ����� �α׸� ����Ͽ� ������ �������� Ȯ���մϴ�.
        Application.Quit(); // ������ �����մϴ�.
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // �����Ϳ��� ���� ���� ��� �����͸� �����մϴ�.
#endif
    }
}