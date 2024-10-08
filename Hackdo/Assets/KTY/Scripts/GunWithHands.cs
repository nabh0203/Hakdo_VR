using UnityEngine;

public class GunWithHands : MonoBehaviour
{
    //�� �𵨸�(��Ʈ�ѷ�)�� ������ ���ӿ�����Ʈ. �� ������Ʈ�� �� �����ƾ� ��!
    [Tooltip("�� �𵨸�(��Ʈ�ѷ�)�� ������ ���ӿ�����Ʈ ")]
    public GameObject GunObject;
    //�� �𵨸�(��Ʈ�ѷ�)�� ������ ���ӿ�����Ʈ 
    [Tooltip("�� �𵨸�(��Ʈ�ѷ�)�� ������ ���ӿ�����Ʈ.hands:Rhand(�ո𵨸�)�� ���⿡ �巡�׵��. ")]
    public GameObject HandControllerL;
    [Tooltip("�� �𵨸�(��Ʈ�ѷ�)�� ������ ���ӿ�����Ʈ.CustomLeftH�� ���⿡ �巡�׵��. ")]
    public GameObject HandControllerR;
    [Tooltip("�ѿ� �پ��ִ� �޼� �𵨸�")]
    public GameObject SecondHandControllerL;
    //�κ��丮 Ȱ��ȭ ���θ� �����ϴ� bool��
    private bool inventoryTriggered;
    //�޼� �𵨸��� ���� ������ bool��
    private bool LHFalse = false;
    public Raycast raycastScript;

    private void Start()
    {

        //������ �� �� �𵨸��� ��Ȱ��ȭ �صд�.
        GunObject.SetActive(false);

    }
    private void OnTriggerEnter(Collider other)
    {
        //���� HandController�̶�� �±װ� �پ��ִ� ������Ʈ�� �κ��丮�� �浹�� ��,
        if (other.gameObject.CompareTag("R"))
        {
            Debug.Log("Trigger");
            //�κ��丮�� Ȱ��ȭ�ȴ�.
            inventoryTriggered = true;

        }

    }
    private void OnTriggerExit(Collider other)
    {
        //���� HandController�̶�� �±װ� �پ��ִ� ������Ʈ�� �κ��丮�� �浹�� ��,
        if (other.gameObject.CompareTag("R"))
        {
            Debug.Log("exit");
            //�κ��丮�� ��Ȱ��ȭ�ȴ�.
            inventoryTriggered = false;


        }

    }
    private void Update()
    {
            //VR ��Ʈ�ѷ��� �׷���ư�� �����ٸ�
            if (inventoryTriggered && OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
            {
                Debug.Log("Grab");
                //�� ������Ʈ�� false���̸�,
                if (!GunObject.activeSelf && inventoryTriggered)
                {
                    SecondHandControllerL.SetActive(true);
                    //�� �𵨸��� Ȱ��ȭ
                    GunObject.SetActive(true);
                    //�κ��丮 �۵� Ȯ�� �α�
                    /*Debug.Log("�κ��丮 �۵�");*/
                    //�� �𵨸��� ��Ȱ��ȭ�ȴ�.
                    HandControllerL.SetActive(false);
                    HandControllerR.SetActive(false);
                    //�� �𵨸� ����� ����Ǵ� ���� ������Ų��.
                    GunObject.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
                    inventoryTriggered = false;
                    LHFalse = true;

                }
                else if (GunObject.activeSelf && inventoryTriggered)
                {
                        raycastScript.b = 0;
                        raycastScript.ReloadBullet = true;
                        GunObject.SetActive(false);
                        HandControllerL.SetActive(true);
                        HandControllerR.SetActive(true);
                        inventoryTriggered = false;
                        LHFalse = false;
                    }
                }
            }
    



    public void ActiveLeftHand()
    {
        if (LHFalse)
        {
            Debug.Log("�޼� ���ƿ�..");
            //�޼� Ȱ��ȭ
            HandControllerL.SetActive(true);
            SecondHandControllerL.SetActive(false);
            LHFalse = false;
        }
        

    }
    public void FalseLeftHand()
    {
        if (!LHFalse)
        {
            Debug.Log("�ϼ� ����!");
            //�޼� Ȱ��ȭ
            HandControllerL.SetActive(false);
            SecondHandControllerL.SetActive(true);
            LHFalse = true;
        }
    }
}
