using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedResetTrigger : MonoBehaviour
{
    public PlayerForwardController playerController;
    public GameObject objectToUnparent; // 부모-자식 관계를 해제할 오브젝트

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // 속도를 원래대로 복구
            playerController.ResetSpeed();

            // 지정한 오브젝트를 부모-자식 관계에서 해제
            objectToUnparent.transform.SetParent(null);
        }
    }
}

