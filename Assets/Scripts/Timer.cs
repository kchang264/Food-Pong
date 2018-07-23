using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

    public Text timerTxt;
    private int totalSec;

	void Start () {
        // Use this for initialization
        totalSec = 120; //Player gets 120 seconds to play  
        timerTxt.text = totalSec.ToString(); 

        InvokeRepeating( "UpdateSeconds" , 2.0f, 1.0f); //calls after 2 seconds for every second 
	}
	
	// Update is called once per frame
	void UpdateSeconds() {
        if( totalSec >= 0 )
        {
            timerTxt.text = totalSec.ToString(); ;
            totalSec = totalSec - 1;
        }
        else
        {
            //time == 0, game must end. Since time ran out, goes to lose screen 
            SceneManager.LoadScene("LoseTest", LoadSceneMode.Single);
        }
        //elapsed time is float 
        // ((int)elapsedTime % 60).ToString("f0"); //float with 0 decimals; f2 = float w/ 2 decimal places    
    }

    public int GetTimeLeft()
    {
        return totalSec; 
    }
}
