using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagSpot : MonoBehaviour
{
    public GameObject targetObject; // Ȱ��ȭ�� ������Ʈ�� Inspector���� �������ּ���.
    public GameObject[] objectsToDestroy; // �ı��� ������Ʈ�� Inspector���� �������ּ���.
    private int destroyedCount = 0; // �ı��� ������Ʈ�� ��

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
        }
    }
}
