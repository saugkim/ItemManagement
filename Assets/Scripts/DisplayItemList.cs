using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayItemList : MonoBehaviour {

    public GameObject LootedItemViewPanel;
    public GameObject ItemListViewPanel;

    public Button ItemListButton;
    public Transform ItemListParent;
    public static List<Button> ItemListButtonList = new List<Button>();

    public GameObject itemDetailPanel;
    //public Button itemDetailPanelEquipButton;
    //public Button itemDetailPanelSellButton;
    public Text itemDetailText;
    public Text itemDetailTextItemId;
    public Image itemDetailImage;


  
    public void ClosePanel()
    {
        itemDetailPanel.SetActive(false);
    }


    //public void ShowItems(string itemListName)
    //{
    //    List<Item> itemList;

    //    switch (itemListName)
    //    {
    //        case "weapon":
    //            itemList = ItemDatabase.sortedWeaponList;
    //            break;
    //        case "amulet":
    //            itemList = ItemDatabase.sortedAmuletList;
    //            break;
    //        case "armor":
    //            itemList = ItemDatabase.sortedArmorList;
    //            break;
    //        case "trinket1":
    //            itemList = ItemDatabase.sortedTrinket1List;
    //            break;
    //        case "trinket2":
    //            itemList = ItemDatabase.sortedTrinket2List;
    //            break;
    //        default:
    //            itemList = null;
    //            break;
    //    }

    //    ShowItemList(itemList);
    //}

    //public void ShowItemList(List<Item> itemList)
    //{
    //    LootedItemViewPanel.SetActive(false);
    //    ItemListViewPanel.SetActive(true);

    //    for (int i = 0; i < ItemListButtonList.Count; i++)
    //    {
    //        Destroy(ItemListButtonList[i].gameObject);
    //    }
    //    ItemListButtonList.Clear();
       

    //    for (int i = 0; i < itemList.Count; i++)
    //    {
    //        Button ButtonObj = Instantiate(ItemListButton);
    //        ButtonObj.transform.SetParent(ItemListParent, false);
    //        ItemListButtonList.Add(ButtonObj);

    //    }

    //    for (int i = 0; i < ItemListButtonList.Count; i++)
    //    {
    //        if(itemList[i].Rarity == ItemRarity.Normal)
    //            ItemListButtonList[i].transform.GetComponent<Image>().color = Color.white;
    //        if(itemList[i].Rarity == ItemRarity.Magic)
    //            ItemListButtonList[i].transform.GetComponent<Image>().color = Color.blue;
    //        if (itemList[i].Rarity == ItemRarity.Rare)
    //            ItemListButtonList[i].transform.GetComponent<Image>().color = Color.yellow;
    //        if (itemList[i].Rarity == ItemRarity.Ancient)
    //            ItemListButtonList[i].transform.GetComponent<Image>().color = new Color(143, 0, 254, 1);
    //        if (itemList[i].Rarity == ItemRarity.Legendary)
    //            ItemListButtonList[i].transform.GetComponent<Image>().color = new Color(218, 165, 32);


    //        string spriteName = itemList[i].ItemImage;
    //        ItemListButtonList[i].transform.Find("ItemImage").GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>(spriteName);
    //        ItemListButtonList[i].transform.Find("ItemName").GetComponent<Text>().text = itemList[i].ItemName;
    //        ItemListButtonList[i].transform.Find("ItemId").GetComponent<Text>().text = itemList[i].ItemId.ToString();                //GetComponentInChildren(1)<Text>().

    //    }
    //}



    //public void ShowItemDetails(Button btn)
    //{
    //    for (int i = 0; i < ItemDatabase.itemDB.Count; i++)
    //    {
    //        if (btn.transform.Find("ItemId").GetComponent<Text>().text == ItemDatabase.itemDB[i].ItemId.ToString())
    //        // if (btn.GetComponentInChildren<Text>().text == itemDB[i].ItemName)
    //        {
    //            itemDetailPanel.SetActive(true);
    //            itemDetailText.text = ItemDatabase.itemDB[i].ToString();
    //            Debug.Log(ItemDatabase.itemDB[i].ToString());
    //            itemDetailTextItemId.text = ItemDatabase.itemDB[i].ItemId.ToString();
    //            string spriteName = ItemDatabase.itemDB[i].ItemImage;

    //            itemDetailImage.sprite = Resources.Load<Sprite>(spriteName);
    //        }
    //    }
    //}

  
}
