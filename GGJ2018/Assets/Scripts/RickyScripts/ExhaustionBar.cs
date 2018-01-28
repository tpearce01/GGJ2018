using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExhaustionBar : MonoBehaviour {
	public static ExhaustionBar instance;
    [SerializeField] private float lerpSpeed;
    [SerializeField] private float exhaustionSpeed;
    [SerializeField] private Image content;
    [SerializeField] private Stats myExhaustion;
	[SerializeField] float tickDistance;
	private static float fillAmount;
    private float startPos = 0;


    public float MaxValue {
        get; set;
    }

    public float Value
    {
        set {
            fillAmount = Map(value, 0, MaxValue, 0, 1);
        }
    }
    // Use this for initialization
    void Start () {
        startPos = CameraMovement.xPosition();
        Value = 0;
    }

    private void Awake() {
		instance = this;
        myExhaustion.Initialize();
    }

    // Update is called once per frame
    void FixedUpdate () {
		AddExhaustion ();
    }

    private void HandleBar() {
        if (fillAmount != content.fillAmount) {
            content.fillAmount = Mathf.Lerp(content.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
        }
    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax) {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }

	public void ChangeValue(float value){
		myExhaustion.CurrentVal += value;
	}

	void AddExhaustion(){
		if (CameraMovement.xPosition () - startPos > tickDistance) {
			startPos = CameraMovement.xPosition ();
			myExhaustion.CurrentVal += exhaustionSpeed;
		}
		HandleBar ();
	}
}
