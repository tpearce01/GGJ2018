using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

	public static InventoryManager instance;

	public GameObject[] itemObjects;

	void Awake(){
		instance = this;
	}

	public void ChangeItemCount(Item index, int value){
		ChangeItemCount ((int)index, value);
	}
	public void ChangeItemCount(int index, int value){
		itemObjects [index].GetComponent<Item_Count>().ChangeValue (value);
	}

	public void SetItemCount(Item index, int value){
		SetItemCount ((int)index, value);
	}
	public void SetItemCount(int index, int value){
		itemObjects [index].GetComponent<Item_Count>().SetValue (value);
	}
}

public enum Item{
	Food = 0, 
	Water = 1,
	RadioComponent1 = 2,
	RadioComponent2 = 3,
	RadioComponent3 = 4
}
