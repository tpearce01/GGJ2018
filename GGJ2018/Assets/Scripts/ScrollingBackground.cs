using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* ScrollingBackground
 * 	
 * Use: Set Camera and background sprite
 * Automatically moves background as camera moves
 */ 
public class ScrollingBackground : MonoBehaviour {

	[SerializeField] GameObject camera;
	[SerializeField] Sprite background;
	[SerializeField] GameObject[] backgrounds;
	int currentBackground = 0;
	float startPos = 0;

	void Start(){
		Test ();
		backgrounds [1].transform.position = new Vector3 (background.bounds.max.x * 2, backgrounds [1].transform.position.y, backgrounds [1].transform.position.z);
	}

	void Update(){
		if (camera.transform.position.x >= startPos + background.bounds.max.x * 2 ) {
			if (currentBackground == 1) {
				backgrounds [1].transform.position += Vector3.right * background.bounds.max.x * 4;
				currentBackground = 0;
			} else {
				backgrounds [0].transform.position += Vector3.right * background.bounds.max.x * 4;
				currentBackground = 1;
			}
			startPos = camera.transform.position.x;
		}
	}

	void Test(){
		Debug.Log (background.bounds.max.x);
	}


}
