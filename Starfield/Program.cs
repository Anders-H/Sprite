using System;
using System.Drawing;
using Sprite;

namespace Starfield
{
    public class Program
    {
        public static SpriteBitmap Star;
        public static GameEngine GameEngine { get; private set; }

        public static void Main()
        {
            // Create and initialize the game engine.
            GameEngine = new GameEngine("Starfield", OnLoadResources);
            GameEngine.LoadResources();

            // Run the game.
            GameEngine.Run(new StarfieldScene());
        }

        private static void OnLoadResources(object sender, EventArgs e)
        {
            // Draw a "star".
            var star = new Bitmap(2, 2);
            star.SetPixel(0, 1, Color.White);
            star.SetPixel(0, 0, Color.White);
            star.SetPixel(1, 1, Color.White);
            star.SetPixel(1, 0, Color.White);

            // Create a sprite bitmap from the star.
            Star = SpriteBitmap.FromImage(star, 1, 1);

            // Tell engine that loading is completed.
            GameEngine.SetLoadResourcesComplete();
        }
    }

    // Define the star sprite that will fly from right to left.
    public class StarSprite : BatchGameSprite
    {
        private int SpeedX { get; }

        public StarSprite(SpriteBitmap spriteBitmap, int y, int speedX) : base(spriteBitmap, 320, y, 1)
        {
            SpeedX = speedX;
        }

        public override void ApplyLogic() =>
            X += SpeedX;

        public override bool Alive() =>
            X > -5;
    }

    public class StarfieldScene : IScene
    {
        private readonly Random _rnd = new Random();

        // Create a sprite batch (used for fire-and-forget sprites) to hold the stars.
        private readonly SpriteBatch _spriteBatch = new SpriteBatch();

        public void Render(GameEngine gameEngine)
        {
            // Check if the user wants to exit.
            if (gameEngine.SpriteWindow.IsKeyDown(VirtualKeys.Escape))
                gameEngine.SpriteWindow.Running = false;

            // Add a new star each frame.
            _spriteBatch.Add(new StarSprite(Program.Star, _rnd.Next(199), -(_rnd.Next(5) + 1)));

            // Make the stars act.
            _spriteBatch.ApplyLogic();

            // Draw the frame.
            _spriteBatch.Draw(gameEngine.SpriteWindow);
            gameEngine.SpriteWindow.Swap();
        }
    }
}