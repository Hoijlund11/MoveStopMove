using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum GameState { MainMenu, GamePlay,  GamePause, Shopping, Finish}
public class GameManager : Singleton<GameManager>
{
    private GameState state;

    private void Awake()
    {
        ChangeState(GameState.MainMenu);
        UIManager.Instance.OpenUI<MainMenu>();
        LevelManager.Instance.LoadLevel();
        PlayerPrefs.SetInt("Weapon", 0);
        DataManager.Instance.SetLockitem(ItemType.Weapon, 0, true);

    }

    public void ChangeState(GameState gameState)
    {
        state = gameState;
    }

    public bool IsState(GameState gameState)
    {
        return state == gameState;
    }
}
