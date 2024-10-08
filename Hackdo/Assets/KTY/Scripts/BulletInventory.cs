using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletInventory : MonoBehaviour
{
    //�հ� �κ��丮�� �� �� trigger���¿��� �۵��ϱ� �����. �׷���
    //��û ���� ť�긦 �����ؼ� �տ� ��ġ�����ְ�(+rigidbody isKinematic), mesh renderer�� ������,
    //Tag LeftInv�� �����Ͽ� ���Խ��Ѿ� �Ѵ�. 

    [Tooltip("������ ������Ʈ �������� �ִ� ����")]
    public GameObject spawnObject;
    [Tooltip("���� ��ġ/������ ��ġ GameObject�� �ִ� ����")]
    public Transform spawnLocation;


    //���� �κ��丮�� Ʈ���� ���� = ��Ȱ��ȭ.
    private bool isTriggered = false;
    //�Ѿ� ������(BP) �������� 
    private GameObject BP;
    private int objectsSpawned = 0;
    public int SpawnLimit = 2;
    // Update is called once per frame
    void Update()
    {
        //���� �׷� ��ư�� ���� ���°�, �Ѱ�Ƚ������ �۰�, Ʈ���Ű� �� ���¸�,
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger) && objectsSpawned < SpawnLimit && isTriggered)
        {
            //���� SO�� �����Ǿ����� �ʴٸ�,
            if (BP == null) 

            {
                /*�Ѿ��� �� ��ġ�� �����Ѵ�*/
                BP = Instantiate(spawnObject, spawnLocation); 
                //������ ������ Ƚ�� ī��Ʈ�Ѵ�.
                objectsSpawned++;
                

            }
            
        }
    }


    public void OnTriggerEnter(Collider other)
    {
        //���� ���� ���� �ָӴϿ� Ʈ���� ���� ��,
        if (other.CompareTag("LeftInv") &&  !isTriggered)
        {
            //Ʈ���� ���� true
            isTriggered = true;
            


        }
    }
    private void OnTriggerExit(Collider other)
    {
        //���� ���� ���� �ָӴϸ� ����� ��,
        if (other.CompareTag("LeftInv"))
        {
            //Ʈ���� ���� false
            isTriggered = false;
        }
    }





}
