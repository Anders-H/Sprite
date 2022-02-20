namespace Sprite.Sample
{
    public class GameScene : IScene
    {
        private int i = 0;
        private float p = 0;
        private int frame = 0;
        private int yOffset = 0;

        public void Render(GameEngine gameEngine)
        {
            yOffset = (yOffset + 1) % 8;

            p += 0.1f;
            if (p > 1)
                p = 0;
            for (int y = -1; y < 25; y++)
            {
                for (int x = 0; x < 40; x++)
                {
                    gameEngine.SpriteWindow.DrawGlBitmap(Program.GlBitmap, x * 8, y * 8 + yOffset, 5);
                }
            }

            frame = 0;
            if (gameEngine.SpriteWindow.IsKeyDown(VirtualKeys.Right))
            {
                i++;
                frame = 2;
            }
            if (gameEngine.SpriteWindow.IsKeyDown(VirtualKeys.Left))
            {
                i--;
                frame = 1;
            }

            Gl.glColor4f(1, 1, 1, 1);
            gameEngine.SpriteWindow.DrawGlBitmap(Program.GlBitmap, 12 + i, 200 - 16, frame);
            Gl.glColor4f(1, 1, 1, 1);
            gameEngine.SpriteWindow.Swap();
        }
    }
}