using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour
{
    //��ź �Ŵ��� ��ũ��Ʈ�� �ٸ������� ������ �� �ֵ��� �ҷ���
    private static BombManager instance;
    //��ź�� ��ġ���� Ƚ���� ó����.
    private int bombPlanted;
    [Tooltip("��ź�� �� �迭�� �Է��ϴ� ĭ")]
    public GameObject[] bombs;
    /*
    [Tooltip("�����ϴ� ��ƼŬ ������")]
    public GameObject BoomParticle;
    */
    //��ź �Ŵ��� ������ �����ϵ��� ��.(private static " instance�� ¦���� ����)
    public GameObject ChagngeScene;
    public static BombManager Instance { get { return instance; } }
    public string tagToDeactivate; // ��Ȱ��ȭ�� ������Ʈ�� �±׸� Inspector���� �������ּ���.
    public GameObject SceneMove;
    public GameObject People;
    [Tooltip("�ڸ� ��ũ��Ʈ�� �Ҵ��ϴ� ĭ")]
    public SubtitleSystem ui; //�ڸ� ��ũ��Ʈ �Ҵ�


    private void Start()
    {
        People.SetActive(false);
    }
    private void Awake()
    {
        // �̹� �ٸ� �ν��Ͻ��� �����ϴ� ��� ���� �ν��Ͻ��� �ı��ϰ�,
        // �׷��� ���� ��쿡�� ���� �ν��Ͻ��� �����Ѵ�.
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
    /// ��ź ��ġȽ�� �ν� �� ��ź���� �Լ� ����
    /// </summary>
    public void BombCount()
    {
        //BombPlant���� ��ġ�ɶ����� ī��Ʈ�ȴ�.
        bombPlanted++;

        //3�� ��ġ/ī��Ʈ �Ǿ��� ��,
        if (bombPlanted == 3)
        {
            //�������� ����� �Բ� �α� ���.
            Debug.Log("All Planted, ready to be explode.");
            //��ź�� �����Ų��.
            ActivateBombs();
        }
    }

    /// <summary>
    /// ��� ��ź�� ��Ȱ��ȭ�ؼ� �Ⱥ��̰� ���� ��, ���� ��ƼŬ �����ϴ� �޼���.
    /// </summary>
    private void ActivateBombs()
    {
        // "ActivateBombsAfterDelay" �޼��带 2�� �Ŀ� �����մϴ�.
        Invoke("ActivateBombsAfterDelay", 2f);
        StartCoroutine(ui.PlayAudioAndShowSubtitle2());
    }

    private void ActivateBombsAfterDelay()
    {
      
        

        // ������ �±׸� ���� ��� ������Ʈ�� ã�Ƽ� ��Ȱ��ȭ�մϴ�.
        GameObject[] objectsToDeactivate = GameObject.FindGameObjectsWithTag(tagToDeactivate);
        foreach (GameObject obj in objectsToDeactivate)
        {
            People.SetActive(true);
            obj.SetActive(false);
            ChagngeScene.SetActive(true);
            
        }
    }
}
