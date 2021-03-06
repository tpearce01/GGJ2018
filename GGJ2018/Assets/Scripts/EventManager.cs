﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

	static bool[] completedEvents = new bool[18];	//List of event status flags. False means not encountered or failed, True means successfully completed.
													//Size should be euqal to number of events/NPCs in the game

	//TestNPC2
	public static void HelpedStarvingGuy(){
		Debug.Log ("You shared your rations");
		CompletedEvent (EventType.StarvingGuy);
		AudioManager.instance.PlaySound(Sound.HealUp);
	}

	//TestNPC
	public static void HelpedLifeAlert(){
		Debug.Log ("You called Life Alert");
		CompletedEvent (EventType.LifeAlert);
		AudioManager.instance.PlaySound(Sound.HealUp);
	}

	//Default or no event
	public static void NoEvent(){
		Debug.Log ("No Event Triggered.");
	}

	public static void HelpedNPC(int NPCNumber){
		completedEvents[NPCNumber] = true;
	}

	/// <summary>
	/// Check individual event flag
	/// </summary>
	/// <param name="et">Et.</param>
	public static bool CheckEventStatus(EventType et){
		return completedEvents [(int)et];
	}
	public static bool CheckEventStatus(int NPCNumber){
		return completedEvents [NPCNumber];
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

	public static void SubtractOneWater(int NPCNumber){
		if (InventoryManager.instance.IsValidOperation (Item.Water, 1)) {
			InventoryManager.instance.ChangeItemCount (Item.Water, -1);
			HelpedNPC (NPCNumber);
		}
	}

	public static void SubtractTwoWater(int NPCNumber){
		if (InventoryManager.instance.IsValidOperation (Item.Water, 2)) {
			SubtractOneWater (NPCNumber);
			SubtractOneWater (NPCNumber);
			HelpedNPC (NPCNumber);
		}
	}

	public static void AddOneWater(){
		InventoryManager.instance.ChangeItemCount (Item.Water, 1);
	}

	public static void AddOneFood(){
		InventoryManager.instance.ChangeItemCount (Item.Food, 1);
	}

	public static void SubtractOneFood(int NPCNumber){
		if (InventoryManager.instance.IsValidOperation (Item.Food, 1)) {
			InventoryManager.instance.ChangeItemCount (Item.Food, -1);
			HelpedNPC (NPCNumber);
		}
	}

	public static void SubtractThreeFood(int NPCNumber){
		if (InventoryManager.instance.IsValidOperation (Item.Food, 3)) {
			SubtractOneFood (NPCNumber);
			SubtractOneFood (NPCNumber);
			SubtractOneFood (NPCNumber);
			HelpedNPC (NPCNumber);
		}
	}

	public static void IncreaseExhaustion10(int NPCNumber){
		ExhaustionBar.instance.ChangeValue (.1f);
	}

	public static void IncreaseExhaustion20(int NPCNumber){
		IncreaseExhaustion10 (NPCNumber);
		IncreaseExhaustion10 (NPCNumber);
	}

	public static void IncreaseExhaustion30(int NPCNumber){
		IncreaseExhaustion10 (NPCNumber);
		IncreaseExhaustion10 (NPCNumber);
		IncreaseExhaustion10 (NPCNumber);
	}

	public static void IncreaseExhaustion50(int NPCNumber){
		IncreaseExhaustion10 (NPCNumber);
		IncreaseExhaustion10 (NPCNumber);
		IncreaseExhaustion10 (NPCNumber);
		IncreaseExhaustion10 (NPCNumber);
		IncreaseExhaustion10 (NPCNumber);
	}

	public static void ReduceExhaustion10(){
		ExhaustionBar.instance.ChangeValue (-.1f);
	}

	public static void SubtractOneOfEach(){
		if (InventoryManager.instance.IsValidOperation (Item.Water, 1) && InventoryManager.instance.IsValidOperation (Item.Food, 1)) {
			InventoryManager.instance.ChangeItemCount (Item.Food, -1);
			InventoryManager.instance.ChangeItemCount (Item.Water, -1);
			ExhaustionBar.instance.ChangeValue (.1f);
		}
	}

	public static void Thief(){
		InventoryManager.instance.SetItemCount (Item.Food, 0);
		InventoryManager.instance.SetItemCount (Item.Water, 0);
	}
		
}

public enum EventType{
	NoEvent = 0,
	LifeAlert = 1,
	StarvingGuy = 2,
	SubOneFood = 3,
	SubThreeFood = 4,
	SubOneWater = 5,
	SubTwoWater = 6,
	Exhaust10 = 7,
	Exhaust20 = 8,
	Exhaust30 = 9,
	Exhaust50 = 10,
	SubOneOfEach = 11,
	Thief = 12
}
