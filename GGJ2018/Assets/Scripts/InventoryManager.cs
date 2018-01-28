﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour {

	public static InventoryManager instance;

	public GameObject[] itemObjects;
	public GameObject notEnoughResourcesPanel;

	void Awake(){
		instance = this;
	}

	public void ChangeItemCount(Item index, int value){
		ChangeItemCount ((int)index, value);
	}
	public void ChangeItemCount(int index, int value){
		if (itemObjects [index].GetComponent<Item_Count> ().Amount <= 0) {
			OpenNotEnoughResourcesPanel ();
		} else {
			itemObjects [index].GetComponent<Item_Count> ().ChangeValue (value);
		}
	}

	public void SetItemCount(Item index, int value){
		SetItemCount ((int)index, value);
	}
	public void SetItemCount(int index, int value){
		if (itemObjects [index].GetComponent<Item_Count> ().Amount <= 0) {
			OpenNotEnoughResourcesPanel ();
		} else {
			itemObjects [index].GetComponent<Item_Count> ().SetValue (value);
		}
	}

	public void CloseNotEnoughResourcesPanel(){
		notEnoughResourcesPanel.SetActive (false);
	}

	public void OpenNotEnoughResourcesPanel(){
		notEnoughResourcesPanel.SetActive (true);
	}


	public bool IsValidOperation(Item index, int requiredAmount){
		return IsValidOperation ((int)index, requiredAmount);
	}
	public bool IsValidOperation(int index, int requiredAmount){
		if (itemObjects [index].GetComponent<Item_Count> ().Amount < requiredAmount) {
			OpenNotEnoughResourcesPanel ();
			return false;
		} 
		return true;
	}


}

public enum Item{
	Food = 0, 
	Water = 1,
	RadioComponent1 = 2,
	RadioComponent2 = 3,
	RadioComponent3 = 4
}
