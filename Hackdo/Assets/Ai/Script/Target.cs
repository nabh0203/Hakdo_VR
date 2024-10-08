using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    void Start()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Boom"))
        {

            GameObject parentObject = transform.parent.gameObject; // 부모 오브젝트를 참조
            if (parentObject != null) // 부모 오브젝트가 존재하는 경우
            {
                //Animator parentAnimator = parentObject.GetComponent<Animator>();
                //parentAnimator.SetBool("Dead2", true); // 부모 오브젝트의 애니메이터를 "Dead2"로 설정
                Destroy(parentObject); // 부모 오브젝트를 파괴
            }
            else // 부모 오브젝트가 없는 경우
            {
                Destroy(gameObject,3f); // 현재 오브젝트를 파괴
            }
            Debug.Log("파티클 충돌");
        }
    }
}