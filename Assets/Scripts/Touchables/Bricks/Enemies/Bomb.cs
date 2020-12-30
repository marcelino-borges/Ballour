using System;
using System.Collections;
using UnityEngine;

public class Bomb : EnemyBrick, IBomb
{
    [SerializeField]
    protected Vector2 damageArea;
    public Vector2 DamageArea { get => damageArea; set => damageArea = value; }

    [SerializeField]
    protected LayerMask whatIsTarget;
    public LayerMask WhatIsTarget { get => whatIsTarget; set => whatIsTarget = value; }

    public bool destroyOtherBombs = false;
    public bool destroyBricks = true;

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

    public virtual void Explode()
    {
        CastDamageOnArea();
        DestroyObject();
    }

    public virtual void CastDamageOnArea()
    {
        Collider2D[] colliders = RaycastArea();

        if (colliders != null && colliders.Length > 0)
        {
            foreach (Collider2D col in colliders)
            {
                MonoBehaviour monoBehaviour = col.gameObject.GetComponent<MonoBehaviour>();
                if (destroyBricks && monoBehaviour is DestroyableBrick)
                {
                    DestroyableBrick destroyable = col.gameObject.GetComponent<DestroyableBrick>();
                    if (!destroyable.isDestroyed)
                    {
                        destroyable.isDestroyed = true;
                        LevelManager.instance.DecreaseTotalObjectivesToDestroy(1);
                        Destroy(destroyable.gameObject);
                    }
                }

                if(destroyOtherBombs && monoBehaviour is Bomb)
                {
                    Bomb bomb = monoBehaviour.gameObject.GetComponent<Bomb>();
                    bomb.StartCoroutine(bomb.ExecuteDelayed(.1f, bomb.Explode));               
                }
            }
        }
    }

    public IEnumerator ExecuteDelayed(float delay, Action action)
    {
        yield return new WaitForSeconds(delay);
        action();
    }

    protected virtual Collider2D[] RaycastArea()
    {
        return Physics2D.OverlapBoxAll(transform.position, damageArea, 0f, whatIsTarget);        
    }

    public override void OnTouchPlayer(PlayerBall player)
    {
        if (LevelManager.instance.isGameOver)
            return;
        player.TakeDamage(Damage);
        player.SetColor(currentColor);
        Explode();
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, damageArea);
    }
#endif
}
