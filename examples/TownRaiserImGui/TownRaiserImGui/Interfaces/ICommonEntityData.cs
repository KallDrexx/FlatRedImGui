using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownRaiserImGui.Entities;
using static TownRaiserImGui.GumRuntimes.IconButtonRuntime;

namespace TownRaiserImGui.Interfaces
{
    public interface ICommonEntityData
    {
        Microsoft.Xna.Framework.Input.Keys Hotkey { get; }
        string DataName { get; }
        string MenuTitleDisplay { get; }
        int Gold { get; }
        int Lumber { get; }
        int Stone { get; }
        int CapacityUsed { get; }
        bool ShouldEnableButton(int lumber, int stone, int gold, int currentCapacity, int maxCapacity, IEnumerable<Building> existingBuildings, IUpdatesStatus entityCreatedFrom);
    }
}
