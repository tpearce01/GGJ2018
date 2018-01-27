using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Item_Count : MonoBehaviour {

    public Text item_text; //The text object
    public Button item_button; //Item being used

    [SerializeField] private int amount; //How many # items they have
	
	// Update is called once per frame
	void Update () {
        item_text.text = amount.ToString(); //update text
	}

    public void decrement()
    {
        if(amount == 0) {
            item_button.interactable = false;
        }
        amount = amount - 1;
    }
}
