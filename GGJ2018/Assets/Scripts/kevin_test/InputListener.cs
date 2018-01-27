﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputListener : MonoBehaviour {

    // setting up the event handler
    public KeyCode key;
    public EventArgs e = null;
    public delegate void Listener(InputListener listener, EventArgs e);
    public event Listener keyDown;
    public event Listener mouseDown;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnGUI()
    {
        Event ev = Event.current;
        if (ev.isKey && ev.type == UnityEngine.EventType.KeyDown)
        {
            key = ev.keyCode;
            if (keyDown != null)
            {
                keyDown(this, e);
            }
            Debug.Log("The " + key + " has been pressed.");
        }
        if (ev.isMouse && ev.type == UnityEngine.EventType.MouseDown)
        {
            if (mouseDown != null)
            {
                mouseDown(this, e);
            }
            Debug.Log("The " + ev.button + " has been pressed.");
        }
    }
}
