#nullable enable
namespace Sprite.Sample;

public class DecorativeSpaceship : BatchGameSprite
{
    private int SpeedY { get; set; }

    public DecorativeSpaceship(SpriteBitmap spriteBitmap, int x, int speedY) : base(spriteBitmap, x, 200, 0)
    {
        SpeedY = speedY;
    }

    public override void ApplyLogic()
    {
        Y += SpeedY;
    }

    public override bool Alive() =>
        Y > -5;
}