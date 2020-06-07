using FlatRedImGui;
using ImGuiNET;
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
            var displayNameBuffer = GetTextBuffer(nameof(DisplayName));
            ImGui.InputText("Display Name", displayNameBuffer, (uint) displayNameBuffer.Length);
            UpdatePropertyFromTextBuffer(nameof(DisplayName));

            var health = Health;
            ImGui.InputInt("Health", ref health);
            Health = health;

            var gold = GoldCost;
            ImGui.InputInt("Gold Cost", ref gold);
            GoldCost = gold;

            var capacity = Capacity;
            ImGui.InputInt("Capacity", ref capacity);
            Capacity = capacity;

            var damage = AttackDamage;
            ImGui.InputInt("Damage", ref damage);
            AttackDamage = damage;

            var range = AttackRange;
            ImGui.InputFloat("Attack Range", ref range);
            AttackRange = range;

            var speed = MovementSpeed;
            ImGui.InputFloat("Movement Speed", ref speed);
            MovementSpeed = speed;

            var harvest = ResourceHarvestAmount;
            ImGui.InputInt("Harvest Amount", ref harvest);
            ResourceHarvestAmount = harvest;
        }
    }
}