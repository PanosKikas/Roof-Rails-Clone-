using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidInputManager : PlayerInputManager
{
    protected override void UpdateInputs()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                HorizontalInput = touch.deltaPosition.x / 50f;
                Debug.Log("Horizontal Input " + HorizontalInput);
            }
        }
        else
        {
            HorizontalInput = 0;
        }
    }
}
