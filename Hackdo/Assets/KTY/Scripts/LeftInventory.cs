using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftInventory : MonoBehaviour
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
    //���� ������Ʈ (SO) �������� - ������ٵ�� �ݶ��̴� ������ ������������.
    private GameObject SO;
   //������Ʈ ���� Ƚ�� ī��Ʈ.
    private int objectsSpawned = 0;
    public int SpawnLimit = 2;
    // Update is called once per frame
    void Update()
    {
        if (SO != null)
        {
            //���� �׷� ��ư�� ���� ���°�, ������ ���°� �ƴϰ�, Ʈ���Ű� �� ���¸�,
            if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger) && isTriggered)
            {

                //������ٵ� ������ ������ ������Ʈ(SO)�� �����ϰ� �ҷ��´�.
                Rigidbody rb = SO.GetComponent<Rigidbody>();
                //ĸ���ݶ��̴� ������ ������ ������Ʈ(SO)�� �����ϰ� �ҷ��´�.
                CapsuleCollider cc = SO.GetComponent<CapsuleCollider>();
                //�߷��� Ű��, 
                rb.useGravity = true;
                //Ʈ���Ÿ� ����. �̷��� �۵��ϸ� Ű��ƽ�� ������� �ʰ� ����ź ���� �� ������ �����ϴ�.
                cc.isTrigger = false;
            }
        }
    }


    public void OnTriggerEnter(Collider other)
    {
        isTriggered = true;
        //���� ���� ���� �ָӴϿ� Ʈ���� ���� ��,
        if (other.CompareTag("LeftInv") && objectsSpawned < SpawnLimit)
        {
            //���� SO�� �����Ǿ����� �ʴٸ�,
            if (SO == null)

            {
                //������ ������Ʈ, ������ �����ǰ��� �����ȴ�.
                SO = Instantiate(spawnObject, spawnLocation.transform.position, transform.rotation);
                SO.transform.SetParent(gameObject.transform);
                //Ʈ���� ���� true
                isTriggered = true;
                //������ ������ Ƚ�� ī��Ʈ�Ѵ�.
                objectsSpawned++;


            }
            
            
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
