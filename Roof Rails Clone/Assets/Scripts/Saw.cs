using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    MeshRenderer meshRenderer;
    Collider collider;

    private void Awake()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        collider = GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!GameManager.Instance.IsGameRunning)
        {
            return;
        }

        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<PlayerMovement>().Stop();
            GameManager.Instance.GameOver();
        }

        Pipe pipe = collision.collider.GetComponent<Pipe>();
        if (pipe)
        {
            Transform playerTransform = pipe.GetComponentInParent<PlayerMovement>().transform;
            bool rightCut = transform.position.x - playerTransform.position.x > 0;
            Vector3 collisionPoint = collision.collider.ClosestPoint(transform.position);
            collisionPoint += Vector3.right * meshRenderer.bounds.extents.x;
            pipe.Cut(collisionPoint, rightCut);
        }
    }
}
