using UnityEngine;

public class CircleBomb : Bomb
{
    protected override void Awake()
    {
        base.Awake();
    }

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

    protected override Collider2D[] RaycastArea()
    {
        return Physics2D.OverlapCircleAll(transform.position, damageArea.x, WhatIsDestroyableBrick);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, damageArea.x);
    }
#endif
}
