using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportMove : MonoBehaviour
{
    public VR_Fade VRFade;
    public Transform Finishpoint;
    public GameObject Player;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            StartCoroutine(TeleportPlayer());
            
        }
        
    }

    IEnumerator TeleportPlayer()
    {
        // 페이드아웃 시작
        VRFade.FadeOut();
        // 페이드아웃이 완료될 때까지 기다림
        yield return new WaitForSeconds(VRFade.fadeTime);

        // 플레이어를 지정한 위치로 이동
        Player.transform.position = Finishpoint.position;

        // 페이드인 시작
        VRFade.FadeIn();


    }
}