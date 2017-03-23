using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ScoreManager : MonoBehaviour {
    [SerializeField]
    private int currentScore;
    [SerializeField]
    private string maxScoreKey;

    public void SetCurrentScore(int num)
    {
        currentScore = num;
    }

    public void AddCurrentScore(int num)
    {
        currentScore += num;
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }


    public void SetMaxScore(int num)
    {
        //darle un valor al puntaje mayor;
        PlayerPrefs.SetInt(maxScoreKey, num);
    }

    public int GetMaxScore()
    {
        if (PlayerPrefs.HasKey(maxScoreKey))
        {
            return PlayerPrefs.GetInt(maxScoreKey);
        }
        else
            return 0;
    }

    public bool isHigherThanMax(int num)
    {
        return num > GetMaxScore();
    }

    public void SaveChanges()
    {
        PlayerPrefs.Save();
    }

    [ContextMenu("ClearPlayerPrefs")]
    private void ClearPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}


