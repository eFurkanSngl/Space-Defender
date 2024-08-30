using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerScore : MonoBehaviour
{
    public static PlayerScore Instance;
    public Text scoreText;
    public Text liveText;
    
    public int Score { get; set; }
    public int  live { get; set; }
    
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
        live = 100;
        Score = 0;
        UpdateScore();
        UpdateLive();
        
    }

    private void UpdateScore()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score:" + Score.ToString();
        }
    }

    private void UpdateLive()
    {
       if (liveText != null)
        {
            liveText.text = "Live:" + live.ToString();
        }
        Debug.Log("worked");
    }

    public void IncreaseScore(int value)
    {
        Score += value;
        UpdateScore();
    }

    public void IncreaseLive(int value)
    {
        live -= value;
        UpdateLive();
    }

  
    
    
}
