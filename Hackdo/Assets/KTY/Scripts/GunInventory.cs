using UnityEngine;

public class GunInventory : MonoBehaviour
{
    //복제할 총 모델링(컨트롤러) 게임오브젝트. 
    [Tooltip("총 모델링(컨트롤러)를 저장할 게임오브젝트 ")]
    public GameObject GunObject;
    //오브젝트가 잡혔는지 여부를 물어보는 bool
    private bool pickedUp = true;
    // Update is called once per frame

    private void Start()
    {
        //총 모델링 사이즈가 변경되는 점을 고정시킨다.
        GunObject.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
    }

    public void OnTriggerEnter(Collider other)
    {
        //만약 오른쪽 손이 주머니에 트리거 됬을 시,
        if (other.CompareTag("R") )
        {
            //디버그로 닿았다는 것을 출력하고,
            Debug.Log("touched");
            //총 오브젝트를 실행시킨다(킨다).
            GunObject.SetActive(true);
            //만약 오브젝트가 잡힌 이후로 다시 주머니에 닿은 상태면,
            if (pickedUp)
            {
                //총 오브젝트를 비활성화
                GunObject.SetActive(false);
                //인벤토리에서 떨어지게한다.
                GunObject.transform.parent = null;
                //pickup 초기화 한다.
                pickedUp = false;
            } 

        }
    }
    private void OnTriggerExit(Collider other)
    {
        //만약 오른쪽 손이 주머니에서 벗어났을 때,
        if (other.CompareTag("Gun"))
        {
            Debug.Log("총 벗어남");
            //총이 주머니에서 꺼내졌다는 것을 인식한다. 이 상태로 주머니에 다시 닿으면 if(pickedUp)문이 실행된다.
            pickedUp = true;
            //인벤토리 부모로 할당하여 붙게한다.
            GunObject.transform.parent = transform;
           
        }
    }
}