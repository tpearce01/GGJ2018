﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExhaustionBar : MonoBehaviour {

    [SerializeField] private float lerpSpeed;
    [SerializeField] private float exhaustionSpeed;
    [SerializeField] private Image content;
    [SerializeField] private Stats myExhaustion;
    private float fillAmount;
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
        myExhaustion.Initialize();
    }

    // Update is called once per frame
    void Update () {
		HandleBar();
        if (CameraMovement.xPosition() > startPos) {
            myExhaustion.CurrentVal += exhaustionSpeed;
            startPos = CameraMovement.xPosition();
        }
    }

    private void HandleBar() {
        if (fillAmount != content.fillAmount) {
            content.fillAmount = Mathf.Lerp(content.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
        }
    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax) {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
