using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombPlant : MonoBehaviour
{
    //부착될 표면의 스케일값이 폭탄에 그대로 반영되기에, 표면은 항상 defalut(1,1,1)을 유지해야 한다.
    
    //폭탄 설치 가능 여부 - 활성화 시 카운트가 
    private bool attached = true;

    private void OnTriggerEnter(Collider other)
    {
        //만약 설치 영역에 트리거되고, 폭탄이 설치가능한 상태면,
        if (other.gameObject.CompareTag("Bomb") && attached)
        {

            //폭탄을 설치영역의 부모로 만든다.
            transform.parent = other.transform;
            //설치영역 transform을 null값으로 만들어서 
            transform.parent = null;
            //설치영역 다시설정한다.
            transform.parent = other.transform;
            //폭탄의 회전값을 설정한다.
            transform.rotation = Quaternion.identity;
            //설치 불가능한 상태로 만든다 - 중복 트리거가 되어 BombCount가 잘못작동하는 것을 방지하기 위해 
            attached = false;
            //폭탄 매니저의 BombCount 함수에 값을 전송시킨다. 
            //3번 값이 전송되면, 이벤트가 일어나도록 제작하였다. 어떤 이벤트를 사용할지는 BombManager에서 수정.
            BombManager.Instance.BombCount();
        }
    }
}
