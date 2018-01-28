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

	public static void SubtractOneWater(){
		InventoryManager.instance.ChangeItemCount (Item.Water, -1);
	}

	public static void SubtractTwoWater(){
		SubtractOneWater ();
		SubtractOneWater ();
	}

	public static void AddOneWater(){
		InventoryManager.instance.ChangeItemCount (Item.Water, 1);
	}

	public static void AddOneFood(){
		InventoryManager.instance.ChangeItemCount (Item.Food, 1);
	}

	public static void SubtractOneFood(){
		InventoryManager.instance.ChangeItemCount (Item.Food, -1);
	}

	public static void SubtractThreeFood(){
		SubtractOneFood ();
		SubtractOneFood ();
		SubtractOneFood ();
	}

	public static void IncreaseExhaustion10(){
		ExhaustionBar.ChangeValue (.1f);
	}

	public static void IncreaseExhaustion20(){
		IncreaseExhaustion10 ();
		IncreaseExhaustion10 ();
	}

	public static void IncreaseExhaustion30(){
		IncreaseExhaustion10 ();
		IncreaseExhaustion10 ();
		IncreaseExhaustion10 ();
	}

	public static void IncreaseExhaustion50(){
		IncreaseExhaustion10 ();
		IncreaseExhaustion10 ();
		IncreaseExhaustion10 ();
		IncreaseExhaustion10 ();
		IncreaseExhaustion10 ();
	}

	public static void ReduceExhaustion10(){
		ExhaustionBar.ChangeValue (-.1f);
	}

	public static void SubtractOneOfEach(){
		InventoryManager.instance.ChangeItemCount (Item.Food, -1);
		InventoryManager.instance.ChangeItemCount (Item.Water, -1);
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

/*Thief takes all supplies
 * Food: 5 People need Food [ 1 person: 3 food ]
Water: 6 People need water [ 1 person: 2 water ]
Stamina: 5 people use your Stamina [ 1: 10% stamina, 2: 20% stamina, 1: 30% stamina, 1: 50% stamina ]
All: 1 person.
Thief: 1 person. [ takes all water, all food ]
*/
