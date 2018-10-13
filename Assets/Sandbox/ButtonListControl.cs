using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonListControl : MonoBehaviour {

    [SerializeField]
    GameObject buttonTemplate;

    public GameObject parentObject;

 //   List<int> intList;
    // Use this for initialization


    void Start ()
    {
      //  intList = new List<int>();

        for (int i = 0; i < 20; i++)
        {
            GameObject buttonObj = Instantiate(buttonTemplate) as GameObject;
            
            buttonObj.GetComponent<ButtonListButton>().SetText("Button " + i);

            buttonObj.transform.SetParent(parentObject.transform, false);

        }
	}

	public void ShowText(string message)
    {
        Debug.Log(message);
    }
	// Update is called once per frame
	void Update () {
		
	}

    
}
