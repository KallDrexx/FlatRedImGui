using FlatRedBall.AI.Pathfinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownRaiserImGui.Entities;
using FlatRedBall.Math.Geometry;
using Microsoft.Xna.Framework;

namespace TownRaiserImGui.AI
{
    class AttackUnitHighLevelGoal : HighLevelGoal
    {
        public Unit TargetUnit { get; set; }
        public Unit Owner { get; set; }
        public TileNodeNetwork NodeNetwork { get; set; }



        public bool IsInRangeToAttack()
        {
            var maxAttackDistance = Owner.UnitData.AttackRange + TargetUnit.CircleInstance.Radius;

            var currentDistance = (Owner.Position - TargetUnit.Position).Length();

            return currentDistance < maxAttackDistance;
        }

        public override void DecideWhatToDo()
        {
            if(Owner.ImmediateGoal?.Path?.Count > 0)
            {
                PerformPathfindingDecisions();
            }
            else if(IsInRangeToAttack() == false)
            {
                PathfindToTarget();
            }
            else
            {
                Owner.TryAttack(TargetUnit);
            }
        }

        public override bool GetIfDone()
        {
            return TargetUnit.CurrentHealth <= 0;
        }

        private void PathfindToTarget()
        {
            if(Owner.ImmediateGoal == null)
            {
                Owner.ImmediateGoal = new ImmediateGoal();
            }
            Owner.ImmediateGoal.Path = Owner.GetPathTo(TargetUnit.Position);

        }

        private void PerformPathfindingDecisions()
        {
            bool hasReachedTarget = Owner.CollideAgainst(TargetUnit);

            if(hasReachedTarget)
            {
                Owner.ImmediateGoal.Path.Clear();
                Owner.Velocity = Vector3.Zero;
            }
            else
            {

                var closestNodeToTarget = NodeNetwork.GetClosestNodeTo(ref TargetUnit.Position);

                var lastPoint = Owner.ImmediateGoal.Path.Last();

                var hasTargetMovedFromPath = lastPoint.Position != closestNodeToTarget.Position;

                if (hasTargetMovedFromPath)
                {
                    PathfindToTarget();
                }


            }

        }
    }
}
