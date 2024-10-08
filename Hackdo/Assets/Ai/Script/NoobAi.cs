using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoobAi : MonoBehaviour
{
    public float detectRange = 60f;
    public float stopRange = 50f;
    public float moveSpeed = 50f;

    private Transform playerTransform;
    private Rigidbody rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
            playerTransform = playerObject.transform;
    }

    void Update()
    {
        if (playerTransform == null)
            return;

        MoveTowardsTarget(playerTransform.position);

        if (Vector3.Distance(transform.position, playerTransform.position) <= detectRange)
        {
            if (Vector3.Distance(transform.position, playerTransform.position) <= stopRange)
            {
                animator.SetBool("Dead", true);
                Destroy(gameObject,5f);
            }
        }
    }

    void MoveTowardsTarget(Vector3 targetPosition)
    {
        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer <= stopRange) // If the enemy is within stopRange units of the player
        {
            rb.constraints = RigidbodyConstraints.FreezeAll; // Freeze all position and rotation
            animator.SetBool("Dead", true); // Play the "Dead" animation
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

        transform.position += direction * moveSpeed * Time.deltaTime; // ÀÌµ¿ 
    }
}
