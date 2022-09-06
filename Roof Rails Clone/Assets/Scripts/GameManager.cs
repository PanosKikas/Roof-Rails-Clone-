using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool IsGameRunning { get; private set; } = false;
    public bool PastFinishLine = false;

    public PlayerMovement PlayerMovement;
    public Pipe pipe;

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

    public void EndGame()
    {
        Debug.LogError("END GAME");
        IsGameRunning = false;
        if (pipe.transform.parent != null)
        {
            pipe.transform.SetParent(null);
            Rigidbody rb = pipe.gameObject.AddComponent<Rigidbody>();
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
