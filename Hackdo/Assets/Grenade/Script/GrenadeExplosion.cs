using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeExplosion : MonoBehaviour
{
    // 수류탄 폭발 범위
    public float explosionRadius = 5.0f;

    // 수류탄이 터지는 함수
    public void Explode()
    {
        // 폭발 범위 내의 모든 콜라이더를 가져옴
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        // 각 콜라이더에 대해 디버그 메시지를 출력
        foreach (Collider hit in colliders)
        {
            Debug.Log("폭발 이펙트에 맞은 오브젝트: " + hit.gameObject.name);
        }
    }
}
