using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public KeyCode moveUp = KeyCode.UpArrow;
    public KeyCode moveDown = KeyCode.DownArrow;
    public float speed = 10.0f;
    public float boundY = 6.0f;
    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        var vel = rb2d.velocity;
        //move up and down 
        if (Input.GetKey(moveUp) || Input.GetKey( KeyCode.W ))
        {
            vel.y = speed;
        }
        else if (Input.GetKey(moveDown) || Input.GetKey( KeyCode.S ) )
        {
            vel.y = -speed;
        }
        //rotate 
        else if( Input.GetKey(KeyCode.LeftArrow ) || Input.GetKey( KeyCode.A ) )
        {
            transform.Rotate( 0, 0, 1, Space.Self ); 
        }
        else if( Input.GetKey( KeyCode.RightArrow ) | Input.GetKey( KeyCode.D ) )
        {
            transform.Rotate(0, 0, -1, Space.Self);
        }
        else if (!Input.anyKey)
        {
            vel.y = 0;
        }
        rb2d.velocity = vel;

        var pos = transform.position;
        if (pos.y > boundY)
        {
            pos.y = boundY;
        }
        else if (pos.y < -boundY)
        {
            pos.y = -boundY;
        }
        transform.position = pos;
	}
}
