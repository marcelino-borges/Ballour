using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : Collectable
{
    public int healthAmount = 1;

    public override void OnTouchPlayer(PlayerBall player)
    {
        base.OnTouchPlayer(player);

        player.IncreaseHealth(healthAmount);
    }
}
