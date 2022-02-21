namespace Sprite
{
    public abstract class BatchGameSprite : GameSprite
    {
        protected BatchGameSprite(SpriteBitmap spriteBitmap) : base(spriteBitmap)
        {
        }

        protected BatchGameSprite(SpriteBitmap spriteBitmap, int x, int y, int frame) : base(spriteBitmap, x, y, frame)
        {
        }

        public abstract void ApplyLogic();

        public abstract bool Alive();
    }
}