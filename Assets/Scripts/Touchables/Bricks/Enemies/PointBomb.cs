using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBomb : EnemyBrick, IBomb
{
    [SerializeField]
    private Vector2 damageArea;
    public Vector2 DamageArea { get => damageArea; set => damageArea = value; }

    [SerializeField]
    private LayerMask whatIsDestroyableBrick;
    public LayerMask WhatIsDestroyableBrick { get => whatIsDestroyableBrick; set => whatIsDestroyableBrick = value; }

    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Start()
    {
        base.Start();

        if (isRandomColor)
            SetColor(SortRandomColor());
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public void Explode()
    {
        CastDamageOnArea();
        DestroyObject();
    }

    public void CastDamageOnArea()
    {
        
    }
}
