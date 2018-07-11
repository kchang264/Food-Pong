using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour {

    private Rigidbody2D rb2d;
    private Vector2 vel;
    public float minSpeed = 3.0f;
    public float maxSpeed = 9.0f;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("GoBall", 2);
	}
	
    /*custom clamp magnitude function that accounts for both max and min */
    public static Vector2 ClampMagnitude(Vector2 v, float max, float min)
    {
        double sm = v.sqrMagnitude;
        if (sm > (double)max * (double)max)
            return v.normalized * max;
        else if (sm < (double)min * (double)min)
            return v.normalized * min;
        return v;
    }

    /* if x velocity becomes 0, sets it to 2 so it isn't stuck up and down*/
    private void preventVertical()
    {
        if (rb2d.velocity.x == 0.0f)
        {
            rb2d.velocity = new Vector2(2.0f, rb2d.velocity.y);
        }
    }

    /* wait for 2 seconds before checking if velocity is below/above an amount*/
    IEnumerator MinMaxVelocity()
    {
        yield return new WaitForSeconds(2); // wait for 2 seconds b/c thats how long before the ball moves
        rb2d.velocity = ClampMagnitude(rb2d.velocity, maxSpeed, minSpeed);
        preventVertical();
    }

	// Update is called once per frame
	void Update () {
        StartCoroutine(MinMaxVelocity());
    }

    void GoBall()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            rb2d.AddForce(new Vector2(20, -15));
        }
        else
        {
            rb2d.AddForce(new Vector2(-20, -15));
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Paddle"))
        {
            vel.x = rb2d.velocity.x;
            vel.y = (rb2d.velocity.y / 2.0f) + (coll.collider.attachedRigidbody.velocity.y / 3.0f);
            rb2d.velocity = vel;
        }
    }
}
