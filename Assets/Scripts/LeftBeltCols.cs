using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftBeltCols : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D col)
    {
        //If ball enters trigger, then acts as a wall. 
        if ( col.gameObject.tag == "Ball" )
        {
            Rigidbody2D rb = col.GetComponent<Rigidbody2D>();
            
            //acting as a wall 
            rb.velocity = new Vector2(-rb.velocity.x, -rb.velocity.y);
        }
    }
}
