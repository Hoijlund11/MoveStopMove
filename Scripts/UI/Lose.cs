using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.UI;

public class Lose : UICanvas
{
    public Text time_Text;
    public Text revive_Text;
    public float time = 10f;
    public Button mainMenuButton;
    public Button reviveButton;
    public Button closeButton;
    
    public bool isClose = false;
    private void Update()
    {
        if (isClose == true)
        {
            return;
        }
        CountDown();
    }

    public void CountDown()
    {
        time -= Time.deltaTime;
        if (time <= 0)
        {
            time_Text.text = "LOSE!!!";
            mainMenuButton.gameObject.SetActive(true);
            return;
        }
        time_Text.text = Mathf.FloorToInt(time).ToString();
    }

    public void MainMenuButton()
    {
        GameManager.Instance.ChangeState(GameState.MainMenu);
        UIManager.Instance.OpenUI<MainMenu>();
        Close(0);
    }

    public void ReviveButton()
    {
        int coin = PlayerPrefs.GetInt("coin");
        if (coin >= 100)
        {
            coin -= 100;
            PlayerPrefs.SetInt("coin", coin);
            LevelManager.Instance.player.Revive();
        }
        else
        {
            return;
        }
        Close(0);
    }

    public void CloseButton()
    {
        isClose = true;
        time_Text.text = "LOSE!!!";
        revive_Text.gameObject.SetActive(false);
        reviveButton.gameObject.SetActive(false);
        closeButton.gameObject.SetActive(false);
        mainMenuButton.gameObject.SetActive(true);
    }
}
