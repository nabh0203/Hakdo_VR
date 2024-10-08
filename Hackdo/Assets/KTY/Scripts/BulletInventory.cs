using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletInventory : MonoBehaviour
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
    //총알 프리팹(BP) 변수생성 
    private GameObject BP;
    private int objectsSpawned = 0;
    public int SpawnLimit = 2;
    // Update is called once per frame
    void Update()
    {
        //만약 그랩 버튼을 누른 상태고, 한계횟수보다 작고, 트리거가 된 상태면,
        if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger) && objectsSpawned < SpawnLimit && isTriggered)
        {
            //만약 SO가 생성되어있지 않다면,
            if (BP == null) 

            {
                /*총알을 손 위치에 복제한다*/
                BP = Instantiate(spawnObject, spawnLocation); 
                //복제될 때마다 횟수 카운트한다.
                objectsSpawned++;
                

            }
            
        }
    }


    public void OnTriggerEnter(Collider other)
    {
        //만약 왼쪽 손이 주머니에 트리거 됬을 시,
        if (other.CompareTag("LeftInv") &&  !isTriggered)
        {
            //트리거 여부 true
            isTriggered = true;
            


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
