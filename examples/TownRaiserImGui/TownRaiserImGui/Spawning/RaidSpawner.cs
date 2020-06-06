using FlatRedBall;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Math;
using FlatRedBall.Screens;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownRaiserImGui.DataTypes;
using TownRaiserImGui.Entities;
using TownRaiserImGui.Factories;

namespace TownRaiserImGui.Spawning
{
    public class RaidSpawner
    {
        #region Fields/Properties

        const float SpawnFrequency = 30;

        double lastSpawn;

        public PositionedObjectList<Building> Buildings { get; set; }
        public TileNodeNetwork NodeNetwork { get; set; }

        public event Action<IEnumerable<UnitData>, Vector3> RequestSpawn;

        #endregion

        public void Activity()
        {
            var screen = ScreenManager.CurrentScreen;

            bool hasTownHall = GetTownHall() != null;

            if(hasTownHall)
            {
                if (screen.PauseAdjustedSecondsSince(lastSpawn) > SpawnFrequency)
                {
                    PerformSpawn();
                }
            }
            else
            {
                // If there's no town hall, reset the timer so that the user gets the full spawn period before the first attack comes.
                lastSpawn = screen.PauseAdjustedCurrentTime;
            }
        }

        private void PerformSpawn()
        {
            var spawnLocation = GetSpawnLocation();

            if(spawnLocation != null)
            {
                var unitDatas= GetUnitDatasToSpawn();

#if DEBUG
                Console.WriteLine($"Spawning with {unitDatas.Count()} enemies for threat level {GetThreatLevel()}");
#endif
                RequestSpawn?.Invoke(unitDatas, spawnLocation.Value);

            }
            lastSpawn = ScreenManager.CurrentScreen.PauseAdjustedCurrentTime;
        }

        private Vector3? GetSpawnLocation()
        {
            Vector3? toReturn = null;

            Building townHall = GetTownHall();

            Building buildingToSpawnBy = null;
            if(townHall != null)
            {
                buildingToSpawnBy = FlatRedBallServices.Random.In(Buildings);
            }

            // No building, no spawn. Sing it Bob!
            if (buildingToSpawnBy != null)
            {
                const float offsetDistance = 150;

                var offsetFromBuilding = FlatRedBallServices.Random.RadialVector2(offsetDistance, offsetDistance);

                // This could result in units being spawned in the middle of a town but...oh well
                var position = buildingToSpawnBy.Position + new Vector3(offsetFromBuilding, 0);
                var closestNode = NodeNetwork.GetClosestNodeTo(ref position);

                toReturn = closestNode.Position;
            }

            return toReturn;
        }

        private Building GetTownHall()
        {
            return Buildings.FirstOrDefault(item => item.BuildingData.Name == BuildingData.TownHall);
        }

        private IEnumerable<UnitData> GetUnitDatasToSpawn()
        {
            var threatData = GetThreatLevel();

            int numberOfSpawns = GlobalContent.TimedSpawnData.Count;

            threatData = System.Math.Min(threatData, numberOfSpawns - 1);

            var spawnData = GlobalContent.TimedSpawnData[threatData];

            List<UnitData> toReturn = new List<UnitData>();

            foreach (var unitName in spawnData.Units)
            {
                toReturn.Add(GlobalContent.UnitData[unitName]);
            }

            return toReturn;
        }

        private int GetThreatLevel()
        {
            int coefficient = 3;
            // threat level is calculated using the number of non-town hall buildings
            return Buildings.Count(item => item.BuildingData.Name != BuildingData.TownHall) / coefficient;
        }


    }
}
