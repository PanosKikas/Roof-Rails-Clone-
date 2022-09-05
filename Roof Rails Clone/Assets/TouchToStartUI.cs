using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchToStartUI : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameManager.Instance.StartGame();
            gameObject.SetActive(false);
        }
    }
}
