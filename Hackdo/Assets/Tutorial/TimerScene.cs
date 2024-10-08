using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerScene : MonoBehaviour
{
    public string nextSceneName; // ��ȯ�� ���� �̸��� �������ּ���.
    public VR_Fade VRFade;
    public float delayTime = 3f; // ���̵� �ƿ� �� ����� �ð� (��)

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
        VRFade.FadeOut();
        // ���̵�ƿ��� �Ϸ�� ������ ��ٸ�
        yield return new WaitForSeconds(VRFade.fadeTime);
        // ���̵� �ƿ��� ���� �� ������ �ð���ŭ ���
        yield return new WaitForSeconds(delayTime);

        // ��� �ð��� ������ ���� ��ȯ�մϴ�.
        SceneManager.LoadScene(nextSceneName);
    }
}
