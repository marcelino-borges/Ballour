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

    public static bool isVibrating = false;

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
        Vibrate();
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

    private IEnumerator Vibrate()
    {
        if (!isVibrating)
        {
            Handheld.Vibrate();
            isVibrating = true;
            yield return new WaitForSeconds(.25f);
            isVibrating = false;
        }

    }

    public override void OnTouchPlayer(PlayerBall player)
    {
        if (LevelManager.instance.isGameOver)
            return;
        player.TakeDamage(Damage);
        player.SetColor(currentColor);
        DestroyObject();
    }

    protected override Color32 SortRandomColor()
    {
        return Utils.SortRandomColorFromColors(Utils.enemyBrickColors);
    }
}
