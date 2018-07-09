using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D col)
    {
        if( ! (col.gameObject.name == "Pong" 
            || col.gameObject.name == "Ball" 
            || col.gameObject.name == "Paddle"))
        {
            Destroy(col.gameObject);
        }
    }
}
