using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	[SerializeField] float moveSpeed;
	[SerializeField] Rigidbody2D rgbd;
	[SerializeField] Animator anim;
	bool isMoving;

	void FixedUpdate(){
		isMoving = false;
		if (Input.GetKey (KeyCode.A)) {
			Move (Direction.Left);
			gameObject.transform.rotation = new Quaternion (0,0,0,0);
			isMoving = !isMoving;
		}
		if (Input.GetKey (KeyCode.D)) {
			Move (Direction.Right);
			gameObject.transform.rotation = new Quaternion (0,180,0,0);
			isMoving = !isMoving;
		}

		if (isMoving) {
			anim.SetBool ("isMoving", true);
		} else {
			anim.SetBool ("isMoving", false);
		}
	}

	void Move(Direction d){
		rgbd.MovePosition ((Vector2)gameObject.transform.position + (int)d * Vector2.right * moveSpeed * Time.deltaTime);
		//gameObject.transform.position = Vector2.Lerp (gameObject.transform.position, (Vector2)gameObject.transform.position + (int)d * Vector2.right * moveSpeed * Time.deltaTime, 0.5f);
	}
}

public enum Direction{
	Left = -1,
	Right = 1
}
