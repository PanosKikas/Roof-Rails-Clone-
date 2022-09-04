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
            Pipe pipe = other.GetComponentInChildren<Pipe>();
            Assert.IsNotNull(pipe, "No pipe component found in player object.");
            pipe.Extend();
            Destroy(gameObject);
        }
    }

    bool IsPlayer(Collider collider)
    {
        return (collider.gameObject.CompareTag("Player"));
    }
}
