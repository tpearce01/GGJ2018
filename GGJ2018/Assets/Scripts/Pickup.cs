using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

	public PickupType type;

	void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.CompareTag("Player")){
			switch((int) type){
			case 0:
				InventoryManager.instance.ChangeItemCount(Item.Food, 1);
				break;
			case 1:
				InventoryManager.instance.ChangeItemCount(Item.Water, 1);
				break;
			case 2:
				ExhaustionBar.instance.ChangeValue(-.1f);
				break;
			case 3:
				InventoryManager.instance.SetItemCount (Item.RadioComponent1, 1);
				break;
			case 4:
				InventoryManager.instance.SetItemCount (Item.RadioComponent2, 1);
				break;
			case 5:
				InventoryManager.instance.SetItemCount (Item.RadioComponent3, 1);
				break;
			default:
				Debug.Log("Error: invalid pickup type");
				break;
			}
		}
		AudioManager.instance.PlaySound (Sound.HealUp);
		Destroy (this.gameObject);
	}
}

public enum PickupType{
	Food = 0,
	Water = 1,
	Energy = 2,
	Radio1 = 3,
	Radio2 = 4,
	Radio3 = 5
}
