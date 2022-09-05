using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool IsGameRunning { get; private set; } = false;

    public PlayerMovement PlayerMovement;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("More than one Game managers found. Destroying...");
            Destroy(gameObject);
        }
    }

    public void StartGame()
    {
        IsGameRunning = true;
        PlayerMovement.StartMoving();
    }

    public void EndGame()
    {
        IsGameRunning = false;
    }
}
