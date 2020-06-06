using FlatRedBall;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownRaiserImGui.DataTypes;

namespace TownRaiserImGui.Entities
{
    public partial class Unit
    {

        private static readonly string UnitWoodChop = "unit_chop_wood";
        private static readonly string UnitMineGold = "unit_mine_gold";
        private static readonly string UnitMineStone = "unit_mine_stone";

        private static readonly string UnitAttack = "unit_attack";
        private static readonly string UnitDeath = "unit_death";
        private static readonly string UnitObey = "unit_obey";
        private static readonly string UnitSelect = "unit_select";
        private static readonly string UnitSpawn = "unit_spawn";

        private static readonly string WeaponSound = "combat_attack";
        
        public static void TryToPlayResourceGatheringSfx(Vector3 soundOrigin, Screens.ResourceType resourceType)
        {
            SoundEffect soundEffect = null;
            switch (resourceType)
            {
                case Screens.ResourceType.Gold:
                    soundEffect = GetRandomSoundEffect(UnitMineGold);
                    SoundEffectTracker.TryPlayCameraRestrictedSoundEffect(soundEffect, UnitMineGold, Camera.Main.Position, soundOrigin);
                    break;
                case Screens.ResourceType.Lumber:
                    soundEffect = GetRandomSoundEffect(UnitWoodChop);
                    SoundEffectTracker.TryPlayCameraRestrictedSoundEffect(soundEffect, UnitWoodChop, Camera.Main.Position, soundOrigin);
                    break;
                case Screens.ResourceType.Stone:
                    //ToDo: Rick - Uncomment when stone is implemented.
                    soundEffect = GetRandomSoundEffect(UnitMineStone);
                    SoundEffectTracker.TryPlayCameraRestrictedSoundEffect(soundEffect, UnitMineStone, Camera.Main.Position, soundOrigin);
                    break;
            }
        }

        public static void TryPlayAttackSound(Unit unit)
        {
            var soundEffectName = $"{UnitAttack}_{unit.UnitData.SoundEffectName}";
            var soundEffect = GetRandomSoundEffect(soundEffectName);

            SoundEffectTracker.TryPlayCameraRestrictedSoundEffect(soundEffect, soundEffectName, Camera.Main.Position, unit.Position);
        }
        public static void TryPlayDeathSound(Unit unit)
        {
            var soundEffectName = $"{UnitDeath}_{unit.UnitData.SoundEffectName}";
            var soundEffect = GetRandomSoundEffect(soundEffectName);

            SoundEffectTracker.TryPlayCameraRestrictedSoundEffect(soundEffect, soundEffectName, Camera.Main.Position, unit.Position);
        }
        public static void TryPlayWeaponsSound(Unit unit)
        {
            string soundEffectName = $"{WeaponSound}_{unit.UnitData.WeaponSoundEffectName}";
            var soundEffect = GetRandomSoundEffect(soundEffectName);

            SoundEffectTracker.TryPlayCameraRestrictedSoundEffect(soundEffect, soundEffectName, Camera.Main.Position, unit.Position);
        }
        public static void TryPlayObeySound(UnitData unit)
        {
            var soundEffectName = $"{UnitObey}_{unit.SoundEffectName}";
            TryPlayRandomSound(soundEffectName);
        }
        public static void TryPlaySelectSound(UnitData unit)
        {
            var soundEffectName = $"{UnitSelect}_{unit.SoundEffectName}";
            TryPlayRandomSound(soundEffectName);
        }
        public static void TryPlaySpawnSound(UnitData unit)
        {
            var soundEffectName = $"{UnitSpawn}_{unit.SoundEffectName}";
            TryPlayRandomSound(soundEffectName);
        }
        public static SoundEffect GetRandomSoundEffect(string soundName)
        {
            int count = 1;
            //Finds the number of sounds
            while (true)
            {
                bool soundExists = GetFile($"{soundName}_{count + 1}") != null;
                if (soundExists)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            //Picks a random sound from a variant if it exists
            int randomInt = FlatRedBall.FlatRedBallServices.Random.Next(count) + 1;

            return (SoundEffect)GetFile($"{soundName}_{randomInt}");
        }

        public static void TryPlayRandomSound(string soundName)
        {
            var soundEffect = GetRandomSoundEffect(soundName);
                        
            //For now only track by the sound class, not the random numbered sound variation.
            //We can expand that later.
            SoundEffectTracker.TryPlaySound(soundEffect, soundName);
        }
    }
}
