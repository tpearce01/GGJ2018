using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScriptN : MonoBehaviour {

    [SerializeField]
    InputListener inputListener;


	// Use this for initialization
	void Start () {
        // subscribe to input listener
        inputListener.keyDown += new InputListener.Listener(onKeyDown);
	}

    private void onKeyDown(InputListener listener, EventArgs e)
    {
        Debug.Log("Input " + inputListener.key + " received.");
        if (inputListener.key == KeyCode.D)
        {
            // move right
        }
        if (inputListener.key == KeyCode.A)
        {
            // move left
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
