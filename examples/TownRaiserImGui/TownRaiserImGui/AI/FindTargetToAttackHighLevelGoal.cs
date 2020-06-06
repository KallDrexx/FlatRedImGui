using FlatRedBall.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownRaiserImGui.Entities;

namespace TownRaiserImGui.AI
{
    public class FindTargetToAttackHighLevelGoal : HighLevelGoal
    {
        public Unit Owner { get; set; }

        public PositionedObjectList<Unit> AllUnits { get; set; }
        public PositionedObjectList<Building> AllBuildings { get; set; }

        public float AggroRadius { get; set; } = 80;

        public override void DecideWhatToDo()
        {
            TryAssignAttack();

        }

        public bool TryAssignAttack(bool replace = true)
        {
            bool didAssignAttack = TryAssignAttackUnit(replace, Owner, AllUnits, AggroRadius);

            // we prioritize units over buildings, since units can fight back
            // At this time, only bad guys can attack buildings. May need to change
            // this if we decide to add units that are built by the bad guys:
            if (!didAssignAttack && Owner.UnitData.IsEnemy)
            {
#if DEBUG
                if (AllBuildings == null)
                {
                    throw new NullReferenceException($"Need to assign {nameof(AllBuildings)} when instantiating this unit.");
                }
#endif

                float buildingAggroSquared = (AggroRadius + 24) * (AggroRadius + 24);
                var foundBuilding = AllBuildings
                    .Where(item => (item.Position - Owner.Position).LengthSquared() < buildingAggroSquared)
                    .OrderBy(item => (item.Position - Owner.Position).LengthSquared())
                    .FirstOrDefault();

                if (foundBuilding != null)
                {
                    var attackBuildingGoal = Owner.AssignAttackGoal(foundBuilding, replace);

                    // prefer attacking units:
                    attackBuildingGoal.PreferAttackingUnits = true;

                    didAssignAttack = true;
                }
            }
            return didAssignAttack;
        }

        public static bool TryAssignAttackUnit(bool replace, Unit owner, 
            PositionedObjectList<Unit> allUnits, float aggroRadius)
        {
            bool didAssignAttack = false;

            float aggroSquared = aggroRadius * aggroRadius;
            bool isTargetAnEnemyUnit = !owner.UnitData.IsEnemy;

            var foundUnit = allUnits.FirstOrDefault(item =>
                (item.Position - owner.Position).LengthSquared() < aggroSquared
                    && item.UnitData.IsEnemy == isTargetAnEnemyUnit
                    && item.CurrentHealth > 0
                );

            if (foundUnit != null)
            {
                owner.AssignAttackGoal(foundUnit, replace);
                didAssignAttack = true;
            }

            return didAssignAttack;
        }

        public override bool GetIfDone()
        {
            return false;
        }
    }
}
