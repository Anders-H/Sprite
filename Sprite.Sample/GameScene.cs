#nullable enable
namespace Sprite.Sample;

public class GameScene : IScene
{
    private int i;
    private float _p;
    private int _frame;
    private int _yOffset;

    public void Render(GameEngine gameEngine)
    {
        _yOffset = (_yOffset + 1) % 8;

        _p += 0.1f;
        if (_p > 1)
            _p = 0;
        for (int y = -1; y < 25; y++)
        {
            for (int x = 0; x < 40; x++)
            {
                gameEngine.SpriteWindow.DrawGlBitmap(Program.GlBitmap, x * 8, y * 8 + _yOffset, 5);
            }
        }

        _frame = 0;
        if (gameEngine.SpriteWindow.IsKeyDown(VirtualKeys.Right))
        {
            i++;
            _frame = 2;
        }
        if (gameEngine.SpriteWindow.IsKeyDown(VirtualKeys.Left))
        {
            i--;
            _frame = 1;
        }

        Gl.glColor4f(1, 1, 1, 1);
        gameEngine.SpriteWindow.DrawGlBitmap(Program.GlBitmap, 12 + i, 200 - 16, _frame);
        Gl.glColor4f(1, 1, 1, 1);
        gameEngine.SpriteWindow.Swap();
    }
}