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

            GameObject parentObject = transform.parent.gameObject; // �θ� ������Ʈ�� ����
            if (parentObject != null) // �θ� ������Ʈ�� �����ϴ� ���
            {
                //Animator parentAnimator = parentObject.GetComponent<Animator>();
                //parentAnimator.SetBool("Dead2", true); // �θ� ������Ʈ�� �ִϸ����͸� "Dead2"�� ����
                Destroy(parentObject); // �θ� ������Ʈ�� �ı�
            }
            else // �θ� ������Ʈ�� ���� ���
            {
                Destroy(gameObject,3f); // ���� ������Ʈ�� �ı�
            }
            Debug.Log("��ƼŬ �浹");
        }
    }
}