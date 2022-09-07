using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField]
    private float horizontalSpeed = 3f;

    private float currentForwardSpeed;

    [SerializeField]
    private float forwardNormalSpeed = 8f;

    private float targetForwardSpeed;

    private Animator animator = null;

    private bool stopped = true;
    private bool isSpeedLerping = false;

    [SerializeField]
    private float boostLerpSpeed = 3f;

    private PlayerInputManager inputManager;

    private float horizontalInput = 0f;

    public Pipe pipe;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        currentForwardSpeed = forwardNormalSpeed;
        inputManager = GetComponent<PlayerInputManager>();
        if (inputManager == null)
        {
            Assert.IsNotNull(inputManager, "No input manager found in player object!");
        }
    }

    // Start is called before the first frame update
    public void StartMoving()
    {
        animator.SetFloat("MoveSpeed", 1);
        stopped = false;
    }

    public void BoostSpeed(float targetSpeed)
    {
        isSpeedLerping = true;
        targetForwardSpeed = targetSpeed;
    }

    public void ResetToNormalSpeed()
    {
        isSpeedLerping = true;
        targetForwardSpeed = forwardNormalSpeed;
    }

    public void Stop()
    {
        stopped = true;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        currentForwardSpeed = 0f;
        animator.SetFloat("MoveSpeed", 0f);
        pipe.DetachFromPlayer();
    }

    private void Update()
    {
        if (stopped)
        {
            return;
        }

        horizontalInput = inputManager.HorizontalInput;

        if (isSpeedLerping)
        {
            if (Mathf.Abs(targetForwardSpeed - currentForwardSpeed) <= 0.01f)
            {
                currentForwardSpeed = targetForwardSpeed;
                isSpeedLerping = false;
                return;
            }
            currentForwardSpeed = Mathf.Lerp(currentForwardSpeed, targetForwardSpeed, Time.deltaTime * boostLerpSpeed);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (stopped)
        {
            return;
        }

        rb.velocity = new Vector3(horizontalInput * horizontalSpeed, rb.velocity.y, currentForwardSpeed);
    }
}
