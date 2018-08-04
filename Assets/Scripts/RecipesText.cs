/* 
 * ### RecipesText.cs ###
 * Initializes a random recipe and writes to text element
 * Has array of ingredients (as gameobjects) that can be customized
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RecipesText : MonoBehaviour {

    [HideInInspector]
    public GameObject[] ListOfIngredients;

    public int[] numberItems;
    public Text txt;
    public int maxRecipe; // max number one ingredient the recipe can call for

    public GameObject endPanel;

    /*Updates Text element with the current GameObject Names and Count of ingredients needed*/
    public void StartingRecipe( GameObject[] ListOfIngredients )
    {
        //grabs recipe 
        GameObject recipeObject = GameObject.Find("RecipeToDo");
        Recipe recipe = recipeObject.GetComponent<Recipe>(); 

        txt.text = recipe.recipeName + "\n";
        for (int i = 0; i < recipe.ListOfIngredients.Length; ++i)
        {
            txt.text += recipe.ListOfIngredients[i].name + ": " + recipe.numberItems[i] + "\n";
        }
    }


    /*Checks if all elements in numberItems == 0, and if they are, returns True*/
    private bool RecipeDone()
    {
        for (int i = 0; i < numberItems.Length; ++i)
        {
            if (numberItems[i] != 0)
            {
                return false;
            }
        }
        return true;
    }

	// Use this for initialization
	void Start () {
        GameObject recipeObject = GameObject.Find("RecipeToDo");
        Recipe recipe = recipeObject.GetComponent<Recipe>();
        ListOfIngredients = recipe.ListOfIngredients; //should be pass by reference 
        numberItems = recipe.numberItems; 

        txt = GetComponent<Text>();
        StartingRecipe(ListOfIngredients);

 	}
    void Update()
    {
        if (RecipeDone())
        {
            endPanel.SetActive(true);
        }
    }
}
