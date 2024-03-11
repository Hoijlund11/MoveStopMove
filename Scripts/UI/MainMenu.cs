using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : UICanvas
{
    public Text coin_text;
    private void Start()
    {
        coin_text.text = PlayerPrefs.GetInt("coin").ToString();
    }
    public void PlayButton()
    {
        GameManager.Instance.ChangeState(GameState.GamePlay);
        UIManager.Instance.OpenUI<GamePlay>();
        Close(0);
    }

    public void WeaponShopButton()
    {
        GameManager.Instance.ChangeState(GameState.Shopping);
        UIManager.Instance.OpenUI<WeaponShop>();
        Close(0);
    }

    public void SkinShopButton()
    {
        GameManager.Instance.ChangeState(GameState.Shopping);
        UIManager.Instance.OpenUI<SkinShop>();
        Close(0);
    }

}
