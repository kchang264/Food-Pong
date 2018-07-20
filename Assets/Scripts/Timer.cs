using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timerTxt;
    private int totalSec;
    private bool endTime; 

	void Start () {
        // Use this for initialization
        totalSec = 10; //Player gets 120 seconds to play  
        endTime = true;
        InvokeRepeating( "UpdateSeconds" , 0f, 1.0f);
	}
	
	// Update is called once per frame
	void UpdateSeconds() {
        if( totalSec >= 0 )
        {
            string secString = totalSec.ToString();
            timerTxt.text = secString;
            totalSec = totalSec - 1;
        }
        else
        {
            //time == 0, game must end 
        }
        //elapsed time is float 
        // ((int)elapsedTime % 60).ToString("f0"); //float with 0 decimals; f2 = float w/ 2 decimal places    
    }
}
