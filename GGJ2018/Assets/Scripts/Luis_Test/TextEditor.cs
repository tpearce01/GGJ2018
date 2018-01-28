using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextEditor : MonoBehaviour {

    [SerializeField] private TMP_Text ArrowText;  //The text.
    [SerializeField] private string path; //Name of Path

    void Update()
    {
        ArrowText.text = path;
    }
}
