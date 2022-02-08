using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPumping : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private float score;
    [SerializeField] private Text scoreText, speedText;
    public int speedMetr;
    [SerializeField] private RunnerModes player; 
    private float newSpeed,loadSpeed;
    private void Start()
    {
        loadSpeed = PlayerPrefs.GetFloat("AccelerationTest");
        playerController.SetSpeedAdd(loadSpeed);

        speedMetr = Convert.ToInt32(player.Speed);
        scoreText.text = "Max speed: " + speedMetr.ToString() + " MPH";
    }
    private void FixedUpdate()
    {
        speedMetr = Convert.ToInt32(player.Speed);
        speedText.text = "Max speed: " + speedMetr.ToString() + " MPH";
    }
    public void AddScore(float newScore)
    {
        score = newScore;
    }
    public void BuyAcceleration()
    {
        newSpeed = playerController.ClickSpeedAdd + score / 30000;

        if (newSpeed > loadSpeed)
        {
            PlayerPrefs.SetFloat("AccelerationTest", newSpeed);
            playerController.SetSpeedAdd(newSpeed);
        }
        
        score = 0;
    }
    public void SetScore(float newScore)
    {
        score += newScore;
        scoreText.text = "Score: " + score.ToString();
        BuyAcceleration();
    }
}
