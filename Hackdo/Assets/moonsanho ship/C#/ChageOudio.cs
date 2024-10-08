using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChageOudio : MonoBehaviour
{
    public PlayerForwardController playerController; // PlayerForwardController 스크립트를 연결할 public 변수를 선언합니다.
    public AudioClip newSound; // 새로운 사운드 클립을 참조하는 public 변수를 선언합니다.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("충돌");
            // 오디오 클립을 새로운 사운드로 교체
            playerController.audioSource.clip = newSound;
            playerController.audioSource.Play(); // 변경된 클립을 재생합니다.
        }
    }
}
