using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownRaiserImGui.Entities;

namespace TownRaiserImGui
{
    public enum CombatOrPeace
    {
        Combat,
        Peace
    }
    //Used only to keep track of when units are in battle. When the battle is over, if the player units are the only ones left it will result in the victory music.
    public static class CombatTracker
    {
        private static List<Unit> m_PlayerUnits = new List<Unit>();
        private static List<Unit> m_EnemyUnits = new List<Unit>();

        public static bool AreUnitsInCombat => m_EnemyUnits.Count > 0 && m_PlayerUnits.Count > 0;
        public static int PlayerCount => m_PlayerUnits.Count;
        public static int EnemyCount => m_EnemyUnits.Count;

        public static void RegisterUnitForCombat(Unit unit)
        {
            if(unit.UnitData.IsEnemy)
            {
                if(m_EnemyUnits.Contains(unit) == false)
                {
                    m_EnemyUnits.Add(unit);
                }
            }
            else
            {
                if(m_PlayerUnits.Contains(unit) == false)
                {
                    m_PlayerUnits.Add(unit);
                }
            }
        }

        public static void RemoveUnit(Unit unit)
        {
            if(unit.UnitData.IsEnemy)
            {
                m_EnemyUnits.Remove(unit);
            }
            else
            {
                m_PlayerUnits.Remove(unit);
            }
        }
        public static void Clear()
        {
            m_PlayerUnits.Clear();
            m_EnemyUnits.Clear();
        }
    }
}
