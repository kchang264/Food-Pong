using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn: MonoBehaviour {
    public GameObject ingredient;
    public bool stopSpawn = false;
    public float spawnTime;
    public float delay; 
    public float ySpeed; 

	// Use this for initialization
	void Start () {
        //invoke repeating call (call method over and over) 
        InvokeRepeating("spawnObject", spawnTime, delay);
	}
	
	public void spawnObject()
    {
        GameObject spawned = Instantiate(ingredient, transform.position, transform.rotation);
        spawned.GetComponent<Rigidbody2D>().velocity = new Vector2(0, ySpeed);

        if( stopSpawn )
        {
            CancelInvoke("spawnObject"); 
        }

    }
}
