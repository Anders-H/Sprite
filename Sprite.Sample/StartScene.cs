namespace Sprite.Sample
{
    public class StartScene : IScene
    {
        private BouncingSprite BouncingSprite { get; }

        public StartScene()
        {
            BouncingSprite = new BouncingSprite(Program.GlBitmap, 200, 30);
        }

        public void Render(GameEngine gameEngine)
        {
            BouncingSprite.ApplyLogic();

            if (gameEngine.SpriteWindow.IsKeyDown(VirtualKeys.Escape))
                gameEngine.SpriteWindow.Running = false;

            if (gameEngine.SpriteWindow.IsKeyDown(VirtualKeys.Return))
                gameEngine.SetScene(new GameScene());

            gameEngine.SpriteWindow.DrawGlBitmap(Program.IntroBitmap, 20, 20);
            BouncingSprite.Draw(gameEngine.SpriteWindow);
            gameEngine.SpriteWindow.Swap();
        }
    }
}