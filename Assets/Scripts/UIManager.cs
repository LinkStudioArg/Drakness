using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour {
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private GameObject gameOverPanel;
    private GameManager gameManager;

 
    private void Awake()
    {
        Time.timeScale = 1;
        gameManager = FindObjectOfType<GameManager>();
    }
    public void ShowGameOver()
    {
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
