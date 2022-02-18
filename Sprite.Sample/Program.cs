﻿namespace Sprite.Sample
{
    internal class Program
    {
        private static SpriteBitmap glBitmap;
        private static bool _loadComplete;

        static Program()
        {
            _loadComplete = false;
        }

        static void Main(string[] args)
        {
            var gfx = new SpriteWindow("Test");
            gfx.OnLoadResources += Gfx_OnLoadResources;

            while (!_loadComplete)
            {
                System.Threading.Thread.Sleep(100);
                gfx.DoEvents();
            }

            var i = 0;
            float p = 0;
            var frame = 0;
            var yOffset = 0;

            while (gfx.Running)
            {
                yOffset = (yOffset+1) % 8;

                p += 0.1f;
                if (p > 1)
                    p = 0;
                for (int y = -1; y < 25; y++)
                {
                    for (int x = 0; x < 40; x++)
                    {
                        gfx.DrawGlBitmap(glBitmap, x * 8, y * 8 + yOffset, 5);
                    }
                }

                frame = 0;
                if (gfx.IsKeyDown(VirtualKeys.Right))
                {
                    i++;
                    frame = 2;
                }
                if (gfx.IsKeyDown(VirtualKeys.Left))
                {
                    i--;
                    frame = 1;
                }

                
                Gl.glColor4f(1, 1, 1, 1);
                gfx.DrawGlBitmap(glBitmap, 12+i, 200-16, frame);
                Gl.glColor4f(1, 1, 1, 1);
                gfx.Swap();
            }
        }

        private static void Gfx_OnLoadResources(object sender, System.EventArgs e)
        {
            System.Threading.Thread.Sleep(2000);
            glBitmap = SpriteBitmap.FromImage(Properties.Resources.test, 4, 4);
            _loadComplete = true;
        }
    }
}
