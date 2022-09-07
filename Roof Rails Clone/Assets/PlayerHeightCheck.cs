using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHeightCheck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (GameManager.Instance.IsGameRunning)
            {
                GameManager.Instance.GameOver();
            }   
        }
    }
}
