
namespace TownRaiserImGui.DataTypes
{
    public partial class UnitData
    {
        public string Name;
        public string NameDisplay;
        public string SoundEffectName;
        public string WeaponSoundEffectName;
        public int Health;
        public System.Double TrainTime;
        public int ResourceHarvestAmount;
        public int AttackDamage;
        public float AttackRange;
        public float MovementSpeed;
        public int BounceAdditionalMagnitude;
        public int AttackBounceAdditionalMagnitude;
        public int AttackWobbleAdditionalMagnitude;
        public int GoldCost;
        public int Capacity;
        public string Size;
        public bool IsEnemy;
        public bool InitiatesBattle;
        public Microsoft.Xna.Framework.Input.Keys HotkeyFieldButUseProperty;
        public const string Worker = "Worker";
        public const string Fighter = "Fighter";
        public const string Slime = "Slime";
        public const string Bat = "Bat";
        public const string Goblin = "Goblin";
        public const string Skeleton = "Skeleton";
        public const string Snake = "Snake";
        public const string KingSkeleton = "KingSkeleton";
        public const string Cyclops = "Cyclops";
        public const string Octopus = "Octopus";
        public const string Dragon = "Dragon";
        public static System.Collections.Generic.List<System.String> OrderedList = new System.Collections.Generic.List<System.String>
        {
        Worker
        ,Fighter
        ,Slime
        ,Bat
        ,Goblin
        ,Skeleton
        ,Snake
        ,KingSkeleton
        ,Cyclops
        ,Octopus
        ,Dragon
        };
        
        
    }
}
