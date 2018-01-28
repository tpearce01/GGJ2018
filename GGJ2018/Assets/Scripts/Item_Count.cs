using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Item_Count : MonoBehaviour {

    public Text item_text; //The text object
    public Button item_button; //Item being used

    [SerializeField] private int amount; //How many # items they have

	void Start(){
		UpdateText ();
	}

    public void decrement()
    {
        if(amount == 0) {
            item_button.interactable = false;
        }
        amount = amount - 1;
		UpdateText ();
    }

	public void ChangeValue(int value){
		amount += value;
		if(amount <= 0) {
			item_button.interactable = false;
		}
		if (amount < 0) {
			amount = 0;
		}
		UpdateText ();
	}

	public void SetValue(int value){
		amount = value;
		if(amount <= 0) {
			item_button.interactable = false;
		}
		if (amount < 0) {
			amount = 0;
		}
		UpdateText ();
	}

	void UpdateText(){
		item_text.text = amount.ToString(); //update text
	}
}
