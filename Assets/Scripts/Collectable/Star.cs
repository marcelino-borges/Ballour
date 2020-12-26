public class Star : Collectable
{
    public int value = 1;

    public override void OnTouchPlayer(PlayerBall player)
    {
        player.GatherCollectable(1);
        DestroyObject();
    }

    public override void DestroyObject()
    {
        base.DestroyObject();
        Destroy(gameObject);
    }
}
