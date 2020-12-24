using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Brick : Touchable
{
    public GameObject explosionParticlesPrefab;    

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected abstract Color SortRandomColor();
}
