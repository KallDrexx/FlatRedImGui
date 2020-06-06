using FlatRedBall.Graphics.Animation;
using FlatRedBall.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownRaiserImGui.DataTypes;
using TownRaiserImGui.Entities;
using TownRaiserImGui.Interfaces;

namespace TownRaiserImGui.GumRuntimes
{
    public partial class IconButtonRuntime
    {
        public IUpdatesStatus EntityCreatedFrom;

        private float m_ProgressSpriteOriginalTopCoordinate;
        private float m_ProgressSpriteOriginalHeight;

        private ICommonEntityData m_HotKeyData;
        public ICommonEntityData HotkeyData
        {
            get
            {
                return m_HotKeyData;
            }
            set
            {
                if(value == null)
                {
                    throw new Exception("Something went wrong. Trying to set hotkey data with null value.");
                }
                if(value != null)
                {
                    m_HotKeyData = value;
                    SetIconFrom(GlobalContent.GumAnimationChains[m_HotKeyData.DataName]);
                }
            }
        }

        public BuildingData HotKeyDataAsBuildingData => m_HotKeyData as BuildingData;
        public UnitData HotKeyDataAsUnitData => m_HotKeyData as UnitData;

        partial void CustomInitialize()
        {
            m_ProgressSpriteOriginalTopCoordinate = this.ProgressSprite.TextureTop;
            m_ProgressSpriteOriginalHeight = this.ProgressSprite.TextureHeight;
        }

        public void SetIconFrom(AnimationChain animationChain)
        {
            // this assumes the chain only has 1 frame so we grab that frame and set it on the sprite:
            var frame = animationChain[0];
            var textureWidth = frame.Texture.Width;
            var textureHeight = frame.Texture.Height;

            this.SpriteInstance.TextureLeft = MathFunctions.RoundToInt( frame.LeftCoordinate * (float)textureWidth);
            this.SpriteInstance.TextureTop = MathFunctions.RoundToInt(frame.TopCoordinate * (float)textureHeight);
            this.SpriteInstance.TextureWidth = MathFunctions.RoundToInt((frame.RightCoordinate - frame.LeftCoordinate) * (float)textureWidth);
            this.SpriteInstance.TextureHeight = MathFunctions.RoundToInt((frame.BottomCoordinate - frame.TopCoordinate) * (float)textureHeight);
        }

        public void UpdateButtonEnabledState(int lumber, int stone, int gold, int currentCapacity, int maxCapacity, IEnumerable<Building> existingBuildings, IUpdatesStatus selectedBuilding)
        {
            var isEnabled = m_HotKeyData.ShouldEnableButton(lumber, stone, gold, currentCapacity, maxCapacity, existingBuildings, EntityCreatedFrom);

            //Only enable the button if the selected builidng has completed construction.
            if(selectedBuilding != null)
            {
                isEnabled &= selectedBuilding.IsConstructionComplete;
            }
#if DEBUG
            if(Entities.DebuggingVariables.HasInfiniteResources)
            {
                isEnabled = true;
            }
#endif

            Enabled = isEnabled;
        }
        public void UpdateDisplayFromEntiy(IUpdatesStatus selectedEntity)
        {
            var key = HotkeyData.DataName;
            var progressValue = selectedEntity.ProgressPercents.ContainsKey(key) ? selectedEntity.ProgressPercents[key] : 0.0;
            var countValue = selectedEntity.ButtonCountDisplays.ContainsKey(key) ? selectedEntity.ButtonCountDisplays[key] : 0;

            if(progressValue > 0)
            {
                this.ProgressSprite.Visible = true;
                var currentTextureHeight = MathFunctions.RoundToInt(this.Height * progressValue);
                var heightDifference = m_ProgressSpriteOriginalHeight - currentTextureHeight;
                var newTop = (int)(m_ProgressSpriteOriginalTopCoordinate + heightDifference); //Add to move down the texture.

                this.ProgressSprite.TextureHeight = currentTextureHeight;
                this.ProgressSprite.TextureTop = newTop;

            }
            else
            {
                this.ProgressSprite.Visible = false;

            }

            if (countValue > 0)
            {
                this.TextInstance.Visible = true;
                this.TextInstance.Text = $"{countValue}";
            }
            else
            {
                this.TextInstance.Visible = false;
            }
        }
    }
}
