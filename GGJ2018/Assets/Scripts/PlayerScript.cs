using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    int exhaustion;
    bool moving;

    Rigidbody2D rigidBody;
    CircleCollider2D collider;
    

	// Use this for initialization
	void Start () {
        exhaustion = 100;
        rigidBody = GetComponent<Rigidbody2D>();
        collider = GetComponent<CircleCollider2D>();
        
	}
	
	// Update is called once per frame
	void Update () {
		if (moving)
        {
            // exhaustion meter stuff
        }
         
	}
}
