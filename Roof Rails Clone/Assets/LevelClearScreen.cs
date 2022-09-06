using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelClearScreen : MonoBehaviour
{
    public ExtensionCounter counter;
    public TextMeshProUGUI CollectedPipesText;
    public TextMeshProUGUI MultiplierText;
    public TextMeshProUGUI ProductText;

    public GameObject LevelClearPanel;
    public GameObject[] PanelsToDisable;

    private void Start()
    {
        GameManager.Instance.OnGameWon += OnGameWon;
    }

    private void OnGameWon(int multiplier)
    {
        int pipesCollected = counter.Count;
        CollectedPipesText.text = pipesCollected.ToString();
        MultiplierText.text = "X" + multiplier;
        ProductText.text = (multiplier * counter.Count).ToString();
        LevelClearPanel.SetActive(true);

        foreach (GameObject panel in PanelsToDisable)
        {
            panel.SetActive(false);
        }
    }

    private void Update()
    {
        if (LevelClearPanel.activeSelf && Input.GetMouseButtonDown(0))
        {
            GameManager.Instance.RestartLevel();
        }
    }
}
