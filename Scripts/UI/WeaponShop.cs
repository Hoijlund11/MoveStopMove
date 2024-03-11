using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponShop : UICanvas
{
    public ItemsData itemsData;

    public int index;
    public int coin;

    public Text puchase_text;
    public Text coin_text;
    public Text weaponName_text;

    public GameObject weapon;
    public Transform weaponHolder;

    protected override void StartCanvas()
    {
        index = PlayerPrefs.GetInt("weapon");
        ShowWeapon(index);
        coin = PlayerPrefs.GetInt("coin");
        coin_text.text = coin.ToString();
    }

    public void NextButton()
    {
        index++;
        if (index > itemsData.weaponListDatas.Count - 1)
        {
            index = itemsData.weaponListDatas.Count - 1;
            return;
        }

        ShowWeapon(index);
    }

    public void BackButton()
    {
        index--;
        if (index < 0)
        {
            index = 0;
            return;
        }
       
        ShowWeapon(index);
    }

    public void PuchaseButton()
    {
        if (coin < itemsData.weaponListDatas[index].price)
        {
            return;
        }
        PlayerPrefs.SetInt("Weapon",itemsData.weaponListDatas[index].id);
        DataManager.Instance.SetLockitem(ItemType.Weapon, index, true);
        LevelManager.Instance.player.ChangeItem(ItemType.Weapon, index);
        puchase_text.text = "Equiped";

    }

    public void CloseButton()
    {
        GameManager.Instance.ChangeState(GameState.MainMenu);
        UIManager.Instance.OpenUI<MainMenu>();
        Close(0);
    }

    public void ShowWeapon(int index)
    {
        Destroy(weapon);
        weapon = Instantiate(itemsData.weaponListDatas[index].object__, weaponHolder);
        weapon.gameObject.transform.localScale = new Vector3(weapon.transform.localScale.x * 300, weapon.transform.localScale.y * 300, weapon.transform.localScale.z * 300);
        weaponName_text.text = itemsData.weaponListDatas[index].object__.name;
        Debug.Log(DataManager.Instance.IsLockItem(ItemType.Weapon, index));
        if (DataManager.Instance.IsLockItem(ItemType.Weapon, index) == false)
        {
            if (PlayerPrefs.GetInt("Weapon") == itemsData.weaponListDatas[index].id)
            {
                puchase_text.text = "Equiped";
            }
            else
            {
                puchase_text.text = "Equip";
            }
        }
        else
        {
            puchase_text.text = itemsData.weaponListDatas[index].price.ToString();
        }
    }
}
