
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedImGui;
using Microsoft.Xna.Framework;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TownRaiserImGui.ImGuiControls;

namespace TownRaiserImGui
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        private DemoWindow _demoWindow;
        private ImGuiManager _imGuiManager;

        public Game1() : base()
        {
            graphics = new GraphicsDeviceManager(this);

#if WINDOWS_PHONE || ANDROID || IOS

            // Frame rate is 30 fps by default for Windows Phone,
            // so let's keep that for other phones too
            TargetElapsedTime = TimeSpan.FromTicks(333333);
            graphics.IsFullScreen = true;
#elif WINDOWS || DESKTOP_GL
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
#endif


#if WINDOWS_8
            FlatRedBall.Instructions.Reflection.PropertyValuePair.TopLevelAssembly = 
                this.GetType().GetTypeInfo().Assembly;
#endif

        }

        protected override void Initialize()
        {
            #if IOS
            var bounds = UIKit.UIScreen.MainScreen.Bounds;
            var nativeScale = UIKit.UIScreen.MainScreen.Scale;
            var screenWidth = (int)(bounds.Width * nativeScale);
            var screenHeight = (int)(bounds.Height * nativeScale);
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            #endif
        
            IsMouseVisible = true;

            FlatRedBallServices.InitializeFlatRedBall(this, graphics);
            FlatRedBallServices.GraphicsOptions.TextureFilter = TextureFilter.Point;

			CameraSetup.SetupCamera(SpriteManager.Camera, graphics);
            GlobalContent.Initialize();
            FlatRedBall.Screens.ScreenManager.Start(typeof(TownRaiserImGui.Screens.MainMenu));

            //Setup a custom 
            CustomCursorGraphicController.Initialize(this);

            _imGuiManager = new ImGuiManager(this);
            _demoWindow = new DemoWindow { IsVisible = false };
            _imGuiManager.AddElement(_demoWindow);

            base.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            FlatRedBallServices.Update(gameTime);
            FlatRedBall.Screens.ScreenManager.Activity();

            if (InputManager.Keyboard.KeyReleased(Keys.F12))
            {
                _demoWindow.IsVisible = !_demoWindow.IsVisible;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            FlatRedBallServices.Draw();

            base.Draw(gameTime);
        }
    }
}
