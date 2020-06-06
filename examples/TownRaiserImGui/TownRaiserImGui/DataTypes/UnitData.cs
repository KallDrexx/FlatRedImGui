using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using TownRaiserImGui.Interfaces;
using static TownRaiserImGui.GumRuntimes.IconButtonRuntime;
using TownRaiserImGui.Entities;

namespace TownRaiserImGui.DataTypes
{
    public partial class UnitData : ICommonEntityData
    {
        public Keys Hotkey => HotkeyFieldButUseProperty;
        public string DataName => Name;
        public string MenuTitleDisplay => this.NameDisplay;
        public int Gold => this.GoldCost;
        //At this time, units do not have a stone or lumber requirement
        public int Lumber => 0;
        public int Stone => 0;
        public int CapacityUsed => this.Capacity;
        public bool ShouldEnableButton(int lumber, int stone, int gold, int currentCapacity, int maxCapacity, IEnumerable<Building> existingBuildings, IUpdatesStatus entityCreatedFrom)
        {
            //An entity button should be enabled if there is enough gold and either capacity exists or there are units in the training queue.
            return GoldCost <= gold && ((currentCapacity + Capacity) <= maxCapacity || 
                entityCreatedFrom?.ButtonCountDisplays?.Any(x => x.Value > 0) == true) ;
        }
    }
}
