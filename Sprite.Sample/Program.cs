using System;

namespace Sprite.Sample
{
    internal class Program
    {
        public static SpriteBitmap IntroBitmap;
        public static SpriteBitmap GlBitmap;
        public static GameEngine GameEngine { get; private set; }

        static void Main(string[] args)
        {
            GameEngine = new GameEngine(
                "My Game",
                OnLoadResources,
                new StartScene()
            );

            GameEngine.LoadResources();

            GameEngine.Run();
        }

        private static void OnLoadResources(object sender, EventArgs e)
        {
            IntroBitmap = SpriteBitmap.FromImage(Properties.Resources.press_enter, 1, 1);
            GlBitmap = SpriteBitmap.FromImage(Properties.Resources.test, 4, 4);
            GameEngine.SetLoadResourcesComplete();
        }
    }
}