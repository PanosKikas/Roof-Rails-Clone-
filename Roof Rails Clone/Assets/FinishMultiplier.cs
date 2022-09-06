using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinishMultiplier : MonoBehaviour
{
    public TextMeshProUGUI MultiplierText;
    private int multiplierValue;

    private void Start()
    {
        string multiplierText = MultiplierText.text;
        string multiplierNumberText = multiplierText.Replace("X", "");
        bool success = Int32.TryParse(multiplierNumberText, out multiplierValue);
        if (!success)
        {
            Debug.LogError("Couldn't parse string: " + multiplierText);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            GameManager.Instance.WinGame(multiplierValue);
        }
    }
}
