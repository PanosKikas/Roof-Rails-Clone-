using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rail : MonoBehaviour
{
    public float BoostSpeed = 12;
    public GameObject SparksParticles;

    private void OnCollisionEnter(Collision collision)
    {
        Pipe pipe = collision.collider.GetComponent<Pipe>();
        if (pipe)
        {
            pipe.AddRail(this);
            PlayerMovement playerMovement = pipe.GetComponentInParent<PlayerMovement>();
            SparksParticles.gameObject.SetActive(true);
            playerMovement?.BoostSpeed(BoostSpeed);
        }

        if (collision.collider.CompareTag("Player") && collision.collider.transform.position.y > transform.position.y)
        {
            Pipe childPipe = collision.collider.GetComponentInChildren<Pipe>();
            childPipe.DetachFromPlayer();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Pipe"))
        {
            SparksParticles.transform.position = collision.GetContact(0).point;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        Pipe pipe = collision.collider.GetComponent<Pipe>();
        if (pipe)
        {
            pipe.RemoveRail(this);
            SparksParticles.SetActive(false);
        }
    }
}
