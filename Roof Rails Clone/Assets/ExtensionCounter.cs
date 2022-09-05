using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExtensionCounter : MonoBehaviour
{
    public TextMeshProUGUI CounterText;
    private int count = 0;
    public Pipe pipe;

    private void Start()
    {
        pipe.OnExtensionCollected += Increment;
    }

    public void Reset()
    {
        count = 0;
        CounterText.text = "0";
    }

    public void Increment()
    {
        ++count;
        CounterText.text = count.ToString();
    }
}
