using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Bullet
{
    private void Update()
    {
        Move();
    }
    public override void BulletRotation()
    {
        transform.Rotate(rotation * Time.deltaTime * 50);
    }

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.CompareTag("Player") && other.gameObject != character.gameObject)
        {
            SimplePool.Despawn(this);
        }
    }
}
