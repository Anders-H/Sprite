using System.Collections.Generic;

namespace Sprite
{
    public class SpriteBatch
    {
        private List<BatchGameSprite> Sprites { get; }

        public SpriteBatch()
        {
            Sprites = new List<BatchGameSprite>();
        }

        public int Count =>
            Sprites.Count;

        public void Add(BatchGameSprite sprite) =>
            Sprites.Add(sprite);

        public void ApplyLogic()
        {
            foreach (var batchGameSprite in Sprites)
                batchGameSprite.ApplyLogic();

            foreach (var batchGameSprite in Sprites)
            {
                if (!batchGameSprite.Alive())
                {
                    Sprites.Remove(batchGameSprite);
                    return;
                }
            }
        }

        public void Draw(SpriteWindow spriteWindow)
        {
            foreach (var batchGameSprite in Sprites)
                if (batchGameSprite.Alive())
                    batchGameSprite.Draw(spriteWindow);
        }
    }
}