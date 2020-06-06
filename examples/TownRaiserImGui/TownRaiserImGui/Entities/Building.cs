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
using TownRaiserImGui.Interfaces;
using FlatRedBall.Screens;
using TownRaiserImGui.CustomEvents;
using System.Linq;

#if FRB_XNA || SILVERLIGHT
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Vector3 = Microsoft.Xna.Framework.Vector3;
using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;

#endif
#endregion

namespace TownRaiserImGui.Entities
{
	public partial class Building: IUpdatesStatus
	{
        #region Fields/Properties

        private const int MaxTrainableUnits = 5;


        public ICommonEntityData EntityData => BuildingData;
        private int m_CurrentHealth;
        private int m_DamageTakenDuringContruction;
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
        public IEnumerable<string> ButtonDatas => BuildingData.TrainableUnits.AsReadOnly();
        public string CurrentTrainingUnit => TrainingQueue.Count > 0 ? TrainingQueue[0] : null;
        public Dictionary<string, double> ProgressPercents { get; private set; }
        public Dictionary<string, int> ButtonCountDisplays { get; private set; }


        private RallyPointMarker m_RallyPointMarker;
        private Vector3? m_RallyPoint;
        public Vector3? RallyPoint
        {
            get
            {
                return m_RallyPoint;
            }
            set
            {
                m_RallyPoint = value;
                if(m_RallyPoint.HasValue)
                {
                    if(m_RallyPointMarker == null)
                    {
                        m_RallyPointMarker = Factories.RallyPointMarkerFactory.CreateNew();
                    }
                    m_RallyPointMarker.Position = m_RallyPoint.Value;
                }
            }
        }

        double constructionTimeStarted = 0;
        public bool IsConstructionComplete { get; private set; } = true;
        public bool HasTrainableUnits => BuildingData.TrainableUnits.Count > 0;

        //For now, we will spawn to the bottom right corner of the building's AAR.
        public float UnitSpawnX => X + AxisAlignedRectangleInstance.Width / 2;
        public float UnitSpawnY => Y -AxisAlignedRectangleInstance.Height / 2;

        //While it's a list, we will treat is as a queue.
        //Queues will not let us return it as readonly.
        public List<string> TrainingQueue { get; private set; }
        #endregion

        #region Private Fields/Properties
        private double m_TraningStartTime;

        private bool IsTrainingComplete
        {
            get
            {
                var currentScreen = ScreenManager.CurrentScreen;

#if DEBUG
                if(DebuggingVariables.TrainImmediately)
                {
                    return true;
                }
#endif

                return m_TraningStartTime > 0 && currentScreen.PauseAdjustedSecondsSince(m_TraningStartTime) >= GlobalContent.UnitData[CurrentTrainingUnit].TrainTime;
            }
        }

        private bool DidTrainingStall => m_TraningStartTime < 0;
        private double TrainingProgress
        {
            get
            {
                var currentScreen = ScreenManager.CurrentScreen;
                //We want the progress left. So we subtract the ratio from 1.
                return  1 - (currentScreen.PauseAdjustedSecondsSince(m_TraningStartTime) / GlobalContent.UnitData[CurrentTrainingUnit].TrainTime);
            }
        }
        #endregion

        public event Action BuildingConstructionCompleted;
        public event EventHandler OnDestroy;
        public event EventHandler<UpdateStatusEventArgs> UpdateStatus;

        #region Initialize Methods

        private void CustomInitialize()
        {
            InitializeIUpdatestatusLists();

            this.HealthBarRuntimeInstance.CurrentHealthStatusState = GumRuntimes.HealthBarRuntime.HealthStatus.Full;
            this.HealthBarRuntimeInstance.Z = -1;

            // not anything we want clickable:
            FlatRedBall.Gui.GuiManager.RemoveWindow(HealthBarRuntimeInstance);


#if DEBUG
            this.AxisAlignedRectangleInstance.Visible = DebuggingVariables.ShowBuildingOutline;
#endif
        }

        private void InitializeIUpdatestatusLists()
        {
            TrainingQueue = new List<string>();
            ProgressPercents = new Dictionary<string, double>(); //A dictionary to support the cooldown system. Units may have abilities under cooldown.
            ButtonCountDisplays = new Dictionary<string, int>();
            
        }

        #endregion

        #region Activity Methods

        private void CustomActivity()
        {
            ConstructionActivity();
            HealthBarActivity();
            TrainingActivity();
        }

        private void ConstructionActivity()
        {
            if(!IsConstructionComplete)
            {
                var ratioComplete = 
                    FlatRedBall.Screens.ScreenManager.CurrentScreen.PauseAdjustedSecondsSince(constructionTimeStarted) / BuildingData.BuildTime;

#if DEBUG
                if(DebuggingVariables.BuildImmediately)
                {
                    ratioComplete = 1;
                }
#endif

                if(ratioComplete < .5)
                {
                    SpriteInstance.CurrentChainName = "BeingBuilt1";
                }
                else if(ratioComplete < 1)
                {
                    SpriteInstance.CurrentChainName = "BeingBuilt2";
                }
                else
                {
                    SpriteInstance.CurrentChainName = BuildingData.Name;
                    IsConstructionComplete = true;
                    PlayConstructionCompleteSoundEffect(BuildingData);
                    BuildingConstructionCompleted?.Invoke();
                }


                CurrentHealth = (int)(ratioComplete * BuildingData.Health) - m_DamageTakenDuringContruction;
            }
        }


        internal void StartBuilding()
        {
            IsConstructionComplete = false;
            constructionTimeStarted = FlatRedBall.Screens.ScreenManager.CurrentScreen.PauseAdjustedCurrentTime;
            m_DamageTakenDuringContruction = 0;
            CurrentHealth = 0;
            // to force an immediate update of visuals
            PlayConstructionStartSoundEffect();
            ConstructionActivity();
        }

        private void HealthBarActivity()
        {
            var healthPercentage = 100 * this.CurrentHealth / (float)BuildingData.Health;

            this.HealthBarRuntimeInstance.HealthPercentage = healthPercentage;
        }

        private void TrainingActivity()
        {
            if (TrainingQueue.Count > 0)
            {
                var trainingUnit = CurrentTrainingUnit;
                ProgressPercents[trainingUnit] = TrainingProgress;
                if(IsTrainingComplete)
                {

                    TrainingQueue.RemoveAt(0);

                    ButtonCountDisplays[trainingUnit]--;

                    if(TrainingQueue.Count > 0)
                    {
                        TryStartTraining(CurrentTrainingUnit);
                    }

                    //Spawn the unit after qeueuing up a new unit for training.
                    //This will ensure the ui can properly update to show if the unit has enough capacity or if there is a queued unit.
                    var spawnPosition = new Vector3() { X = UnitSpawnX, Y = UnitSpawnY, Z = 1 };
                    // so the units don't stack in a line line:
                    spawnPosition.Y += FlatRedBallServices.Random.Between(0, 1);
                    spawnPosition.X += FlatRedBallServices.Random.Between(0, 1);
                    var newUnit = ((Screens.GameScreen)ScreenManager.CurrentScreen).SpawnNewUnit(trainingUnit, spawnPosition);

                    if(RallyPoint.HasValue)
                    {
                        newUnit.AssignMoveGoal(RallyPoint.Value.X, RallyPoint.Value.Y);
                    }
                }
                else if(TrainingQueue.Count > 0 && DidTrainingStall)
                {
                    //If the queue greater than 0 we check if we stalled, which is a negative start time.
                    TryStartTraining(CurrentTrainingUnit);
                }
                this.UpdateStatus?.Invoke(this, new UpdateStatusEventArgs());
            }
        }
        public void TryCancelBuilding()
        {
            if(IsConstructionComplete == false)
            {
                var gameScreen = ScreenManager.CurrentScreen as Screens.GameScreen;
                gameScreen.Stone += BuildingData.Stone;
                gameScreen.Lumber += BuildingData.Lumber;
                this.Destroy();
            }
        }
        public bool TryAddUnitToTrain(string unit)
        {
            bool wasSuccessful = true;
            //If the queue is empty, we try start the training.
            //If not we will add the unit to the end of the queue and inform the caller.
            if(TrainingQueue.Count == 0)
            {
                wasSuccessful = TryStartTraining(unit);
            }

            if (wasSuccessful)
            {
                TrainingQueue.Add(unit);
                //We will initialize the dictionary with all posible units.
                ButtonCountDisplays[unit]++;

                this.UpdateStatus?.Invoke(this, new UpdateStatusEventArgs());
            }
            return wasSuccessful;
        }

        public bool CancelLastTrainingInstance(string unitTypeToCancel)
        {
            bool wasCanceled = false;
            if(TrainingQueue.Count > 0)
            {
                int lastIndex = TrainingQueue.LastIndexOf(unitTypeToCancel);

                if (lastIndex > -1)
                {
                    TrainingQueue.RemoveAt(lastIndex);
                    ButtonCountDisplays[unitTypeToCancel]--;

                    if(lastIndex == 0)
                    {
                        if (TrainingQueue.Count > 0)
                        {
                            TryStartTraining(CurrentTrainingUnit);
                        }
                    }

                    if(ButtonCountDisplays[unitTypeToCancel] == 0)
                    {
                        ProgressPercents[unitTypeToCancel] = 0;
                    }

                    this.UpdateStatus?.Invoke(this, new UpdateStatusEventArgs());

                    wasCanceled = true;
                }
            }

            return wasCanceled;
        }

        public float GetHealthRatio()
        {
            
            return (float)CurrentHealth / (float)BuildingData.Health;
        }

        public bool IsCursorOverSprite(Cursor cursor)
        {
            return SpriteInstance.Alpha != 0 && SpriteInstance.AbsoluteVisible && cursor.IsOn3D(SpriteInstance, LayerProvidedByContainer);
        }

        private bool TryStartTraining(string unitName)
        {
            var gameScreen = ScreenManager.CurrentScreen as Screens.GameScreen;

            bool canTrain = false;
            if (this.IsConstructionComplete == true && gameScreen != null)
            {
                canTrain = gameScreen.CheckIfCanStartTraining(unitName);

                if (canTrain)
                {
                    
                    m_TraningStartTime = ScreenManager.CurrentScreen.PauseAdjustedCurrentTime;
                    ProgressPercents.Clear();
                    ProgressPercents.Add(unitName, 1);
                }
                else
                {
                    m_TraningStartTime = -1;
                }
            }

            return canTrain;
        }
        internal void TakeDamage(int attackDamage)
        {
            CurrentHealth -= attackDamage;
            if(IsConstructionComplete == false)
            {
                m_DamageTakenDuringContruction += attackDamage;
            }
            PlayDamageSoundEffect();
            if (CurrentHealth <= 0)
            {
                Destroy();
            }
        }
        public void UpdateHealthSprite()
        {
            var healthRatio = GetHealthRatio();

            if(healthRatio > .66)
            {
                this.HealthBarRuntimeInstance.CurrentHealthStatusState = GumRuntimes.HealthBarRuntime.HealthStatus.Full;
            }
            else if(healthRatio > .33)
            {
                this.HealthBarRuntimeInstance.CurrentHealthStatusState = GumRuntimes.HealthBarRuntime.HealthStatus.TwoThird;
            }
            else
            {
                this.HealthBarRuntimeInstance.CurrentHealthStatusState = GumRuntimes.HealthBarRuntime.HealthStatus.OneThird;
            }

        }
        public void UpdateRallyPointVisibility(bool isVisible)
        {
            if (m_RallyPointMarker != null)
            {
                m_RallyPointMarker.SpriteInstanceVisible = isVisible;
            }
        }

        internal void InterpolateToState(object buildComplete, double buildTime)
        {
            throw new NotImplementedException();
        }


        public int GetCapacityInQueue()
        {
            return this.TrainingQueue.Sum(item => GlobalContent.UnitData[item].CapacityUsed);
            throw new NotImplementedException();
        }
        #endregion

        private void CustomDestroy()
		{
            this.OnDestroy?.Invoke(this, null);
            this.UpdateStatus?.Invoke(this, new UpdateStatusEventArgs() { WasEntityDestroyed = true });

            //Refund any training units on building destruction.
            var gameScreen = ScreenManager.CurrentScreen as Screens.GameScreen;
            foreach (var unit in TrainingQueue)
            {
                gameScreen.Gold += GlobalContent.UnitData[unit].Gold;
            }
            gameScreen.UpdateResourceDisplay();

            this.TrainingQueue.Clear();
            this.TrainingQueue = null;

            this.ProgressPercents.Clear();
            this.ProgressPercents = null;

            this.ButtonCountDisplays.Clear();
            this.ButtonCountDisplays = null;

            this.OnDestroy = null;
            this.UpdateStatus = null;

            m_RallyPointMarker?.Destroy();
            m_RallyPointMarker = null;
    }

        private static void CustomLoadStaticContent(string contentManagerName)
        {


}




    }
}
