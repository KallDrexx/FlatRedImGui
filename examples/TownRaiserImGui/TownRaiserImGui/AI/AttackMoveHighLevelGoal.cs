using FlatRedBall.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownRaiserImGui.Entities;

namespace TownRaiserImGui.AI
{
    class AttackMoveHighLevelGoal : HighLevelGoal
    {
        WalkToHighLevelGoal walkGoal;
        FindTargetToAttackHighLevelGoal findTargetGoal;

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
                findTargetGoal.Owner = owner;
            }
        }

        PositionedObjectList<Unit> allUnits;
        public PositionedObjectList<Unit> AllUnits
        {
            get { return allUnits; }
            set
            {
                allUnits = value;
                findTargetGoal.AllUnits = allUnits;
            }
        }

        PositionedObjectList<Building> allBuildings;
        public PositionedObjectList<Building> AllBuildings
        {
            get { return allBuildings; }
            set
            {
                allBuildings = value;
                findTargetGoal.AllBuildings = allBuildings;
            }
        }

        public float TargetX { get; set; }
        public float TargetY { get; set; }
        public float AggroRadius
        {
            get { return findTargetGoal.AggroRadius; }
            set { findTargetGoal.AggroRadius = value; }
        }

        bool hasReachedTarget = false;


        public AttackMoveHighLevelGoal()
        {
            CreateFindTargetGoal();
        }

        private void CreateFindTargetGoal()
        {
            findTargetGoal = new AI.FindTargetToAttackHighLevelGoal();
            findTargetGoal.Owner = this.Owner;
            
        }

        public override bool GetIfDone()
        {
            return hasReachedTarget;
        }

        public override void DecideWhatToDo()
        {
            
            // don't replace, we want to keep this move attack at the base
            bool isAttacking = findTargetGoal.TryAssignAttack(replace:false);

            if(isAttacking)
            {
                walkGoal = null;
            }
            if(!isAttacking)
            {
                bool isWalking = Owner.ImmediateGoal?.Path?.Count > 0;

                if(!isWalking)
                {
                    if(walkGoal == null)
                    {
                        walkGoal = new WalkToHighLevelGoal();
                        walkGoal.Owner = Owner;
                        walkGoal.TargetPosition =
                            new Microsoft.Xna.Framework.Vector3(TargetX, TargetY, 0);

                        walkGoal.DecideWhatToDo();
                    }
                    else
                    {
                        hasReachedTarget = true;
                    }
                }

            }

        }

        // Actually we may not need this method since this method will never get called if the user is attacking.
        private bool GetIfOwnerIsAttacking()
        {
            var currentHighLevelGoal = Owner.HighLevelGoals.Count > 0 ? Owner.HighLevelGoals.Peek() : null;

            return currentHighLevelGoal is AttackUnitHighLevelGoal || currentHighLevelGoal is AttackBuildingHighLevelGoal;
        }
    }
}
