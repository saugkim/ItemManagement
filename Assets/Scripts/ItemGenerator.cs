using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;
using System.Linq;

public class ItemGenerator : MonoBehaviour
{
    public Character character;
    public ItemType itemType;
    public ItemRarity rarity;
    public string itemImage;
    public string itemImageName;
    public int itemId;
    public string itemName;
 //   public string description;
    public float damage;

    public float health;
    public float regeneration;
    public float cooldownReduction;
    public float criticalHitChance;
    public float criticalHitDamage;
    public float movementSpeed;
    public int tierLevel;

    int count;
    int maxId;

    private void Start()
    {
     //? GetMaximumId()?    
    }

    public void GetMaximumId()
    {
        maxId = ItemDatabase.initialCountValue;
        Debug.Log(maxId);

        count = maxId;
    }

    
    public void CreateItem()
    {
        
        count++;
        itemId = count;
        itemImage = "giftbox";

        ItemContainer itemContainer = new ItemContainer();

        string jsondata = File.ReadAllText(Application.dataPath + "/StreamingAssets/ItemDatabase.json");
        itemContainer = JsonMapper.ToObject<ItemContainer>(jsondata);

        switch (itemType)
        {
            case ItemType.WEAPON: 
                itemContainer.WeaponL.Add(new Item(itemId, itemName, character, itemType, rarity, 
                    itemImage, itemImageName, damage, health, regeneration, cooldownReduction, criticalHitChance, criticalHitDamage, movementSpeed, tierLevel ));
                break;
            case ItemType.ARMOR: //list
                itemContainer.ArmorL.Add(new Item(itemId, itemName, character, itemType, rarity, 
                    itemImage, itemImageName, damage, health, regeneration, cooldownReduction, criticalHitChance, criticalHitDamage, movementSpeed, tierLevel));
                break;
            case ItemType.Amulet: //list
                itemContainer.AmuletL.Add(new Item(itemId, itemName, character, itemType, rarity, 
                    itemImage, itemImageName, damage, health, regeneration, cooldownReduction, criticalHitChance, criticalHitDamage, movementSpeed, tierLevel));
                break;
            case ItemType.TRINKET1: //list
                itemContainer.Trinket1L.Add(new Item(itemId, itemName, character, itemType, rarity, 
                    itemImage, itemImageName, damage, health, regeneration, cooldownReduction, criticalHitChance, criticalHitDamage, movementSpeed, tierLevel));
                break;
            case ItemType.TRINKET2: //list
                itemContainer.Trinket2L.Add(new Item(itemId, itemName, character, itemType, rarity, 
                    itemImage, itemImageName, damage, health, regeneration, cooldownReduction, criticalHitChance, criticalHitDamage, movementSpeed, tierLevel));
                break;

            default:
                break;
        }

        string json = JsonMapper.ToJson(itemContainer);

        File.WriteAllText(Application.streamingAssetsPath + "/ItemDatabase.json", json);       
    }
}
