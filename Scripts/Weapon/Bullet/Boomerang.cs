using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : Bullet
{
    public bool isReturning = false;
    private void Update()
    {
        Move();
    }

    public override void Move()
    {
        BulletRotation();

        if (isReturning == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, this.character.transform.position, Time.deltaTime * speed);

            if (Vector3.Distance(transform.position, this.character.transform.position) < 0.1f)
            {
                isReturning = false;
                SimplePool.Despawn(this);
            }
            return;
        }

        if (isReturning == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);
            if (Vector3.Distance(transform.position, target) < 0.1f)
            {
                isReturning = true;
            }
        }
        
    }

    public override void BulletRotation()
    {
        transform.Rotate(rotation * Time.deltaTime * 50);
        
    }
}
