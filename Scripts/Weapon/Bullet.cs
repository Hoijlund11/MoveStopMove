using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : GameUnit
{
    public float speed = 10;

    public Vector3 target;
    public Vector3 rotation;
    public Vector3 startPos;

    public Character character;


    public virtual void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
        this.BulletRotation();
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            SimplePool.Despawn(this);
        }        
    }

    public void OnInit(Vector3 target, Character character)
    {
        this.target = target + Vector3.up;
        this.character = character;
    }

    public virtual void BulletRotation()
    {
        transform.forward = target - transform.position;  
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        Character c;
        if (other.CompareTag("Player") && other.gameObject != character.gameObject)
        {
            SimplePool.Spawn<HitVFX>(PoolType.Hit, transform.position, transform.rotation);
            if (this.character.name == "Player")
            {
                SoundManager.Instance.PlaySFX("Hit");
            }
           
            c = other.GetComponent<Character>();
            c.OnDeath();
            this.character.RemoveTarget(c);
            this.character.ScaleUp();
        }
    }

}
