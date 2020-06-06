using System;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Specialized;
using FlatRedBall.Audio;
using FlatRedBall.Screens;
using TownRaiserImGui.Entities;
using TownRaiserImGui.Screens;
namespace TownRaiserImGui.Screens
{
	public partial class GameScreen
	{
        void OnMinimapButtonInstanceClick (FlatRedBall.Gui.IWindow callingWindow)
        {
            this.MinimapInstance.Visible = !this.MinimapInstance.Visible;
        }
		
	}
}
