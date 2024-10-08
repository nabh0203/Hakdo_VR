using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftInventory : MonoBehaviour
{
    //손과 인벤토리는 둘 다 trigger상태여서 작동하기 힘들다. 그래서
    //엄청 작은 큐브를 제작해서 손에 위치시켜주고(+rigidbody isKinematic), mesh renderer은 꺼놓고,
    //Tag LeftInv을 생성하여 포함시켜야 한다. 

    [Tooltip("복제될 오브젝트 프리팹을 넣는 공간")]
    public GameObject spawnObject;
    [Tooltip("손의 위치/복제될 위치 GameObject를 넣는 공간")]
    public Transform spawnLocation;
    
    //왼쪽 인벤토리에 트리거 여부 = 비활성화.
    private bool isTriggered = false;
    //스폰 오브젝트 (SO) 변수생성 - 리지드바디와 콜라이더 설정값 가져오기위해.
    private GameObject SO;
   //오브젝트 복제 횟수 카운트.
    private int objectsSpawned = 0;
    public int SpawnLimit = 2;
    // Update is called once per frame
    void Update()
    {
        if (SO != null)
        {
            //만약 그랩 버튼을 누른 상태고, 복제된 상태가 아니고, 트리거가 된 상태면,
            if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger) && isTriggered)
            {

                //리지드바디 변수를 스폰된 오브젝트(SO)에 선언하고 불러온다.
                Rigidbody rb = SO.GetComponent<Rigidbody>();
                //캡슐콜라이더 변수를 스폰된 오브젝트(SO)에 선언하고 불러온다.
                CapsuleCollider cc = SO.GetComponent<CapsuleCollider>();
                //중력을 키고, 
                rb.useGravity = true;
                //트리거를 끈다. 이렇게 작동하면 키네틱을 사용하지 않고도 수류탄 복제 및 조작이 가능하다.
                cc.isTrigger = false;
            }
        }
    }


    public void OnTriggerEnter(Collider other)
    {
        isTriggered = true;
        //만약 왼쪽 손이 주머니에 트리거 됬을 시,
        if (other.CompareTag("LeftInv") && objectsSpawned < SpawnLimit)
        {
            //만약 SO가 생성되어있지 않다면,
            if (SO == null)

            {
                //복제될 오브젝트, 지정한 포지션값에 복제된다.
                SO = Instantiate(spawnObject, spawnLocation.transform.position, transform.rotation);
                SO.transform.SetParent(gameObject.transform);
                //트리거 여부 true
                isTriggered = true;
                //복제될 때마다 횟수 카운트한다.
                objectsSpawned++;


            }
            
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //만약 왼쪽 손이 주머니를 벗어낫을 시,
        if (other.CompareTag("LeftInv"))
        {
            //트리거 여부 false
            isTriggered = false;
        }
    }





}
