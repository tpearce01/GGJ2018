﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public static GameObject camera;
	[SerializeField] GameObject player;

	void Start(){
		camera = this.gameObject;
	}

	void Update(){
		Move ();
	}

	void Move(){
		if (gameObject.transform.position.x < player.transform.position.x) {
			//Move towards the player
			gameObject.transform.position = new Vector3(player.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
		} else {
			//Don't move
		}
	}
}
