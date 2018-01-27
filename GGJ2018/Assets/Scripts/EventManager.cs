using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

	static bool helpedLifeAlert = false;

	public static void HelpedLifeAlert(){
		Debug.Log ("You called Life Alert");
		helpedLifeAlert = true;
	}

	public static void NoEvent(){
		Debug.Log ("No Event Triggered.");
	}
}

public enum EventType{
	NoEvent = 0,
	LifeAlert = 1
}
