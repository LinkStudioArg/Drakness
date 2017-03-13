using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField]
    private int playerScore = 0;
    [SerializeField]
    private Color gameOverBackgroundColor;
    private UIManager uiManager;
    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
    }

    private void Update()
    {
        uiManager.UpdateScoreText(playerScore);
    }

    public void AddScore(int num)
    {
        playerScore += num;
    }

    public void GameOver()
    {
        uiManager.ShowGameOver();

        Time.timeScale = 0;
    }
    

}
