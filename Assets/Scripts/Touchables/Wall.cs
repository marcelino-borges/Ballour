using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : Touchable
{
    public enum WallPosition
    {
        Left,
        Right,
        Top,
        Bottom
    }

    public WallPosition position;

    public float bordersMargin = 5f;

    protected override void Start()
    {
        base.Start();

        Vector3 levelDimensions = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        switch (position)
        {
            case WallPosition.Left:
                IncreaseHeightUntilFitScreen(levelDimensions);
                float leftPos = (-levelDimensions.x) - (spriteRenderer.bounds.size.x / 2) + bordersMargin;
                transform.position = new Vector3(leftPos, transform.position.y, transform.position.z);

                break;
            case WallPosition.Right:
                IncreaseHeightUntilFitScreen(levelDimensions);
                float rightPos = (levelDimensions.x) + (spriteRenderer.bounds.size.x / 2) - bordersMargin;
                transform.position = new Vector3(rightPos, transform.position.y, transform.position.z);

                break;
            case WallPosition.Top:
                IncreaseWidthUntilFitScreen(levelDimensions);
                float topPos = (levelDimensions.y) + (spriteRenderer.bounds.size.y / 2) - bordersMargin;
                transform.position = new Vector3(transform.position.x, topPos, transform.position.z);

                break;
            case WallPosition.Bottom:
                IncreaseWidthUntilFitScreen(levelDimensions);
                //margin replaced by the 0.1 multiplier, which is the anchor percentage used at the HUD bottom elements
                float bottomPos = (-levelDimensions.y) - (spriteRenderer.bounds.size.y / 2) + ((levelDimensions.y * 2f) * .12f);
                transform.position = new Vector3(transform.position.x, bottomPos, transform.position.z);

                break;
        }
    }

    private void IncreaseHeightUntilFitScreen(Vector3 levelDimensions)
    {
        while (spriteRenderer.bounds.size.y < levelDimensions.y * 2.2f)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + 3f, transform.localScale.z);
        }
    }

    private void IncreaseWidthUntilFitScreen(Vector3 levelDimensions)
    {
        while (spriteRenderer.bounds.size.x < levelDimensions.x * 2.2f)
        {
            transform.localScale = new Vector3(transform.localScale.x + 3f, transform.localScale.y, transform.localScale.z);
        }
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
    }
}
