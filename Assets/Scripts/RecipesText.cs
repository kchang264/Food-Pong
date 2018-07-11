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

    public GameObject[] ListOfIngredients;
    public int[] numberItems;
    public Text txt;
    public int maxRecipe; // max number one ingredient the recipe can call for

    /*Updates Text element with the current GameObject Names and Count of ingredients needed*/
    public void StartingRecipe(GameObject[] ListOfIngredients)
    {
        txt.text = "Recipe\n";
        for (int i = 0; i < ListOfIngredients.Length; ++i)
        {
            txt.text += ListOfIngredients[i].name + ": " + numberItems[i] + "\n";
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
        /*instantiate numberItems with random values*/
        numberItems = new int[ListOfIngredients.Length];
        for (int i = 0; i < ListOfIngredients.Length; ++i)
        {
            int rand = Random.Range(1, maxRecipe);
            numberItems[i] = rand;
        }

        txt = GetComponent<Text>();
        StartingRecipe(ListOfIngredients);
 	}
    void Update()
    {
        if (RecipeDone())
        {
            SceneManager.LoadScene("WinTest", LoadSceneMode.Single);
        }
    }
}
