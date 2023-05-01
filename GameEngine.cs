using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Sprite
{
    public class GameEngine
    {
        private bool _loadResourcesComplete;
        private readonly EventHandler _onLoadResources;
        private string WindowTitle { get; }
        public SpriteWindow SpriteWindow { get; private set; }
        public IScene CurrentScene { get; private set; }

        public GameEngine(string windowTitle, EventHandler onLoadResources)
        {
            _loadResourcesComplete = false;
            WindowTitle = windowTitle;
            _onLoadResources = onLoadResources;
        }

        public void LoadResources()
        {
            SpriteWindow = new SpriteWindow(WindowTitle);
            SpriteWindow.OnLoadResources += _onLoadResources;
            SpriteWindow.Form.Text = @"Loading...";
            SpriteWindow.DoEvents();

            while (!_loadResourcesComplete)
            {
                Thread.Sleep(100);
                SpriteWindow.DoEvents();
            }

            SpriteWindow.Form.Text = WindowTitle;
        }

        public void SetLoadResourcesComplete()
        {
            _loadResourcesComplete = true;
        }

        public void Run(IScene startScene)
        {
            if (!_loadResourcesComplete)
                throw new SystemException("Resources not loaded.");

            CurrentScene = startScene;

            var stopwatch = new Stopwatch();

            while (SpriteWindow.Running)
            {
                stopwatch.Restart();
                CurrentScene.Render(this);
                var sleep = 17 - stopwatch.ElapsedMilliseconds;

                if (sleep > 0)
                    Thread.Sleep((int)sleep);
            }
        }

        public void SetScene(IScene scene)
        {
            CurrentScene = scene;
        }
    }
}