#nullable enable
using System;

namespace Sprite.Sample;

public class StartScene : IScene
{
    private int _tick;
        
    private readonly Random _rnd;

    private BouncingSprite BouncingSprite { get; }

    private SpriteBatch SpriteBatch { get; }

    public StartScene()
    {
        _rnd = new Random();
        BouncingSprite = new BouncingSprite(Program.GlBitmap, 200, 30);
        SpriteBatch = new SpriteBatch();
    }

    public void Render(GameEngine gameEngine)
    {
        _tick++;

        if (_tick%5 == 0)
            SpriteBatch.Add(new DecorativeSpaceship(Program.GlBitmap, _rnd.Next(317), -(_rnd.Next(4) + 1)));

        BouncingSprite.ApplyLogic();

        if (gameEngine.SpriteWindow.IsKeyDown(VirtualKeys.Escape))
            gameEngine.SpriteWindow.Running = false;

        if (gameEngine.SpriteWindow.IsKeyDown(VirtualKeys.Return))
            gameEngine.SetScene(new GameScene());

        gameEngine.SpriteWindow.DrawGlBitmap(Program.IntroBitmap, 20, 20);
        BouncingSprite.Draw(gameEngine.SpriteWindow);
        SpriteBatch.ApplyLogic();
        SpriteBatch.Draw(gameEngine.SpriteWindow);
        gameEngine.SpriteWindow.Swap();
    }
}