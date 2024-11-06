using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using System;
using UnityEngine.SocialPlatforms.Impl;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;
    public int scoreValue = 0;
    public int highscoreValue;

    void Start()
    {
    }

    private void Update()
    {
       scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshProUGUI>();
       highscoreText = GameObject.FindGameObjectWithTag("Highscore").GetComponent<TextMeshProUGUI>();
    }
    public void AddScore()
    {
       scoreValue += 1;
       scoreText.text = scoreValue.ToString();
       highscoreText.text = highscoreValue.ToString();

        if (scoreValue > highscoreValue)
        {
            highscoreValue = scoreValue;
            highscoreText.text = highscoreValue.ToString();
        }
    }
}
