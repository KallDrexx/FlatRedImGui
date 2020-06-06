#region Usings

using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;

using FlatRedBall.Math.Geometry;
using FlatRedBall.Math.Splines;
using BitmapFont = FlatRedBall.Graphics.BitmapFont;
using Cursor = FlatRedBall.Gui.Cursor;
using GuiManager = FlatRedBall.Gui.GuiManager;
using Gum.Wireframe;
using FlatRedBall.Math;

#if FRB_XNA || SILVERLIGHT
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Vector3 = Microsoft.Xna.Framework.Vector3;
using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;

#endif
#endregion

namespace TownRaiserImGui.Entities
{
	public partial class GroupSelector
	{

        bool isDragging = false;

        GraphicalUiElement visualRepresentation;
        public GraphicalUiElement VisualRepresentation
        {
            get { return visualRepresentation; }
            set { visualRepresentation = value; visualRepresentation.Visible = false; }
        }

        public bool IsInSelectionMode { get; set; }

        public float StartWorldX { get; private set; }
        public float StartWorldY { get; private set;}

        public float EndWorldX { get; private set; }
        public float EndWorldY { get; private set; }

        public event EventHandler SelectionFinished;

        public bool WasReleasedThisFrame { get; set; }

        /// <summary>
        /// Initialization logic which is execute only one time for this Entity (unless the Entity is pooled).
        /// This method is called when the Entity is added to managers. Entities which are instantiated but not
        /// added to managers will not have this method called.
        /// </summary>
		private void CustomInitialize()
		{


		}

		private void CustomActivity()
		{
            WasReleasedThisFrame = false;
            if(IsInSelectionMode)
            {
                var cursor = GuiManager.Cursor;

                if(cursor.PrimaryPush  && cursor.WindowOver == null)
                {
                    VisualRepresentation.Visible = true;

                    StartWorldX = cursor.WorldXAt(0);
                    StartWorldY = cursor.WorldYAt(0);

                    isDragging = true;
                }

                if(isDragging)
                {
                    EndWorldX = cursor.WorldXAt(0);
                    EndWorldY = cursor.WorldYAt(0);

                    SetFromWorldUnits(
                        System.Math.Min(StartWorldX, EndWorldX), 
                        System.Math.Max(StartWorldX, EndWorldX),
                        System.Math.Max(StartWorldY, EndWorldY), 
                        System.Math.Min(StartWorldY, EndWorldY));
                }

                if (cursor.PrimaryClick && isDragging)
                {
                    VisualRepresentation.Visible = false;
                    isDragging = false;

                    float minimumMovementForGroupSelection = 2;

                    if (Math.Abs(StartWorldX - EndWorldX) > minimumMovementForGroupSelection || 
                        Math.Abs(StartWorldY - EndWorldY) > minimumMovementForGroupSelection)
                    {
                        this.X = (StartWorldX + EndWorldX) / 2.0f;
                        this.Y = (StartWorldY + EndWorldY) / 2.0f;

                        this.AxisAlignedRectangleInstance.Width =
                            System.Math.Max(StartWorldX, EndWorldX) - System.Math.Min(StartWorldX, EndWorldX);

                        this.AxisAlignedRectangleInstance.Width =
                            System.Math.Max(StartWorldX, EndWorldX) - System.Math.Min(StartWorldX, EndWorldX);
                        this.AxisAlignedRectangleInstance.Height =
                            System.Math.Max(StartWorldY, EndWorldY) - System.Math.Min(StartWorldY, EndWorldY);

                        this.SelectionFinished?.Invoke(this, null);

                        WasReleasedThisFrame = true;
                    }
                }
            }

		}

		private void CustomDestroy()
		{


		}

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }

        public void SetFromWorldUnits(float left, float right, float top, float bottom)
        {
            int leftScreen = 0;
            int topScreen = 0;
            int bottomScreen = 0;
            int rightScreen = 0;
            MathFunctions.AbsoluteToWindow(left, top, 0, ref leftScreen, ref topScreen, Camera.Main);
            MathFunctions.AbsoluteToWindow(right, bottom, 0, ref rightScreen, ref bottomScreen, Camera.Main);

            // we're 2x zoomed:
            leftScreen /= 2;
            topScreen /= 2;
            bottomScreen /= 2;
            rightScreen /= 2;

            VisualRepresentation.X = leftScreen;
            VisualRepresentation.Y = topScreen;
            VisualRepresentation.Width = rightScreen - leftScreen;
            VisualRepresentation.Height = bottomScreen - topScreen;
        }
    }
}
