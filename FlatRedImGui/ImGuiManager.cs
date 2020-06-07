using System.Collections.Generic;
using FlatRedBall;
using FlatRedBall.Graphics;
using FlatRedBall.Gui;
using FlatRedBall.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlatRedImGui
{
    public class ImGuiManager : IDrawableBatch
    {
        private readonly ImGuiRenderer _renderer;
        private readonly List<ImGuiElement> _elements = new List<ImGuiElement>();
        private readonly Game _game;

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; } = 20;
        public bool UpdateEveryFrame { get; } = false;

        public ImGuiManager(Game game)
        {
            _game = game;
            _renderer = new ImGuiRenderer(game);
            _renderer.RebuildFontAtlas();
            
            ScreenManager.PersistentDrawableBatches.Add(this);
            SpriteManager.AddDrawableBatch(this);
        }

        public void AddElement(ImGuiElement element)
        {
            _elements.Add(element);
        }

        public void RemoveElement(ImGuiElement element)
        {
            _elements.Remove(element);
        }
        
        public void Draw(Camera camera)
        {
            var oldSamplerState = _game.GraphicsDevice.SamplerStates[0];
            _game.GraphicsDevice.SamplerStates[0] = new SamplerState();
            
            _renderer.BeforeLayout(TimeManager.LastUpdateGameTime);
            
            foreach (var element in _elements)
            {
                element.Render();
            }
            
            _renderer.AfterLayout();
            _game.GraphicsDevice.SamplerStates[0] = oldSamplerState;
        }

        public void Update()
        {
        }

        public void Destroy()
        {
        }
    }
}