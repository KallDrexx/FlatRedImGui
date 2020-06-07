using FlatRedImGui;
using TownRaiserImGui.DataTypes;

namespace TownRaiserImGui.ImGuiControls
{
    public class GlobalUnitEditor : ImGuiElement
    {
        public string UnitId { get; private set; }
        
        [HasTextBuffer(100)]
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

        public int GoldCost
        {
            get => Get<int>();
            set => Set(value);
        }

        public int Capacity
        {
            get => Get<int>();
            set => Set(value);
        }

        public int AttackDamage
        {
            get => Get<int>();
            set => Set(value);
        }

        public float AttackRange
        {
            get => Get<float>();
            set => Set(value);
        }

        public float MovementSpeed
        {
            get => Get<float>();
            set => Set(value);
        }

        public int ResourceHarvestAmount
        {
            get => Get<int>();
            set => Set(value);
        }

        public GlobalUnitEditor(UnitData unitData)
        {
            using (DisablePropertyChangedNotifications())
            {
                UnitId = unitData.Name;
                Health = unitData.Health;
                DisplayName = unitData.NameDisplay;
                GoldCost = unitData.GoldCost;
                Capacity = unitData.Capacity;
                AttackDamage = unitData.AttackDamage;
                AttackRange = unitData.AttackRange;
                MovementSpeed = unitData.MovementSpeed;
                ResourceHarvestAmount = unitData.ResourceHarvestAmount;
            }
        }
        
        protected override void CustomRender()
        {
            InputText(nameof(DisplayName), "Display Name");
            InputInt(nameof(Health), "Health");
            InputInt(nameof(GoldCost), "Gold Cost");
            InputInt(nameof(Capacity), "Capacity");
            InputInt(nameof(AttackDamage), "Attack Damage");
            InputFloat(nameof(AttackRange), "Attack Range");
            InputFloat(nameof(MovementSpeed), "Movement Speed");
            InputInt(nameof(ResourceHarvestAmount), "Resource Harvesting");
        }
    }
}