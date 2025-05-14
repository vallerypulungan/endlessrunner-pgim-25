using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private GameObject StartMenuUI;
    [SerializeField] private GameObject GameOverUI;
    [SerializeField] private TextMeshProUGUI highScoreUI;
    [SerializeField] private TextMeshProUGUI currentScoreUI;

    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
        gameManager.onGameOver.AddListener(ActivateGameOverUI);
    }

    public void PlayButtonHandler()
    {
        gameManager.StartGame();
    }

    public void ActivateGameOverUI()
    {
        GameOverUI.SetActive(true);
        StartMenuUI.SetActive(false);

        highScoreUI.text = "High Score: " + Mathf.RoundToInt(gameManager.data.highScore).ToString();
        currentScoreUI.text = "Current Score: " + Mathf.RoundToInt(gameManager.currentScore).ToString();

       
    }

    private void Update()
    {
        scoreUI.text = gameManager.PrettyScore();
    }
}
