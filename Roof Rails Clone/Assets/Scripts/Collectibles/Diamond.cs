using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    public int Value = 1;
    public CollectCanvas CollectCanvasUI;
    private Color color;

    private void Start()
    {
        color = GetComponent<MeshRenderer>().material.color;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pipe"))
        {
            other.GetComponentInParent<Player>().CollectDiamond(Value);
            CollectCanvas canvasInstance = Instantiate(CollectCanvasUI, transform.position, Quaternion.identity);
            canvasInstance.SetTextColor(color);
            canvasInstance.Animate(Value.ToString());
            Destroy(gameObject);
        }
    }
}
