using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Light))]
public class FlickeringLight : MonoBehaviour
{
    public float minIntensity = 10f;
    public float maxIntensity = 30f;
    public float duration = 1f; // ������ ���� �ð�

    private Light lightSource;

    void Start()
    {
        lightSource = GetComponent<Light>();
        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        while (true)
        {
            // intensity ���� min���� max�� ����
            for (float t = 0; t < duration; t += Time.deltaTime)
            {
                lightSource.intensity = Mathf.Lerp(minIntensity, maxIntensity, t / duration);
                yield return null;
            }

            // intensity ���� max���� min���� ����
            for (float t = 0; t < duration; t += Time.deltaTime)
            {
                lightSource.intensity = Mathf.Lerp(maxIntensity, minIntensity, t / duration);
                yield return null;
            }
        }
    }
}
