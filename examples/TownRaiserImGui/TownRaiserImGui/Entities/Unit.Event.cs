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
namespace TownRaiserImGui.Entities
{
	public partial class Unit
	{
        void OnAfterUnitDataSet (object sender, EventArgs e)
        {
            var animationName = this.UnitData.Name;
            this.SpriteInstance.CurrentChainName = animationName;
            // line up the bottom of the sprite
            this.SpriteInstance.UpdateToCurrentAnimationFrame();
            this.SpriteInstance.RelativeY = this.SpriteInstance.Height / 2.0f;


            this.CurrentHealth = this.UnitData.Health;
            this.ShadowSprite.CurrentChainName = "Shadow" + UnitData.Size;
        }
		
	}
}
