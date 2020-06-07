using FlatRedImGui;
using TownRaiserImGui.DataTypes;

namespace TownRaiserImGui.ImGuiControls
{
    public class GlobalBuildingEditor : ImGuiElement
    {
        public string BuildingId
        {
            get => Get<string>(); 
            set => Set(value);
        }
        
        [HasTextBuffer(25)]
        public string DisplayName
        {
            get => Get<string>();
            set => Set(value);
        }

        public int Health
        {
            get => Get<int>();
            set => Set(value);
        }

        public double BuildTime
        {
            get => Get<double>();
            set => Set(value);
        }

        public int LumberCost
        {
            get => Get<int>();
            set => Set(value);
        }

        public int StoneCost
        {
            get => Get<int>();
            set => Set(value);
        }

        public int Capacity
        {
            get => Get<int>();
            set => Set(value);
        }

        public GlobalBuildingEditor(BuildingData buildingData)
        {
            using (DisablePropertyChangedNotifications())
            {
                BuildingId = buildingData.Name;
                DisplayName = buildingData.NameDisplay;
                Health = buildingData.Health;
                BuildTime = buildingData.BuildTime;
                LumberCost = buildingData.LumberCost;
                StoneCost = buildingData.StoneCost;
                Capacity = buildingData.Capacity;
            }
        }

        protected override void CustomRender()
        {
            InputText(nameof(DisplayName), "Display Name");
            InputInt(nameof(Health), "Health");
            InputDouble(nameof(BuildTime), "Build time");
            InputInt(nameof(LumberCost), "Lumber Cost");
            InputInt(nameof(StoneCost), "Stone Cost");
            InputInt(nameof(Capacity), "Capacity");
        }
    }
}