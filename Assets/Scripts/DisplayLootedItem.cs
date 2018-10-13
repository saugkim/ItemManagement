using UnityEngine;
using UnityEngine.UI;
using System.IO;
using LitJson;
using System.Collections.Generic;
using System.Linq;
using System;

public class DisplayLootedItem : MonoBehaviour
{
    ItemDatabase itemDatabase;

    List<Item> LootedItems = new List<Item>();
    //List<Item> C1ItemList = new List<Item>();
    //List<Item> C2ItemList = new List<Item>();
    //List<Item> sortedC1ItemList = new List<Item>();
    //List<Item> sortedC2ItemList = new List<Item>();

    List<Item> tempItem = new List<Item>();

    public GameObject LootedItemViewPanel;
    public GameObject ItemListViewPanel;
    public GameObject lootedItemDetailsPanel;

    public Text lootedItemDetailText;
    public Text lootedItemDetailItemId;
    public Image lootedItemImage;

    public Text giftboxNumber;
    int boxcounter;

    public void Start()
    {
        CreateITemList();
        itemDatabase = FindObjectOfType<ItemDatabase>();
        
    }

    public void ClosePanel()
    {
        lootedItemDetailsPanel.SetActive(false);
    }

    private static Character SelectCharacter(string character)
    {
        Character selectedCharacter;

        switch (character)
        {
            case "character1":
                selectedCharacter = Character.Character1;
                break;
            case "character2":
                selectedCharacter = Character.Character2;
                break;
            default:
                selectedCharacter = Character.Character1;
                break;
        }

        return selectedCharacter;
    }

    public void ShowItem(string character)
    {
        Character selectedCharacter = SelectCharacter(character);

        ShowLootedItem(character: selectedCharacter);
    }

    public void OpenBox(string character)
    {
        Character selectedCharacter = SelectCharacter(character);

        OpenTheBox(character: selectedCharacter);
    }

    public void ShowLootedItem(Character character)
    {
        ItemListViewPanel.SetActive(false);

        LootedItemViewPanel.SetActive(true);

        LootedItems.Clear();

       
        List<Item> characterItemList;

        if (character == Character.Character1)
        {     
            characterItemList = tempItem.Where<Item>(x => x.Character == Character.Character1).OrderBy(x => x.ItemId).ToList();
            //characterItemList = sortedC1ItemList;
        }
        else if(character == Character.Character2)
        {
            characterItemList = tempItem.Where<Item>(x=> x.Character == Character.Character2).OrderBy(x => x.ItemId).ToList();
           // characterItemList = sortedC2ItemList;
        }
        else
        {
            characterItemList = null;
        }


        for (int i = 0; i < characterItemList.Count; i++)
        {
            if (characterItemList[i].ItemImage == "giftbox")
            {
                LootedItems.Add(characterItemList[i]);
            }
        }
        
        boxcounter = LootedItems.Count;
    }

    private void CreateITemList()
    {
        ItemContainer itemContainer = new ItemContainer();
        string jsondata = File.ReadAllText(Application.dataPath + "/StreamingAssets/ItemDatabase.json");
        itemContainer = JsonMapper.ToObject<ItemContainer>(jsondata);


        for (int i = 0; i < itemContainer.WeaponL.Count; i++)
        {
            tempItem.Add(itemContainer.WeaponL[i]);

        }
        for (int i = 0; i < itemContainer.AmuletL.Count; i++)
        {
            tempItem.Add(itemContainer.AmuletL[i]);

        }
        for (int i = 0; i < itemContainer.ArmorL.Count; i++)
        {
            tempItem.Add(itemContainer.ArmorL[i]);

        }
        for (int i = 0; i < itemContainer.Trinket1L.Count; i++)
        {
            tempItem.Add(itemContainer.Trinket1L[i]);

        }
        for (int i = 0; i < itemContainer.Trinket2L.Count; i++)
        {
            tempItem.Add(itemContainer.Trinket2L[i]);

        }
    }

    private void Update()
    {
        giftboxNumber.text = boxcounter.ToString();

        if(boxcounter <= 0)
        {
            giftboxNumber.text = "No giftbox left";
            lootedItemDetailsPanel.SetActive(false);

        }
    }

    public void OpenTheBox(Character character)
    {
        boxcounter--;

        ItemContainer itemContainer = new ItemContainer();
        string jsondata = File.ReadAllText(Application.dataPath + "/StreamingAssets/ItemDatabase.json");
        itemContainer = JsonMapper.ToObject<ItemContainer>(jsondata);

        lootedItemDetailsPanel.SetActive(true);
        lootedItemDetailText.text = LootedItems[0].ToString();
        lootedItemDetailItemId.text = LootedItems[0].ItemId.ToString();

        string spriteName = LootedItems[0].ItemImageName;

        Debug.Log(spriteName);
        lootedItemImage.sprite = Resources.Load<Sprite>(spriteName);

        List<Item> tempWeapon;
        List<Item> tempArmor;
        List<Item> tempAmulet;
        List<Item> tempTrinket1;
        List<Item> tempTrinket2;

        if (character == Character.Character1)
        {
            tempWeapon = itemDatabase.WeaponList;
            tempArmor = itemDatabase.ArmorList;
            tempAmulet = itemDatabase.AmuletList;
            tempTrinket1 = itemDatabase.Trinket1List;
            tempTrinket2 = itemDatabase.Trinket2List;
        }
        else if (character == Character.Character2)
        {
            tempWeapon = itemDatabase.C2WeaponList;
            tempArmor = itemDatabase.C2ArmorList;
            tempAmulet = itemDatabase.C2AmuletList;
            tempTrinket1 = itemDatabase.C2Trinket1List;
            tempTrinket2 = itemDatabase.C2Trinket2List;
        }
        else
        {
            tempWeapon = null;
            tempArmor = null;
            tempAmulet = null;
            tempTrinket1 = null;
            tempTrinket2 = null;
        }

        for (int i = 0; i < tempItem.Count; i++)
        {
            if (LootedItems[0].ItemId == tempItem[i].ItemId)
            {
                tempItem[i].ItemImage = tempItem[i].ItemImageName;

                switch (tempItem[i].ItemType)
                {
                    case ItemType.WEAPON:
                        tempWeapon.Add(tempItem[i]);
                        for (int j = 0; j < itemContainer.WeaponL.Count; j++)
                        {
                            if (tempItem[i].ItemId == itemContainer.WeaponL[j].ItemId)
                            {
                                itemContainer.WeaponL[j].ItemImage = itemContainer.WeaponL[j].ItemImageName;
                                break;
                            }
                        }
                        break;
                    case ItemType.ARMOR:
                        for (int j = 0; j < itemContainer.ArmorL.Count; j++)
                        {
                            if (tempItem[i].ItemId == itemContainer.ArmorL[j].ItemId)
                            {
                                itemContainer.ArmorL[j].ItemImage = itemContainer.ArmorL[j].ItemImageName;
                                break;
                            }
                        }
                        tempArmor.Add(tempItem[i]);
                        break;
                    case ItemType.Amulet:
                        for (int j = 0; j < itemContainer.AmuletL.Count; j++)
                        {
                            if (tempItem[i].ItemId == itemContainer.AmuletL[j].ItemId)
                            {
                                itemContainer.AmuletL[j].ItemImage = itemContainer.AmuletL[j].ItemImageName;
                                break;
                            }
                        }
                        tempAmulet.Add(tempItem[i]);
                        break;
                    case ItemType.TRINKET1:
                        for (int j = 0; j < itemContainer.Trinket1L.Count; j++)
                        {
                            if (tempItem[i].ItemId == itemContainer.Trinket1L[j].ItemId)
                            {
                                itemContainer.Trinket1L[j].ItemImage = itemContainer.Trinket1L[j].ItemImageName;
                                break;
                            }
                        }
                        tempTrinket1.Add(tempItem[i]);
                        break;
                    case ItemType.TRINKET2:
                        for (int j = 0; j < itemContainer.Trinket2L.Count; j++)
                        {
                            if (tempItem[i].ItemId == itemContainer.Trinket2L[j].ItemId)
                            {
                                itemContainer.Trinket2L[j].ItemImage = itemContainer.Trinket2L[j].ItemImageName;
                                break;
                            }
                        }
                        tempTrinket2.Add(tempItem[i]);
                        break;
                    default:
                        break;
                }

                string json = JsonMapper.ToJson(itemContainer);
                File.WriteAllText(Application.streamingAssetsPath + "/ItemDatabase.json", json);
            }
        }

        LootedItems.Remove(LootedItems[0]);
    }    
}