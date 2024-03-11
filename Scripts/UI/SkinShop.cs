using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinShop : UICanvas
{
    public ItemsData itemsData;
    public ItemType type;
    public Text puchase_text;
    public Text coin_text;

    public int index;
    public int coin;

    public List<GameObject> contentPanels;
    public List<Toggle> tabButtons;

    protected override void StartCanvas()
    {
        base.StartCanvas();
        ShowTab(0);
        coin = PlayerPrefs.GetInt("coin");
        coin_text.text = coin.ToString();
    }

    public void PuchaseButton()
    {
        switch (type)
        {
            case ItemType.Hat:
                PlayerPrefs.SetInt("hat", index);
                break;
            case ItemType.Pant:
                PlayerPrefs.SetInt("pant", index);
                break;
            case ItemType.Sheild:
                PlayerPrefs.SetInt("sheild", index);
                break;
            case ItemType.Skin:
                break;
        }
        DataManager.Instance.SetLockitem(type, index, false);
        puchase_text.text = "Equipped";
    }

    public void CloseButton()
    {
        GameManager.Instance.ChangeState(GameState.MainMenu);
        UIManager.Instance.OpenUI<MainMenu>();
        LevelManager.Instance.player.SetItem();
        Close(0);
    }

    public void ChangeHat(int i)
    {
        LevelManager.Instance.player.ChangeItem(ItemType.Hat, i + 1);
        index = i;

        Debug.Log(DataManager.Instance.IsLockItem(ItemType.Hat, index));
    }

    public void ChangeShield(int i)
    {
        LevelManager.Instance.player.ChangeItem(ItemType.Sheild, i + 1);
        index = i;

    }

    public void ChangePant(int i)
    {
        LevelManager.Instance.player.ChangeItem(ItemType.Pant, i + 1);
        index = i;
    }

    public void ChangeSkin(int i)
    {

    }

    public void ShowTab(int tabIndex)
    {
        index = 0;
        LevelManager.Instance.player.SetItem();
        for (int i = 0; i < contentPanels.Count; i++)
        {
            if (i == tabIndex)
            {
                type = (ItemType)i;
                contentPanels[i].SetActive(true);
                LevelManager.Instance.player.ChangeItem((ItemType)i, 1);
            }
            else
            {
                contentPanels[i].SetActive(false);
            }
        }
    }

    public void ShowItemInfo()
    {

    }
}
