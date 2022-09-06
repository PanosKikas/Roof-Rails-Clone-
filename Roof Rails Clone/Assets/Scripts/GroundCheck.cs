using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private Animator animator;
    public bool IsGrounded { get; private set; } = true;

    public float TargetBoostSpeed = 5;
    private PlayerMovement playerMovement;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            animator.SetBool("Grounded", true);
            playerMovement.ResetToNormalSpeed();
            IsGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            animator.SetBool("Grounded", false);
            IsGrounded = false;
            playerMovement.BoostSpeed(TargetBoostSpeed);
        }
    }
}
