using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScriptN : MonoBehaviour {

    [SerializeField]
    Rigidbody2D rigidBody;
    Collider2D collider;
    InputListener inputListener;

    int exhaustion = 0;
    bool moving = false;

    // Use this for initialization
    void Start () {
        // subscribe to input listener
        inputListener.keyDown += new InputListener.Listener(onKeyDown);
        rigidBody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
	}

    private void onKeyDown(InputListener listener, EventArgs e)
    {
        Debug.Log("Input " + inputListener.key + " received.");
        if (inputListener.key == KeyCode.D)
        {
            // move right
            MoveRight();
        }
        if (inputListener.key == KeyCode.A)
        {
            // move left
            MoveLeft();
        }
        if (inputListener.key == KeyCode.E)
        {
            // stuff
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    void MoveRight()
    {

    }

    void MoveLeft()
    {

    }


}
