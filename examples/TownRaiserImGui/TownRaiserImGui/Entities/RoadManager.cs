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
using FlatRedBall.Math;
using System.Collections.Specialized;
using Microsoft.Xna.Framework;
using System.Linq;

namespace TownRaiserImGui.Entities
{
	public partial class RoadManager
	{
        PositionedObjectList<Building> allBuildings;


        /// <summary>
        /// Initialization logic which is execute only one time for this Entity (unless the Entity is pooled).
        /// This method is called when the Entity is added to managers. Entities which are instantiated but not
        /// added to managers will not have this method called.
        /// </summary>
		private void CustomInitialize()
		{


		}

        public void SetBuildings(PositionedObjectList<Building> buildings)
        {
            allBuildings = buildings;
        }
        private void CustomActivity()
		{


		}

        public void RefreshRoadsForBuilding(Building building, bool wasAdded)
        {
            if(wasAdded)
            {
                UpdateRoadsAround(building.Position, hasBuilding:true);
            }
            else
            {
                UpdateRoadsAround(building.Position, hasBuilding:false);
            }
        }

        private void UpdateRoadsAround(Vector3 position, bool hasBuilding)
        {
            position.Z = this.Z;

            const float tileWidth = 16;
            const float smallOffset = tileWidth / 2.0f;
            const float edgeOffset = tileWidth * 1.5f;
            const float buildingOffset = tileWidth * 3;

            bool buildingAbove = HasBuildingAt(position + new Vector3(0, buildingOffset, 0));
            bool buildingBelow = HasBuildingAt(position + new Vector3(0, -buildingOffset, 0));
            bool buildingLeft = HasBuildingAt(position + new Vector3(-buildingOffset, 0, 0));
            bool buildingRight = HasBuildingAt(position + new Vector3(buildingOffset, 0, 0));

            bool buildingAboveLeft = HasBuildingAt(position + new Vector3(-buildingOffset, buildingOffset, 0));
            bool buildingAboveRight = HasBuildingAt(position + new Vector3(buildingOffset, buildingOffset, 0));
            bool buildingBelowLeft = HasBuildingAt(position + new Vector3(-buildingOffset, -buildingOffset, 0));
            bool buildingBelowRight = HasBuildingAt(position + new Vector3(buildingOffset, -buildingOffset, 0));


            bool showAbove = hasBuilding || buildingAbove;
            bool showBelow = hasBuilding || buildingBelow;
            bool showLeft = hasBuilding || buildingLeft;
            bool showRight = hasBuilding || buildingRight;

            UpdateRoadSprite(position + new Vector3(-smallOffset, edgeOffset, 0), showAbove, "Horizontal");
            UpdateRoadSprite(position + new Vector3( smallOffset, edgeOffset, 0), showAbove, "Horizontal");

            UpdateRoadSprite(position + new Vector3(edgeOffset, smallOffset, 0), showRight, "Vertical");
            UpdateRoadSprite(position + new Vector3(edgeOffset, -smallOffset, 0), showRight, "Vertical");

            UpdateRoadSprite(position + new Vector3(-edgeOffset,-smallOffset, 0), showLeft, "Vertical");
            UpdateRoadSprite(position + new Vector3(-edgeOffset, smallOffset, 0), showLeft, "Vertical");

            UpdateRoadSprite(position + new Vector3(-smallOffset, -edgeOffset, 0), showBelow, "Horizontal");
            UpdateRoadSprite(position + new Vector3(smallOffset, -edgeOffset, 0), showBelow, "Horizontal");

            string topLeftSprite = "Cross";
            if ((buildingAbove && buildingLeft) || buildingAboveLeft)
            {
                topLeftSprite = "Cross";
            }
            else if(buildingLeft)
            {
                topLeftSprite = "TTop";
            }
            else if(buildingAbove)
            {
                topLeftSprite = "HLeft";
            }
            else
            {
                topLeftSprite = "CornerTL";
            }

            string topRightSprite = "Cross";
            if((buildingAbove && buildingRight) || buildingAboveRight)
            {
                topRightSprite = "Cross";
            }
            else if(buildingRight)
            {
                topRightSprite = "TTop";
            }
            else if(buildingAbove)
            {
                topRightSprite = "HRight";
            }
            else
            {
                topRightSprite = "CornerTR";
            }



            string bottomLeftSprite = "Cross";
            if((buildingBelow && buildingLeft) || buildingBelowLeft)
            {
                bottomLeftSprite = "Cross";
            }
            else if(buildingLeft)
            {
                bottomLeftSprite = "TBottom";
            }
            else if(buildingBelow)
            {
                bottomLeftSprite = "HLeft";
            }
            else
            {
                bottomLeftSprite = "CornerBL";
            }

            string bottomRightSprite = "Cross";
            if((buildingBelow && buildingRight) || buildingBelowRight)
            {
                bottomRightSprite = "Cross";
            }
            else if(buildingRight)
            {
                bottomRightSprite = "TBottom";
            }
            else if(buildingBelow)
            {
                bottomRightSprite = "HRight";
            }
            else
            {
                bottomRightSprite = "CornerBR";
            }

            UpdateRoadSprite(position + new Vector3(-edgeOffset, edgeOffset, 0), showAbove || showLeft, topLeftSprite);
            UpdateRoadSprite(position + new Vector3(edgeOffset, edgeOffset, 0), showAbove || showRight, topRightSprite);
            UpdateRoadSprite(position + new Vector3(edgeOffset, -edgeOffset, 0), showBelow || showLeft, bottomRightSprite);
            UpdateRoadSprite(position + new Vector3(-edgeOffset, -edgeOffset, 0), showBelow || showRight, bottomLeftSprite);
        }

        private void UpdateRoadSprite(Vector3 position, bool showAbove, string chainName)
        {
            Sprite spriteAt = GetRoadSpriteAt(position);

            if(spriteAt == null && showAbove)
            {
                spriteAt = new Sprite();
                spriteAt.Position = position;
                spriteAt.TextureScale = 1;
                spriteAt.AnimationChains = AnimationChainListFile;

                SpriteManager.AddSprite(spriteAt);
                this.Sprites.Add(spriteAt);
                this.Sprites.SortXInsertionAscending();
            }
            if(spriteAt != null && !showAbove)
            {
                SpriteManager.RemoveSprite(spriteAt);
            }

            if(spriteAt != null)
            {
                spriteAt.CurrentChainName = chainName;
            }
        }

        private Sprite GetRoadSpriteAt(Vector3 position)
        {
            var startIndex = Sprites.GetFirstAfter(position.X - 1, Axis.X, 0, Sprites.Count);

            var endIndexExclusive = Sprites.GetFirstAfter(position.X + 1, Axis.X, startIndex, Sprites.Count);

            for(int i = startIndex; i < endIndexExclusive; i++)
            {
                var sprite = Sprites[i];
                if(position.X > sprite.Left && position.X < sprite.Right && position.Y > sprite.Bottom && position.Y < sprite.Top)
                {
                    return sprite;
                }
            }

            return null;
        }

        private bool HasBuildingAt(Vector3 position)
        {
            return allBuildings.Any(item => item.Collision.IsPointInside(position.X, position.Y));
        }

        private void CustomDestroy()
		{


		}

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }
	}
}
