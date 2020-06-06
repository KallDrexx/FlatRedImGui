using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall;
using Microsoft.Xna.Framework;

#if !FRB_MDX
using System.Linq;
#endif

namespace TownRaiserImGui
{
	internal static class CameraSetup
	{
            // This is a generated file created by Glue. To change this file, edit the camera settings in Glue.
            // To access the camera settings, push the camera icon.
            internal static void SetupCamera (Camera cameraToSetUp, GraphicsDeviceManager graphicsDeviceManager) 
            {
                SetupCamera(cameraToSetUp, graphicsDeviceManager, 800, 600);
            }
            internal static void SetupCamera (Camera cameraToSetUp, GraphicsDeviceManager graphicsDeviceManager, int width, int height) 
            {
                cameraToSetUp.UsePixelCoordinates(false, 400, 300);
            }
            internal static void ResetCamera (Camera cameraToReset) 
            {
                cameraToReset.X = 0;
                cameraToReset.Y = 0;
                cameraToReset.XVelocity = 0;
                cameraToReset.YVelocity = 0;
                // Glue does not generate a detach call because the camera may be attached by this point
            }

	}
}
