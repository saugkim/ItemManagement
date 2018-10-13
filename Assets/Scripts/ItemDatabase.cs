
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using LitJson;
using System;
using System.Linq;

public class ItemDatabase : MonoBehaviour
{
    
    public GameObject LootedItemViewPanel;
    public GameObject ItemListViewPanel;

    public Button ItemListButton;
    public Transform ItemListParent;
    public static List<Button> ItemListButtonList = new List<Button>();

    public GameObject itemDetailPanel;
    public GameObject lootedItemDetailPanel;

    public Text itemDetailText;
    public Text itemDetailTextItemId;
    public Image itemDetailImage;

    public List<Item> itemDB = new List<Item>();
    public static List<Item> sortedItemDB = new List<Item>();

    public List<Item> WeaponList = new List<Item>();
    public List<Item> ArmorList = new List<Item>();
    public List<Item> AmuletList = new List<Item>();
    public List<Item> Trinket1List = new List<Item>();
    public List<Item> Trinket2List = new List<Item>();

    public List<Item> C2WeaponList = new List<Item>();
    public List<Item> C2ArmorList = new List<Item>();
    public List<Item> C2AmuletList = new List<Item>();
    public List<Item> C2Trinket1List = new List<Item>();
    public List<Item> C2Trinket2List = new List<Item>();

    //public List<Item> Char1List = new List<Item>();
    //public List<Item> Char2List = new List<Item>();
    //List<Item> sortedWeaponList = new List<Item>();
    //List<Item> sortedArmorList = new List<Item>();
    //List<Item> sortedAmuletList = new List<Item>();
    //List<Item> sortedTrinket1List = new List<Item>();
    //List<Item> sortedTrinket2List = new List<Item>();
    //List<Item> C2sortedWeaponList = new List<Item>();
    //List<Item> C2sortedArmorList = new List<Item>();
    //List<Item> C2sortedAmuletList = new List<Item>();
    //List<Item> C2sortedTrinket1List = new List<Item>();
    //List<Item> C2sortedTrinket2List = new List<Item>();

    public List<Button> Imagebuttons;
    public Image weaponImage;
    public Image armorImage;
    public Image amuletImage;
    public Image trinket1Image;
    public Image trinket2Image;

    string spriteName;

    Item selectedWeapon = new Item();
    Item selectedArmor = new Item();
    Item selectedAmulet = new Item();
    Item selectedTrinket1 = new Item();
    Item selectedTrinket2 = new Item();

    ItemStats itemStats = new ItemStats();

    public GameObject DisplayStatsPanel;
    public Text currentStatus;

    public static int initialCountValue;


    private void Start()
    {
        weaponImage.sprite = Resources.Load<Sprite>("transparent");
        armorImage.sprite = Resources.Load<Sprite>("transparent");
        amuletImage.sprite = Resources.Load<Sprite>("transparent");
        trinket1Image.sprite = Resources.Load<Sprite>("transparent");
        trinket2Image.sprite = Resources.Load<Sprite>("transparent");
        for (int i = 0; i < Imagebuttons.Count; i++)
        {
            Imagebuttons[0].transform.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        }

        RefreshItemlist();
        LoadData();
    }

    public void ClosePanel(string panelName)
    {
        if(panelName == "itemDetailPanel")
        {
            itemDetailPanel.SetActive(false);
        }
        
        if(panelName =="dispalyStatsPanel")
        {
            DisplayStatsPanel.SetActive(false);
        }
    }

    public void RefreshItemlist()
    {
        CreateItemList();

        sortedItemDB = itemDB.OrderBy(x => x.ItemId).ToList();
        initialCountValue = sortedItemDB[itemDB.Count - 1].ItemId;
        Debug.Log("ITEMDB " + itemDB.Count);

        //sortedWeaponList = WeaponList.OrderByDescending(x => x.TierLevel).ThenBy(x => x.Rarity).ToList();
        //sortedArmorList = ArmorList.OrderByDescending(x => x.TierLevel).ThenBy(x => x.Rarity).ToList();
        //sortedAmuletList = AmuletList.OrderByDescending(x => x.TierLevel).ThenBy(x => x.Rarity).ToList();
        //sortedTrinket1List = Trinket1List.OrderByDescending(x => x.TierLevel).ThenBy(x => x.Rarity).ToList();
        //sortedTrinket2List = Trinket2List.OrderByDescending(x => x.TierLevel).ThenBy(x => x.Rarity).ToList();

        //C2sortedWeaponList = C2WeaponList.OrderByDescending(x => x.TierLevel).ThenBy(x => x.Rarity).ToList();
        //C2sortedArmorList = C2ArmorList.OrderByDescending(x => x.TierLevel).ThenBy(x => x.Rarity).ToList();
        //C2sortedAmuletList = C2AmuletList.OrderByDescending(x => x.TierLevel).ThenBy(x => x.Rarity).ToList();
        //C2sortedTrinket1List = C2Trinket1List.OrderByDescending(x => x.TierLevel).ThenBy(x => x.Rarity).ToList();
        //C2sortedTrinket2List = C2Trinket2List.OrderByDescending(x => x.TierLevel).ThenBy(x => x.Rarity).ToList();

    }

    public void LoadData()
    {
        if (File.Exists(Application.streamingAssetsPath + "/CurrentItemStats.json"))
        {
            string json = File.ReadAllText(Application.streamingAssetsPath + "/CurrentItemStats.json");
            itemStats = JsonUtility.FromJson<ItemStats>(json);

            int tempWeaponId;
            int tempArmorId;
            int tempAmuletId;
            int tempTrinket1Id;
            int tempTrinket2Id;

            if(gameObject.name == "Character1")
            {
                tempWeaponId = itemStats.currentWeaponId;
                tempArmorId = itemStats.currentArmorId;
                tempAmuletId = itemStats.currentAmuletId;
                tempTrinket1Id = itemStats.currentTrinket1Id;
                tempTrinket2Id = itemStats.currentTrinket2Id;
            }
            else if (gameObject.name == "Character2")
            {
                tempWeaponId = itemStats.C2currentWeaponId;
                tempArmorId = itemStats.C2currentArmorId;
                tempAmuletId = itemStats.C2currentAmuletId;
                tempTrinket1Id = itemStats.C2currentTrinket1Id;
                tempTrinket2Id = itemStats.C2currentTrinket2Id;
            }
            else
            {
                tempWeaponId = 0;
                tempArmorId = 0;
                tempAmuletId = 0;
                tempTrinket1Id = 0;
                tempTrinket2Id = 0;
            }

            // possible additional characters

            for (int i = 0; i < itemDB.Count; i++)
            {
                if (tempWeaponId == itemDB[i].ItemId)
                {
                    Imagebuttons[0].transform.GetComponent<Image>().color = SetButtonColor(itemDB[i].Rarity);
                    spriteName = itemDB[i].ItemImage;
                    weaponImage.sprite = Resources.Load<Sprite>(spriteName);
                    selectedWeapon = itemDB[i];
                }
                if(tempArmorId == itemDB[i].ItemId)
                {
                    Imagebuttons[1].transform.GetComponent<Image>().color = SetButtonColor(itemDB[i].Rarity);
                    spriteName = itemDB[i].ItemImage;
                    armorImage.sprite = Resources.Load<Sprite>(spriteName);
                    selectedArmor = itemDB[i];
                }
                if (tempAmuletId == itemDB[i].ItemId)
                {
                    Imagebuttons[2].transform.GetComponent<Image>().color = SetButtonColor(itemDB[i].Rarity);
                    spriteName = itemDB[i].ItemImage;
                    amuletImage.sprite = Resources.Load<Sprite>(spriteName);
                    selectedAmulet = itemDB[i];
                }
                if (tempTrinket1Id == itemDB[i].ItemId)
                {
                    Imagebuttons[3].transform.GetComponent<Image>().color = SetButtonColor(itemDB[i].Rarity);
                    spriteName = itemDB[i].ItemImage;
                    trinket1Image.sprite = Resources.Load<Sprite>(spriteName);
                    selectedTrinket1 = itemDB[i];
                }
                if (tempTrinket2Id == itemDB[i].ItemId)
                {
                    Imagebuttons[4].transform.GetComponent<Image>().color = SetButtonColor(itemDB[i].Rarity);
                    spriteName = itemDB[i].ItemImage;
                    trinket2Image.sprite = Resources.Load<Sprite>(spriteName);
                    selectedTrinket2 = itemDB[i];
                }

               
            }
        }
        else
        {
            Debug.Log("File not exists");
        }
    }

    public void ShowItems(string itemListName)
    {
        List<Item> itemList;

        switch (itemListName)
        {
            case "weapon":
                itemList = WeaponList.OrderByDescending(x => x.TierLevel).ThenBy(x => x.Rarity).ToList(); 
                break;
            case "amulet":
                itemList = AmuletList.OrderByDescending(x => x.TierLevel).ThenBy(x => x.Rarity).ToList();
                break;
            case "armor":
                itemList = ArmorList.OrderByDescending(x => x.TierLevel).ThenBy(x => x.Rarity).ToList();
                break;
            case "trinket1":
                itemList = Trinket1List.OrderByDescending(x => x.TierLevel).ThenBy(x => x.Rarity).ToList();
                break;
            case "trinket2":
                itemList = Trinket2List.OrderByDescending(x => x.TierLevel).ThenBy(x => x.Rarity).ToList();
                break;

            case "c2weapon":
                itemList = C2WeaponList.OrderByDescending(x => x.TierLevel).ThenBy(x => x.Rarity).ToList();
                break;
            case "c2amulet":
                itemList = C2AmuletList.OrderByDescending(x => x.TierLevel).ThenBy(x => x.Rarity).ToList();
                break;
            case "c2armor":
                itemList = C2ArmorList.OrderByDescending(x => x.TierLevel).ThenBy(x => x.Rarity).ToList();
                break;
            case "c2trinket1":
                itemList = C2Trinket1List.OrderByDescending(x => x.TierLevel).ThenBy(x => x.Rarity).ToList();
                break;
            case "c2trinket2":
                itemList = C2Trinket2List.OrderByDescending(x => x.TierLevel).ThenBy(x => x.Rarity).ToList();
                break;
            default:
                itemList = null;
                break;
        }

        ShowItemList(itemList);
    }

 
    public void ShowItemList(List<Item> itemList)
    {
        LootedItemViewPanel.SetActive(false);
        ItemListViewPanel.SetActive(true);

        for (int i = 0; i < ItemListButtonList.Count; i++)
        {
            Destroy(ItemListButtonList[i].gameObject);
        }
        ItemListButtonList.Clear();


        for (int i = 0; i < itemList.Count; i++)
        {
            Button ButtonObj = Instantiate(ItemListButton);
            ButtonObj.transform.SetParent(ItemListParent, false);
            ItemListButtonList.Add(ButtonObj);
        }

        for (int i = 0; i < ItemListButtonList.Count; i++)
        {
            ItemListButtonList[i].transform.GetComponent<Image>().color = SetButtonColor(itemList[i].Rarity);

            string spriteName = itemList[i].ItemImageName;
            ItemListButtonList[i].transform.Find("ItemImage").GetComponentInChildren<Image>().sprite = Resources.Load<Sprite>(spriteName);
            ItemListButtonList[i].transform.Find("ItemName").GetComponent<Text>().text = itemList[i].ItemName;
            ItemListButtonList[i].transform.Find("ItemId").GetComponent<Text>().text = itemList[i].ItemId.ToString();

        }
    }

    private Color SetButtonColor(ItemRarity rarity)
    {
        Color newColor;

        switch(rarity)
        {
            case ItemRarity.Normal:
                newColor = new Color(1, 1, 1, 0.5f);
                break;
            case ItemRarity.Magic:
                newColor = new Color(0.25f, 0.50f, 0.75f, 0.5f);
                break;
            case ItemRarity.Rare:
                newColor = new Color(0.75f, 0.75f, 0.1f, 0.5f);
                break;
            case ItemRarity.Ancient:
                newColor = new Color(0.56f, 0, 0.996f, 0.5f);
                break;
            case ItemRarity.Legendary:
                newColor = new Color(0.86f, 0.65f, 0.125f, 0.5f);
                break;
            default:
                newColor = new Color(1, 1, 1, 1);
                break;
        }
        return newColor;
    }

    public void ShowItemDetails(Button btn)
    {
        for (int i = 0; i < ItemListButtonList.Count; i++)
        {
            Color tempColor = ItemListButtonList[i].transform.GetComponent<Image>().color;

            if (btn == ItemListButtonList[i])
            {
                btn.transform.GetComponent<Image>().color = new Color(tempColor.r, tempColor.g, tempColor.b, 1.0f);
            }     
            else
            {
                ItemListButtonList[i].transform.GetComponent<Image>().color = new Color(tempColor.r, tempColor.g, tempColor.b, 0.5f);
            }
        }

        for (int i = 0; i < itemDB.Count; i++)
        {
            if (btn.transform.Find("ItemId").GetComponent<Text>().text == itemDB[i].ItemId.ToString())
            {
                itemDetailPanel.SetActive(true);
                itemDetailText.text = itemDB[i].ToString();
                Debug.Log(itemDB[i].ToString());
                itemDetailTextItemId.text = itemDB[i].ItemId.ToString();

                string spriteName = itemDB[i].ItemImageName;
                itemDetailImage.sprite = Resources.Load<Sprite>(spriteName);
            }
        }
    }

    public void DisplayCurrentStats()
    {
        LoadData();
        DisplayStatsPanel.SetActive(true);
        
        float CombinedDamage = selectedWeapon.Damage + selectedArmor.Damage + selectedAmulet.Damage + selectedTrinket1.Damage + selectedTrinket2.Damage;
        float CombinedHealth = selectedWeapon.Health + selectedArmor.Health + selectedAmulet.Health + selectedTrinket1.Health + selectedTrinket2.Health;
        float CombinedRegeneration = selectedWeapon.Regeneration + selectedArmor.Regeneration + selectedAmulet.Regeneration + selectedTrinket1.Regeneration + selectedTrinket2.Regeneration;
        float CombinedCooldownReduction = selectedWeapon.CooldownReduction + selectedArmor.CooldownReduction + selectedAmulet.CooldownReduction + selectedTrinket1.CooldownReduction + selectedTrinket2.CooldownReduction;
        float CombinedCriticalHitChance = selectedWeapon.CriticalHitChance + selectedArmor.CriticalHitChance + selectedAmulet.CriticalHitChance + selectedTrinket1.CriticalHitChance + selectedTrinket2.CriticalHitChance;
        float CombinedCriticalHitDamage = selectedWeapon.CriticalHitDamage + selectedArmor.CriticalHitDamage + selectedAmulet.CriticalHitDamage + selectedTrinket1.CriticalHitDamage + selectedTrinket2.CriticalHitDamage;
        float CombinedMovementSpeed = selectedWeapon.MovementSpeed + selectedArmor.MovementSpeed + selectedAmulet.MovementSpeed + selectedTrinket1.MovementSpeed + selectedTrinket2.MovementSpeed;

        string temp = "Status of the Current Equipment \nDamage: " + CombinedDamage + 
                "\nHealth: " + CombinedHealth + "\nRegeneration: " + CombinedRegeneration +
                "\nCooldownReduction: " + CombinedCooldownReduction + "\nCriticalHitChance: " + CombinedCriticalHitChance +
                "\nCriticalHitDamage: " + CombinedCriticalHitDamage + "\nMovementSpeed: " + CombinedMovementSpeed; ;

        currentStatus.text = temp;
    }

   
    public void SellSelectedItem(Button btn)
    {
        List<Item> tempweapon;
        List<Item> temparmor;
        List<Item> tempamulet;
        List<Item> temptrinket1;
        List<Item> temptrinket2;
        string tempweaponstring;
        string temparmorstring;
        string tempamuletstring;
        string temptrinket1string;
        string temptrinket2string;
       
        if (gameObject.name == "Character1")
        {
            tempweapon  = WeaponList;
            temparmor = ArmorList;
            tempamulet = AmuletList;
            temptrinket1 = Trinket1List;
            temptrinket2 = Trinket2List;

            tempweaponstring = "weapon";
            temparmorstring = "armor";
            tempamuletstring = "amulet";
            temptrinket1string = "trinket1";
            temptrinket2string = "trinket2";
        }
        else if (gameObject.name == "Character2")
        {
            tempweapon = C2WeaponList;
            temparmor = C2ArmorList;
            tempamulet = C2AmuletList;
            temptrinket1 = C2Trinket1List;
            temptrinket2 = C2Trinket2List;

            tempweaponstring = "c2weapon";
            temparmorstring = "c2armor";
            tempamuletstring = "c2amulet";
            temptrinket1string = "c2trinket1";
            temptrinket2string = "c2trinket2";
        }
        else
        {
            tempweapon = WeaponList;
            temparmor = ArmorList;
            tempamulet = AmuletList;
            temptrinket1 = Trinket1List;
            temptrinket2 = Trinket2List;

            tempweaponstring = null;
            temparmorstring = null;
            tempamuletstring = null;
            temptrinket1string = null;
            temptrinket2string = null;
        }

        ItemContainer itemContainer = new ItemContainer();
        string jsondata = File.ReadAllText(Application.dataPath + "/StreamingAssets/ItemDatabase.json");
        itemContainer = JsonMapper.ToObject<ItemContainer>(jsondata);

        for (int i = 0; i < itemDB.Count; i++)
        {
            if(btn.transform.parent.Find("ItemID").GetComponent<Text>().text == itemDB[i].ItemId.ToString())
            {
                switch (itemDB[i].ItemType)
                {
                    case ItemType.WEAPON:
                        if (itemStats.currentWeaponId == itemDB[i].ItemId || itemStats.C2currentWeaponId == itemDB[i].ItemId)
                        {
                            Imagebuttons[0].transform.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
                            weaponImage.sprite = Resources.Load<Sprite>("transparent");
                        }
                        for (int j = 0; j < itemContainer.WeaponL.Count; j++)
                        {
                            if (itemDB[i].ItemId == itemContainer.WeaponL[j].ItemId)
                            {
                                itemContainer.WeaponL.Remove(itemContainer.WeaponL[j]);
                                GoldCount.currentGold += itemDB[i].TierLevel * RarityFactor(itemDB[i].Rarity);

                                CloseDeletedItemDetailPanel();
                            }
                        }
                        for (int j = 0; j < tempweapon.Count; j++)
                        {
                            if (itemDB[i].ItemId == tempweapon[j].ItemId)
                            {
                                tempweapon.Remove(tempweapon[j]);
                                if (ItemListViewPanel.activeSelf)
                                {
                                    //ShowItemList(sortedWeaponList);
                                    ShowItems(tempweaponstring);
                                }
                            }
                        }
                        break;

                    case ItemType.ARMOR:
                        if (itemStats.currentArmorId == itemDB[i].ItemId || itemStats.C2currentArmorId == itemDB[i].ItemId)
                        {
                            Imagebuttons[1].transform.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                            armorImage.sprite = Resources.Load<Sprite>("transparent");
                        }
                        for (int j = 0; j < itemContainer.ArmorL.Count; j++)
                        {
                            if (itemDB[i].ItemId == itemContainer.ArmorL[j].ItemId)
                            {
                                itemContainer.ArmorL.Remove(itemContainer.ArmorL[j]);
                                GoldCount.currentGold += itemDB[i].TierLevel * RarityFactor(itemDB[i].Rarity);

                                CloseDeletedItemDetailPanel();
                            }
                        }
                        for (int j = 0; j < temparmor.Count; j++)
                        {
                            if (itemDB[i].ItemId == temparmor[j].ItemId)
                            {
                                temparmor.Remove(temparmor[j]);
                                if (ItemListViewPanel.activeSelf)
                                {
                                    // ShowItemList(sortedArmorList);
                                    ShowItems(temparmorstring);
                                }
                            }
                        }
                        break;

                    case ItemType.Amulet:
                        if (itemStats.currentAmuletId == itemDB[i].ItemId || itemStats.C2currentAmuletId ==itemDB[i].ItemId)
                        {
                            Imagebuttons[2].transform.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                            amuletImage.sprite = Resources.Load<Sprite>("transparent");
                        }
                        for (int j = 0; j < itemContainer.AmuletL.Count; j++)
                        {
                            if (itemDB[i].ItemId == itemContainer.AmuletL[j].ItemId)
                            {
                                itemContainer.AmuletL.Remove(itemContainer.AmuletL[j]);
                                GoldCount.currentGold += itemDB[i].TierLevel * RarityFactor(itemDB[i].Rarity);

                                CloseDeletedItemDetailPanel();
                            }
                        }
                        for (int j = 0; j < tempamulet.Count; j++)
                        {
                            if (itemDB[i].ItemId == tempamulet[j].ItemId)
                            {
                                tempamulet.Remove(tempamulet[j]);
                                if (ItemListViewPanel.activeSelf)
                                {
                                    //ShowItemList(sortedAmuletList);
                                    ShowItems(tempamuletstring);
                                }
                            }
                        }
                        break;

                    case ItemType.TRINKET1:
                        if (itemStats.currentTrinket1Id == itemDB[i].ItemId || itemStats.C2currentTrinket1Id == itemDB[i].ItemId)
                        {
                            Imagebuttons[3].transform.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                            trinket1Image.sprite = Resources.Load<Sprite>("transparent");
                        }
                        for (int j = 0; j < itemContainer.Trinket1L.Count; j++)
                        {
                            if (itemDB[i].ItemId == itemContainer.Trinket1L[j].ItemId)
                            {
                                itemContainer.Trinket1L.Remove(itemContainer.Trinket1L[j]);
                                GoldCount.currentGold += itemDB[i].TierLevel * RarityFactor(itemDB[i].Rarity);

                                CloseDeletedItemDetailPanel();
                            }
                        }
                        for (int j = 0; j < temptrinket1.Count; j++)
                        {
                            if (itemDB[i].ItemId == temptrinket1[j].ItemId)
                            {
                                temptrinket1.Remove(temptrinket1[j]);
                                if (ItemListViewPanel.activeSelf)
                                {
                                    //ShowItemList(sortedTrinket1List);
                                    ShowItems(temptrinket1string);
                                }
                            }
                        }
                        break;

                    case ItemType.TRINKET2:
                        if(itemStats.currentTrinket2Id == itemDB[i].ItemId)
                        {
                            Imagebuttons[4].transform.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                            trinket2Image.sprite = Resources.Load<Sprite>("transparent");
                        }
                       
                        for (int j = 0; j < itemContainer.Trinket2L.Count; j++)
                        {
                            if (itemDB[i].ItemId == itemContainer.Trinket2L[j].ItemId)
                            {
                                itemContainer.Trinket2L.Remove(itemContainer.Trinket2L[j]);
                                GoldCount.currentGold += itemDB[i].TierLevel * RarityFactor(itemDB[i].Rarity);

                                CloseDeletedItemDetailPanel();
                            }
                        }
                        for (int j = 0; j < temptrinket2.Count; j++)
                        {
                            if (itemDB[i].ItemId == temptrinket2[j].ItemId)
                            {
                                temptrinket2.Remove(temptrinket2[j]);
                                if (ItemListViewPanel.activeSelf)
                                {
                                    //ShowItemList(sortedTrinket2List);
                                    ShowItems(temptrinket2string);
                                }
                            }
                        }
                        break;

                    default:
                        break;
                }

                string json = JsonMapper.ToJson(itemContainer);
                File.WriteAllText(Application.streamingAssetsPath + "/ItemDatabase.json", json);

                itemDB.Remove(itemDB[i]);          
            }
        }
    }

    private void CloseDeletedItemDetailPanel()
    {
        if (itemDetailPanel.activeSelf)
        {
            itemDetailPanel.SetActive(false);
        }
        if (lootedItemDetailPanel.activeSelf)
        {
            lootedItemDetailPanel.SetActive(false);
        }
    }

    private int RarityFactor(ItemRarity rarity)
    {
        int rarityFactor;
        switch(rarity)
        {
            case ItemRarity.Legendary:
                rarityFactor = 200;
                break;
            case ItemRarity.Ancient:
                rarityFactor = 175;
                break;
            case ItemRarity.Rare:
                rarityFactor = 150;
                break;
            case ItemRarity.Magic:
                rarityFactor = 125;
                break;
            case ItemRarity.Normal:
                rarityFactor = 100;
                break;
            default:
                rarityFactor = 100;
                break;
        }
        return rarityFactor;
    }

    public void EquipSelectedItem(Button btn)
    {
        for (int i = 0; i < itemDB.Count; i++)
        {
            if (btn.transform.parent.Find("ItemID").GetComponent<Text>().text == itemDB[i].ItemId.ToString())
            {
                switch (itemDB[i].ItemType)
                {
                    case ItemType.WEAPON:
                        if(itemDB[i].Character == Character.Character1)
                        {
                            itemStats.currentWeaponId = itemDB[i].ItemId;
                        }
                        else if(itemDB[i].Character == Character.Character2)
                        {
                            itemStats.C2currentWeaponId = itemDB[i].ItemId;
                        }
                        Imagebuttons[0].transform.GetComponent<Image>().color = SetButtonColor(itemDB[i].Rarity);
                        spriteName = itemDB[i].ItemImageName;
                        weaponImage.sprite = Resources.Load<Sprite>(spriteName);
                        break;
                    case ItemType.ARMOR:
                        if (itemDB[i].Character == Character.Character1)
                        {
                            itemStats.currentArmorId = itemDB[i].ItemId;
                        }
                        else if (itemDB[i].Character == Character.Character2)
                        {
                            itemStats.C2currentArmorId = itemDB[i].ItemId;
                        }
                        Imagebuttons[1].transform.GetComponent<Image>().color = SetButtonColor(itemDB[i].Rarity);
                        spriteName = itemDB[i].ItemImageName;
                        armorImage.sprite = Resources.Load<Sprite>(spriteName);
                        break;
                    case ItemType.Amulet:
                        if (itemDB[i].Character == Character.Character1)
                        {
                            itemStats.currentAmuletId = itemDB[i].ItemId;
                        }
                        else if (itemDB[i].Character == Character.Character2)
                        {
                            itemStats.C2currentAmuletId = itemDB[i].ItemId;
                        }
                        Imagebuttons[2].transform.GetComponent<Image>().color = SetButtonColor(itemDB[i].Rarity);
                        spriteName = itemDB[i].ItemImageName;
                        amuletImage.sprite = Resources.Load<Sprite>(spriteName);
                        break;
                    case ItemType.TRINKET1:
                        if (itemDB[i].Character == Character.Character1)
                        {
                            itemStats.currentTrinket1Id = itemDB[i].ItemId;
                        }
                        else if (itemDB[i].Character == Character.Character2)
                        {
                            itemStats.C2currentTrinket1Id = itemDB[i].ItemId;
                        }
                        Imagebuttons[3].transform.GetComponent<Image>().color = SetButtonColor(itemDB[i].Rarity);
                        spriteName = itemDB[i].ItemImageName;
                        trinket1Image.sprite = Resources.Load<Sprite>(spriteName);
                        break;
                    case ItemType.TRINKET2:
                        if (itemDB[i].Character == Character.Character1)
                        {
                            itemStats.currentTrinket2Id = itemDB[i].ItemId;
                        }
                        else if (itemDB[i].Character == Character.Character2)
                        {
                            itemStats.C2currentTrinket2Id = itemDB[i].ItemId;
                        }
                        Imagebuttons[4].transform.GetComponent<Image>().color = SetButtonColor(itemDB[i].Rarity);
                        spriteName = itemDB[i].ItemImageName;
                        trinket2Image.sprite = Resources.Load<Sprite>(spriteName);
                        break;
                    default:
                        break;
                }
            }
        }
        string json = JsonUtility.ToJson(itemStats);
        File.WriteAllText(Application.streamingAssetsPath + "/CurrentItemStats.json", json);
    }
   
    private void CreateItemList()
    {
        ItemContainer itemContainer = new ItemContainer();
        string jsondata = File.ReadAllText(Application.dataPath + "/StreamingAssets/ItemDatabase.json");
        itemContainer = JsonMapper.ToObject<ItemContainer>(jsondata);


        for (int i = 0; i < itemContainer.WeaponL.Count; i++)
        {
            itemDB.Add(itemContainer.WeaponL[i]);

        }
        for (int i = 0; i < itemContainer.AmuletL.Count; i++)
        {
            itemDB.Add(itemContainer.AmuletL[i]);

        }
        for (int i = 0; i < itemContainer.ArmorL.Count; i++)
        {
            itemDB.Add(itemContainer.ArmorL[i]);

        }
        for (int i = 0; i < itemContainer.Trinket1L.Count; i++)
        {
            itemDB.Add(itemContainer.Trinket1L[i]);

        }
        for (int i = 0; i < itemContainer.Trinket2L.Count; i++)
        {
            itemDB.Add(itemContainer.Trinket2L[i]);

        }

        Debug.Log("Total ItemDB list number" + itemDB.Count);

        WeaponList = itemDB.Where<Item> (x =>
               x.Character == Character.Character1 && x.ItemType == ItemType.WEAPON && x.ItemImage == x.ItemImageName).ToList();
        AmuletList = itemDB.Where<Item>(x =>
               x.Character == Character.Character1 && x.ItemType == ItemType.Amulet && x.ItemImage == x.ItemImageName).ToList();
        ArmorList = itemDB.Where<Item>(x =>
               x.Character == Character.Character1 && x.ItemType == ItemType.ARMOR && x.ItemImage == x.ItemImageName).ToList();
        Trinket1List = itemDB.Where<Item>(x =>
               x.Character == Character.Character1 && x.ItemType == ItemType.TRINKET1 && x.ItemImage == x.ItemImageName).ToList();
        Trinket2List = itemDB.Where<Item>(x =>
               x.Character == Character.Character1 && x.ItemType == ItemType.TRINKET2 && x.ItemImage == x.ItemImageName).ToList();


        Debug.Log("number of weapon" + WeaponList.Count);

    }

}