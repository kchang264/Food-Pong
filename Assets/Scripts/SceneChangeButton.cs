using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* 
 * Writes the behavior of a button that will change to another scene called "sceneName" 
 */
public class SceneChangeButton : MonoBehaviour {

    public void changeScene( string sceneName )
    {
        Debug.Log("I am here");
        SceneManager.LoadScene(sceneName);
    }
}
