using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ExtensionCounter : MonoBehaviour
{
    public TextMeshProUGUI CounterText;
    public int Count { get; private set; } = 0;
    public Pipe pipe;

    private void Start()
    {
        pipe.OnExtensionCollected += Increment;
    }

    public void Increment()
    {
        ++Count;
        CounterText.text = Count.ToString();
    }
}
