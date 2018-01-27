using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	[SerializeField] float moveSpeed;
	[SerializeField] Rigidbody2D rgbd;

	void Update(){
		if (Input.GetKey (KeyCode.A)) {
			Move (Direction.Left);
		}
		if (Input.GetKey (KeyCode.D)) {
			Move (Direction.Right);
		}
	}

	void Move(Direction d){
		rgbd.MovePosition ((Vector2)gameObject.transform.position + (int)d * Vector2.right * moveSpeed * Time.deltaTime);
	}
}

public enum Direction{
	Left = -1,
	Right = 1
}
