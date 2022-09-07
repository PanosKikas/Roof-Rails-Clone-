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
            pipe.DetachFromPlayer();
        }
    }
}
