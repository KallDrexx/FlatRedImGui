using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Math.Geometry;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownRaiserImGui.Entities;

namespace TownRaiserImGui.AI
{
    public class WalkToHighLevelGoal : HighLevelGoal
    {

        bool hasAlreadyGottenPath = false;

        public Vector3? TargetPosition;

        public AxisAlignedRectangle TargetResource { get; set; }

        public Unit Owner { get; set; }
        public Unit TargetUnit { get; set; }
        public Building TargetBuilding { get; set; }
        /// <summary>
        /// Forces an additional node at the target to force <paramref name="Owner"/> to push to <paramref name="TargetPosition"/> even if it is not near a node.
        /// </summary>
        public bool ForceAttemptToGetToExactTarget { get; set; }


        private void GetPath()
        {
            hasAlreadyGottenPath = true;

            var vector3 = TargetPosition.Value;
            if(Owner.ImmediateGoal == null)
            {
                Owner.ImmediateGoal = new ImmediateGoal();
            }

            var path = Owner.GetPathTo(vector3);
            if (ForceAttemptToGetToExactTarget && TargetPosition.HasValue)
            {
                // Add a node for the center to make sure unit tries to get as close as possible, regardless of where the last node leaves them.
                path.Add(new PositionedNode() { X = TargetPosition.Value.X, Y = TargetPosition.Value.Y, Z = TargetPosition.Value.Z });
            }
            Owner.ImmediateGoal.Path = path;
        }

        public override bool GetIfDone()
        {
            return hasAlreadyGottenPath && (Owner.ImmediateGoal?.Path?.Count() > 0) == false;
        }

        public override void DecideWhatToDo()
        {
            if(!hasAlreadyGottenPath)
            {
                GetPath();
            }
        }
    }

}
