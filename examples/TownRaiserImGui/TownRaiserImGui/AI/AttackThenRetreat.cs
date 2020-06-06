using FlatRedBall.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownRaiserImGui.Entities;

namespace TownRaiserImGui.AI
{
    public class AttackThenRetreat : HighLevelGoal
    {
        public const float BuildingAttackingRadius = 64;

        Unit owner;
        public Unit Owner
        {
            get
            {
                return owner;
            }
            set
            {
                owner = value;
            }
        }


        AttackMoveHighLevelGoal attackMove;
        bool hasMovedBack = false;
        

        PositionedObjectList<Unit> allUnits;
        public PositionedObjectList<Unit> AllUnits
        {
            get { return allUnits; }
            set
            {
                allUnits = value;
            }
        }

        public float StartX { get; set; }
        public float StartY { get; set; }
        public float TargetX { get; set; }
        public float TargetY { get; set; }

        public PositionedObjectList<Building> BuildingsToFocusOn
        { get; private set; } = new PositionedObjectList<Building>(); 

        public bool IsDone { get; set; }

        public override bool GetIfDone()
        {
            return IsDone;
        }

        public override void DecideWhatToDo()
        {
            if(attackMove == null && BuildingsToFocusOn.Any(item =>item.CurrentHealth > 0))
            {
                attackMove = new AttackMoveHighLevelGoal();
                // multiply it by 1.5 to make it larger, so buildings get sucked in no matter what
                attackMove.AggroRadius = BuildingAttackingRadius * 1.5f;
                attackMove.Owner = Owner;
                attackMove.AllUnits = AllUnits;
                attackMove.AllBuildings = BuildingsToFocusOn;

                attackMove.TargetX = TargetX;
                attackMove.TargetY = TargetY;
            }

            if (attackMove != null)
            {
                attackMove.DecideWhatToDo();
                if(BuildingsToFocusOn.All(item=>item.CurrentHealth <= 0))
                {
                    attackMove = null;
                }
            }

            if(attackMove == null && !hasMovedBack)
            {
                hasMovedBack = true;

                Owner.AssignMoveGoal(StartX, StartY, replace:false);
            }
            if(hasMovedBack && (Owner.ImmediateGoal?.Path == null || Owner.ImmediateGoal.Path.Count == 0 ))
            {
                IsDone = true;
            }
        }
    }
}
