using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    
    [SerializeField]
    private Color gameOverBackgroundColor;
    private UIManager uiManager;
    private ScoreManager scoreManager;

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    private void Update()
    {
        uiManager.UpdateScoreText(scoreManager.GetCurrentScore());
    }


    public void GameOver()
    {
        //Verificar que el puntaje obtenido sea o no mayor que el mayor

        if (scoreManager.isHigherThanMax(scoreManager.GetCurrentScore()))
        {
            scoreManager.SetMaxScore(scoreManager.GetCurrentScore());
            scoreManager.SaveChanges();
        }
        Debug.Log("Actual: " + scoreManager.GetCurrentScore() + " | Max: " + scoreManager.GetMaxScore());
        uiManager.ShowGameOver();
        Time.timeScale = 0;
    }
    

}
