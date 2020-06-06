using FlatRedBall.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownRaiserImGui.CustomEvents;
using TownRaiserImGui.Interfaces;

namespace TownRaiserImGui.GumRuntimes
{
    public partial class ResourceCostContainerRuntime
    {
        private ICommonEntityData m_LastUpdatedData;
        public void UpadteResourceDisplayText(UpdateUiEventArgs args)
        {
            m_LastUpdatedData = args.SelectedData;

            this.GoldCostText = $"{args.GoldCost}";
            this.LumberCostText = $"{args.LumberCost}";
            this.StoneCostText = $"{args.StoneCost}";
            this.CapacityCostText = $"{args.CapacityCost}";

            //ChangeColor based on affordability.
            if(args.ShouldCheckAffordability)
            {
                var gameScreen = ScreenManager.CurrentScreen as Screens.GameScreen;
                GoldTextColorState = gameScreen.Gold >= args.GoldCost ? ResourceCostDisplayRuntime.TextColor.CanAfford : ResourceCostDisplayRuntime.TextColor.CannotAfford;
                LumberTextColorState = gameScreen.Lumber >= args.LumberCost ? ResourceCostDisplayRuntime.TextColor.CanAfford : ResourceCostDisplayRuntime.TextColor.CannotAfford;
                StoneTextColorState = gameScreen.Stone >= args.StoneCost ? ResourceCostDisplayRuntime.TextColor.CanAfford : ResourceCostDisplayRuntime.TextColor.CannotAfford;
                CapacityTextColorState = gameScreen.MaxCapacity >=  gameScreen.CurrentCapacityUsed + args.CapacityCost || gameScreen.HasTrainingUnits ? ResourceCostDisplayRuntime.TextColor.CanAfford : ResourceCostDisplayRuntime.TextColor.CannotAfford;

            }
            else
            {
                GoldTextColorState = ResourceCostDisplayRuntime.TextColor.CanAfford;
                LumberTextColorState = ResourceCostDisplayRuntime.TextColor.CanAfford;
                StoneTextColorState = ResourceCostDisplayRuntime.TextColor.CanAfford;
                CapacityTextColorState = ResourceCostDisplayRuntime.TextColor.CanAfford;
            }
        }

        public void UpdateFromLastRollOverData()
        {
            if (m_LastUpdatedData != null)
            {
                UpadteResourceDisplayText(new UpdateUiEventArgs(m_LastUpdatedData));
            }
        }
    }
}
