using System;

namespace Sprite.Sample
{
    internal class Program
    {
        public static SpriteBitmap IntroBitmap;
        public static SpriteBitmap GlBitmap;
        public static GameEngine GameEngine { get; private set; }

        public static void Main(string[] args)
        {
            GameEngine = new GameEngine("My Game", OnLoadResources);

            GameEngine.LoadResources();

            GameEngine.Run(new StartScene());
        }

        private static void OnLoadResources(object sender, EventArgs e)
        {
            IntroBitmap = SpriteBitmap.FromImage(Properties.Resources.press_enter, 1, 1);
            GlBitmap = SpriteBitmap.FromImage(Properties.Resources.test, 4, 4);
            GameEngine.SetLoadResourcesComplete();
        }
    }
}