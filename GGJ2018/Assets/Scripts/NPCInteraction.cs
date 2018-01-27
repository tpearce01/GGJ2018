using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour {
	[SerializeField] GameObject inRangeUI;
	[SerializeField] GameObject dialogue;

	bool hasInteracted = false;

	void Update(){
		if (inRangeUI.activeSelf && Input.GetKeyDown (KeyCode.E)) {
			dialogue.SetActive(true);
			inRangeUI.SetActive (false);
		}
	}

	//Display 'E' when in range
	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player") && !hasInteracted){
			inRangeUI.SetActive(true);
		}
	}

	//Hide 'e' when in range
	void OnTriggerExit2D(Collider2D other){
		if(other.CompareTag("Player")){
			inRangeUI.SetActive(false);
		}
	}

	//Hide dialogue
	public void EndDialogue(){
		dialogue.SetActive (false);
		hasInteracted = true;
	}
}
