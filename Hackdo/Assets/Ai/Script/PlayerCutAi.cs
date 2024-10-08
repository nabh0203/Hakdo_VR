using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class PlayerCutAi : MonoBehaviour
    {
        public float detectRange = 60f; // 감지 범위를 40m로 변경
        public float stopRange = 50f; //거리 감지 범위30m로 설정
        public float moveSpeed = 50f; // 적군 속도
    public GameObject boom2;
        public Transform firePoint;
        private LineRenderer laserLine;
        private Transform playerTransform;
    public float someThreshold = 5f;
        private Animator animator;
        private bool isAttacking = false;
        private Rigidbody rb;
        public Canvas myCanvas;
        public Image myImage;
    private ParticleSystem part; // 파티클 시스템
    private List<ParticleCollisionEvent> collisionEvents; // 파티클 충돌 이벤트를 저장할 리스트

    private float hitTime = 0f;

        void Start()
        {
            part = GetComponent<ParticleSystem>();
            collisionEvents = new List<ParticleCollisionEvent>();
            rb = GetComponent<Rigidbody>();
            laserLine = GetComponent<LineRenderer>();

            if (laserLine == null)
            {
                laserLine = this.gameObject.AddComponent<LineRenderer>();
                laserLine.material = new Material(Shader.Find("Standard"));
                laserLine.startColor = Color.red;
                laserLine.endColor = Color.red;
                laserLine.startWidth = 0.01f;
                laserLine.endWidth = 0.01f;
            }

            laserLine.positionCount = 2;

            animator = GetComponent<Animator>();

            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

            if (playerObject != null)
                playerTransform = playerObject.transform;


        }

    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Anemy"); // 모든 적 AI를 찾습니다.

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position); // 현재 AI와 다른 AI 간의 거리를 계산합니다.

            if (distance < someThreshold) // 만약 거리가 임계값보다 작다면
            {
                Vector3 dirToEnemy = transform.position - enemy.transform.position; // 현재 AI에서 다른 AI를 향하는 방향을 계산합니다.
                Vector3 newPos = transform.position + dirToEnemy; // 새로운 위치를 계산합니다.

                transform.position = newPos; // 현재 AI의 위치를 업데이트합니다.
            }
        }
        DrawLaser(firePoint.transform.position, firePoint.transform.position + firePoint.transform.forward * 100);

        if (playerTransform == null)
            return;

        MoveTowardsTarget(playerTransform.position);

        if (Vector3.Distance(transform.position, playerTransform.position) <= detectRange)
        {
            if (Vector3.Distance(transform.position, playerTransform.position) <= stopRange && !isAttacking)
            {
                isAttacking = true;
                animator.SetBool("Attack", true);
              
            }
         
        }
    }

    void MoveTowardsTarget(Vector3 targetPosition)
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer <= stopRange) // If the enemy is within stopRange units of the player
        {
            rb.constraints = RigidbodyConstraints.FreezeAll; // Freeze all position and rotation
            return; // Don't move any closer
        }
        else
        {
            rb.constraints = RigidbodyConstraints.None; // Remove constraints when moving
        }

        targetPosition.y = transform.position.y; // Set the target's y to our current y

        Vector3 direction = (targetPosition - transform.position).normalized;
        direction.y = 0; // Ignore the y component for the direction

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * moveSpeed);

        transform.position += direction * moveSpeed * Time.deltaTime; // 이동 
    }


    void DrawLaser(Vector3 startPosition, Vector3 endPosition)
        {
            laserLine.SetPosition(0, startPosition);
            laserLine.SetPosition(1, endPosition);
        }
   
   
}
