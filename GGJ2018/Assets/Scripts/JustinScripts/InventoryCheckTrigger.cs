using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCheckTrigger : MonoBehaviour {

    [SerializeField] private GameObject player;
    private Item_Count inventoryTotal;
    private BoxCollider2D collider;
    

	// Use this for initialization
	void Start () {
        collider = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (collider.IsTouching(player.GetComponent<BoxCollider2D>()))
        {
            // Sets food and water to zero for fire event
            //InventoryManager.instance.SetItemCount(Item.Food, 0);
            //InventoryManager.instance.SetItemCount(Item.Water, 0);
            Debug.Log("trigger hit");
        }
		
	}
}
