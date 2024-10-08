using UnityEngine;

public class GunInventory : MonoBehaviour
{
    //������ �� �𵨸�(��Ʈ�ѷ�) ���ӿ�����Ʈ. 
    [Tooltip("�� �𵨸�(��Ʈ�ѷ�)�� ������ ���ӿ�����Ʈ ")]
    public GameObject GunObject;
    //������Ʈ�� �������� ���θ� ����� bool
    private bool pickedUp = true;
    // Update is called once per frame

    private void Start()
    {
        //�� �𵨸� ����� ����Ǵ� ���� ������Ų��.
        GunObject.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
    }

    public void OnTriggerEnter(Collider other)
    {
        //���� ������ ���� �ָӴϿ� Ʈ���� ���� ��,
        if (other.CompareTag("R") )
        {
            //����׷� ��Ҵٴ� ���� ����ϰ�,
            Debug.Log("touched");
            //�� ������Ʈ�� �����Ų��(Ų��).
            GunObject.SetActive(true);
            //���� ������Ʈ�� ���� ���ķ� �ٽ� �ָӴϿ� ���� ���¸�,
            if (pickedUp)
            {
                //�� ������Ʈ�� ��Ȱ��ȭ
                GunObject.SetActive(false);
                //�κ��丮���� ���������Ѵ�.
                GunObject.transform.parent = null;
                //pickup �ʱ�ȭ �Ѵ�.
                pickedUp = false;
            } 

        }
    }
    private void OnTriggerExit(Collider other)
    {
        //���� ������ ���� �ָӴϿ��� ����� ��,
        if (other.CompareTag("Gun"))
        {
            Debug.Log("�� ���");
            //���� �ָӴϿ��� �������ٴ� ���� �ν��Ѵ�. �� ���·� �ָӴϿ� �ٽ� ������ if(pickedUp)���� ����ȴ�.
            pickedUp = true;
            //�κ��丮 �θ�� �Ҵ��Ͽ� �ٰ��Ѵ�.
            GunObject.transform.parent = transform;
           
        }
    }
}