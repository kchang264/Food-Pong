using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RecipeList : MonoBehaviour {

    //List of Recipes 
    public GameObject[] list; 

    //when a recipe button is selected in SelectRecipe Scene 
    //i is index in list 
    public void createRecipe( int i ) 
    {
        //check if a GameObject named "RecipeToDo" exists, if so, delete it
        GameObject recipeObject = GameObject.Find("RecipeToDo"); 
        if (recipeObject != null )
        {
            Destroy(recipeObject); 
        }

        //create a Recipe Object to be passed on to next scene 
        GameObject newRecipe = Instantiate(list[i]);
        newRecipe.name = "RecipeToDo"; 

        //tell Unity to preserve object
        DontDestroyOnLoad(newRecipe);

        //load Pong 
        SceneManager.LoadScene("Pong");
    }

    public int getRecipeNum()
    {
        return list.Length; 
    }
}
