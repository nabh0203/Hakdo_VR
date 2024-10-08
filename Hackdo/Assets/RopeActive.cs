using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RopeActive : MonoBehaviour
{
    //밧줄로 묶인 모델링은 체크해제인 상태이여야 함.
    [Tooltip("SetActive=false 할 밧줄 모델링")]
    public GameObject Rope;
    [Tooltip("SetActive=true 할 밧줄로 묶인 모델링")]
    public GameObject Roped;
    public VR_Fade fade;
    public string nextSceneName;

    private void OnTriggerEnter(Collider other)
    {
        //밧줄이 바위에 접촉될 시
        if (other.gameObject.CompareTag("Rope"))
        {
            //밧줄과 바위는 비활성화, 밧줄로묶인 오브젝트 활성화.
            Rope.SetActive(false);
            
            Roped.SetActive(true);
            StartCoroutine(ChangeScene());
        }
    }

    IEnumerator ChangeScene()
    {
        fade.FadeOut();
        // 페이드아웃이 완료될 때까지 기다림
        yield return new WaitForSeconds(fade.fadeTime);



        // 음성 클립이 끝나면 씬을 전환합니다.
        SceneManager.LoadScene(nextSceneName);
    }
}
