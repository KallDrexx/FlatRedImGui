
namespace TownRaiserImGui.DataTypes
{
    public partial class BuildingData
    {
        public string Name;
        public string NameDisplay;
        public string SoundEffectName;
        public int Health;
        public float FoodPerSecond;
        public System.Double BuildTime;
        public int LumberCost;
        public int StoneCost;
        public int Capacity;
        public Microsoft.Xna.Framework.Input.Keys HotkeyFieldButUseProperty;
        public System.Collections.Generic.List<string> TrainableUnits = new System.Collections.Generic.List<string>();
        public System.Collections.Generic.List<TownRaiserImGui.DataTypes.Requirement> Requirements = new System.Collections.Generic.List<TownRaiserImGui.DataTypes.Requirement>();
        public const string TownHall = "TownHall";
        public const string Tent = "Tent";
        public const string House = "House";
        public const string Barracks = "Barracks";
        public static System.Collections.Generic.List<System.String> OrderedList = new System.Collections.Generic.List<System.String>
        {
        TownHall
        ,Tent
        ,House
        ,Barracks
        };
        
        
    }
}
