using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Touchable
{
    public override void DestroyObject()
    {
        Destroy(gameObject);
    }

    public override void OnTouchPlayer(PlayerBall player)
    {
        
    }
}
