using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rail : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Pipe pipe = collision.collider.GetComponent<Pipe>();
        if (pipe)
        {
            pipe.AddRail(this);
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
