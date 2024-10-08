using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamAi : MonoBehaviour
{
    public float detectRange = 20f; // 감지 범위
    public float stopRange = 30f; // 멈추는 범위
    public float moveSpeed = 10f; // 이동 속도
  
    public Transform firePoint; // 발사 위치
    private Animator animator;
    private Transform playerTransform;
    private Transform enemyTransform;
    private bool isAttackingEnemy = false;
    public float followDistance = 2f; // 플레이어를 따라갈 때 유지할 거리
    private Vector3 lastKnownPlayerPosition; // 플레이어의 마지막 위치
    void Start()
    {
        animator = GetComponent<Animator>();
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player object not found!");
        }

        GameObject enemyObject = GameObject.FindGameObjectWithTag("Anemy");
        if (enemyObject != null)
        {
            enemyTransform = enemyObject.transform;
        }

        if (playerTransform != null)
        {
            lastKnownPlayerPosition = playerTransform.position;
        }

    }

    void Update()
    {
        Vector3 targetPosition;

        if (playerTransform != null)
        {
            lastKnownPlayerPosition = playerTransform.position;
            Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;
            targetPosition = playerTransform.position - directionToPlayer * followDistance;

            MoveTowardsTarget(targetPosition);

            if (enemyTransform == null) return;

            float distanceToEnemy = Vector3.Distance(transform.position, enemyTransform.position);

            if (distanceToEnemy <= detectRange && !isAttackingEnemy)
            {
                animator.SetBool("Attack", true);
                isAttackingEnemy = true;
                StartCoroutine(FireBullets(enemyTransform));
            }

            else if (distanceToEnemy > detectRange && isAttackingEnemy)
            {
                animator.SetBool("Attack", false);
                isAttackingEnemy = false;
            }
        }
        else
        {
            MoveTowardsTarget(lastKnownPlayerPosition);
        }
    }

    void MoveTowardsTarget(Vector3 targetPosition)
    {
        targetPosition.y = transform.position.y;

        Vector3 direction = (targetPosition - transform.position).normalized;

        Quaternion targetRotation = Quaternion.LookRotation(direction);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * moveSpeed);

        if (Vector3.Distance(transform.position, targetPosition) > followDistance)
        {
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }
    IEnumerator FireBullets(Transform target)
    {
        for (int i = 0; i < 3; i++)
        {
            
           
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(3f);

        isAttackingEnemy = false;
    }
}