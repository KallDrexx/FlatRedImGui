using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Math;
using FlatRedBall.Math.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownRaiserImGui.Entities;

namespace TownRaiserImGui.AI
{
    public class AttackBuildingHighLevelGoal : HighLevelGoal
    {
        public Building TargetBuilding { get; set; }
        public PositionedObjectList<Unit> AllUnits { get; set; }
        public Unit Owner { get; set; }
        public TileNodeNetwork NodeNetwork { get; set; }

        public bool PreferAttackingUnits { get; set; } = false;

        public bool IsInRangeToAttack()
        {
            var maxAttackDistance = Owner.UnitData.AttackRange;

            // There's no point to rect built in to FRB, but there's segment to rect, so we'll use that
            var segment = new Segment(Owner.Position, Owner.Position);
            // There's nothing built in to do distance to shape collections, so we'll use the rect. 
            // not as robust:

            return TargetBuilding.Collision.IsPointInside(Owner.X, Owner.Y) || 
                maxAttackDistance >= segment.DistanceTo(TargetBuilding.AxisAlignedRectangleInstance);
        }


        public override void DecideWhatToDo()
        {
            bool didRetargetUnit = false;
            if(PreferAttackingUnits)
            {
                didRetargetUnit = FindTargetToAttackHighLevelGoal.TryAssignAttackUnit(
                    replace:false,
                    owner:Owner,
                    allUnits:AllUnits,
                    aggroRadius:80);
            }
            if(!didRetargetUnit)
            {
                if (IsInRangeToAttack() == false)
                {
                    PathfindToTarget();
                }
                else
                {
                    Owner.TryAttack(TargetBuilding);
                }
            }
        }

        public override bool GetIfDone()
        {
            return TargetBuilding.CurrentHealth <= 0;
        }

        private void PathfindToTarget()
        {
            if (Owner.ImmediateGoal == null)
            {
                Owner.ImmediateGoal = new ImmediateGoal();
            }
            Owner.ImmediateGoal.Path = Owner.GetPathTo(TargetBuilding.Position);

        }
    }
}
