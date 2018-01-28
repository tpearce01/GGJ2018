using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	[SerializeField] float moveSpeed;
	[SerializeField] Rigidbody2D rgbd;
    [SerializeField] ExhaustionBar exhaustionBar;
	[SerializeField] Animator anim;
	bool isMoving;
    bool isExhausted;

	void FixedUpdate(){
		isMoving = false;
        isExhausted = false;
        
        if (exhaustionBar.maxExhaustion()) {
            isExhausted = !isExhausted;
            moveSpeed = 0;
            anim.SetBool ("isExhausted", true);
        } else {
            anim.SetBool("isExhausted", false);
        }

		if (Input.GetKey (KeyCode.A)) {// && !isExhausted) {
			Move (Direction.Left);
			gameObject.transform.rotation = new Quaternion (0,0,0,0);
			isMoving = !isMoving;
		}
		if (Input.GetKey (KeyCode.D)) { //&& !isExhausted) {
			Move (Direction.Right);
			gameObject.transform.rotation = new Quaternion (0,180,0,0);
			isMoving = !isMoving;
		}

        if (exhaustionBar.overHalfExhaustion())
        {
            anim.SetBool("isTired", true);
        } else {
            anim.SetBool("isTired", false);
        }

        if (isMoving) {
			anim.SetBool ("isMoving", true);
			if (!AudioManager.instance.IsPlaying (Sound.Footsteps)) {
				AudioManager.instance.PlaySoundLoop (Sound.Footsteps);
			}
		} else {
			anim.SetBool ("isMoving", false);
			if (AudioManager.instance.IsPlaying (Sound.Footsteps)) {
				AudioManager.instance.EndSoundAbrupt (Sound.Footsteps);
			}
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
