
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;

using FlatRedBall.Math.Geometry;
using FlatRedBall.Math.Splines;

using Cursor = FlatRedBall.Gui.Cursor;
using GuiManager = FlatRedBall.Gui.GuiManager;
using FlatRedBall.Localization;

using Keys = Microsoft.Xna.Framework.Input.Keys;
using Vector3 = Microsoft.Xna.Framework.Vector3;
using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;
using FlatRedBall.Gui;
using TownRaiserImGui.GumRuntimes;

namespace TownRaiserImGui.Screens
{
	public partial class TestScreen
	{

		void CustomInitialize()
		{

            //this.ColoredRectangleInstance.Children.Add(button);

		}

        private void HandleClick(IWindow window)
        {
            //int m = 3;
        }

        private void HandleLosePush(IWindow window)
        {

        }

        void CustomActivity(bool firstTimeCalled)
		{
            var keyboard = InputManager.Keyboard;

            if(keyboard.KeyPushed(Keys.Up))
            {
                var button = new IconButtonRuntime();
                button.Parent = this.StackingContainer;
                button.Click += HandleClick;
            }
            else if(keyboard.KeyPushed(Keys.Down))
            {
                var buttonToRemove = this.StackingContainer.Children.Last() as IconButtonRuntime;

                if(buttonToRemove != null)
                {
                    buttonToRemove.Parent = null;
                }
            }
        }

		void CustomDestroy()
		{


		}

        static void CustomLoadStaticContent(string contentManagerName)
        {


        }

	}
}
