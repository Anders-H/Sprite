using System;
using System.Threading;

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
            SpriteWindow.Form.Text = "Loading...";
            SpriteWindow.DoEvents();

            while (!_loadResourcesComplete)
            {
                Thread.Sleep(100);
                Thread.Yield();
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

            while (SpriteWindow.Running)
            {
                CurrentScene.Render(this);
            }
        }

        public void SetScene(IScene scene)
        {
            CurrentScene = scene;
        }
    }
}