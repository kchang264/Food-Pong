using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//EndPanel is activated when either timer reaches 0, or all the ingredients are destroyed 
// (RecipeText.cs) 


public class EndPanelScript : MonoBehaviour {
    private Score scoreScript;
    private int gameScore;
    public Text scoreText; 

    private Timer timerScript;
    private int timeLeft;
    public Text timeText;

    public Text totalScoreText; 

    //buttons 
    public GameObject retryButton;  
    public GameObject nextButton;

    // Use this for initialization
    void Start () {
        //grab score 
        scoreScript = Camera.main.GetComponent<Score>();
        gameScore = scoreScript.GetScore();
        scoreText.text = gameScore.ToString();

        //grab time left 
        timerScript = Camera.main.GetComponent<Timer>();
        timeLeft = timerScript.GetTimeLeft();
        timeText.text = timeLeft.ToString();

        //calc total score 
        int totalScore = scoreScript.calcTotalScore(timeLeft);
        totalScoreText.text = totalScore.ToString(); 

        // deactivate/activate retry and next button
        if( timeLeft == 0 ) //no more time left means a loss 
        {
            retryButton.SetActive(true); 
        }
        else
        {
            nextButton.SetActive(true);
        }
    }
}
