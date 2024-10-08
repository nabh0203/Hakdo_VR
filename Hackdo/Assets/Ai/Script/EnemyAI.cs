using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyAI : MonoBehaviour
{
    public float detectRange = 20f; // 감지 범위
    public float stopRange = 30f; // 멈추는 범위
    public float moveSpeed = 2f; // 이동 속도
    
    public Transform firePoint; // 발사 위치
    private LineRenderer laserLine; // 레이저 포인터
    private Transform playerTransform;
    private bool isChasingPlayer = false;
    private Vector3 lastKnownPosition;
    public List<Transform> waypoints; // Waypoints for patrol route.
    private int currentWaypointIndex;
    private Animator animator;
    private Vector3 _lastKnownPosition;
    private bool _isChasingPlayer;
    private bool isAttacking = false;
    private Rigidbody rb;
    public Canvas myCanvas; // 할당할 캔버스
    public Image myImage; // 할당할 이미지
    private float hitTime = 0f; // hitfo 당한 시간
    void Start()
    {
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
        {
            playerTransform = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player object not found!");
        }

        currentWaypointIndex = -1;
        GoToNextWaypoint();
    }

    void Update()
    {
        DrawLaser(firePoint.transform.position, firePoint.transform.position + firePoint.transform.forward * 100);

        Vector3 position = transform.position;
        transform.position = position;
        if (playerTransform == null)
            return;

        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer <= detectRange)
        {

            Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;

            // Move towards the player's position
            MoveTowardsTarget(playerTransform.position);

            lastKnownPosition = transform.position; // Update the last known position
            isChasingPlayer = true; // Start chasing the player

            if (distanceToPlayer <= stopRange && !isAttacking)
            {
                isAttacking = true;
                animator.SetBool("Attack", true);
            }   
        }
        else if (isChasingPlayer) // If the enemy was chasing the player but now the player is out of range
        {
            // Move back to the last known position
            MoveTowardsTarget(lastKnownPosition);
            animator.SetBool("Attack", false);
            if (Vector3.Distance(transform.position, lastKnownPosition) < 0.1f)
            {
                isChasingPlayer = false; // Stop chasing the player when we've reached our previous position
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
            {
                
                GoToNextWaypoint();
            }
            else
            {
                // Follow waypoint path when not chasing or returning to last known position.
                MoveTowardsTarget(waypoints[currentWaypointIndex].position);
            }
        }
    }
    void GoToNextWaypoint()
    {
        currentWaypointIndex++;

        if (currentWaypointIndex >= waypoints.Count)
        {
            currentWaypointIndex = 0;
        }
    }

    void MoveTowardsTarget(Vector3 targetPosition)
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);
        if (distanceToPlayer <= 5f) // If the enemy is within 5 units of the player
        {
            return; // Don't move any closer
        }

        targetPosition.y = transform.position.y; // Set the target's y to our current y

        Vector3 direction = (targetPosition - transform.position).normalized;
        direction.y = 0; // Ignore the y component for the direction

        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * moveSpeed);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        Vector3 movement = direction * moveSpeed * Time.deltaTime;
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z); // y축 속도(중력)은 그대로 유지
    }

    IEnumerator FireBullets(Vector3 direction)
    {
        while (isAttacking)
        {
            Ray ray = new Ray(firePoint.position, direction);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.tag == "Player")
                {
                    Debug.Log("맞쳤어요!");
                    if (!myCanvas.gameObject.activeSelf)
                    {
                        myCanvas.gameObject.SetActive(true);
                    }

                    hitTime = Time.deltaTime;
                    Debug.Log(hitTime);

                    if (hitTime > 2f && hitTime <= 3f)
                    {
                        Debug.Log("Changing texture scale to 0.9");
                        Vector2 tiling = myImage.material.mainTextureScale;
                        tiling.x = 0.9f;
                        myImage.material.mainTextureScale = tiling;
                    }

                    else if (hitTime > 3f)
                    {
                        Vector2 tiling = myImage.material.mainTextureScale;
                        tiling.x = 0.4f;
                        myImage.material.mainTextureScale = tiling;
                    }
                }
                else
                {
                    if (myCanvas.gameObject.activeSelf)
                    {
                        myCanvas.gameObject.SetActive(false);
                    }

                    // reset the timer and texture scale when not hitting the enemy.
                    hitTime = 0f;
                    Vector2 resetTiling = new Vector2(1, 1);
                    myImage.material.mainTextureScale = resetTiling;
                }
            }

            yield return null; // Wait until the next frame
        }
    }
    void DrawLaser(Vector3 startPosition, Vector3 endPosition)
    {
        laserLine.SetPosition(0, startPosition);
        laserLine.SetPosition(1, endPosition);
    }

}
