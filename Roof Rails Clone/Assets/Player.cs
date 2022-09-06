using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerCollectables Collectables;

    public event Action<int> OnDiamondCollected;

    private void Awake()
    {
        // Normally the collectables would need to persist and saved on the phone
        // Here because we only have one level it is not needed.
        Collectables = new PlayerCollectables();
    }

    public void CollectDiamond(int value = 1)
    {
        Collectables.Diamonds += value;
        OnDiamondCollected?.Invoke(Collectables.Diamonds);
    }

    public int GetDiamondsCount()
    {
        return Collectables.Diamonds;
    }
}
