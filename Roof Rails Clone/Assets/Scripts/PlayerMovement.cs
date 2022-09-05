using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private float horizontalInput = 0f;

    [SerializeField]
    private float horizontalSpeed = 3f;

    private float currentForwardSpeed;

    [SerializeField]
    private float forwardNormalSpeed = 8f;

    [SerializeField]
    private float targetForwardSpeed = 14f;

    private Animator animator = null;

    private bool awaitingFirstTouch = true;
    private bool isSpeedLerping = false;

    [SerializeField]
    private float boostLerpSpeed = 1.5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        currentForwardSpeed = forwardNormalSpeed;
    }

    // Start is called before the first frame update
    public void StartMoving()
    {
        animator.SetFloat("MoveSpeed", 1);
        awaitingFirstTouch = false;
    }

    public void BoostSpeed()
    {
        isSpeedLerping = true;
        targetForwardSpeed = currentForwardSpeed * 1.5f;
    }

    public void ResetToNormalSpeed()
    {
        isSpeedLerping = true;
        targetForwardSpeed = forwardNormalSpeed;
    }

    private void Update()
    {
        if (awaitingFirstTouch)
        {
            return;
        }

        horizontalInput = Input.GetAxisRaw("Horizontal");

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
        if (awaitingFirstTouch)
        {
            return;
        }

        rb.position += new Vector3(horizontalInput * horizontalSpeed, 0, currentForwardSpeed) * Time.fixedDeltaTime;
    }
}
