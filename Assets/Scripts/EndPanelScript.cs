using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//EndPanel is activated when either timer reaches 0, or all the ingredients are destroyed 
// (RecipeText.cs) 
// this is attached to EndPanel GameObject 


public class EndPanelScript : MonoBehaviour {
    //Score Objects 
    private Score scoreScript;
    private int gameScore;
    public Text scoreText; 

    //Time Objects 
    private Timer timerScript;
    private int timeLeft;
    public Text timeText;

    public Text totalScoreText; 

    //buttons 
    public GameObject retryButton;  
    public GameObject nextButton;

    //Title Text: 
    public Text titleText; 

    //Grab ball to determine how many lives are left 
    private BallMovement ballScript; 

    // Use this for initialization
    void Start () {
        //find ball gameobject by name, then grab BallMovement component; determine lives left  
        GameObject ball = GameObject.Find("Ball");
        ballScript = ball.GetComponent<BallMovement>();
        int livesLeft = ballScript.lives;

        //grab time left 
        timerScript = Camera.main.GetComponent<Timer>();
        timeLeft = timerScript.GetTimeLeft();
        timeText.text = timeLeft.ToString();

        //Calculate Score: grab score 
        scoreScript = Camera.main.GetComponent<Score>();
        gameScore = scoreScript.GetScore();
        scoreText.text = gameScore.ToString();

        //Determine if Win or Loss. If Loss, timeLeft is not considered in total score
        // deactivate/activate retry and next button, and setup title 
        //no more time left means a loss, or lives = 0

        if (timeLeft == 0 || livesLeft < 0 )   
        {
            retryButton.SetActive(true);
            titleText.text = "Loss";
            totalScoreText.text = scoreText.text;

        }
        else
        {
            //nextButton.SetActive(true);
            titleText.text = "Win";

            //calc total score 
            int totalScore = scoreScript.calcTotalScore(timeLeft);
            totalScoreText.text = totalScore.ToString();
        }

        

        
    }
}
