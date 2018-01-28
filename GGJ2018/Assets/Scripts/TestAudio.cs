using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAudio : MonoBehaviour {

	void Update(){
		if(Input.GetKeyDown(KeyCode.Q)){
			AudioManager.instance.PlaySound (Sound.Test);
		}
		if (Input.GetKeyDown (KeyCode.W)) {
			AudioManager.instance.PlaySoundLoop (Sound.Test);
		}
		if (Input.GetKeyDown (KeyCode.E)) {
			AudioManager.instance.EndSoundAbrupt (Sound.Test);
		}
		if (Input.GetKeyDown (KeyCode.R)) {
			AudioManager.instance.EndAllSoundsAbrupt ();
		}
		if (Input.GetKeyDown (KeyCode.T)) {
			AudioManager.instance.EndSoundFade (Sound.Test, 5);
		}
	}
}
