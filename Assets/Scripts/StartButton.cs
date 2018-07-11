using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour {

    // add other button code to this script too once those scenes are made

    public Button start;
    //public Button instructions;
    //public Button credits;

	// Use this for initialization
	void Start () {
        Button startbtn = start.GetComponent<Button>();
    }

    public void StartOnClick()
    {
        SceneManager.LoadScene("Pong");
    }
}
