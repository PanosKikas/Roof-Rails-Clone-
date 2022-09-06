using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rail : MonoBehaviour
{
    public float BoostSpeed = 12;

    private void OnCollisionEnter(Collision collision)
    {
        Pipe pipe = collision.collider.GetComponent<Pipe>();
        if (pipe)
        {
            pipe.AddRail(this);
            PlayerMovement playerMovement = pipe.GetComponentInParent<PlayerMovement>();
            playerMovement?.BoostSpeed(BoostSpeed);
        }     
    }

    private void OnCollisionExit(Collision collision)
    {
        Pipe pipe = collision.collider.GetComponent<Pipe>();
        if (pipe)
        {
            pipe.RemoveRail(this);
        }
    }
}
