using FlatRedBall;
using FlatRedBall.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownRaiserImGui.GumRuntimes
{
    partial class HealthBarRuntime
    {

        partial void CustomInitialize()
        {
        }

        public void PositionTo(PositionedObject positionedObject, float yOffset)
        {
            int screenX = 0;
            int screenY = 0;

            MathFunctions.AbsoluteToWindow(positionedObject.X, positionedObject.Y, positionedObject.Z, ref screenX, ref screenY, Camera.Main);

            var zoom = Managers.Renderer.Camera.Zoom;


            X = screenX / zoom;
            Y = yOffset + screenY / zoom;
        }

    }


}
