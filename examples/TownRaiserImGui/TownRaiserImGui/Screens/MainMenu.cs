
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

namespace TownRaiserImGui.Screens
{
	public partial class MainMenu
	{
        bool hasRespondedToInput = false;
		void CustomInitialize()
		{


		}

		void CustomActivity(bool firstTimeCalled)
		{
            if(!hasRespondedToInput)
            {
                if(GuiManager.Cursor.PrimaryClick || InputManager.Keyboard.AnyKeyPushed())
                {
                    hasRespondedToInput = true;
                    this.InstructionText.Text = "Loading...";
                    // give it 1 so the loading text displays:
                }

            }
            else
            {

                MoveToScreen(typeof(GameScreen));

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
