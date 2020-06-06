using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownRaiserImGui.DataTypes;

namespace TownRaiserImGui.CustomEvents
{
    public class ConstructBuildingEventArgs : EventArgs
    {
        public BuildingData BuildingData;
    }
}
