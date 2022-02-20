namespace Sprite.Sample
{
    public class StartScene : IScene
    {
        public void Render(GameEngine gameEngine)
        {
            if (gameEngine.SpriteWindow.IsKeyDown(VirtualKeys.Escape))
                gameEngine.SpriteWindow.Running = false;

            if (gameEngine.SpriteWindow.IsKeyDown(VirtualKeys.Return))
                gameEngine.SetScene(new GameScene());

            gameEngine.SpriteWindow.DrawGlBitmap(Program.IntroBitmap, 20, 20);
            gameEngine.SpriteWindow.Swap();
        }
    }
}