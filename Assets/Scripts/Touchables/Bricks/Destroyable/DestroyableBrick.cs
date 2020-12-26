using MilkShake;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableBrick : Brick
{
    public int score;
    public int hitPoints = 1;

    public ShakePreset shakePreset;

    public bool isDestroyed = false;

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
        Shaker.ShakeAll(shakePreset);
        if (explosionParticlesPrefab != null)
        {
            ParticleSystem.MainModule explosion = Instantiate(explosionParticlesPrefab, transform.position, Quaternion.identity)
                .GetComponent<ParticleSystem>().main;

            explosion.startColor = currentColor;
        }
        LevelManager.instance.CountDestroyedObjective();
        Destroy(gameObject);
    }

    public override void OnTouchPlayer(PlayerBall player)
    {
        if (LevelManager.instance.isGameOver)
            return;

        player.AddScore(score);
        player.SetColor(currentColor);

        HandleDamage(1);
    }

    public void HandleDamage(int damage)
    {        
        if (DecreaseHitPoints(damage) <= 0)
        {
            if (destroySfx != null)
                SoundManager.instance.PlaySound2D(destroySfx);

            DestroyObject();
        }
        else
        {
            if (touchSfx != null)
                SoundManager.instance.PlaySound2D(touchSfx);
        }
    }

    public int DecreaseHitPoints(int amount)
    {
        return --hitPoints;
    }

    protected override Color32 SortRandomColor()
    {
        return Utils.SortRandomColorFromColors(Utils.destroyableBrickColors);
    }
}
