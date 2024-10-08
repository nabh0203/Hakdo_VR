using UnityEngine;

public class GunSwitch : MonoBehaviour
{
    //총 모델링(컨트롤러)를 저장할 게임오브젝트 
    [Tooltip("총 모델링(컨트롤러)를 저장할 게임오브젝트 ")]
    public GameObject GunObject;
    //손 모델링(컨트롤러)을 저장할 게임오브젝트 
    [Tooltip("손 모델링(컨트롤러)을 저장할 게임오브젝트.hands:Rhand(손모델링)를 여기에 드래그드롭. ")]
    public GameObject HandController;
    //인벤토리 활성화 여부를 저장하는 bool값
    private bool inventoryTriggered;
    

    private void Start()
    {

        //시작할 때 총 모델링을 비활성화 해둔다.
        GunObject.SetActive(false);
        GunObject.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);

    }
    private void OnTriggerEnter(Collider other)
    {
        //만약 HandController이라는 태그가 붙어있는 오브젝트가 인벤토리와 충돌될 시,
        if (other.gameObject.CompareTag("R"))
        {
            Debug.Log("toched");
            //인벤토리가 활성화된다.
            GunObject.SetActive(true);
                        
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        //만약 HandController이라는 태그가 붙어있는 오브젝트가 인벤토리와 충돌될 시,
        if (other.gameObject.CompareTag("R"))
        {
            //인벤토리가 활성화된다.
            inventoryTriggered = false;
            

        }

    }
    private void Update()
    {
        //인벤토리가 활성화되어있는 상태면,
        if (inventoryTriggered)
        {

            //VR 컨트롤러의 그랩버튼이 눌린다면
            if (OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
            {
                Debug.Log("Grab");
                //총 오브젝트가 false값이면,
                if (!GunObject.activeSelf) { 

                    //총 모델링이 활성화
                    GunObject.SetActive(true);
                    //인벤토리 작동 확인 로그
                    /*Debug.Log("인벤토리 작동");*/
                    //손 모델링이 비활성화된다.
                    HandController.SetActive(false);    

                }

                //만약 총 모델링이 활성화되어있고 인벤토리를 다시 트리거한다면,
                else
                {

                //총 모델링 비활성화
                GunObject.SetActive(false);
                GunObject.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
                    //인벤토리 작동 확인 로그
                    //손 모델링 활성화    
                    HandController.SetActive(true);
                
                }

            }

        }
    }

}
