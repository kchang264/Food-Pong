/** 
 * Filename: Spawn.cs
 * Description: Describes the spawner's behavior. Should spawn a random ingredient every second 
 * Date: July 6, 2018 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn: MonoBehaviour {
    public GameObject borderObject;
    public bool stopSpawn = false;
    public float spawnIngredientTime;
    public float spawnBorderTime;
    public float delay; 
    public float ySpeed;

    public GameObject[] ingredients;

	// Use this for initialization
	void Start () {
        //invoke repeating call (call method over and over) 
        InvokeRepeating("spawnIngredient", spawnIngredientTime, delay);
        InvokeRepeating("spawnBorder", spawnBorderTime, delay);
    }
	
    /** 
     * Function Name: spawnObject() 
     * Function Prototype: public void spawnObject(); 
     * Description: Spawns objects once every *delay* seconds, 
     * Parameters: None 
     * Side Effects: Creates ingredients in the game world that move in a downwards direction 
     *              at ySpeed. 
     * Error Conditions: None
     * Return Value: None 
     */
	public void spawnIngredient()
    {
        //pick random object in ingredients[] and create object 
        int index = Random.Range(0, ingredients.Length);
        GameObject spawned = Instantiate(ingredients[index], transform.position, ingredients[index].transform.rotation);
        spawned.GetComponent<Rigidbody2D>().velocity = new Vector2(0, ySpeed);
        spawned.name = ingredients[index].name;  // ANNA was HERE! I added this line so that the name doesn't say (Clone)

        if ( stopSpawn )
        {
            CancelInvoke("spawnObject"); 
        }

    }

    public void spawnBorder()
    {
        //spawn border 
        GameObject border = Instantiate(borderObject, transform.position, transform.rotation);
        border.GetComponent<Rigidbody2D>().velocity = new Vector2(0, ySpeed);

        if (stopSpawn)
        {
            CancelInvoke("spawnObject");
        }

    }
}
