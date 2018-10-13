using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GoldCount : MonoBehaviour {

    public static GoldCount goldCount;
    public static int currentGold;


    public Text goldText;


	// Use this for initialization
	void Start () {
        currentGold = 10;
	}
	
	// Update is called once per frame
	void Update () {
        goldText.text = "GOLD: " + currentGold;
	}
}
