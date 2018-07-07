using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyIngredient : MonoBehaviour {

    private Rigidbody2D rb;
    public int speed;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
    private void OnMouseDown()
    {
        Debug.Log("Click");
        rb.velocity = new Vector2(speed, 0.0f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if( other.gameObject.tag != "ignore")
        {
            Destroy(other.gameObject);
            rb.velocity = new Vector2(-speed, -rb.velocity.y);
        }
        
    }

	// Update is called once per frame
	void Update () {

	}
}
