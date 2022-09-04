using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    public GameObject Pipe;
    [SerializeField]
    private float ExtensionAmount = 0.1f;

    public void Extend()
    {
        Pipe.transform.localScale += Vector3.up * ExtensionAmount;
    }
}
