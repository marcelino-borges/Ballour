using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : Touchable
{
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

    public override void DestroyObject() {}

    public override void OnTouchPlayer(PlayerBall player)
    {
        player.SetColor(currentColor);
        if (touchSfx != null)
            SoundManager.instance.PlaySound2D(touchSfx);
        float xVel = Mathf.Abs(player.rbd2.velocity.x);
        float yVel = Mathf.Abs(player.rbd2.velocity.y);

        if (xVel > yVel)
        {
            player.rbd2.velocity = new Vector2(player.rbd2.velocity.x, -1 * player.rbd2.velocity.y) * 3;
        } else if (yVel > xVel)
        {
            player.rbd2.velocity = new Vector2(-1 * player.rbd2.velocity.x, player.rbd2.velocity.y) * 3;
        }

    }
}
