using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour {

	public void UseItemEvent(int item){
		InventoryManager.instance.ChangeItemCount(item, -1);
		ExhaustionBar.instance.ChangeValue (-.1f);

	}
}
