using UnityEngine;

public class GunSwitch : MonoBehaviour
{
    //�� �𵨸�(��Ʈ�ѷ�)�� ������ ���ӿ�����Ʈ 
    [Tooltip("�� �𵨸�(��Ʈ�ѷ�)�� ������ ���ӿ�����Ʈ ")]
    public GameObject GunObject;
    //�� �𵨸�(��Ʈ�ѷ�)�� ������ ���ӿ�����Ʈ 
    [Tooltip("�� �𵨸�(��Ʈ�ѷ�)�� ������ ���ӿ�����Ʈ.hands:Rhand(�ո𵨸�)�� ���⿡ �巡�׵��. ")]
    public GameObject HandController;
    //�κ��丮 Ȱ��ȭ ���θ� �����ϴ� bool��
    private bool inventoryTriggered;
    

    private void Start()
    {

        //������ �� �� �𵨸��� ��Ȱ��ȭ �صд�.
        GunObject.SetActive(false);
        GunObject.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);

    }
    private void OnTriggerEnter(Collider other)
    {
        //���� HandController�̶�� �±װ� �پ��ִ� ������Ʈ�� �κ��丮�� �浹�� ��,
        if (other.gameObject.CompareTag("R"))
        {
            Debug.Log("toched");
            //�κ��丮�� Ȱ��ȭ�ȴ�.
            GunObject.SetActive(true);
                        
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        //���� HandController�̶�� �±װ� �پ��ִ� ������Ʈ�� �κ��丮�� �浹�� ��,
        if (other.gameObject.CompareTag("R"))
        {
            //�κ��丮�� Ȱ��ȭ�ȴ�.
            inventoryTriggered = false;
            

        }

    }
    private void Update()
    {
        //�κ��丮�� Ȱ��ȭ�Ǿ��ִ� ���¸�,
        if (inventoryTriggered)
        {

            //VR ��Ʈ�ѷ��� �׷���ư�� �����ٸ�
            if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
            {
                Debug.Log("Grab");
                //�� ������Ʈ�� false���̸�,
                if (!GunObject.activeSelf) { 

                    //�� �𵨸��� Ȱ��ȭ
                    GunObject.SetActive(true);
                    //�κ��丮 �۵� Ȯ�� �α�
                    /*Debug.Log("�κ��丮 �۵�");*/
                    //�� �𵨸��� ��Ȱ��ȭ�ȴ�.
                    HandController.SetActive(false);    

                }

                //���� �� �𵨸��� Ȱ��ȭ�Ǿ��ְ� �κ��丮�� �ٽ� Ʈ�����Ѵٸ�,
                else
                {

                //�� �𵨸� ��Ȱ��ȭ
                GunObject.SetActive(false);
                GunObject.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
                    //�κ��丮 �۵� Ȯ�� �α�
                    //�� �𵨸� Ȱ��ȭ    
                    HandController.SetActive(true);
                
                }

            }

        }
    }

}
