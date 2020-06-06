using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownRaiserImGui.Interfaces;

namespace TownRaiserImGui.CustomEvents
{
    public class UpdateUiEventArgs: EventArgs
    {
        public int GoldCost;
        public int LumberCost;
        public int StoneCost;
        public int CapacityCost;
        public string TitleDisplay;
        public bool ShouldCheckAffordability;
        public ICommonEntityData SelectedData;

        public UpdateUiEventArgs()
        {

        }
        public UpdateUiEventArgs(ICommonEntityData dataToSetFrom)
        {
            SelectedData = dataToSetFrom;
            TitleDisplay = dataToSetFrom.MenuTitleDisplay;
            GoldCost = dataToSetFrom.Gold;
            LumberCost = dataToSetFrom.Lumber;
            StoneCost = dataToSetFrom.Stone;
            CapacityCost = dataToSetFrom.CapacityUsed;
            ShouldCheckAffordability = true;
        }

        public static UpdateUiEventArgs RollOffValue = new UpdateUiEventArgs { GoldCost = 0, LumberCost = 0, StoneCost = 0, TitleDisplay = "Build Menu" };
    }
}
