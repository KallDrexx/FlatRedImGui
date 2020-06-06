using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownRaiserImGui.DataTypes;

namespace TownRaiserImGui.Entities
{
    public partial class Building
    {
        private static string BuildingConstructionComplete = "building_constuction_complete";
        private static string GenericBuildingComplete = "building_constuction_complete_generic_1";
        private static string BuildingContstructionStart = "building_construction_start_generic_1";
        private static string BuildingDestruction = "building_destruction";
        private static string BuildingTakeDamage = "combat_building_damage";

        private static void PlayConstructionCompleteSoundEffect(BuildingData building)
        {
            var soundEffectName = $"{BuildingConstructionComplete}_{building.SoundEffectName}_1";
            var soundEffect = (SoundEffect)GetFile(soundEffectName);

            if(soundEffect == null)
            {
                soundEffect = building_constuction_complete_generic_1;
                soundEffectName = GenericBuildingComplete;
            }

            SoundEffectTracker.TryPlaySound(soundEffect, soundEffectName);
        }

        public static void PlayConstructionStartSoundEffect()
        {
            //Right now we do not have building specific start sounds. But I want to track the when the sound is played.
            //Unless desired by the sound guys, we will keep it setup like this.
            SoundEffectTracker.TryPlaySound(building_constuction_start_generic_1, BuildingContstructionStart);
        }

        public static void PlayDestructionSoundEffect()
        {

        }

        public static void PlayDamageSoundEffect()
        {
            int count = 1;
            //Finds the number of sounds
            while (true)
            {
                bool soundExists = GetFile($"{BuildingTakeDamage}_{count + 1}") != null;
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

            var soundEffect = (SoundEffect)GetFile($"{BuildingTakeDamage}_{randomInt}");

            SoundEffectTracker.TryPlaySound(soundEffect, BuildingTakeDamage);
        }
    }
}
