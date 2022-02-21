namespace Sprite
{
    public class GameSprite
    {
        public SpriteBitmap SpriteBitmap { get; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Frame { get; set; }

        public GameSprite(SpriteBitmap spriteBitmap) : this(spriteBitmap, 0, 0, 0)
        {
        }

        public GameSprite(SpriteBitmap spriteBitmap, int x, int y, int frame)
        {
            SpriteBitmap = spriteBitmap;
            X = x;
            Y = y;
            Frame = frame;
        }

        public virtual void Draw(SpriteWindow spriteWindow)
        {
            Gl.glColor4f(1, 1, 1, 1);
            spriteWindow.DrawGlBitmap(SpriteBitmap, X, Y, Frame);
        }
    }
}