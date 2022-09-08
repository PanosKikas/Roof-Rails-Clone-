using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    private PlayerCollectables Collectables;

    public event Action<int> OnDiamondCollected;

    public Pipe pipe;
    private PlayerMovement playerMovement;
    private float stopPlayerMovementDelay = 2.5f;

    private void Awake()
    {
        // Normally the collectables would need to persist and saved on the phone
        // Here because we only have one level it is not needed.
        Collectables = new PlayerCollectables();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Start()
    {
        GameManager.Instance.OnGameWon += OnGameWon;
        GameManager.Instance.OnGameOver += OnGameOver;
    }

    private void OnGameOver()
    {
        Camera.main.GetComponent<CinemachineBrain>().enabled = false;
        StartCoroutine(StopPlayerMovementWithDelay());
    }

    IEnumerator StopPlayerMovementWithDelay()
    {
        yield return new WaitForSeconds(stopPlayerMovementDelay);
        playerMovement.Stop();
        this.gameObject.SetActive(false);
    }

    public void OnStart()
    {
        playerMovement.StartMoving();
    }

    public void OnGameWon(int _)
    {
        playerMovement.Stop();
        pipe.DetachFromPlayer();
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
