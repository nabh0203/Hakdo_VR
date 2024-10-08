using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagSpot : MonoBehaviour
{
    public GameObject targetObject; // 활성화할 오브젝트를 Inspector에서 지정해주세요.
    public GameObject[] objectsToDestroy; // 파괴할 오브젝트를 Inspector에서 지정해주세요.
    private int destroyedCount = 0; // 파괴된 오브젝트의 수

    void Update()
    {
        // 배열에 저장된 오브젝트 중 파괴된 오브젝트의 수를 세고, 그 수가 10개가 되면 targetObject를 활성화합니다.
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
