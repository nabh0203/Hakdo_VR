using UnityEngine;

public class DestroySpot : MonoBehaviour
{
    public GameObject targetObject; // Ȱ��ȭ�� ������Ʈ�� Inspector���� �������ּ���.
    public GameObject[] objectsToDestroy; // �ı��� ������Ʈ�� Inspector���� �������ּ���.
    private int destroyedCount = 0; // �ı��� ������Ʈ�� ��
    public SubtitleSystem subtitleSystem; // SubtitleSystem ��ũ��Ʈ ����
    [Tooltip("���� ���� �� üũ�Ͻÿ�. �ƴ� �� üũ����.")]
    public bool occupationScene = false;

    void Update()
    {
        // �迭�� ����� ������Ʈ �� �ı��� ������Ʈ�� ���� ����, �� ���� 10���� �Ǹ� targetObject�� Ȱ��ȭ�մϴ�.
        destroyedCount = 0;
        foreach (GameObject obj in objectsToDestroy)
        {
            if (obj == null)
            {
                destroyedCount++;
            }
        }
        if (destroyedCount >= objectsToDestroy.Length)
        {
            targetObject.SetActive(true);
            gameObject.SetActive(false);

            if (occupationScene)
            {
                //UI ����
                subtitleSystem.SetUI1Active(false);
                subtitleSystem.SetUI2Active(true);
            }
        }
    }
}
