using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCut : MonoBehaviour
{
    [SerializeField]
    private const float RotationSpeed = 400f;

    private Rigidbody rb;

    private bool rotating = false;
    private float targetYRotation;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        rb.AddForce(transform.forward * -1 * 5f, ForceMode.Impulse);
    }

    public void RotateTo(float targetYRotation)
    {
        this.targetYRotation = targetYRotation;
        rotating = true;
    }


    private void FixedUpdate()
    {
        if (!rotating)
        {
            return;
        }

        float deltaRotationY = Time.fixedDeltaTime * RotationSpeed;
        deltaRotationY *= Mathf.Sign(targetYRotation);
        float currentAngle = rb.rotation.eulerAngles.y > 180 ? (rb.rotation.eulerAngles.y - 360f) : rb.rotation.eulerAngles.y;

        if (Mathf.Abs(deltaRotationY + currentAngle) >= Mathf.Abs(targetYRotation))
        {
            StopRotating();
            return;
        }

        var rot = Quaternion.Euler(0f, rb.rotation.eulerAngles.y + deltaRotationY, 90f);
        rb.MoveRotation(rot);
    }

    private void StopRotating()
    {
        rb.velocity = Vector3.zero;
        rb.transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, targetYRotation, transform.rotation.eulerAngles.z));
        rb.angularVelocity = Vector3.zero;
        rotating = false;
    }
}
