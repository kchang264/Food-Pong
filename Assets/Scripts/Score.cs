using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText; 

    private string scText;
    private int score; 

	// Use this for initialization
	void Start () {
        scText = "Score: ";
        score = 0;
	}
	
    //when the desired ingredient is hit, add 10 points. 
	public void onHit()
    {
        score += 10; //Each ingreidient gives 10 points for now 
        scoreText.text = scText + score;
    }

    //After game ends, caclcualte time remaining and current score to give total score. 
    public int calcTotalScore(int secsLeft )
    {
        return score + 5* secsLeft; 
    }

    public int GetScore()
    {
        return score; 
    }

}
