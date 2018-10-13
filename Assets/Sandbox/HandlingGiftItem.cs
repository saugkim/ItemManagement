using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using System.IO;

public class HandlingGiftItem : MonoBehaviour {


    public GameObject BtnUIPrefab;
    public GameObject parentCanvas;

    List<GameObject> Buttons = new List<GameObject>();

    List<Item> LootedItems = new List<Item>();


    private void Start()
    {
        // parentCanvas = GameObject.FindObjectOfType(Canvas)

       

        //for (int i = 0; i < ItemDatabase.itemDB.Count; i++)
        //{
        //    Debug.Log(ItemDatabase.itemDB[i].ItemImage);

        //    if (ItemDatabase.itemDB[i].ItemImage == "giftbox")
        //    {
        //        LootedItems.Add(ItemDatabase.itemDB[i]);
        //        Debug.Log("added");
        //    }
        //}

       


        for (int i = 0; i < LootedItems.Count; i++)
        {
            GameObject obj = Instantiate(BtnUIPrefab);
            // obj.transform.parent = parentCanvas.transform;
            obj.transform.SetParent(parentCanvas.transform, false);
            Buttons.Add(obj);
            Debug.Log("Tehty");

        }
    }

    public void ShowGiftBox()
    {

        for(int i = 0; i<LootedItems.Count; i++)
        {
            string spriteName = LootedItems[i].ItemImage;
            Debug.Log(spriteName);
            Buttons[i].GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>("giftbox");

        }
    }

    /*
    public void OpenBox(Button btn)
    {
        ItemContainer itemContainer = new ItemContainer();
        string jsondata = File.ReadAllText(Application.dataPath + "/StreamingAssets/ItemDatabase.json");
        itemContainer = JsonMapper.ToObject<ItemContainer>(jsondata);

        int i;

        if (btn == Buttons[0].GetComponentInChildren<Button>())
        {
            for (i = 0; i < ItemDatabase.itemDB.Count; i++)
            {
                if (LootedItems[0].ItemId == ItemDatabase.itemDB[i].ItemId)
                {
                    ItemDatabase.itemDB[i].ItemImage = "image1";

                    switch (ItemDatabase.itemDB[i].ItemType)
                    {
                        case ItemType.WEAPON:
                            for (int j = 0; j < itemContainer.WeaponL.Count; j++)
                            {
                                if (ItemDatabase.itemDB[i].ItemId == itemContainer.WeaponL[j].ItemId)
                                {
                                    itemContainer.WeaponL[j].ItemImage = "image1";
                                    break;
                                }
                            }
                            break;
                        case ItemType.ARMOR:
                            for (int j = 0; j < itemContainer.ArmorL.Count; j++)
                            {
                                if (ItemDatabase.itemDB[i].ItemId == itemContainer.ArmorL[j].ItemId)
                                {
                                    itemContainer.ArmorL[j].ItemImage = "image1";
                                    break;
                                }
                            }
                            break;
                        case ItemType.NECK:
                            for (int j = 0; j < itemContainer.NeckL.Count; j++)
                            {
                                if (ItemDatabase.itemDB[i].ItemId == itemContainer.NeckL[j].ItemId)
                                {
                                    itemContainer.NeckL[j].ItemImage = "image1";
                                    break;
                                }
                            }
                            break;
                        case ItemType.TRINKET1:
                            for (int j = 0; j < itemContainer.Trinket1L.Count; j++)
                            {
                                if (ItemDatabase.itemDB[i].ItemId == itemContainer.Trinket1L[j].ItemId)
                                {
                                    itemContainer.Trinket1L[j].ItemImage = "image1";
                                    break;
                                }
                            }
                            break;
                        case ItemType.TRINKET2:
                            for (int j = 0; j < itemContainer.Trinket2L.Count; j++)
                            {
                                if (ItemDatabase.itemDB[i].ItemId == itemContainer.Trinket2L[j].ItemId)
                                {
                                    itemContainer.Trinket2L[j].ItemImage = "image1";
                                    break;
                                }
                            }
                            break;
                        default:
                            break;
                    }

                    string json = JsonMapper.ToJson(itemContainer);

                    File.WriteAllText(Application.streamingAssetsPath + "/ItemDatabase.json", json);
                }
            }
        }   
    }

    public void RemoveItem(Button btn)
    {
        ItemContainer itemContainer = new ItemContainer();
        string jsondata = File.ReadAllText(Application.dataPath + "/StreamingAssets/ItemDatabase.json");
        itemContainer = JsonMapper.ToObject<ItemContainer>(jsondata);

        int i;

        if (btn == Buttons[0].GetComponentInChildren<Button>())
        {
            for (i = 0; i < ItemDatabase.itemDB.Count; i++)
            {
                if (LootedItems[0].ItemId == ItemDatabase.itemDB[i].ItemId)
                {
                    ItemDatabase.itemDB.Remove(ItemDatabase.itemDB[i]);

                    switch (ItemDatabase.itemDB[i].ItemType)
                    {
                        case ItemType.WEAPON:
                            for (int j = 0; j < itemContainer.WeaponL.Count; j++)
                            {
                                if (ItemDatabase.itemDB[i].ItemId == itemContainer.WeaponL[j].ItemId)
                                {
                                    itemContainer.WeaponL.Remove(itemContainer.WeaponL[j]);
                                    break;
                                }
                            }
                            break;
                        case ItemType.ARMOR:
                            for (int j = 0; j < itemContainer.ArmorL.Count; j++)
                            {
                                if (ItemDatabase.itemDB[i].ItemId == itemContainer.ArmorL[j].ItemId)
                                {
                                    itemContainer.ArmorL.Remove(itemContainer.ArmorL[j]);
                                    break;
                                }
                            }
                            break;
                        case ItemType.NECK:
                            for (int j = 0; j < itemContainer.NeckL.Count; j++)
                            {
                                if (ItemDatabase.itemDB[i].ItemId == itemContainer.NeckL[j].ItemId)
                                {
                                    itemContainer.NeckL.Remove(itemContainer.NeckL[j]);
                                    break;
                                }
                            }
                            break;
                        case ItemType.TRINKET1:
                            for (int j = 0; j < itemContainer.Trinket1L.Count; j++)
                            {
                                if (ItemDatabase.itemDB[i].ItemId == itemContainer.Trinket1L[j].ItemId)
                                {
                                    itemContainer.Trinket1L.Remove(itemContainer.Trinket1L[j]);
                                    break;
                                }
                            }
                            break;
                        case ItemType.TRINKET2:
                            for (int j = 0; j < itemContainer.Trinket2L.Count; j++)
                            {
                                if (ItemDatabase.itemDB[i].ItemId == itemContainer.Trinket2L[j].ItemId)
                                {
                                    itemContainer.Trinket2L.Remove(itemContainer.Trinket2L[j]);
                                    break;
                                }
                            }
                            break;
                        default:
                            break;
                    }

                    string json = JsonMapper.ToJson(itemContainer);

                    File.WriteAllText(Application.streamingAssetsPath + "/ItemDatabase.json", json);
                }
            }
        }
    }
    */
}
