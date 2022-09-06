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

        Pipe pipe = collision.collider.GetComponent<Pipe>();
        if (pipe)
        {
            Transform playerTransform = pipe.GetComponentInParent<PlayerMovement>().transform;
            bool rightCut = transform.position.x - playerTransform.position.x > 0;
            Vector3 collisionPoint = collision.collider.ClosestPoint(transform.position);
            collisionPoint += Vector3.right * meshRenderer.bounds.extents.x;
            pipe.Cut(collisionPoint, rightCut);
            collider.isTrigger = true;
        }

        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<PlayerMovement>().Stop();
            collision.collider.GetComponent<Rigidbody>().AddForce(collision.collider.transform.forward * -1f * 2f, ForceMode.Impulse);
            GameManager.Instance.GameOver();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (collider.CompareTag("Player"))
        {
            collider.GetComponent<PlayerMovement>().Stop();
            collider.GetComponent<Rigidbody>().AddForce(collider.transform.forward * -1f * 2f, ForceMode.Impulse);
            GameManager.Instance.GameOver();
        }
    }
}
