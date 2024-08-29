using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    public static PlayerScore Instance;
    public Text scoreText;
    public int Score { get; set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance=this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Score = 0;
        UpdateScore();
    }

    private void UpdateScore()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score:" + Score.ToString();
            
        }
    }

    public void IncreaseScore(int value)
    {
        Score += value;
        UpdateScore();
    }
}
