using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScriptN : MonoBehaviour {

    [SerializeField]
    Rigidbody2D rigidBody;
    [SerializeField]
    Collider2D collider;
    [SerializeField]
    InputListener inputListener;

    int exhaustion = 0;

    [SerializeField]
    bool moving = false;
    int direction = 0;
    int moveSpeed = 1;

    // Use this for initialization
    void Start () {
        // subscribe to input listener
        inputListener.keyDown += new InputListener.Listener(onKeyDown);
        inputListener.keyUp += new InputListener.Listener(onKeyUp);
        rigidBody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
	}

    private void onKeyUp(InputListener listener, EventArgs e)
    {
        Debug.Log("Stopped pressing " + inputListener.key);
        if (inputListener.key == KeyCode.A || inputListener.key == KeyCode.D)
        {
            StopMoving();
        }
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
		if (moving)
        {
            rigidBody.velocity = new Vector2((float)moveSpeed * direction, 0);
        }
        else
        {
            rigidBody.velocity = Vector2.zero;
        }
	}

    void MoveRight()
    {
        Debug.Log("Moving Right.");
        direction = 1;
        moving = true;
    }

    void MoveLeft()
    {
        Debug.Log("Moving Left.");
        direction = -1;
        moving = true;
    }
    void StopMoving()
    {
        Debug.Log("Stop Moving.");
        moving = false;
    }

}
