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

    public PlayerMovement PlayerMovement;
    public Pipe pipe;

    public event Action OnGameOver;
    public event Action<int> OnGameWon;

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
        PastFinishLine = false;
        PlayerMovement.StartMoving();
    }

    public void GameOver()
    {
        EndGame();
        OnGameOver?.Invoke();
    }

    public void WinGame(int multiplier)
    {
        PlayerMovement.Stop();
        EndGame();
        OnGameWon?.Invoke(multiplier);
    }
    
    private void EndGame()
    {
        PlayerMovement.enabled = false;
        IsGameRunning = false;
        if (pipe.transform.parent != null)
        {
            pipe.transform.SetParent(null);
            Rigidbody rb = pipe.gameObject.AddComponent<Rigidbody>();
        }
        Camera.main.GetComponent<CinemachineBrain>().enabled = false;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
