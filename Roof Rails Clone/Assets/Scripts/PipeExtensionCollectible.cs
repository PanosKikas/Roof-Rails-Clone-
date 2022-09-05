using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PipeExtensionCollectible : MonoBehaviour
{
    public GameObject CollectCanvasUI;
    public float CanvasOffset = 2.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (IsPlayer(other))
        {
            Pipe pipe = other.GetComponentInChildren<Pipe>();
            Assert.IsNotNull(pipe, "No pipe component found in player object.");
            Instantiate(CollectCanvasUI, transform.position + Vector3.up * CanvasOffset, Quaternion.identity);
            pipe.Extend();
            Destroy(gameObject);
        }
    }

    bool IsPlayer(Collider collider)
    {
        return (collider.gameObject.CompareTag("Player"));
    }
}
