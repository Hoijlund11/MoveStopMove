using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : UICanvas
{
    public Camera mainCam;
    public List<Transform> targetsList = new List<Transform>();
    public Transform player;
    public Transform holder;

    public Indicator indicatorPrefab;
    public List<Indicator> indi = new List<Indicator>();

    public float screenBorder = 10f;

    public Vector3 playerScreenPos;


    [SerializeField] private RectTransform containerIndicators;
    private void Start()
    {
        this.player = LevelManager.Instance.player.transform;
        this.mainCam = LevelManager.Instance.Camera;
        targetsList = LevelManager.Instance.targets;

        playerScreenPos = mainCam.WorldToScreenPoint(player.position);
        for (int i = 0; i < targetsList.Count; i++)
        {
            Indicator indicator = Instantiate(indicatorPrefab, holder);
            indi.Add(indicator);
        }

    }

    private void Update()
    {
        for (int i = 0; i < targetsList.Count; i++)
        {
            Vector3 pos = mainCam.WorldToScreenPoint(targetsList[i].position);
            if (!OffScreen(pos))
            {
                indi[i].Hide();
            }
            else
            {
                indi[i].Show();

                if (pos.x > 1080)
                {
                    pos.x = 1050;
                }
                if (pos.x < 0)
                {
                    pos.x = 30;
                }
                if (pos.y > 1920)
                {
                    pos.y = 1890;
                }
                if (pos.y < 0)
                {
                    pos.y = 30;
                }
                indi[i].transform.position = pos;
                indi[i].transform.up = pos - playerScreenPos;
            }
        }
    }

    public void SettingButton()
    {
        GameManager.Instance.ChangeState(GameState.GamePause);
        UIManager.Instance.OpenUI<Setting>();
        Close(0);
    }

    public bool OffScreen(Vector3 target)
    {
        bool isOffScreen = false;
        if (target.x <= screenBorder || target.x >= Screen.width || target.y <= screenBorder || target.y >= Screen.height)
        {
            isOffScreen = true;
        }
        return isOffScreen;
    }
}
