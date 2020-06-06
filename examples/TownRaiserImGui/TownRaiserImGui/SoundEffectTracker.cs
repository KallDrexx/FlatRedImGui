using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownRaiserImGui
{
    
    public static class SoundEffectTracker
    {
        private struct SoundTrackerData
        {
            public double LastPlayTime;
            public double SoundDuration;
        }

        private static Dictionary<string, SoundTrackerData> m_LastSoundPlayTimes;
        private static double m_SoundRadius;
        public static void Initialize(double soundRadius)
        {
            m_LastSoundPlayTimes = new Dictionary<string, SoundTrackerData>();
            m_SoundRadius = soundRadius;
        }

        public static void Destroy()
        {
            m_LastSoundPlayTimes.Clear();
            m_LastSoundPlayTimes = null;
        }

        private static double LastPlayTime(string soundToCheck)
        {
            //If a sound has not been played yet, we will return -1
            double lastPlayTime = -1;

            if(m_LastSoundPlayTimes.ContainsKey(soundToCheck))
            {
                lastPlayTime = m_LastSoundPlayTimes[soundToCheck].LastPlayTime;
            }

            return lastPlayTime;
        }

        private static void RegisterTimeLastPlayed(string soundEffectName, double soundEffectDuration, double lastTimePlayed)
        {
            if (m_LastSoundPlayTimes.ContainsKey(soundEffectName))
            {
                var data = m_LastSoundPlayTimes[soundEffectName];
                data.LastPlayTime = lastTimePlayed;
                m_LastSoundPlayTimes[soundEffectName] = new SoundTrackerData(){SoundDuration = soundEffectDuration, LastPlayTime = lastTimePlayed };
            }
            else
            {
                m_LastSoundPlayTimes.Add(soundEffectName, new SoundTrackerData() { LastPlayTime = lastTimePlayed, SoundDuration = soundEffectDuration});
            }
        }

        public static void TryPlaySound(SoundEffect soundEffect, string soundEffectName, float volume = 1, float pitch = 0, float pan = 0)
        {
#if DEBUG
            if (soundEffect == null)
            {
                if (Entities.DebuggingVariables.ThrowExceptionIfNoSoundEffect)
                {
                    throw new Exception($"The sound effect: {soundEffectName}, does not exist.");
                }

                return;
            }
#endif

            var currentScreen = FlatRedBall.Screens.ScreenManager.CurrentScreen;
            var lastSoundPlayTime = LastPlayTime(soundEffectName);

            if (currentScreen.PauseAdjustedSecondsSince(lastSoundPlayTime) >= soundEffect.Duration.TotalSeconds)
            {
                soundEffect.Play(volume, pitch, pan);
                RegisterTimeLastPlayed(soundEffectName, soundEffect.Duration.TotalSeconds, currentScreen.PauseAdjustedCurrentTime);
            }
        }

        public static void TryPlayCameraRestrictedSoundEffect(SoundEffect soundEffect, string soundEffectName, Vector3 cameraPos, Vector3 soundOrigin)
        {
            float distance = (cameraPos - soundOrigin).LengthSquared();

            if(distance <= m_SoundRadius)
            {
                TryPlaySound(soundEffect, soundEffectName);
            }
        }

    }
}
