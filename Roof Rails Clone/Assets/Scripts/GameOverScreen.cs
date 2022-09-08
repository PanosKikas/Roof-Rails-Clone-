using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    public GameObject GameOverPanel;
    private bool awaitInputTouch = false;
    private float waitInput = 0.4f;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.OnGameOver += ShowGameOverScreen;
    }

    private void ShowGameOverScreen()
    {
        StartCoroutine(ShowPanel());
    }

    private IEnumerator ShowPanel()
    {
        GameOverPanel.SetActive(true);
        yield return new WaitForSeconds(waitInput);
        awaitInputTouch = true;
    }

    private void Update()
    {
        if (!awaitInputTouch)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            GameManager.Instance.RestartLevel();
        }
    }
}
