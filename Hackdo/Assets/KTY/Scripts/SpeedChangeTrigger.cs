using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedChangeTrigger : MonoBehaviour
{
    public PlayerForwardController playerController;
    public Transform playerTransform;
    public GameObject objectToParent; // 자식으로 만들 오브젝트
    public AudioClip newSound; // 새로운 사운드 클립
    public SubtitleSystem subtitleSystem; // SubtitleSystem 스크립트 참조

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 속도를 0으로 변경
            playerController.ChangeSpeed(0, 0);

            // 지정한 오브젝트를 자식으로 만듦
            objectToParent.transform.position = playerTransform.position;
            objectToParent.transform.parent = playerTransform;

            // 오디오 클립을 새로운 사운드로 교체
            playerController.audioSource.clip = newSound;

            // UI1 비활성화
            subtitleSystem.SetUI1Active(false);
            subtitleSystem.SetUI2Active(true);

        }
    }
}

