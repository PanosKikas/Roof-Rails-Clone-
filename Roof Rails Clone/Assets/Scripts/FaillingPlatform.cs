using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaillingPlatform : MonoBehaviour
{
    public Rigidbody HoleRb;
    public float fallDelay;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        HoleRb.isKinematic = false;
    }
}
