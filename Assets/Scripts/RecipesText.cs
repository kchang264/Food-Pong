using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipesText : MonoBehaviour {

    public string[] NamesOfIngredients;
    public Text txt;

	// Use this for initialization
	void Start () {
        txt = GetComponent<Text>();
        txt.text = "JIJO";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
