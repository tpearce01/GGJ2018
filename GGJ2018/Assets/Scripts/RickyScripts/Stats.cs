﻿using System;
using System.Collections;
using UnityEngine;

[Serializable] public class Stats {
    [SerializeField] private ExhaustionBar bar;
    [SerializeField] private float maxVal;
    [SerializeField] private float currentVal;

    public float CurrentVal {
        get { return currentVal; }

        set {
            this.currentVal = Mathf.Clamp(value, 0, MaxVal);
            bar.Value = currentVal;
        }
    }

    public float MaxVal
    {
        get { return maxVal; }

        set {
            this.maxVal = value;
            bar.MaxValue = maxVal;
        }
    }

    public void Initialize()
    {
        this.MaxVal = maxVal;
        this.CurrentVal = currentVal;
    }
}