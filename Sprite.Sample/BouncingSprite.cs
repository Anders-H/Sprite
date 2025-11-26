#nullable enable
namespace Sprite.Sample;

public class BouncingSprite : GameSprite
{
    private int SpeedX { get; set; }
    private int SpeedY { get; set; }

    public BouncingSprite(SpriteBitmap spriteBitmap, int x, int y) : base(spriteBitmap, x, y, 5)
    {
        SpeedX = 2;
        SpeedY = 1;
    }

    public void ApplyLogic()
    {
        X += SpeedX;
        Y += SpeedY;

        if (X < 0 || X >= 316)
            SpeedX = -SpeedX;

        if (Y < 0 || Y >= 196)
            SpeedY = -SpeedY;
    }
}