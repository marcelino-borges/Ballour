using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Touchable : MonoBehaviour
{
    public Color startColor;
    public Color currentColor;
    public SpriteRenderer spriteRenderer;
    public AudioClip touchSfx;
    public AudioClip destroySfx;
    public bool isRandomColor;

    protected virtual void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected virtual void Start()
    {
        SetColor(startColor);
    }

    protected virtual void Update()
    {

    }

    protected virtual void FixedUpdate()
    {

    }

    public abstract void DestroyObject();

    public abstract void OnTouchPlayer(PlayerBall player);

    public virtual void SetColor(Color color)
    {
        currentColor = color;
        spriteRenderer.color = color;
    }
}
