using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* 
 * Writes the behavior of a button that will change to another scene called "sceneName" 
 * Also contains exit method 
 */
public class SceneChangeButton : MonoBehaviour {

    public void changeScene( string sceneName )
    {
        SceneManager.LoadScene(sceneName);
    }

    public void exit()
    {
        Application.Quit(); 
    }
}
