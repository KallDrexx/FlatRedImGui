using FlatRedBall.AI.Pathfinding;
using System.Linq;
using TownRaiserImGui.Entities;
using FlatRedBall.Math.Geometry;
using Microsoft.Xna.Framework;
using TownRaiserImGui.Screens;
using FlatRedBall.Math;
using TownRaiserImGui.DataTypes;

namespace TownRaiserImGui.AI
{
    class ResourceReturnHighLevelGoal : HighLevelGoal
    {
        WalkToHighLevelGoal currentWalkGoal;

        public Unit Owner { get; private set; }
        public TileNodeNetwork NodeNetwork { get; private set; }

        public ResourceType TargetResourceType { get; private set; }

        public Building ResourceReturnBuilding { get; set; }
        public AxisAlignedRectangle ResourceReturnBuildingTile { get; set; }

        static AxisAlignedRectangle GetSingleTile(Vector3 singleTileCenter)
        {
            float roundedX = MathFunctions.RoundFloat(singleTileCenter.X - GameScreen.GridWidth / 2.0f, GameScreen.GridWidth);
            float roundedY = MathFunctions.RoundFloat(singleTileCenter.Y - GameScreen.GridWidth / 2.0f, GameScreen.GridWidth);

            AxisAlignedRectangle newAar = new AxisAlignedRectangle();
            newAar.Width = GameScreen.GridWidth;
            newAar.Height = GameScreen.GridWidth;
            newAar.Left = roundedX;
            newAar.Bottom = roundedY;
            newAar.Visible = false;

#if DEBUG
            newAar.Visible = DebuggingVariables.ShowResourceCollision;
#endif

            return newAar;
        }

        public ResourceReturnHighLevelGoal(Unit owner, TileNodeNetwork nodeNetwork, Building targetReturnBuilding)
        {
            Owner = owner;
            NodeNetwork = nodeNetwork;

            ResourceReturnBuilding = targetReturnBuilding;
            ResourceReturnBuildingTile = GetSingleTile(ResourceReturnBuilding.Position);
        }

        bool shouldWeGiveUpReturning = false;
        public override bool GetIfDone()
        {
            // Resources are unlimited, only restricted by mosh pit of units trying to harvest simultaneously.
            return shouldWeGiveUpReturning;
        }

        /// <summary>
        /// Used to adjust a destination Vector3 within tile, askew from center toward the destination.
        /// </summary>
        Vector3 DeterminePositionWithinTileSlightlyCloserToOwner(Vector3 destination, float tileSize)
        {
            Vector3 pointSlightlySkewedTowardOwner;
            // Used to divide the tileSize. (Half was causing weirdness.)
            const float tileSizePortion = 5;
            if (Owner.Position.X > destination.X)
            {
                if (Owner.Position.Y > destination.Y)
                {
                    // Unit is above/right of building. Move target point 
                    pointSlightlySkewedTowardOwner = destination + new Vector3(tileSize / tileSizePortion, tileSize / tileSizePortion, destination.Z);
                }
                else
                {
                    // Unit is below/right of building.
                    pointSlightlySkewedTowardOwner = destination + new Vector3(tileSize / tileSizePortion, tileSize / -tileSizePortion, destination.Z);
                }
            }
            else
            {
                if (Owner.Position.Y > destination.Y)
                {
                    // Unit is above/left of building.
                    pointSlightlySkewedTowardOwner = destination + new Vector3(tileSize / -tileSizePortion, tileSize / tileSizePortion, destination.Z);
                }
                else
                {
                    // Unit is below/right of building.
                    pointSlightlySkewedTowardOwner = destination + new Vector3(tileSize / -tileSizePortion, tileSize / -tileSizePortion, destination.Z);
                }
            }
            return pointSlightlySkewedTowardOwner;
        }

        public WalkToHighLevelGoal GetResourceReturnWalkGoal()
        {
            ResourceReturnBuildingTile = GetSingleTile(ResourceReturnBuilding.Position);
            Vector3 pointSlightlySkewedTowardOwner = DeterminePositionWithinTileSlightlyCloserToOwner(ResourceReturnBuildingTile.Position, ResourceReturnBuildingTile.Width);
            var walkGoal = new WalkToHighLevelGoal()
            {
                Owner = Owner,
                TargetPosition = pointSlightlySkewedTowardOwner,
                ForceAttemptToGetToExactTarget = true,
            };
            return walkGoal;
        }

        bool IsInRangeToReturnResource()
        {
            return Owner.HasResourceToReturn
                && ResourceReturnBuilding != null
                && ResourceReturnBuilding.IsConstructionComplete			
                && Owner.ResourceCollectCircleInstance.CollideAgainst(ResourceReturnBuildingTile);
        }
        void ClearResourceState()
        {
            Owner.SetResourceToReturn(null);
            ResourceReturnBuilding = null;
            ResourceReturnBuildingTile = null;
        }

        void StopMoving()
        {
            currentWalkGoal = null;
            Owner?.ImmediateGoal?.Path?.Clear();
            Owner.Velocity = Vector3.Zero;
        }

        public override void DecideWhatToDo()
        {
            if (IsInRangeToReturnResource())
            {
                // We're close enough to our target return destination: unload!
                StopMoving();

                var screen = FlatRedBall.Screens.ScreenManager.CurrentScreen as GameScreen;

                // If we are trying to return a resource, but the building is a smoldering pile of ashes, stop walking.
                bool areWeReturningResourcesToDestroyedBuilding = Owner.HasResourceToReturn && ResourceReturnBuilding.CurrentHealth <= 0;
                if (areWeReturningResourcesToDestroyedBuilding)
                {
                    currentWalkGoal = null;
                    shouldWeGiveUpReturning = true;
                    return;
                }

                // Increment appropriate resource.
                switch (TargetResourceType)
                {
                    case ResourceType.Gold:
                        screen.Gold += Owner.UnitData.ResourceHarvestAmount;
                        break;
                    case ResourceType.Lumber:
                        screen.Lumber += Owner.UnitData.ResourceHarvestAmount;
                        break;
                    case ResourceType.Stone:
                        screen.Stone += Owner.UnitData.ResourceHarvestAmount;
                        break;
                }
                //Try to play the collect sound.
                screen.TryPlayResourceCollectSound(TargetResourceType, Owner.Position);

                // Update UI
                screen.UpdateResourceDisplay();

                ClearResourceState();
                shouldWeGiveUpReturning = true;
            }
            else
            {
                bool isWalking = Owner?.ImmediateGoal?.Path?.Count > 0;
                if (!isWalking)
                {
                    if (currentWalkGoal == null)
                    {
                        currentWalkGoal = GetResourceReturnWalkGoal();
                        if (currentWalkGoal == null)
                        {
                            // Couldn't get a walk goal back from resource collection. Time to call it quits here.
                            shouldWeGiveUpReturning = true;
                        }
                        else
                        {
                            // Start hiking, unit!
                            currentWalkGoal.DecideWhatToDo();
                        }
                    }
                }
            }
        }
    }

    class ResourceCollectHighLevelGoal : HighLevelGoal
    {
        WalkToHighLevelGoal currentWalkGoal;
        
        public Unit Owner { get; private set; }
        public TileNodeNetwork NodeNetwork { get; private set; }
        
        /// <summary>
        /// The center of the desired resource tile, as if it weren't merged with any neighbors.
        /// </summary>
        public Vector3 SingleTargetResourceTileCenter { get; private set; }
        /// <summary>
        /// The AxisAlignedRectangle that represents what would be our desired resource tile, as if it weren't merged with any neighbors.
        /// </summary>
        public AxisAlignedRectangle SingleTargetResourceTile { get; private set; }
        public AxisAlignedRectangle TargetResourceMergedTile { get; private set; }
        public ResourceType TargetResourceType { get; private set; }

        public PositionedObjectList<Building> AllBuildings { get; set; }
        public Building ResourceReturnBuilding { get; set; }
        public AxisAlignedRectangle ResourceReturnBuildingTile { get; set; }

        /// <summary>
        /// Find the center of the tile clicked on, rather than finding the node nearest the click (which could be opposite side of closest node).
        /// </summary>
        /// <param name="clickPosition">Center of resource clicked on, as if it weren't part of a merged group.</param>
        /// <returns></returns>
        static Vector3 GetSingleTileCenterFromClickPosition(Vector3 clickPosition)
        {
            const float tilesWide = 1;
            return new Vector3(
                MathFunctions.RoundFloat(clickPosition.X, GameScreen.GridWidth * tilesWide, GameScreen.GridWidth * tilesWide / 2),
                MathFunctions.RoundFloat(clickPosition.Y, GameScreen.GridWidth * tilesWide, GameScreen.GridWidth * tilesWide / 2),
                0);
        }
        static AxisAlignedRectangle GetSingleTile(Vector3 singleTileCenter)
        {
            float roundedX = MathFunctions.RoundFloat(singleTileCenter.X - GameScreen.GridWidth / 2.0f, GameScreen.GridWidth);
            float roundedY = MathFunctions.RoundFloat(singleTileCenter.Y - GameScreen.GridWidth / 2.0f, GameScreen.GridWidth);

            AxisAlignedRectangle newAar = new AxisAlignedRectangle();
            newAar.Width = GameScreen.GridWidth;
            newAar.Height = GameScreen.GridWidth;
            newAar.Left = roundedX;
            newAar.Bottom = roundedY;
            newAar.Visible = false;

#if DEBUG
            newAar.Visible = DebuggingVariables.ShowResourceCollision;
#endif

            return newAar;
        }

        public ResourceCollectHighLevelGoal(Unit owner, TileNodeNetwork nodeNetwork, Vector3 clickPosition, AxisAlignedRectangle targetResourceMergedTile, ResourceType targetResourceType, PositionedObjectList<Building> allBuildings)
        {
            Owner = owner;
            NodeNetwork = nodeNetwork;
            TargetResourceMergedTile = targetResourceMergedTile;
            TargetResourceType = targetResourceType;
            AllBuildings = allBuildings;

            // TODO: Handle when we can't get to desired tile (e.g., tree in the middle of forest).
            SingleTargetResourceTileCenter = GetSingleTileCenterFromClickPosition(clickPosition);
            SingleTargetResourceTile = GetSingleTile(SingleTargetResourceTileCenter);
        }

        bool shouldWeGiveUpCollecting = false;
        public override bool GetIfDone()
        {
            // Resources are unlimited, only restricted by mosh pit of units trying to harvest simultaneously.
            return shouldWeGiveUpCollecting;
        }

        const float CollectFrequencyInSeconds = 1;
        /// <summary>
        /// The last time resource was collected. Resource is collected one time every X seconds
        /// as defined by the <paramref name="CollectFrequency"/> value;
        /// </summary>
        double arrivedAtResourceTime;

        /// <summary>
        /// Used to adjust a destination Vector3 within tile, askew from center toward the destination.
        /// </summary>
        Vector3 DeterminePositionWithinTileSlightlyCloserToOwner(Vector3 destination, float tileSize)
        {
            Vector3 pointSlightlySkewedTowardOwner;
            // Used to divide the tileSize. (Half was causing weirdness.)
            const float tileSizePortion = 5;
            if (Owner.Position.X > destination.X)
            {
                if (Owner.Position.Y > destination.Y)
                {
                    // Unit is above/right of building. Move target point 
                    pointSlightlySkewedTowardOwner = destination + new Vector3(tileSize / tileSizePortion, tileSize / tileSizePortion, destination.Z);
                }
                else
                {
                    // Unit is below/right of building.
                    pointSlightlySkewedTowardOwner = destination + new Vector3(tileSize / tileSizePortion, tileSize / -tileSizePortion, destination.Z);
                }
            }
            else
            {
                if (Owner.Position.Y > destination.Y)
                {
                    // Unit is above/left of building.
                    pointSlightlySkewedTowardOwner = destination + new Vector3(tileSize / -tileSizePortion, tileSize / tileSizePortion, destination.Z);
                }
                else
                {
                    // Unit is below/right of building.
                    pointSlightlySkewedTowardOwner = destination + new Vector3(tileSize / -tileSizePortion, tileSize / -tileSizePortion, destination.Z);
                }
            }
            return pointSlightlySkewedTowardOwner;
        }

        public WalkToHighLevelGoal GetResourceReturnWalkGoal()
        {
            WalkToHighLevelGoal walkGoal = null;
            // Set up to return resource
            // Find "closest" building by position comparison.
            // FUTURE: Get building with shorted node path (in case closest is a long winding path).
            ResourceReturnBuilding = AllBuildings
                        .Where(building => building.BuildingData.Name == BuildingData.TownHall && building.IsConstructionComplete)
                        .OrderBy(building => (building.Position - Owner.Position).Length())
                        .FirstOrDefault();

            if (ResourceReturnBuilding != null)
            {
                walkGoal = new WalkToHighLevelGoal();
                ResourceReturnBuildingTile = GetSingleTile(ResourceReturnBuilding.Position);
                Vector3 pointSlightlySkewedTowardOwner = DeterminePositionWithinTileSlightlyCloserToOwner(ResourceReturnBuildingTile.Position, ResourceReturnBuildingTile.Width);
                walkGoal = new WalkToHighLevelGoal();
                walkGoal.Owner = Owner;
                walkGoal.TargetPosition = pointSlightlySkewedTowardOwner;
                walkGoal.ForceAttemptToGetToExactTarget = true;
            }
            return walkGoal;
        }

        bool IsInRangeToCollect()
        {
            return !Owner.HasResourceToReturn &&
                (
                    Owner.ResourceCollectCircleInstance.CollideAgainst(SingleTargetResourceTile)
                    || (Owner.LastResourceCollision == TargetResourceType && Owner?.ImmediateGoal?.Path?.Count == 1)
                );
        }
        bool IsInRangeToReturnResource()
        {
            return Owner.HasResourceToReturn
                && ResourceReturnBuilding != null
                && Owner.ResourceCollectCircleInstance.CollideAgainst(ResourceReturnBuildingTile);
        }
        void ClearResourceState()
        {
            Owner.SetResourceToReturn(null);
            ResourceReturnBuilding = null;
            ResourceReturnBuildingTile = null;
        }

        void StopMoving()
        {
            currentWalkGoal = null;
            Owner?.ImmediateGoal?.Path?.Clear();
            Owner.Velocity = Vector3.Zero;
        }

        public override void DecideWhatToDo()
        {
            if (IsInRangeToReturnResource())
            {
                // We're close enough to our target return destination: unload!

                StopMoving();

                // If we are trying to return a resource, but the building is a smoldering pile of ashes, stop walking.
                bool areWeReturningResourcesToDestroyedBuilding = Owner.HasResourceToReturn && ResourceReturnBuilding.CurrentHealth <= 0;
                if (areWeReturningResourcesToDestroyedBuilding)
                {
                    currentWalkGoal = null;
                    shouldWeGiveUpCollecting = true;
                    return;
                }

                var screen = FlatRedBall.Screens.ScreenManager.CurrentScreen as GameScreen;
                
                // Increment appropriate resource.
                switch (Owner.ResourceTypeToReturn)
                {
                    case ResourceType.Gold:
                        screen.Gold += Owner.UnitData.ResourceHarvestAmount;
                        break;
                    case ResourceType.Lumber:
                        screen.Lumber += Owner.UnitData.ResourceHarvestAmount;
                        break;
                    case ResourceType.Stone:
                        screen.Stone += Owner.UnitData.ResourceHarvestAmount;
                        break;
                }
                //Try to play the collect sound.
                screen.TryPlayResourceCollectSound(Owner.ResourceTypeToReturn.Value, Owner.Position);

                // Update UI
                screen.UpdateResourceDisplay();

                ClearResourceState();
                // Default to !isWalking later to set up return-to-resource trip.
            }
            else if (IsInRangeToCollect())
            {
                // We're close enough to our target resource: harvest!

                StopMoving();

                var screen = FlatRedBall.Screens.ScreenManager.CurrentScreen as GameScreen;

                // Delay resource pick-up once arrived.
                if (arrivedAtResourceTime == 0)
                {
                    arrivedAtResourceTime = screen.PauseAdjustedCurrentTime;
                }

                //Try to play gather sfx
                Unit.TryToPlayResourceGatheringSfx(Owner.Position, this.TargetResourceType);

                bool canCollect = screen.PauseAdjustedSecondsSince(arrivedAtResourceTime) >= CollectFrequencyInSeconds;

                if (canCollect)
                {
                    Owner.SetResourceToReturn(TargetResourceType);
                    arrivedAtResourceTime = 0;
                    // Default to !isWalking later to set up return-to-resource trip.
                }
            }
            else
            {
                bool isWalking = Owner?.ImmediateGoal?.Path?.Count > 0;
                if (!isWalking)
                {
                    if (currentWalkGoal == null)
                    {
                        // Do we already have a resource we should be returning but aren't currently gathering?
                        if (Owner.HasResourceToReturn)
                        {
                            currentWalkGoal = GetResourceReturnWalkGoal();
                            if (currentWalkGoal == null)
                            {
                                // Couldn't get a walk goal back from resource collection. Time to call it quits here.
                                shouldWeGiveUpCollecting = true;
                            }
                            else
                            {
                                // Start hiking, unit!
                                currentWalkGoal.DecideWhatToDo();
                            }
                        }
                        else
                        {
                            Vector3 pointSlightlySkewedTowardOwner = DeterminePositionWithinTileSlightlyCloserToOwner(SingleTargetResourceTileCenter, SingleTargetResourceTile.Width);
                            currentWalkGoal = new WalkToHighLevelGoal();
                            currentWalkGoal.Owner = Owner;
                            currentWalkGoal.TargetPosition = pointSlightlySkewedTowardOwner;
                            currentWalkGoal.ForceAttemptToGetToExactTarget = true;
                            currentWalkGoal.DecideWhatToDo();
                        }
                    }
                }
            }
        }
    }
}