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
using FlatRedBall.Math;
using FlatRedBall.Screens;
using System.Linq;

#if FRB_XNA || SILVERLIGHT
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Vector3 = Microsoft.Xna.Framework.Vector3;
using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;

#endif
#endregion

namespace TownRaiserImGui.Entities
{
	public partial class EncounterSpawnPoint
	{
        const bool mAllowReactivation = false;
        #region Enums

        public enum LogicState
        {
            ActiveWaiting,
            Spawned,
            ReturningUnits,
            Defeated
        }

        #endregion

        #region Fields/Properties

        double lastTimeDestroyed;

        PositionedObjectList<Unit> UnitsCreatedByThis = new PositionedObjectList<Unit>();

        private LogicState currentLogicStateButUseProperty;
        public LogicState CurrentLogicState
        {
            get
            {
                return currentLogicStateButUseProperty;
            }
            set
            {
                currentLogicStateButUseProperty = value;
                UpdateSpriteChainFromCurrentLogicState();
            }
        }

        #endregion

        /// <summary>
        /// Initialization logic which is execute only one time for this Entity (unless the Entity is pooled).
        /// This method is called when the Entity is added to managers. Entities which are instantiated but not
        /// added to managers will not have this method called.
        /// </summary>
        private void CustomInitialize()
		{

        }

		private void CustomActivity()
		{
            bool shouldReactivate = mAllowReactivation &&
                this.CurrentLogicState == LogicState.Defeated &&
                ScreenManager.CurrentScreen.PauseAdjustedSecondsSince(lastTimeDestroyed) > RegenerationTime;

            if(shouldReactivate)
            {
                this.CurrentLogicState = LogicState.ActiveWaiting;
            }

            if (this.CurrentLogicState == LogicState.ReturningUnits
                && UnitsCreatedByThis.All(unit => this.DespawnCircleInstance.CollideAgainst(unit.CircleInstance)))
            {
                for (int i = UnitsCreatedByThis.Count - 1; i >= 0; i--)
                {
                    UnitsCreatedByThis[i].Destroy();
                }
                this.CurrentLogicState = LogicState.ActiveWaiting;
            }
        }

        private void UpdateSpriteChainFromCurrentLogicState()
        {
            switch(CurrentLogicState)
            {
                case LogicState.Spawned:
                case LogicState.ActiveWaiting:
                case LogicState.Defeated:
                    SpriteInstance.CurrentChainName = currentLogicStateButUseProperty.ToString();
                    break;
                case LogicState.ReturningUnits:
                    SpriteInstance.CurrentChainName = LogicState.ActiveWaiting.ToString();
                    break;
            }
        }

		private void CustomDestroy()
		{


		}

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }

        internal void ReturnSpawnedUnits()
        {
            foreach (var unit in UnitsCreatedByThis)
            {
                unit.AssignMoveGoal(this.Position.X, this.Position.Y, replace: true);
            }
            this.CurrentLogicState = LogicState.ReturningUnits;
        }

        internal void Attack(Unit playerUnit, Func<string, Vector3, Unit> spawnAction)
        {
            if(CurrentLogicState == LogicState.ReturningUnits)
            {
                // units already exist, so attack:
                foreach(var unit in UnitsCreatedByThis)
                {
                    unit.AssignMoveAttackGoal(playerUnit.X, playerUnit.Y);
                }
            }
            else
            {
                CreateAllNewUnits(spawnAction);

                foreach (var unit in UnitsCreatedByThis)
                {
                    unit.AssignMoveAttackGoal(playerUnit.X, playerUnit.Y);
                }
            }

            this.CurrentLogicState = LogicState.Spawned;
        }

        private void CreateAllNewUnits(Func<string, Vector3, Unit> spawnAction)
        {
            var data = GlobalContent.EncounterPointData.FirstOrDefault(item => item.Difficulty == this.Difficulty);

            foreach(var enemyName in data.Enemies)
            {
                var unit = spawnAction(enemyName, this.Position);

                unit.Died += HandleUnitDied;

                this.UnitsCreatedByThis.Add(unit);
            }
        }

        private void HandleUnitDied(object sender, EventArgs notused)
        {
            UnitsCreatedByThis.Remove((Unit)sender);
            if(this.UnitsCreatedByThis.Count == 0)
            {
                HandleAllUnitsKilled();
            }
        }

        private void HandleAllUnitsKilled()
        {
            lastTimeDestroyed = ScreenManager.CurrentScreen.PauseAdjustedCurrentTime;
            this.CurrentLogicState = LogicState.Defeated;
        }
    }
}
