using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour {

	public static InventoryManager instance;

	public GameObject[] itemObjects;
	public GameObject notEnoughResourcesPanel;

	[SerializeField] Image toFade;

	void Awake(){
		instance = this;
	}

	void Start(){
		StartCoroutine (CheckGameOver ());
	}

	void Update(){
		if (Input.GetKeyDown (KeyCode.T)) {
			Test ();
		}
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

	IEnumerator CheckGameOver(){
		bool gameOver = false;
		while (!gameOver) {
			if (itemObjects [2].GetComponent<Item_Count> ().Amount >= 1 &&
			   itemObjects [3].GetComponent<Item_Count> ().Amount >= 1 &&
			   itemObjects [4].GetComponent<Item_Count> ().Amount >= 1) {
				gameOver = true;
			}
			yield return new WaitForSeconds (1);
		}
		yield return new WaitForSeconds (1);
		StartCoroutine(FadeToBlack (2));
		yield return new WaitForSeconds (2);
		SceneManager.LoadScene ("game_over");
	}

	IEnumerator FadeToBlack(int duration){
		toFade.gameObject.SetActive (true);
		toFade.color = new Color (toFade.color.r, toFade.color.g, toFade.color.b, 0);
		for (int i = 0; i < 50; i++) {
			toFade.color = new Color (toFade.color.r, toFade.color.g, toFade.color.b, toFade.color.a + 0.02f);
			yield return new WaitForSeconds (duration / 50);
		}
	}

	void Test(){
		itemObjects [2].GetComponent<Item_Count> ().SetValue (1);
		itemObjects [3].GetComponent<Item_Count> ().SetValue (1);
		itemObjects [4].GetComponent<Item_Count> ().SetValue (1);
	}
}

public enum Item{
	Food = 0, 
	Water = 1,
	RadioComponent1 = 2,
	RadioComponent2 = 3,
	RadioComponent3 = 4
}
