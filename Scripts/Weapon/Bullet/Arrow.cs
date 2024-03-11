using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : Bullet
{
    private void Update()
    {
        Move();
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
