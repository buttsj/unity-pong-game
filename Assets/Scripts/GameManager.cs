﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    private GameObject ball;

    private int paddle1Score;
    private int paddle2Score;

    public Text paddle1UI;
    public Text paddle2UI;
    public Text winUI;

    private float defaultTime;

    void Start () {

        ball = GameObject.Find("Ball");

        paddle1Score = 0;
        paddle2Score = 0;

        paddle1UI.text = "Player 1 Score: " + paddle1Score;
        paddle2UI.text = "Player 2 Score: " + paddle2Score;

        defaultTime = Time.timeScale;

    }
	
	void Update () {

        if (Input.GetKeyDown(KeyCode.P))
        {
            if(Time.timeScale != 0)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = defaultTime;
            }
            
        }

        if (Input.GetKeyDown(KeyCode.Backslash))
        {
            Application.CaptureScreenshot("Screenshot.png");
        }

        if (paddle1Score <= 10 && paddle2Score <= 10)
        {
            ScoreUpdate();
        }
    }

    private void ScoreUpdate()
    {
        if (ball.transform.position.z > 18)
        {
            paddle1Score++;
            paddle1UI.text = "Player 1 Score: " + paddle1Score;
            ball.GetComponent<AudioSource>().Play();
            if (paddle1Score >= 11)
            {
                ball.GetComponent<BallBehavior>().RestBall();
                winUI.text = "Player 1 Wins!";
            }
            else
            {
                ball.GetComponent<BallBehavior>().ResetBall();
            }

        }
        else if (ball.transform.position.z < -18)
        {
            paddle2Score++;
            paddle2UI.text = "Player 2 Score: " + paddle2Score;
            ball.GetComponent<AudioSource>().Play();
            if (paddle2Score >= 11)
            {
                ball.GetComponent<BallBehavior>().RestBall();
                winUI.text = "Player 2 Wins!";
            }
            else
            {
                ball.GetComponent<BallBehavior>().ResetBall();
            }
        }
    }
}
