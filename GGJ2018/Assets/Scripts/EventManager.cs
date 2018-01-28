using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

	static bool[] completedEvents = new bool[3];	//List of event status flags. False means not encountered or failed, True means successfully completed.

	//TestNPC2
	public static void HelpedStarvingGuy(){
		Debug.Log ("You shared your rations");
		CompletedEvent (EventType.StarvingGuy);
		//Inventory.GiveWater();
		//Inventory.GiveFood();
		AudioManager.instance.PlaySound(Sound.HealUp);
	}

	//TestNPC
	public static void HelpedLifeAlert(){
		Debug.Log ("You called Life Alert");
		CompletedEvent (EventType.LifeAlert);
		//Inventory.UseWater();
		AudioManager.instance.PlaySound(Sound.HealUp);
	}

	//Default or no event
	public static void NoEvent(){
		Debug.Log ("No Event Triggered.");
	}

	/// <summary>
	/// Check individual event flag
	/// </summary>
	/// <param name="et">Et.</param>
	public static bool CheckEventStatus(EventType et){
		return completedEvents [(int)et];
	}

	/// <summary>
	/// Get list of all event flags
	/// </summary>
	/// <returns>The all event status.</returns>
	public static bool[] GetAllEventStatus(){
		return completedEvents;
	}

	/// <summary>
	/// Set event flag to true.
	/// </summary>
	/// <param name="et">Et.</param>
	public static void CompletedEvent(EventType et){
		completedEvents[(int)et] = true;
	}
		
}

public enum EventType{
	NoEvent = 0,
	LifeAlert = 1,
	StarvingGuy = 2
}
