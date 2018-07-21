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
        totalSec = 10; //Player gets 120 seconds to play  
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
            Debug.Log("INISDE");
            //time == 0, game must end. Since time ran out, goes to lose screen 
            SceneManager.LoadScene("LoseTest", LoadSceneMode.Single);
        }
        //elapsed time is float 
        // ((int)elapsedTime % 60).ToString("f0"); //float with 0 decimals; f2 = float w/ 2 decimal places    
    }
}
