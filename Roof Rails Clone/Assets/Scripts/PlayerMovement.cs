using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private float horizontalInput = 0f;

    [SerializeField]
    private float horizontalSpeed = 3f;

    [SerializeField]
    private float forwardSpeed = 8f;

    private Animator animator = null;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool("Grounded", true);
        animator.SetFloat("MoveSpeed", 1);
    }

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.position += new Vector3(horizontalInput * horizontalSpeed, 0, forwardSpeed) * Time.fixedDeltaTime;

    }
}