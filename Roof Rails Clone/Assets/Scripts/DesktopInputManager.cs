using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopInputManager : PlayerInputManager
{
    protected override void UpdateInputs()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
    }
}
