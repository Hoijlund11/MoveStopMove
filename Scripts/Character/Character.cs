using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;
using static UnityEngine.GraphicsBuffer;

public class Character : GameUnit
{
    [SerializeField] private Animator anim;

    private string currentAnimName;

    public bool isMoving = false;
    public bool isDead = false;
    public bool isAttack = false;

    public Transform shootingPoint;
    public Transform charSkin;
    public Transform header;
    public Transform rightHand;
    public Transform leftHand;

    public List<Character> listTargets = new List<Character>();
    public Character target;

    public ItemsData items;
    public GameObject weapon;
    public GameObject hat;
    public GameObject pant;
    public GameObject shield;
    public List<GameObject> skins;

    public Material invisionMaterial;

    public virtual void OnInit()
    {
        OnIdle();
        charSkin.transform.rotation = Quaternion.Euler(0, 180, 0);
        charSkin.localScale = new Vector3(1, 1, 1);
       
    }

    public virtual void OnDeath()
    {
        isDead = true;
        ChangeAnim("dead");
        ClearTarget();
    }

    public void OnIdle()
    {
        ChangeAnim("idle");
    }

    public void OnDance()
    {
        ChangeAnim("dance");
    }

    public bool CheckTarget()
    {
        bool hasTarget = false;

        if (listTargets != null)
        {
            hasTarget = true;
        }

        return hasTarget;
    }

    public Character CheckClosestTarget()
    {
        float min = Mathf.Infinity;
        float minDistance;
        if (listTargets == null)
        {
            target = null;
        }
        else
        {
            for (int i = 0; i < listTargets.Count; i++)
            {
                minDistance = Vector3.Distance(gameObject.transform.position, listTargets[i].transform.position);
                if (minDistance < min)
                {
                    min = minDistance;
                    target = listTargets[i];
                }
            }
        }
        return target;
    }

    public void AddTarget(Character character)
    {
        listTargets.Add(character);
    }

    public void RemoveTarget(Character character)
    {
        listTargets.Remove(character);
        target = null;
    }

    public void ClearTarget()
    {
        listTargets.Clear();
    }

    public void Attack(Character target)
    {
        if (target == null)
        {
            return;
        }
        if (isAttack == true)
        {
            return;
        }
        transform.LookAt(target.transform.position);
        ChangeAnim("attack");
        isAttack = true;
        Invoke(nameof(ActiveAttack), 0.3f);
        Invoke(nameof(ResetAttack), 2f);
    }

    public void ResetAttack()
    {
        ChangeAnim("idle");
        isAttack = false;
    }

    public void ActiveAttack()
    {
        Bullet bullet = SimplePool.Spawn<Bullet>((PoolType)(PlayerPrefs.GetInt("Weapon") + 1), this.transform.position, Quaternion.identity);
        bullet.OnInit(target.transform.position, this);
    }

    public virtual void ScaleUp()
    {
        charSkin.localScale += new Vector3(0.2f, 0.2f, 0.2f);
    }

    public void ChangeItem(ItemType itemType, int id)
    {
        switch (itemType)
        {
            case ItemType.Weapon:
                Destroy(this.weapon);
                this.weapon = Instantiate(items.weaponListDatas[id].object__, this.rightHand);
                break;
            case ItemType.Hat:
                Destroy(this.hat);
                if(id == 0) break;
                this.hat = Instantiate(this.items.hatListDatas[id - 1].object__, this.header);
                break;
            case ItemType.Pant:
                ChangePant(id);
                break;
            case ItemType.Sheild:
                Destroy(this.shield);
                if (id == 0) break;
                this.shield = Instantiate(this.items.shieldListDatas[id - 1].object__, this.leftHand);
                break;
            case ItemType.Skin:
                for (int i = 0; i < skins.Count; i++)
                {

                }
                break;
        }
    }

    public void ChangePant(int index)
    {
        this.pant.GetComponent<SkinnedMeshRenderer>().material = invisionMaterial;

        if (index == 0) return;
        PantData pantData = (PantData)this.items.pantListDatas[index - 1];
        this.pant.GetComponent<SkinnedMeshRenderer>().material = pantData.pantMaterial;
    }

    public void ChangeAnim(string animName)
    {
        if (currentAnimName != animName)
        {
            anim.ResetTrigger(animName);
            currentAnimName = animName;
            anim.SetTrigger(currentAnimName);
        }
    }
}
