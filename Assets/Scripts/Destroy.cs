using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D col)
    {
        if( col.gameObject.name != "Pong" )
        {
            Destroy(col.gameObject);
        }
    }
}
