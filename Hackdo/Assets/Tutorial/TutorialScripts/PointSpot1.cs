using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpot1 : MonoBehaviour
{
    public GameObject targetObject; // 활성화할 오브젝트를 Inspector에서 지정해주어야 합니다.
    public GunWithHands Gun;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Gun.GunObject.activeSelf)
        {
            targetObject.SetActive(true); // 오브젝트를 활성화시킵니다.
            gameObject.SetActive(false);
        }
    }
}
