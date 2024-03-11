using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : UICanvas
{
    public void MainMenuButton()
    {
        GameManager.Instance.ChangeState(GameState.MainMenu);
        UIManager.Instance.OpenUI<MainMenu>();
        Close(0);
    }

    public void ContinueButton()
    {
        GameManager.Instance.ChangeState(GameState.GamePlay);
        UIManager.Instance.OpenUI<GamePlay>();
        Close(0);
    }
}
