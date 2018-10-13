using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTest : MonoBehaviour {


    public Button myButton;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))

        {
            ChangeButtonColor();
        }
	}

    public void ChangeButtonColor()
    {
        myButton.GetComponent<Image>().color = Color.blue;
    }



}
