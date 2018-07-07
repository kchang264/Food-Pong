using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipesText : MonoBehaviour {

    public string[] NamesOfIngredients;
    private int[] numberItems;
    public Text txt;
    public int maxRecipe;

	// Use this for initialization
	void Start () {
        txt = GetComponent<Text>();
        txt.text = "Recipe\n";
        numberItems = new int[NamesOfIngredients.Length];
        for (int i = 0; i < NamesOfIngredients.Length; ++i)
        {
            int rand = Random.Range(1, maxRecipe);
            numberItems[i] = rand;
            txt.text += NamesOfIngredients[i] + ": " + rand + "\n";
        }
 	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
