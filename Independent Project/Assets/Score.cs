using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscore;
    public int scoreValue = 0;

    void Start()
    {
        highscore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    public void AddScore()
    {
       scoreValue += 1;
       scoreText.text = scoreValue.ToString();

       if (scoreValue > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.GetInt("HighScore", scoreValue);
            highscore.text = scoreValue.ToString();
        }
    }
}
