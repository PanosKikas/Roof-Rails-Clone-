using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPipeCheck : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Pipe pipe = collision.collider.GetComponent<Pipe>();
        if (pipe)
        {
            if (pipe.transform.parent == null)
            {
                return;
            }

            Debug.LogError("COLLIDED WITH " + this.gameObject);
            PlayerMovement playerMovement = pipe.gameObject.GetComponentInParent<PlayerMovement>();
            playerMovement.Stop();

            pipe.DetachFromPlayer();
        }
    }
}
