using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour {
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text maxScoreText;
    [SerializeField]
    private Text currentScoreText;
    [SerializeField]
    private GameObject gameOverPanel;
    private ScoreManager scoreManager;
 
    private void Awake()
    {
        Time.timeScale = 1;
        scoreManager = FindObjectOfType<ScoreManager>();
    }
    public void ShowGameOver()
    {
        maxScoreText.text = "Max: " + scoreManager.GetMaxScore().ToString();
        currentScoreText.text = "Score: " + scoreManager.GetCurrentScore().ToString();
        
        gameOverPanel.SetActive(true);
    }
    public void UpdateScoreText(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }



    public void Replay()
    {
        SceneManager.LoadScene("Level");
    }

    public void Quit()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void Exit()
    {
        Application.Quit();
    }


}
