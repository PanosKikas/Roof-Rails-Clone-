using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    MeshRenderer meshRenderer;
    private void Awake()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Pipe pipe = other.GetComponent<Pipe>();
        if (pipe)
        {
            Vector3 collisionPoint = other.ClosestPoint(transform.position);
            collisionPoint += Vector3.right * meshRenderer.bounds.extents.x;
            Debug.Log("Collision point " + collisionPoint);
            pipe.Cut(collisionPoint);
        }

        if (other.CompareTag("Player"))
        {
            Debug.Log("DIE");
        }
    }
}
