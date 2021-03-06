﻿/*
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

    //Score update setup
    Camera mainCamera; //Score.cs is attached to main camera 
    private Score scoreScript;

    private Rigidbody2D rb;
    public int speed;
    public Text txt;
    private RecipesText script;
    public GameObject ignoreBorder;
    private string[] namesIngredients; // needed to compare names of ingredients (comparing objects doesnt work for some reason)

	// Use this for initialization
	void Start () {
        GameObject recipeObject = GameObject.Find("RecipeToDo");
        Recipe recipe = recipeObject.GetComponent<Recipe>();

        rb = gameObject.GetComponent<Rigidbody2D>();
        script = txt.GetComponent<RecipesText>(); // Access the other script to change the values

        // new array of string versions of names of ingredients for comparison purposes
        namesIngredients = new string[recipe.ListOfIngredients.Length];
        
        for (int i = 0; i < namesIngredients.Length; ++i)
        {
            namesIngredients[i] = recipe.ListOfIngredients[i].name;
        }

        // ignore collisions btwn ball and border #### not sure if this works??? because each border is a clone not the original
        Physics2D.IgnoreCollision(ignoreBorder.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        //setup for updating score 
        scoreScript = Camera.main.GetComponent<Score>(); 
    }

    /*Accesses RecipesText Script and changes the text value every time an ingredient is hit*/

    private void DecrementRecipeCount(Collision2D other)
    {  
        int index = Array.IndexOf(namesIngredients, other.gameObject.name);
        if (index != -1 && script.numberItems[index] > 0)
        {
            script.numberItems[index]--;
            script.StartingRecipe(script.ListOfIngredients);

            //calls a fucntion in Score.cs to update score 
            scoreScript.onHit();
        }       
    }
	
    private void OnMouseDown()
    {
        rb.velocity = new Vector2(speed, 0.0f);
    }

    /*Every time ingredient is hit, the text is updated and ingredient is destroyed*/
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!(other.gameObject.tag == "ignore"
             || other.gameObject.tag == "Wall"
             || other.gameObject.tag == "Paddle"))
        {
            DecrementRecipeCount(other);
            Destroy(other.gameObject);
            rb.velocity = new Vector2(-speed, -rb.velocity.y);
        }

    }
}
