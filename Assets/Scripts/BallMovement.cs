using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public Rigidbody2D rb; 
public float force = 500f;

public class BallMovement : MonoBehaviour {

     

    private void onMouseDown()
    {
        rb.velocity = newVector2(force, 0.0f);

    }
}
