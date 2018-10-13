using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonScript : MonoBehaviour {

    ItemDatabase itemDatabase;
    public GameObject itemDatabaseRef;
    DisplayItemList displayItemList;
  //  DisplayLootedItem displayLootedItemList;

    private void Start()
    {
        //  displayItemList = FindObjectOfType<DisplayItemList>();
        //     displayLootedItemList = FindObjectOfType<DisplayLootedItem>();
        //  itemDatabase = FindObjectOfType<ItemDatabase>();
        itemDatabaseRef = GameObject.FindGameObjectWithTag("Canvas");
        itemDatabase = itemDatabaseRef.GetComponent<ItemDatabase>();
    }

    public void CallSelectedItemShowDetails()
    {
        itemDatabase.ShowItemDetails(GetComponent<Button>());
    }

   
   
}
