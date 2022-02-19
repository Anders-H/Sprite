using System;

namespace Sprite.Sample
{
    internal class Program
    {
        public static SpriteBitmap GlBitmap;
        public static GameEngine GameEngine { get; private set; }

        static void Main(string[] args)
        {
            GameEngine = new GameEngine("My Game", OnLoadResources);
            GameEngine.LoadResources();

            var i = 0;
            float p = 0;
            var frame = 0;
            var yOffset = 0;

            while (GameEngine.SpriteWindow.Running)
            {
                yOffset = (yOffset+1) % 8;

                p += 0.1f;
                if (p > 1)
                    p = 0;
                for (int y = -1; y < 25; y++)
                {
                    for (int x = 0; x < 40; x++)
                    {
                        GameEngine.SpriteWindow.DrawGlBitmap(GlBitmap, x * 8, y * 8 + yOffset, 5);
                    }
                }

                frame = 0;
                if (GameEngine.SpriteWindow.IsKeyDown(VirtualKeys.Right))
                {
                    i++;
                    frame = 2;
                }
                if (GameEngine.SpriteWindow.IsKeyDown(VirtualKeys.Left))
                {
                    i--;
                    frame = 1;
                }

                
                Gl.glColor4f(1, 1, 1, 1);
                GameEngine.SpriteWindow.DrawGlBitmap(GlBitmap, 12+i, 200-16, frame);
                Gl.glColor4f(1, 1, 1, 1);
                GameEngine.SpriteWindow.Swap();
            }
        }

        private static void OnLoadResources(object sender, EventArgs e)
        {
            GlBitmap = SpriteBitmap.FromImage(Properties.Resources.test, 4, 4);
            GameEngine.SetLoadResourcesComplete();
        }
    }
}