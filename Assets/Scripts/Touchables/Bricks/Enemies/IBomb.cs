using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBomb
{
    Vector2 DamageArea { get; set; }
    LayerMask WhatIsTarget { get; set; }

    void Explode();
    void CastDamageOnArea();
}
