using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public enum ItemType { WEAPON, ARMOR, TRINKET1, TRINKET2, Amulet }
public enum ItemRarity { Legendary, Ancient, Rare, Magic, Normal }
public enum Character { Character1, Character2 }

public class Item
{
    public Character Character;
    public ItemType ItemType;

    public ItemRarity Rarity;

    public string ItemImage;
    public string ItemImageName;

    public int ItemId;

    public string ItemName;

    public float Damage;
    public float Health;
    public float Regeneration;
    public float CooldownReduction;
    public float CriticalHitChance;
    public float CriticalHitDamage;
    public float MovementSpeed;

    public int TierLevel;

    //public string TierLevel;

    public Item()
    {

    }

    public Item(int itemId, string itemName, Character character, ItemType itemType,
        ItemRarity rarity, string itemImage, string itemImageName, float damage, float health, 
        float regeneration, float cooldownReduction, float criticalHitChance, float criticalHitDamage, float movementSpeed, int tierLevel)
    {
        this.ItemId = itemId;
        this.ItemName = itemName;
       // this.Description = description;
        this.Character = character;
        this.ItemType = itemType;
        this.Rarity = rarity;
        this.ItemImage = itemImage;
        this.ItemImageName = itemImageName;
        Damage = damage;
        Health = health;
        Regeneration = regeneration;
        CooldownReduction = cooldownReduction;
        CriticalHitChance = criticalHitChance;
        CriticalHitDamage = criticalHitDamage;
        MovementSpeed = movementSpeed;
        TierLevel = tierLevel;
    }

    public override string ToString()
    {
        return ItemName + "\nTier level: " + TierLevel.ToString() + "\nDamage: " + Damage + "\nHealth: "+ Health +"\nRegeneration: " + Regeneration +
                "\nCooldownReduction: " + CooldownReduction + " %\nCriticalHitChance: " + CriticalHitChance + 
                " %\nCriticalHitDamage: "+ CriticalHitDamage + " % \nMovementSpeed: " + MovementSpeed ;
      
    }
}