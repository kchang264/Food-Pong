using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* 
 * Writes the behavior of a button that will take it back to the Title Screen 
 */
public class BackButton : MonoBehaviour {

    public void backToTitle( string name )
    {
        Application.LoadLevel(name);
        //SceneManager.LoadScene("TitleScreen");
    }
}
