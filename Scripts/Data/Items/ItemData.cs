using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType { Hat, Pant, Sheild, Skin, Weapon}

[Serializable]
public class ItemData
{
    public ItemType itemType;
    public int id;
    public string name;
    public Sprite icon;
    public GameObject object__;
    public int price;
}