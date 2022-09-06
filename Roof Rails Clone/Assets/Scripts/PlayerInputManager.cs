using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerInputManager : MonoBehaviour
{
    public float HorizontalInput { get; protected set; }

    protected abstract void UpdateInputs();

    private void Update()
    {
        UpdateInputs();
    }
}
