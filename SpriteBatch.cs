using System.Collections.Generic;

namespace Sprite
{
    internal class SpriteBatch
    {
        private List<BatchGameSprite> Sprites { get; }

        public SpriteBatch()
        {
            Sprites = new List<BatchGameSprite>();
        }

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
    }
}