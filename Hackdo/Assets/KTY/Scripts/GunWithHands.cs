using UnityEngine;

public class GunWithHands : MonoBehaviour
{
    //총 모델링(컨트롤러)를 저장할 게임오브젝트. 총 오브젝트는 꼭 꺼놓아야 함!
    [Tooltip("총 모델링(컨트롤러)를 저장할 게임오브젝트 ")]
    public GameObject GunObject;
    //손 모델링(컨트롤러)을 저장할 게임오브젝트 
    [Tooltip("손 모델링(컨트롤러)을 저장할 게임오브젝트.hands:Rhand(손모델링)를 여기에 드래그드롭. ")]
    public GameObject HandControllerL;
    [Tooltip("손 모델링(컨트롤러)을 저장할 게임오브젝트.CustomLeftH를 여기에 드래그드롭. ")]
    public GameObject HandControllerR;
    [Tooltip("총에 붙어있는 왼손 모델링")]
    public GameObject SecondHandControllerL;
    //인벤토리 활성화 여부를 저장하는 bool값
    private bool inventoryTriggered;
    //왼손 모델링이 꺼진 상태의 bool값
    private bool LHFalse = false;
    public Raycast raycastScript;

    private void Start()
    {

        //시작할 때 총 모델링을 비활성화 해둔다.
        GunObject.SetActive(false);

    }
    private void OnTriggerEnter(Collider other)
    {
        //만약 HandController이라는 태그가 붙어있는 오브젝트가 인벤토리와 충돌될 시,
        if (other.gameObject.CompareTag("R"))
        {
            Debug.Log("Trigger");
            //인벤토리가 활성화된다.
            inventoryTriggered = true;

        }

    }
    private void OnTriggerExit(Collider other)
    {
        //만약 HandController이라는 태그가 붙어있는 오브젝트가 인벤토리와 충돌될 시,
        if (other.gameObject.CompareTag("R"))
        {
            Debug.Log("exit");
            //인벤토리가 비활성화된다.
            inventoryTriggered = false;


        }

    }
    private void Update()
    {
            //VR 컨트롤러의 그랩버튼이 눌린다면
            if (inventoryTriggered && OVRInput.GetDown(OVRInput.Button.SecondaryHandTrigger))
            {
                Debug.Log("Grab");
                //총 오브젝트가 false값이면,
                if (!GunObject.activeSelf && inventoryTriggered)
                {
                    SecondHandControllerL.SetActive(true);
                    //총 모델링이 활성화
                    GunObject.SetActive(true);
                    //인벤토리 작동 확인 로그
                    /*Debug.Log("인벤토리 작동");*/
                    //손 모델링이 비활성화된다.
                    HandControllerL.SetActive(false);
                    HandControllerR.SetActive(false);
                    //총 모델링 사이즈가 변경되는 점을 고정시킨다.
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
            Debug.Log("왼손 돌아옴..");
            //왼손 활성화
            HandControllerL.SetActive(true);
            SecondHandControllerL.SetActive(false);
            LHFalse = false;
        }
        

    }
    public void FalseLeftHand()
    {
        if (!LHFalse)
        {
            Debug.Log("완손 부착!");
            //왼손 활성화
            HandControllerL.SetActive(false);
            SecondHandControllerL.SetActive(true);
            LHFalse = true;
        }
    }
}
