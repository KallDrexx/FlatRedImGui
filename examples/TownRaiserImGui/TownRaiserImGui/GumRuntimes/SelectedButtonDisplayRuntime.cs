using FlatRedBall.Graphics.Animation;
using FlatRedBall.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownRaiserImGui.DataTypes;
using TownRaiserImGui.Interfaces;

namespace TownRaiserImGui.GumRuntimes
{
    public partial class SelectedButtonDisplayRuntime
    {
        private ICommonEntityData m_HotKeyData;
        public ICommonEntityData HotkeyData
        {
            get
            {
                return m_HotKeyData;
            }
            set
            {
                if (value == null)
                {
                    throw new Exception("Something went wrong. Trying to set hotkey data with null value.");
                }
                if (value != null)
                {
                    m_HotKeyData = value;
                    SetIconFrom(GlobalContent.GumAnimationChains[m_HotKeyData.DataName]);
                }
            }
        }

        public BuildingData HotKeyDataAsBuildingData => m_HotKeyData as BuildingData;
        public UnitData HotKeyDataAsUnitData => m_HotKeyData as UnitData;

        public void SetIconFrom(AnimationChain animationChain)
        {
            // this assumes the chain only has 1 frame so we grab that frame and set it on the sprite:
            var frame = animationChain[0];
            var textureWidth = frame.Texture.Width;
            var textureHeight = frame.Texture.Height;

            this.SpriteInstance.TextureLeft = MathFunctions.RoundToInt(frame.LeftCoordinate * (float)textureWidth);
            this.SpriteInstance.TextureTop = MathFunctions.RoundToInt(frame.TopCoordinate * (float)textureHeight);
            this.SpriteInstance.TextureWidth = MathFunctions.RoundToInt((frame.RightCoordinate - frame.LeftCoordinate) * (float)textureWidth);

        }
    }
}
