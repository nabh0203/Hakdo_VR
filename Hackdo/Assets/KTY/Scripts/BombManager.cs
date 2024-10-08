using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour
{
    //폭탄 매니저 스크립트를 다른곳에서 접근할 수 있도록 불러옴
    private static BombManager instance;
    //폭탄이 설치됨의 횟수를 처리함.
    private int bombPlanted;
    [Tooltip("폭탄의 수 배열을 입력하는 칸")]
    public GameObject[] bombs;
    /*
    [Tooltip("폭발하는 파티클 프리팹")]
    public GameObject BoomParticle;
    */
    //폭탄 매니저 접근을 가능하도록 함.(private static " instance와 짝으로 쓰임)
    public GameObject ChagngeScene;
    public static BombManager Instance { get { return instance; } }
    public string tagToDeactivate; // 비활성화할 오브젝트의 태그를 Inspector에서 지정해주세요.
    public GameObject SceneMove;
    public GameObject People;
    [Tooltip("자막 스크립트를 할당하는 칸")]
    public SubtitleSystem ui; //자막 스크립트 할당


    private void Start()
    {
        People.SetActive(false);
    }
    private void Awake()
    {
        // 이미 다른 인스턴스가 존재하는 경우 현재 인스턴스를 파괴하고,
        // 그렇지 않은 경우에만 현재 인스턴스를 설정한다.
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }
    /// <summary>
    /// 폭탄 설치횟수 인식 및 폭탄실행 함수 실행
    /// </summary>
    public void BombCount()
    {
        //BombPlant에서 설치될때마다 카운트된다.
        bombPlanted++;

        //3번 설치/카운트 되었을 시,
        if (bombPlanted == 3)
        {
            //간지나는 영어와 함께 로그 출력.
            Debug.Log("All Planted, ready to be explode.");
            //폭탄을 실행시킨다.
            ActivateBombs();
        }
    }

    /// <summary>
    /// 모든 폭탄을 비활성화해서 안보이게 만든 뒤, 폭발 파티클 생성하는 메서드.
    /// </summary>
    private void ActivateBombs()
    {
        // "ActivateBombsAfterDelay" 메서드를 2초 후에 실행합니다.
        Invoke("ActivateBombsAfterDelay", 2f);
        StartCoroutine(ui.PlayAudioAndShowSubtitle2());
    }

    private void ActivateBombsAfterDelay()
    {
      
        

        // 지정된 태그를 가진 모든 오브젝트를 찾아서 비활성화합니다.
        GameObject[] objectsToDeactivate = GameObject.FindGameObjectsWithTag(tagToDeactivate);
        foreach (GameObject obj in objectsToDeactivate)
        {
            People.SetActive(true);
            obj.SetActive(false);
            ChagngeScene.SetActive(true);
            
        }
    }
}
