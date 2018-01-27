﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public void LoadScene(string sceneToLoad){
		SceneManager.LoadScene (sceneToLoad);
	}

	public void Quit(){
		Application.Quit ();
	}
}