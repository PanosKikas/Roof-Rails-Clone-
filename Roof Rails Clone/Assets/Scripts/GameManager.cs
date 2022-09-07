using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool IsGameRunning { get; private set; } = false;

    [HideInInspector]
    public bool PastFinishLine = false;

    public Player Player;

    public event Action OnGameOver;
    public event Action<int> OnGameWon;

    private void Awake()
    {
        if (Instance == null)
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
        PastFinishLine = false;
        Player.OnStart();
    }

    public void GameOver()
    {
        IsGameRunning = false;
        OnGameOver?.Invoke();
    }

    public void WinGame(int multiplier)
    {
        IsGameRunning = false;
        OnGameWon?.Invoke(multiplier);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
