using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RopeActive : MonoBehaviour
{
    //���ٷ� ���� �𵨸��� üũ������ �����̿��� ��.
    [Tooltip("SetActive=false �� ���� �𵨸�")]
    public GameObject Rope;
    [Tooltip("SetActive=true �� ���ٷ� ���� �𵨸�")]
    public GameObject Roped;
    public VR_Fade fade;
    public string nextSceneName;

    private void OnTriggerEnter(Collider other)
    {
        //������ ������ ���˵� ��
        if (other.gameObject.CompareTag("Rope"))
        {
            //���ٰ� ������ ��Ȱ��ȭ, ���ٷι��� ������Ʈ Ȱ��ȭ.
            Rope.SetActive(false);
            
            Roped.SetActive(true);
            StartCoroutine(ChangeScene());
        }
    }

    IEnumerator ChangeScene()
    {
        fade.FadeOut();
        // ���̵�ƿ��� �Ϸ�� ������ ��ٸ�
        yield return new WaitForSeconds(fade.fadeTime);



        // ���� Ŭ���� ������ ���� ��ȯ�մϴ�.
        SceneManager.LoadScene(nextSceneName);
    }
}
