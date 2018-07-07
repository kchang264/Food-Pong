/*
 *### DestroyIngredient.cs ###
 * Controls Movement of tester ball
 * Destroys collider that comes in contact with this ball
 * If ingredient hit appears on recipe list and has a count > 0, decrement count
 * Update text element (recipe)
 * Accesses RecipesText script to update count of ingredients (numberItems)
 * #### Still need to add a winning condition: User wins (goes to a new scene) when the count of all is = 0
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DestroyIngredient : MonoBehaviour {

    private Rigidbody2D rb;
    public int speed;
    public Text txt;
    private RecipesText script;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        script = txt.GetComponent<RecipesText>(); // Access the other script to change the values
	}

    /*Accesses RecipesText Script and changes the text value every time an ingredient is hit*/
    private void DecrementRecipeCount(Collision2D other)
    {
        Debug.Log(other.gameObject.name);
        int index = Array.IndexOf(script.ListOfIngredients, other.gameObject);
        if (index != -1 && script.numberItems[index] > 0)
        {
            script.numberItems[index]--;
            script.StartingRecipe(script.ListOfIngredients);
        }
    }
	
    private void OnMouseDown()
    {
        Debug.Log("Click");
        rb.velocity = new Vector2(speed, 0.0f);
    }

    /*Every time ingredient is hit, the text is updated and ingredient is destroyed*/
    private void OnCollisionEnter2D(Collision2D other)
    {
        if( other.gameObject.tag != "ignore")
        {
            DecrementRecipeCount(other);
            Destroy(other.gameObject);
            rb.velocity = new Vector2(-speed, -rb.velocity.y);
        }   
    }
}
