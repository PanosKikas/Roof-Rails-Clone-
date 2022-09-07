using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaillingPlatform : MonoBehaviour
{
    public GameObject Hole;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var rb = Hole.GetComponent<Rigidbody>();
            rb.isKinematic = false;
        }
    }
}
