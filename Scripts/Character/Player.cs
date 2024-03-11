using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class Player : Character
{
    [SerializeField] private Rigidbody rb;
    public GameObject attackRange;

    public float moveSpeed;
    public int coin = 0;

    [SerializeField] private FloatingJoystick joystick;

    void Update()
    {
        if (GameManager.Instance.IsState(GameState.GamePlay))
        {
            attackRange.SetActive(true);
            if (isDead == true)
            {
                return;
            }
            if (Mathf.Abs(joystick.Horizontal) > 0 || Mathf.Abs(joystick.Vertical) > 0)
            {
                Move();
                ChangeAnim("run");
                isAttack = false;

            }
            else
            {
                rb.velocity = new Vector3(0, rb.velocity.y, 0);
                ChangeAnim("idle");

                if (listTargets != null)
                {
                    Attack(CheckClosestTarget());
                }
            }
        }
        if (GameManager.Instance.IsState(GameState.Shopping))
        {
            OnDance();
        }

        if (GameManager.Instance.IsState(GameState.MainMenu))
        {
            attackRange.SetActive(false);
            LevelManager.Instance.OnInit();
        }
    }

    public override void OnInit()
    {
        base.OnInit();
        SetItem();
    }

    public void Move()
    {
        rb.velocity = new Vector3(joystick.Horizontal * moveSpeed, rb.velocity.y, joystick.Vertical * moveSpeed);
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            charSkin.transform.rotation = Quaternion.LookRotation(rb.velocity);
        }
    }

    public override void OnDeath()
    {
        base.OnDeath();
        UIManager.Instance.OpenUI<Lose>();
    }

    public void SetItem()
    {
        ChangeItem(ItemType.Weapon, PlayerPrefs.GetInt("Weapon", 0));
        ChangeItem(ItemType.Hat, PlayerPrefs.GetInt("Hat"));
        ChangeItem(ItemType.Pant, PlayerPrefs.GetInt("Pant"));
        ChangeItem(ItemType.Sheild, PlayerPrefs.GetInt("Shield"));
    }

    public void Revive()
    {
        isDead = false;
        ChangeAnim("idle");
    }

    public override void ScaleUp()
    {
        base.ScaleUp();
        SoundManager.Instance.PlaySFX("SizeUp");
    }
}
