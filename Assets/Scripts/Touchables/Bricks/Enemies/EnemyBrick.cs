using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MilkShake;

public class EnemyBrick : Brick
{
    public enum BombType
    {
        Point,
        CircleBomb,
        SquareBomb,
        ColumnBomb
    }

    public bool canDamage = true;
    [SerializeField]
    private int damage;
    public int Damage { get => canDamage ? damage : 0; }

    public ShakePreset shakePreset;

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

    public override void DestroyObject()
    {
        Handheld.Vibrate();
        Shaker.ShakeAll(shakePreset);

        if (explosionParticlesPrefab != null)
        {
            ParticleSystem.MainModule explosion = Instantiate(explosionParticlesPrefab, transform.position, Quaternion.identity)
                .GetComponent<ParticleSystem>().main;
            
            explosion.startColor = currentColor;
        }

        if (destroySfx != null)
            SoundManager.instance.PlaySound2D(destroySfx);

        Destroy(gameObject);
    }

    public override void OnTouchPlayer(PlayerBall player)
    {
        if (LevelManager.instance.isGameOver)
            return;
        player.TakeDamage(Damage);
        player.SetColor(currentColor);
        DestroyObject();
    }

    protected override Color SortRandomColor()
    {
        return Utils.SortRandomColorFromColors(Utils.enemyBrickColors);
    }
}
