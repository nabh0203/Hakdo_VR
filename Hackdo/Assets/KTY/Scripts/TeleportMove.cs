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
        // ���̵�ƿ� ����
        VRFade.FadeOut();
        // ���̵�ƿ��� �Ϸ�� ������ ��ٸ�
        yield return new WaitForSeconds(VRFade.fadeTime);

        // �÷��̾ ������ ��ġ�� �̵�
        Player.transform.position = Finishpoint.position;

        // ���̵��� ����
        VRFade.FadeIn();


    }
}