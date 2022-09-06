using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformInputManagerInjector : MonoBehaviour
{
    private void Awake()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            gameObject.AddComponent<AndroidInputManager>();
        }
        else
        {
            gameObject.AddComponent<DesktopInputManager>();
        }
    }
}
