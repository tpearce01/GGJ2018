using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCDialogue : MonoBehaviour {

	bool eventTriggered = false;

	[SerializeField] Text dialogueText;
	[SerializeField] Text option1Button;
	[SerializeField] Text option2Button;

	[SerializeField] string setDialogue;
	[SerializeField] string setOpt1;
	[SerializeField] string setOpt2;

	[SerializeField] string setSavedDialogue;
	[SerializeField] string setSavedOpt1;
	[SerializeField] string setSavedOpt2;

	[SerializeField] NPCInteraction npci;	//This script will always be attached to an object with NPCInteraction

	[SerializeField] EventType event1;
	[SerializeField] EventType event2;

	void Start(){
		dialogueText.text = setDialogue;
		option1Button.text = setOpt1;
		option2Button.text = setOpt2;
	}

	public void CloseDialogue(){
		npci.EndDialogue ();
	}

	public void TriggerEvent1(){
		TriggerEvent (event1);
	}

	public void TriggerEvent2(){
		TriggerEvent (event2);
	}

	void TriggerEvent(EventType e){
		switch ((int)e) {
		case 0:
			EventManager.NoEvent ();
			break;
		case 1:
			EventManager.HelpedLifeAlert ();
			break;
		case 2:
			EventManager.HelpedStarvingGuy ();
			break;
		case 3:
			EventManager.SubtractOneFood ();
			break;
		case 4:
			EventManager.SubtractThreeFood ();
			break;
		case 5:
			EventManager.SubtractOneWater ();
			break;
		case 6:
			EventManager.SubtractTwoWater ();
			break;
		case 7:
			EventManager.IncreaseExhaustion10 ();
			break;
		case 8:
			EventManager.IncreaseExhaustion20 ();
			break;
		case 9:
			EventManager.IncreaseExhaustion30 ();
			break;
		case 10:
			EventManager.IncreaseExhaustion50 ();
			break;
		case 11:
			EventManager.SubtractOneOfEach ();
			break;
		case 12:
			EventManager.Thief ();
			break;
		default:
			Debug.LogError ("No valid event triggered.");
			break;
		}

	}

	void OnEnable(){
		if (eventTriggered) {
			dialogueText.text = setSavedDialogue;
			option1Button.text = setSavedOpt1;
			option2Button.text = setSavedOpt2;
			event1 = EventType.NoEvent;
			event2 = EventType.NoEvent;
		} else {
			eventTriggered = true;
		}
	}
}
