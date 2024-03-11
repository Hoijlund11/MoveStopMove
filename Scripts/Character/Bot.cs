using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.AI;

public class Bot : Character
{
    public NavMeshAgent agent;
    public Vector3 movePoint;

    private void Start()
    {
        movePoint = transform.position;
        //OnInit();
    }

    private void Update()
    {
        if (GameManager.Instance.IsState(GameState.GamePlay))
        {
            StopMoving();
        }
        if (GameManager.Instance.IsState(GameState.GamePlay))
        {
            if (isDead == true)
            {
                return;
            }

            Move();

            if (listTargets != null && isMoving == false)
            {
                Attack(CheckClosestTarget());
            }
        }

    }

    public override void OnInit()
    {
        this.ChangeItem(ItemType.Weapon, Random.Range(0, 3));
        this.ChangeItem(ItemType.Hat, Random.Range(0, 9));
        this.ChangeItem(ItemType.Pant, Random.Range(0, 3));
        
    }

    public override void OnDeath()
    {
        base.OnDeath();
        agent.enabled = false;
        Invoke(nameof(Dead), 2f);
    }


    public Vector3 FindMovePoint()
    {
        float x = Random.Range(-13, 15);
        float z = Random.Range(-13, 15);
        movePoint = new Vector3(x, 0, z);   
        return movePoint;
    }

    public void Move()
    {
        isMoving = true;
        isAttack = false;
        agent.SetDestination(movePoint);
        ChangeAnim("run");
        if (Vector3.Distance(transform.position, movePoint) < 0.1f)
        {
            StopMoving();
            
        }
    }

    public void StopMoving()
    {
        isMoving = false;
        ChangeAnim("idle");
        Invoke(nameof(FindMovePoint), 2f);
    }

    public void Dead()
    {
        SimplePool.Despawn(this);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            FindMovePoint();
        }
    }
}
