using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HandlePause : MonoBehaviour {
    public GameObject[] paused;

    // creates list of items in pause menu and hides them 
    void Start () {
        Time.timeScale = 1;
        //paused = GameObject.FindGameObjectsWithTag("Paused");
        hidePaused();
        
    }

    /*
     * Loads a scene called "name" based on button pressed 
     */
    public void changeScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    /*
     * unpauses game 
     */
    public void unpause()
    {
        hidePaused();
    }

    // Update is called once per frame
    void Update () {
        //uses the p button to pause and unpause the game
        if (Input.GetKeyDown(KeyCode.P))
        {
            //show paused objects if unpaused 
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                showPaused();
            }
            //hide objects  if paused 
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                hidePaused();
            }
        }
    }

    /**
     * Shows pause menu
     */
    void showPaused()
    {
        Time.timeScale = 0; 
        foreach( GameObject g in paused )
        {
            g.SetActive(true);
        }
    }

    /**
     * Hides pause menu 
     */
     void hidePaused()
    {
        Time.timeScale = 1;
        foreach (GameObject g in paused)
        {
            g.SetActive(false);
        }
    }
}
