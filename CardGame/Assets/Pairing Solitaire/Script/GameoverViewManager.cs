using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameoverViewManager : MonoBehaviour
{
    

    public TextMeshProUGUI scoreText; // Reference to the UI text element displaying the score
    public TextMeshProUGUI highScoreText; // Reference to the UI text element displaying the high score

    private int score; // Current score value
    private int highScore; // Highest score achieved

    private void Awake()
    {
       
    }

    private void Start()
    {
        score = 0;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateScoreText();
        UpdateHighScoreText();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();

        if (score > highScore)
        {
            highScore = score;
            UpdateHighScoreText();
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }

    private void UpdateScoreText()
    {
        scoreText.text =score.ToString();
    }

    private void UpdateHighScoreText()
    {
        highScoreText.text = highScore.ToString();
    }
}
