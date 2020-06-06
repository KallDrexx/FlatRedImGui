using FlatRedBall;
using FlatRedBall.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownRaiserImGui.Entities;
using FlatRedBall.Gui;

namespace TownRaiserImGui.GumRuntimes
{
    public partial class MinimapContentsRuntime
    {
        List<ColoredRectangleRuntime> unitRectangles = new List<ColoredRectangleRuntime>();
        List<ColoredRectangleRuntime> buildingRectangles = new List<ColoredRectangleRuntime>();

        const float divisor = 16;

        partial void CustomInitialize()
        {
            this.DragOver += UpdateCameraPositionToCursor;
            this.Push += UpdateCameraPositionToCursor;
        }

        private void UpdateCameraPositionToCursor(IWindow window)
        {
            var cursor = GuiManager.Cursor;
            var screenX = cursor.ScreenX/2;
            var screenY = cursor.ScreenY/2;

            var relativeX = screenX - ((RenderingLibrary.IPositionedSizedObject)this).X;
            var relativeY = screenY - ((RenderingLibrary.IPositionedSizedObject)this).Y;

            FlatRedBall.Camera.Main.X = relativeX * divisor;
            FlatRedBall.Camera.Main.Y = -relativeY * divisor;
        }

        public void UpdateTo(PositionedObjectList<Unit> units, PositionedObjectList<Building> buildings)
        {
            UpdateRectangleCount(unitRectangles, units);
            UpdateRectangleCount(buildingRectangles, buildings, 255, 255, 0);

            for (int i = 0; i < units.Count; i++)
            {
                if (units[i].UnitData.IsEnemy)
                {
                    unitRectangles[i].Red = 255;
                    unitRectangles[i].Green = 0;
                    unitRectangles[i].Blue = 0;
                }
                else
                {
                    unitRectangles[i].Red = 0;
                    unitRectangles[i].Green = 255;
                    unitRectangles[i].Blue = 0;
                }
                UpdatePosition(unitRectangles[i], units[i]);
            }

            for(int i = 0; i < buildings.Count; i++)
            {

                UpdatePosition(buildingRectangles[i], buildings[i]);
            }

            this.CameraFrame.X = Camera.Main.X / divisor;
            this.CameraFrame.Y = -Camera.Main.Y / divisor;
            this.CameraFrame.Width = Camera.Main.OrthogonalWidth / divisor;
            this.CameraFrame.Height = Camera.Main.OrthogonalHeight / divisor;
        }

        private void UpdateRectangleCount<T>(List<ColoredRectangleRuntime> gumRectangles, PositionedObjectList<T> positionedObjects,
            int red = 255, int green =255, int blue = 255) where T : PositionedObject
        {
            while (gumRectangles.Count < positionedObjects.Count)
            {
                var rectangle = CreateNewRectangle();
                rectangle.Red = red;
                rectangle.Green = green;
                rectangle.Blue = blue;

                gumRectangles.Add(rectangle);
            }
            while (gumRectangles.Count > positionedObjects.Count)
            {
                gumRectangles.Last().Parent = null;
                gumRectangles.RemoveAt(gumRectangles.Count - 1);
            }
        }

        private void UpdatePosition(ColoredRectangleRuntime coloredRectangleRuntime, PositionedObject frbObject)
        {
            coloredRectangleRuntime.X = frbObject.X / divisor;
            coloredRectangleRuntime.Y = -frbObject.Y / divisor;
        }

        private ColoredRectangleRuntime CreateNewRectangle()
        {
            var rectangle = new ColoredRectangleRuntime();
            rectangle.Parent = this;
            rectangle.Width = 1;
            rectangle.Height = 1;
            rectangle.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
            rectangle.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
            return rectangle;
        }
    }
}
