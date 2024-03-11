using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitVFX : GameUnit
{
    private void Start()
    {
        Invoke(nameof(DespawnSelf), 0.3f);
    }
    private void DespawnSelf()
    {
        SimplePool.Despawn(this);
    }
}
