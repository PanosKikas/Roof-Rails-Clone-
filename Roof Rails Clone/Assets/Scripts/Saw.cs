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
            Debug.Log("Collision point " + collisionPoint);
            pipe.Cut(collisionPoint, rightCut);
        }

        if (collision.collider.CompareTag("Player"))
        {
            
            collision.collider.GetComponent<PlayerMovement>().Stop();
            collision.collider.GetComponent<Rigidbody>().AddForce(collision.collider.transform.forward * -1f * 2f, ForceMode.Impulse);
            GameManager.Instance.GameOver();
        }
    }
}
