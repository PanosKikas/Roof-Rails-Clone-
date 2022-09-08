using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiamondCounter : MonoBehaviour
{
    public Player Player;
    public TextMeshProUGUI DiamondCounterText;


    private void Start()
    {
        DiamondCounterText.text = Player.GetDiamondsCount().ToString();
        Player.OnDiamondCollected += OnDiamondValueChanged;
    }

    private void OnDiamondValueChanged(int newDiamondCount)
    {
        DiamondCounterText.text = newDiamondCount.ToString();
    }
}
