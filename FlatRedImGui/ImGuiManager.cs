using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FlatRedBall;
using FlatRedBall.Graphics;
using FlatRedBall.Gui;
using FlatRedBall.Screens;
using ImGuiNET;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlatRedImGui
{
    public class ImGuiManager
    {
        public static ImGuiManager Current { get; private set; }
        
        private readonly ImGuiRenderer _renderer;
        private readonly List<ImGuiElement> _elements = new List<ImGuiElement>();
        private readonly Game _game;
        
        /// <summary>
        /// If true than ImGui elements are currently accepting mouse inputs.  This can be used to detect if the game
        /// should react to the mouse or not, to prevent the game from reacting to mouse input meant for UI elements.
        /// </summary>
        public bool AcceptingMouseInput { get; private set; }
        
        /// <summary>
        /// If true than ImGui elements are currently accepting keyboard inputs.  This can be used to detect if the
        /// game should react to key presses or ignore them (to prevent input meant for ImGui to affect the game).
        /// </summary>
        public bool AcceptingKeyboardInput { get; private set; }

        public ImGuiManager(Game game)
        {
            if (Current != null)
            {
                throw new InvalidOperationException("Only one ImGuiManager may exist at one time");
            }

            Current = this;
            
            _game = game;
            _renderer = new ImGuiRenderer(game);
            _renderer.RebuildFontAtlas();

            var drawableBatch = new ImGuiDrawableBatch(this);
            var window = new ImGuiWindow(this);
            
            ScreenManager.PersistentDrawableBatches.Add(drawableBatch);
            ScreenManager.PersistentWindows.Add(window);
            SpriteManager.AddDrawableBatch(drawableBatch);
            GuiManager.AddWindow(window);
        }

        public void AddElement(ImGuiElement element)
        {
            _elements.Add(element);
        }

        public void RemoveElement(ImGuiElement element)
        {
            _elements.Remove(element);
        }
        
        private void Draw()
        {
            var oldSamplerState = _game.GraphicsDevice.SamplerStates[0];
            _game.GraphicsDevice.SamplerStates[0] = new SamplerState();
            
            _renderer.BeforeLayout(TimeManager.LastUpdateGameTime);

            foreach (var element in _elements)
            {
                element.Render();
            }
            
            var io = ImGui.GetIO();
            AcceptingKeyboardInput = io.WantCaptureKeyboard;
            AcceptingMouseInput = io.WantCaptureMouse;

            _renderer.AfterLayout();
            _game.GraphicsDevice.SamplerStates[0] = oldSamplerState;
        }

        private class ImGuiDrawableBatch : IDrawableBatch
        {
            private readonly ImGuiManager _manager;

            public float X { get; set; }
            public float Y { get; set; }
            public float Z { get; set; } = 20;
            public bool UpdateEveryFrame { get; } = false;

            public ImGuiDrawableBatch(ImGuiManager manager)
            {
                _manager = manager;
            }
            
            public void Draw(Camera camera)
            {
                _manager.Draw();
            }

            public void Update() { }

            public void Destroy() { }
        }
        
        private class ImGuiWindow : IWindow
        {
            private readonly ImGuiManager _manager;

            public ImGuiWindow(ImGuiManager manager)
            {
                _manager = manager;
            }

            public string Name { get; set; }
            public Layer Layer { get; }
            public bool Visible { get; set; } = true;
            public ReadOnlyCollection<IWindow> Children { get; }
            public bool Enabled { get; set; } = true;
            public bool MovesWhenGrabbed { get; set; }
            public bool GuiManagerDrawn { get; set; }
            public bool IgnoredByCursor { get; set; }
            public ReadOnlyCollection<IWindow> FloatingChildren { get; }
            public float WorldUnitX { get; set; }
            public float WorldUnitY { get; set; }
            public float WorldUnitRelativeX { get; set; }
            public float WorldUnitRelativeY { get; set; }
            public float ScaleX { get; set; }
            public float ScaleY { get; set; }
            public float X { get; set; }
            public float Y { get; set; }
            public float Z { get; } = 20;
            public IWindow Parent { get; set; }
            public event WindowEvent Click;
            public event WindowEvent ClickNoSlide;
            public event WindowEvent SlideOnClick;
            public event WindowEvent Push;
            public event WindowEvent DragOver;
            public event WindowEvent RollOn;
            public event WindowEvent RollOff;
            public event WindowEvent RollOver;
            public event WindowEvent EnabledChange;
            IVisible IVisible.Parent { get; }
            public bool AbsoluteVisible { get; }
            public bool IgnoresParentVisibility { get; set; }

            public bool HasCursorOver(Cursor cursor) => _manager.AcceptingMouseInput;
            
            public bool IsPointOnWindow(float x, float y) => _manager.AcceptingMouseInput;

            public void TestCollision(Cursor cursor)
            {
                if (_manager.AcceptingMouseInput)
                {
                    cursor.WindowPushed = this;
                    cursor.WindowOver = this;
                }
            }

            public void Activity(Camera camera) { }

            public void CallRollOff() { }

            public void CallRollOn() { }

            public void CallRollOver() { }

            public void CallClick() { }

            public void CloseWindow() { }

            public void OnDragging() { }

            public void OnResize() { }

            public void OnResizeEnd() { }

            public void OnLosingFocus() { }

            public void SetScaleTL(float newScaleX, float newScaleY) { }

            public void SetScaleTL(float newScaleX, float newScaleY, bool keepTopLeftStatic) { }

            public void UpdateDependencies() { }

            public bool GetParentVisibility() => false;

            public bool OverlapsWindow(IWindow otherWindow) => false;
        }
    }
}