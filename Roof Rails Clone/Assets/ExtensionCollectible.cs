using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class ExtensionCollectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (IsPlayer(other))
        {
            PipeController pipeController = other.GetComponent<PipeController>();
            Assert.IsNotNull(pipeController, "No pipe controller component found in player");
            pipeController.Extend();
            Destroy(gameObject);
        }
    }

    bool IsPlayer(Collider collider)
    {
        return (collider.gameObject.CompareTag("Player"));
    }
}
