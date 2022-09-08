using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidInputManager : PlayerInputManager
{
    float scaleDownInputModifier = 0.02f;

    protected override void UpdateInputs()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                HorizontalInput = touch.deltaPosition.x * scaleDownInputModifier;
            }
        }
        else
        {
            HorizontalInput = 0;
        }
    }
}
