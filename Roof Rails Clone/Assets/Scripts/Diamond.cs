using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public int Value = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pipe"))
        {
            other.GetComponentInParent<Player>().CollectDiamond(Value);
            Destroy(gameObject);
        }
    }
}
