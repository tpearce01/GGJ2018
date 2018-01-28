using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour {

	public Text toFade;

	void Start(){
		FadeInStart (3);
	}

	public void FadeInStart(float duration){
		toFade.color = new Color (toFade.color.r, toFade.color.g, toFade.color.b, 0);
		StartCoroutine (FadeIn(duration));
	}

	public void FadeOutStart(float duration){
		toFade.color = new Color (toFade.color.r, toFade.color.g, toFade.color.b, 1);
		StartCoroutine (FadeOut(duration));
	}

	IEnumerator FadeIn(float duration){
		for (int i = 0; i < 50; i++) {
			toFade.color = new Color (toFade.color.r, toFade.color.g, toFade.color.b, toFade.color.a + 0.02f);
			yield return new WaitForSeconds (duration / 50);
		}
		yield return new WaitForSeconds (3);
		FadeOutStart (3);
	}

	IEnumerator FadeOut(float duration){
		for (int i = 0; i < 50; i++) {
			toFade.color = new Color (toFade.color.r, toFade.color.g, toFade.color.b, toFade.color.a - 0.02f);
			yield return new WaitForSeconds (duration / 50);
		}
	}
}
