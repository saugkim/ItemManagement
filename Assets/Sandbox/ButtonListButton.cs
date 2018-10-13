using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListButton : MonoBehaviour {

    [SerializeField]
    Text myText;
    [SerializeField]
    ButtonListControl buttonControl;
    string showText = null;

	// Use this for initialization
	void Start () {
        buttonControl = FindObjectOfType<ButtonListControl>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetText(string textString)
    {
        showText = textString;
        myText.text = textString;
    }

    public void OnClick()
    {
        buttonControl.ShowText(showText);
    }
}
