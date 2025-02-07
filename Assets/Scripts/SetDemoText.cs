using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetDemoText : MonoBehaviour {
    public TMP_InputField inputField;

    [Multiline (100)]
    public string defaultInput;

    void Start () {
        inputField.text = defaultInput;
    }
}