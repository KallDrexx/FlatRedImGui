#region Usings

using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;

using FlatRedBall.Math.Geometry;
using FlatRedBall.Math.Splines;
using BitmapFont = FlatRedBall.Graphics.BitmapFont;
using Cursor = FlatRedBall.Gui.Cursor;
using GuiManager = FlatRedBall.Gui.GuiManager;
using TownRaiserImGui.AI;
using FlatRedBall.Math;
using FlatRedBall.Screens;
using System.Linq;
using StateInterpolationPlugin;
using Microsoft.Xna.Framework;

#if FRB_XNA || SILVERLIGHT
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Vector3 = Microsoft.Xna.Framework.Vector3;
using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;

#endif
#endregion

namespace TownRaiserImGui.Entities
{
	public partial class Unit
	{
        #region Properties

        public ImmediateGoal ImmediateGoal { get; set; }

        public Stack<HighLevelGoal> HighLevelGoals { get; set; } = new Stack<HighLevelGoal>();

        public TileNodeNetwork NodeNetwork { get; set; }

        public PositionedObjectList<Unit> AllUnits { get; set; }

        public PositionedObjectList<Building> AllBuildings { get; set; }

        float BounceRandomizingCoefficient = 1;
        float AttackWobbleRandomizingCoefficient = 1;

        private int m_CurrentHealth;
        public int CurrentHealth
        {
            get
            {
                return m_CurrentHealth;
            }
            set
            {
                m_CurrentHealth = value;
                UpdateHealthSprite();
            }
        }
        
        public bool HasResourceToReturn
        {
            get { return ResourceTypeToReturn != null; }
        }
        /// <summary>
        /// If unit has a resource to return, this is the type. If not, should be null.
        /// </summary>
        public Screens.ResourceType? ResourceTypeToReturn { get; set; }

        public Screens.ResourceType? LastResourceCollision { get; set; }

        #endregion

        #region Private Fields/Properties

#if DEBUG
        PositionedObjectList<Line> pathLines = new PositionedObjectList<Line>();
#endif

        // The last time damage was dealt. Damage is dealt one time every X seconds
        // as defined by the DamageFrequency value;
        private double lastDamageDealt;
        private double deathStartTime;
        private float deathTextureOriginalHeight;
        const float DamageFrequency = 1;

        #endregion

        #region Events

        public event EventHandler Died;

        #endregion

        #region Initialize

        /// <summary>
        /// Initialization logic which is execute only one time for this Entity (unless the Entity is pooled).
        /// This method is called when the Entity is added to managers. Entities which are instantiated but not
        /// added to managers will not have this method called.
        /// </summary>
        private void CustomInitialize()
        {
            BounceRandomizingCoefficient = FlatRedBallServices.Random.Between(0.9f, 1.1f);
            AttackWobbleRandomizingCoefficient = FlatRedBallServices.Random.Between(0.9f, 1.1f);

            this.HealthBarRuntimeInstance.CurrentHealthStatusState = GumRuntimes.HealthBarRuntime.HealthStatus.Full;
            this.HealthBarRuntimeInstance.Z = -2;

            // make it not clickable
            FlatRedBall.Gui.GuiManager.RemoveWindow(HealthBarRuntimeInstance);

#if DEBUG
            this.ResourceCollectCircleInstance.Visible = DebuggingVariables.ShowResourceCollision;
#endif
        }

        #endregion

        #region Activity

        private void CustomActivity()
        {
            HighLevelActivity();

            ImmediateAiActivity();

            WalkingBounceActivity();

            AttackWobbleActivity();

            DeathActivity();

#if DEBUG
            DebugActivity();
#endif
        }

        bool isAttacking => HighLevelGoals.OfType<AttackUnitHighLevelGoal>().Any();
        double? timeStartedAttacking;
        const float attackWobbleMagnitudeBaseline = 4;
        private void AttackWobbleActivity()
        {
            if (CurrentHealth <= 0 || !isAttacking)
            {
                // We may want to ease to identity rotation so the unit doesn't snap to vertical when they finish attacking.
                // The current wobble is fairly minimal, so it's not very noticeable.
                SpriteInstance.RelativeRotationMatrix = Matrix.Identity;
                timeStartedAttacking = null;
                return;
            }
            else if (timeStartedAttacking == null)
            {
                timeStartedAttacking = ScreenManager.CurrentScreen.PauseAdjustedCurrentTime;
            }

            var timeSinceStartedAttacking = ScreenManager.CurrentScreen.PauseAdjustedSecondsSince(timeStartedAttacking.Value);
            var sinResult = (float)Math.Sin(timeSinceStartedAttacking * MathHelper.TwoPi * AttackWobblesPerSecond * AttackWobbleRandomizingCoefficient);
            SpriteInstance.RelativeRotationMatrix = Matrix.CreateRotationZ(-MathHelper.ToRadians(sinResult * (attackWobbleMagnitudeBaseline + UnitData.AttackWobbleAdditionalMagnitude)));
        }

        bool shouldBounce => isWalking || isAttacking;
        bool isWalking => Velocity != Vector3.Zero;
        double? timeStartedMoving;
        const float walkingBounceMagnitudeBaseline = 3;
        private void WalkingBounceActivity()
        {
            if (CurrentHealth <= 0 || !shouldBounce)
            {
                // We may want to ease to 0 bounce so the unit doesn't snap to ground level when they reach a destination.
                // The current bounce is so small, it's not very noticeable.
                SpriteInstance.RelativeY = SpriteInstance.Height / 2;
                timeStartedMoving = null;
                return;
            }
            else if (timeStartedMoving == null)
            {
                timeStartedMoving = ScreenManager.CurrentScreen.PauseAdjustedCurrentTime;
            }
            
            var timeSinceStartedMoving = ScreenManager.CurrentScreen.PauseAdjustedSecondsSince(timeStartedMoving.Value);
            var sinResult = (float)Math.Sin(timeSinceStartedMoving * MathHelper.TwoPi * HopsPerSecond * BounceRandomizingCoefficient);
            var bounceMagnitude = walkingBounceMagnitudeBaseline + (isAttacking ? UnitData.AttackBounceAdditionalMagnitude : UnitData.BounceAdditionalMagnitude);
            SpriteInstance.RelativeY = (Math.Abs(sinResult) * bounceMagnitude) + (SpriteInstance.Height / 2);
        }

        private void DeathActivity()
        {
            if(CurrentHealth <= 0)
            {
                var deathTimeLeft = 1 - (float)(ScreenManager.CurrentScreen.PauseAdjustedSecondsSince(deathStartTime) / DeathSpriteDuration);

                var newTextureHeight = deathTextureOriginalHeight * deathTimeLeft;
                SpriteInstance.BottomTexturePixel = SpriteInstance.TopTexturePixel + newTextureHeight;

                SpriteInstance.RelativeY = SpriteInstance.Height / 2;
            }            
        }

#if DEBUG
        private void DebugActivity()
        {
            if(DebuggingVariables.ShowUnitPaths)
            {
                int numberOfLinesNeeded = this.ImmediateGoal?.Path?.Count ?? 0;

                while(this.pathLines.Count < numberOfLinesNeeded)
                {
                    var line = new Line();
                    line.Visible = true;
                    pathLines.Add(line);
                }
                while (this.pathLines.Count > numberOfLinesNeeded)
                {
                    ShapeManager.Remove(pathLines.Last());
                }

                for (int i = 0; i < numberOfLinesNeeded; i++)
                {
                    Vector3 pointBefore;
                    if (i == 0)
                    {
                        pointBefore = this.Position;
                    }
                    else
                    {
                        pointBefore = ImmediateGoal.Path[i - 1].Position;
                    }
                    Vector3 pointAfter = ImmediateGoal.Path[i].Position;

                    pathLines[i].SetFromAbsoluteEndpoints(pointBefore, pointAfter);
                }

            }
        }
#endif

        private void HealthBarActivity()
        {
            HealthBarRuntimeInstance.Y = -SpriteInstance.Height * .85f;

            var healthPercentage = 100 * GetHealthRatio();

            this.HealthBarRuntimeInstance.HealthPercentage = healthPercentage;
        }

        private float GetHealthRatio()
        {
            return this.CurrentHealth / (float)UnitData.Health;
        }

        private void HighLevelActivity()
        {
            if (CurrentHealth > 0)
            {
                var currentGoal = HighLevelGoals.Count == 0 ? null : HighLevelGoals.Peek();

                if (currentGoal?.GetIfDone() == true)
                {
                    HighLevelGoals.Pop();
                }

                currentGoal = HighLevelGoals.Count == 0 ? null : HighLevelGoals.Peek();

                currentGoal?.DecideWhatToDo();

                if (currentGoal == null)
                {
                    TryStartFindingTarget();
                }
            }
        }

        private void ImmediateAiActivity()
        {
            if(ImmediateGoal?.Path?.Count > 0 && CurrentHealth > 0)
            {
                MoveAlongPath();
            }
        }

        internal void AssignAttackThenRetreat(float worldX, float worldY, bool replace = true)
        {
            // we'll just make a circle:
            var circle = new Circle();
            circle.Radius = AttackThenRetreat.BuildingAttackingRadius; ;
            circle.X = worldX;
            circle.Y = worldY;

            var buildingsToTarget = AllBuildings
                .Where(item => item.CollideAgainst(circle))
                .Take(3)
                .ToList();

            // if there's no buildings, then just do a regular attack move:
            if(buildingsToTarget.Count == 0)
            {
                AssignMoveAttackGoal(worldX, worldY, replace);
            }
            else
            {
                var goal = new AttackThenRetreat();
                goal.StartX = this.X;
                goal.StartY = this.Y;

                goal.TargetX = worldX;
                goal.TargetY = worldY;

                goal.AllUnits = AllUnits;
                goal.BuildingsToFocusOn.AddRange( buildingsToTarget);
                goal.Owner = this;

                if (replace)
                {
                    this.HighLevelGoals.Clear();
                }
                this.HighLevelGoals.Push(goal);
                this.ImmediateGoal = null;
            }
        }

        public void AssignMoveAttackGoal(float worldX, float worldY, bool replace = true)
        {
            var goal = new AttackMoveHighLevelGoal();
            goal.TargetX = worldX;
            goal.TargetY = worldY;
            goal.Owner = this;
            goal.AllUnits = AllUnits;
            goal.AllBuildings = AllBuildings;

            if (replace)
            {
                this.HighLevelGoals.Clear();
            }
            this.HighLevelGoals.Push(goal);
            this.ImmediateGoal = null;
        }

        public void AssignMoveGoal(float worldX, float worldY, bool replace = true)
        {
            var goal = new WalkToHighLevelGoal();

            goal.Owner = this;
            goal.TargetPosition =
                new Microsoft.Xna.Framework.Vector3(worldX, worldY, 0);

            if(replace)
            {
                this.HighLevelGoals.Clear();
            }
            this.HighLevelGoals.Push(goal);
            this.ImmediateGoal = null;
        }

        private void MoveAlongPath()
        {
            PositionedNode node = ImmediateGoal.Path[0];

            var amountMovedIn2Frames = UnitData.MovementSpeed * 2 / 60.0f;

            var difference = Position - node.Position;
            difference.Z = 0;

            if (difference.Length() < amountMovedIn2Frames)
            {
                ImmediateGoal.Path.RemoveAt(0);

                if(ImmediateGoal.Path.Count == 0)
                {
                    ImmediateGoal.Path = null;
                    Velocity = Vector3.Zero;
                }

            }

            if(ImmediateGoal.Path != null)
            {
                bool wasPreviouslyMoving = Velocity != Vector3.Zero;
                var direction = node.Position - Position;
                direction.Normalize();

                direction.Z = 0;
                Velocity = direction * UnitData.MovementSpeed;

                SpriteInstance.FlipHorizontal = Velocity.X > 0;
            }
        }

        public List<PositionedNode> GetPathTo(Vector3 position)
        {
            var toReturn = NodeNetwork.GetPath(ref Position, ref position);

            // remove node 0 if there's more than 1 node, because otherwise the user backtracks:
            if(toReturn.Count > 1)
            {
                toReturn.RemoveAt(0);
            }
            return toReturn;
        }

        internal void TryStartFindingTarget()
        {
            if(this.UnitData.InitiatesBattle && CurrentHealth > 0)
            {
                var goal = new FindTargetToAttackHighLevelGoal();
                goal.Owner = this;
                goal.AllUnits = AllUnits;
                goal.AllBuildings = AllBuildings;

                HighLevelGoals.Clear();
                HighLevelGoals.Push(goal);
            }
        }

        void ToggleResourceIndicator()
        {
            ResourceIndicatorSpriteInstance.Visible = HasResourceToReturn;
            // Set resource image, if we have one. (Otherwise, don't care since it's not visible.)
            if (ResourceTypeToReturn != null)
            {
                string resourceAnimationChainName;
                switch (ResourceTypeToReturn.Value) {
                    case Screens.ResourceType.Lumber:
                        resourceAnimationChainName = "ResourceLumber";
                        break;
                    case Screens.ResourceType.Stone:
                        resourceAnimationChainName = "ResourceStone";
                        break;
                    default:
                    //case Screens.ResourceType.Gold:
                        resourceAnimationChainName = "ResourceGold";
                        break;
                }
                ResourceIndicatorSpriteInstance.CurrentChainName = resourceAnimationChainName;
            }
        }

        /// <summary>
        /// Unit has a resource to return, but we don't have enough to restart a full resource collection goal (e.g., harvested item, then cancelled -> no prior resource destination available).
        /// </summary>
        public void AssignResourceReturnGoal(Vector3 clickPosition, Building targetReturnBuilding, Screens.ResourceType resourceType)
        {
            var returnResourceGoal = new ResourceReturnHighLevelGoal(
                owner: this,
                nodeNetwork: NodeNetwork,
                targetReturnBuilding: targetReturnBuilding
            );
            if (ImmediateGoal?.Path != null)
            {
                ImmediateGoal.Path.Clear();
            }
            HighLevelGoals.Clear();
            HighLevelGoals.Push(returnResourceGoal);
        }
        public void AssignResourceCollectGoal(Vector3 clickPosition, AxisAlignedRectangle resourceGroupTile, Screens.ResourceType resourceType)
        {
            var collectResourceGoal = new ResourceCollectHighLevelGoal(
                owner: this,
                nodeNetwork: NodeNetwork,
                clickPosition: clickPosition,
                targetResourceMergedTile: resourceGroupTile,
                targetResourceType: resourceType,
                allBuildings: AllBuildings
            );
            if (ImmediateGoal?.Path != null)
            {
                ImmediateGoal.Path.Clear();
            }
            HighLevelGoals.Clear();
            HighLevelGoals.Push(collectResourceGoal);
        }
        public void AssignAttackGoal(Unit enemy, bool replace = true)
        {
            var attackGoal = new AttackUnitHighLevelGoal();
            attackGoal.TargetUnit = enemy;
            attackGoal.Owner = this;
            attackGoal.NodeNetwork = this.NodeNetwork;

            if(replace)
            {
                HighLevelGoals.Clear();
            }
            HighLevelGoals.Push(attackGoal);
        }

        public AttackBuildingHighLevelGoal AssignAttackGoal(Building building, bool replace = true)
        {
            var attackGoal = new AttackBuildingHighLevelGoal();
            attackGoal.TargetBuilding = building;
            attackGoal.Owner = this;
            attackGoal.AllUnits = this.AllUnits;
            attackGoal.NodeNetwork = this.NodeNetwork;

            if(replace)
            {
                HighLevelGoals.Clear();
            }
            HighLevelGoals.Push(attackGoal);

            return attackGoal;
        }

        public void TakeDamage(int attackDamage)
        {
            CurrentHealth -= attackDamage;
            if(CurrentHealth <= 0)
            {
                PerformDeath();
                
            }
        }

        public void PerformDeath()
        {
            TryPlayDeathSound(this);
            CombatTracker.RemoveUnit(this);
            this.SpriteInstance.CurrentChainName = "Death";
            this.SpriteInstance.RelativeY = this.SpriteInstance.Height / 2.0f;

            this.deathTextureOriginalHeight = this.SpriteInstance.Height;
            this.deathStartTime = ScreenManager.CurrentScreen.PauseAdjustedCurrentTime;

            this.ShadowSprite.CurrentChainName = "ShadowSmall";
            this.HealthBarRuntimeInstance.Visible = false;

            this.Velocity = Vector3.Zero;
            if (UnitData.IsEnemy == false)
            {
                var screen = ScreenManager.CurrentScreen as Screens.GameScreen;
                screen.CurrentCapacityUsed -= UnitData.Capacity;
                screen.UpdateResourceDisplay();
            }
            Died?.Invoke(this, null);
            this.Call(Destroy).After(DeathSpriteDuration);
        }

        public void TryAttack(Unit targetUnit)
        {
            var screen = FlatRedBall.Screens.ScreenManager.CurrentScreen;
            bool canAttack = screen.PauseAdjustedSecondsSince(lastDamageDealt) >= DamageFrequency;

            if (canAttack)
            {
                CombatTracker.RegisterUnitForCombat(this);
                CombatTracker.RegisterUnitForCombat(targetUnit);

                lastDamageDealt = screen.PauseAdjustedCurrentTime;

                targetUnit.TakeDamage(UnitData.AttackDamage);
                TryPlayAttackSound(this);
                TryPlayWeaponsSound(this);
            }
        }


        public void TryAttack(Building targetBuilding)
        {
            var screen = FlatRedBall.Screens.ScreenManager.CurrentScreen;
            bool canAttack = screen.PauseAdjustedSecondsSince(lastDamageDealt) >= DamageFrequency;

            if (canAttack)
            {
                lastDamageDealt = screen.PauseAdjustedCurrentTime;

                targetBuilding.TakeDamage(UnitData.AttackDamage);

                TryPlayAttackSound(this);
            }
        }

        public override void UpdateDependencies(double currentTime)
        {
            if(currentTime != mLastDependencyUpdate)
            {
                base.UpdateDependencies(currentTime);

                HealthBarActivity();
            }

        }

        public bool IsInCameraBounds()
        {
            float left = Camera.Main.AbsoluteLeftXEdgeAt(Z);
            float right = Camera.Main.AbsoluteRightXEdgeAt(Z);
            float top = Camera.Main.AbsoluteTopYEdgeAt(Z);
            float bottom = Camera.Main.AbsoluteBottomYEdgeAt(Z);

            return left < X && right > X && bottom < Y && top > Y;
        }

#endregion

        public void UpdateHealthSprite()
        {
            var healthRatio = GetHealthRatio();

            if (healthRatio > .66)
            {
                this.HealthBarRuntimeInstance.CurrentHealthStatusState = GumRuntimes.HealthBarRuntime.HealthStatus.Full;
            }
            else if (healthRatio > .33)
            {
                this.HealthBarRuntimeInstance.CurrentHealthStatusState = GumRuntimes.HealthBarRuntime.HealthStatus.TwoThird;
            }
            else
            {
                this.HealthBarRuntimeInstance.CurrentHealthStatusState = GumRuntimes.HealthBarRuntime.HealthStatus.OneThird;
            }

        }

        public void SetResourceToReturn(Screens.ResourceType? resourceType = null)
        {
            ResourceTypeToReturn = resourceType;

            ToggleResourceIndicator();
        }

        private void CustomDestroy()
		{
#if DEBUG
            while (this.pathLines.Count > 0)
            {
                ShapeManager.Remove(pathLines.Last());
            }
#endif
        }

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }
	}
}
