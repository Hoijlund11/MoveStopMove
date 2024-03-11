using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "ItemsData", menuName = "ScriptableObjects/ItemsData", order = 1)]
public class ItemsData : ScriptableObject
{
    public List<ItemData> weaponListDatas = new List<ItemData>();
    public List<ItemData> hatListDatas = new List<ItemData>();
    public List<PantData> pantListDatas = new List<PantData>();
    public List<ItemData> shieldListDatas = new List<ItemData>();
    public List<ItemData> skinListDatas = new List<ItemData>();

    public List<Material> materials = new List<Material>();
}
