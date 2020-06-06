    using System.Linq;
    namespace TownRaiserImGui.GumRuntimes
    {
        public partial class ResourceDisplayRuntime : TownRaiserImGui.GumRuntimes.ContainerRuntime
        {
            #region State Enums
            public enum VariableState
            {
                Default
            }
            #endregion
            #region State Fields
            VariableState mCurrentVariableState;
            #endregion
            #region State Properties
            public VariableState CurrentVariableState
            {
                get
                {
                    return mCurrentVariableState;
                }
                set
                {
                    mCurrentVariableState = value;
                    switch(mCurrentVariableState)
                    {
                        case  VariableState.Default:
                            CapacityResourceInstance.CurrentIconStateState = TownRaiserImGui.GumRuntimes.ResourceRuntime.IconState.Capacity;
                            GoldResourceInstance.CurrentIconStateState = TownRaiserImGui.GumRuntimes.ResourceRuntime.IconState.Gold;
                            LumberResourceInstance.CurrentIconStateState = TownRaiserImGui.GumRuntimes.ResourceRuntime.IconState.Lumber;
                            StoneResourceInstance.CurrentIconStateState = TownRaiserImGui.GumRuntimes.ResourceRuntime.IconState.Stone;
                            ChildrenLayout = Gum.Managers.ChildrenLayout.LeftToRightStack;
                            ClipsChildren = false;
                            Height = 24f;
                            HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                            Visible = true;
                            Width = 323f;
                            WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                            WrapsChildren = false;
                            X = 1f;
                            XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                            XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                            Y = 0f;
                            YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                            YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                            CapacityResourceInstance.ResourceText = "0";
                            CapacityResourceInstance.X = 10f;
                            CapacityResourceInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                            CapacityResourceInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                            CapacityResourceInstance.Y = 0f;
                            CapacityResourceInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                            CapacityResourceInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            GoldResourceInstance.X = 10f;
                            GoldResourceInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                            GoldResourceInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                            GoldResourceInstance.Y = 0f;
                            GoldResourceInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                            GoldResourceInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            LumberResourceInstance.ResourceText = "9,999";
                            LumberResourceInstance.X = 10f;
                            LumberResourceInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                            LumberResourceInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                            LumberResourceInstance.Y = 0f;
                            LumberResourceInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                            LumberResourceInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            StoneResourceInstance.ResourceText = "99,999";
                            StoneResourceInstance.X = 10f;
                            StoneResourceInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                            StoneResourceInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                            StoneResourceInstance.Y = 0f;
                            StoneResourceInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                            StoneResourceInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            break;
                    }
                }
            }
            #endregion
            #region State Interpolation
            public void InterpolateBetween (VariableState firstState, VariableState secondState, float interpolationValue) 
            {
                #if DEBUG
                if (float.IsNaN(interpolationValue))
                {
                    throw new System.Exception("interpolationValue cannot be NaN");
                }
                #endif
                bool setCapacityResourceInstanceCurrentIconStateStateFirstValue = false;
                bool setCapacityResourceInstanceCurrentIconStateStateSecondValue = false;
                TownRaiserImGui.GumRuntimes.ResourceRuntime.IconState CapacityResourceInstanceCurrentIconStateStateFirstValue= TownRaiserImGui.GumRuntimes.ResourceRuntime.IconState.Lumber;
                TownRaiserImGui.GumRuntimes.ResourceRuntime.IconState CapacityResourceInstanceCurrentIconStateStateSecondValue= TownRaiserImGui.GumRuntimes.ResourceRuntime.IconState.Lumber;
                bool setCapacityResourceInstanceXFirstValue = false;
                bool setCapacityResourceInstanceXSecondValue = false;
                float CapacityResourceInstanceXFirstValue= 0;
                float CapacityResourceInstanceXSecondValue= 0;
                bool setCapacityResourceInstanceYFirstValue = false;
                bool setCapacityResourceInstanceYSecondValue = false;
                float CapacityResourceInstanceYFirstValue= 0;
                float CapacityResourceInstanceYSecondValue= 0;
                bool setGoldResourceInstanceCurrentIconStateStateFirstValue = false;
                bool setGoldResourceInstanceCurrentIconStateStateSecondValue = false;
                TownRaiserImGui.GumRuntimes.ResourceRuntime.IconState GoldResourceInstanceCurrentIconStateStateFirstValue= TownRaiserImGui.GumRuntimes.ResourceRuntime.IconState.Lumber;
                TownRaiserImGui.GumRuntimes.ResourceRuntime.IconState GoldResourceInstanceCurrentIconStateStateSecondValue= TownRaiserImGui.GumRuntimes.ResourceRuntime.IconState.Lumber;
                bool setGoldResourceInstanceXFirstValue = false;
                bool setGoldResourceInstanceXSecondValue = false;
                float GoldResourceInstanceXFirstValue= 0;
                float GoldResourceInstanceXSecondValue= 0;
                bool setGoldResourceInstanceYFirstValue = false;
                bool setGoldResourceInstanceYSecondValue = false;
                float GoldResourceInstanceYFirstValue= 0;
                float GoldResourceInstanceYSecondValue= 0;
                bool setHeightFirstValue = false;
                bool setHeightSecondValue = false;
                float HeightFirstValue= 0;
                float HeightSecondValue= 0;
                bool setLumberResourceInstanceCurrentIconStateStateFirstValue = false;
                bool setLumberResourceInstanceCurrentIconStateStateSecondValue = false;
                TownRaiserImGui.GumRuntimes.ResourceRuntime.IconState LumberResourceInstanceCurrentIconStateStateFirstValue= TownRaiserImGui.GumRuntimes.ResourceRuntime.IconState.Lumber;
                TownRaiserImGui.GumRuntimes.ResourceRuntime.IconState LumberResourceInstanceCurrentIconStateStateSecondValue= TownRaiserImGui.GumRuntimes.ResourceRuntime.IconState.Lumber;
                bool setLumberResourceInstanceXFirstValue = false;
                bool setLumberResourceInstanceXSecondValue = false;
                float LumberResourceInstanceXFirstValue= 0;
                float LumberResourceInstanceXSecondValue= 0;
                bool setLumberResourceInstanceYFirstValue = false;
                bool setLumberResourceInstanceYSecondValue = false;
                float LumberResourceInstanceYFirstValue= 0;
                float LumberResourceInstanceYSecondValue= 0;
                bool setStoneResourceInstanceCurrentIconStateStateFirstValue = false;
                bool setStoneResourceInstanceCurrentIconStateStateSecondValue = false;
                TownRaiserImGui.GumRuntimes.ResourceRuntime.IconState StoneResourceInstanceCurrentIconStateStateFirstValue= TownRaiserImGui.GumRuntimes.ResourceRuntime.IconState.Lumber;
                TownRaiserImGui.GumRuntimes.ResourceRuntime.IconState StoneResourceInstanceCurrentIconStateStateSecondValue= TownRaiserImGui.GumRuntimes.ResourceRuntime.IconState.Lumber;
                bool setStoneResourceInstanceXFirstValue = false;
                bool setStoneResourceInstanceXSecondValue = false;
                float StoneResourceInstanceXFirstValue= 0;
                float StoneResourceInstanceXSecondValue= 0;
                bool setStoneResourceInstanceYFirstValue = false;
                bool setStoneResourceInstanceYSecondValue = false;
                float StoneResourceInstanceYFirstValue= 0;
                float StoneResourceInstanceYSecondValue= 0;
                bool setWidthFirstValue = false;
                bool setWidthSecondValue = false;
                float WidthFirstValue= 0;
                float WidthSecondValue= 0;
                bool setXFirstValue = false;
                bool setXSecondValue = false;
                float XFirstValue= 0;
                float XSecondValue= 0;
                bool setYFirstValue = false;
                bool setYSecondValue = false;
                float YFirstValue= 0;
                float YSecondValue= 0;
                switch(firstState)
                {
                    case  VariableState.Default:
                        setCapacityResourceInstanceCurrentIconStateStateFirstValue = true;
                        CapacityResourceInstanceCurrentIconStateStateFirstValue = TownRaiserImGui.GumRuntimes.ResourceRuntime.IconState.Capacity;
                        if (interpolationValue < 1)
                        {
                            this.CapacityResourceInstance.ResourceText = "0";
                        }
                        setCapacityResourceInstanceXFirstValue = true;
                        CapacityResourceInstanceXFirstValue = 10f;
                        if (interpolationValue < 1)
                        {
                            this.CapacityResourceInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        if (interpolationValue < 1)
                        {
                            this.CapacityResourceInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        setCapacityResourceInstanceYFirstValue = true;
                        CapacityResourceInstanceYFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.CapacityResourceInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.CapacityResourceInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ChildrenLayout = Gum.Managers.ChildrenLayout.LeftToRightStack;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ClipsChildren = false;
                        }
                        setGoldResourceInstanceCurrentIconStateStateFirstValue = true;
                        GoldResourceInstanceCurrentIconStateStateFirstValue = TownRaiserImGui.GumRuntimes.ResourceRuntime.IconState.Gold;
                        setGoldResourceInstanceXFirstValue = true;
                        GoldResourceInstanceXFirstValue = 10f;
                        if (interpolationValue < 1)
                        {
                            this.GoldResourceInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        if (interpolationValue < 1)
                        {
                            this.GoldResourceInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        setGoldResourceInstanceYFirstValue = true;
                        GoldResourceInstanceYFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.GoldResourceInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.GoldResourceInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setHeightFirstValue = true;
                        HeightFirstValue = 24f;
                        if (interpolationValue < 1)
                        {
                            this.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        setLumberResourceInstanceCurrentIconStateStateFirstValue = true;
                        LumberResourceInstanceCurrentIconStateStateFirstValue = TownRaiserImGui.GumRuntimes.ResourceRuntime.IconState.Lumber;
                        if (interpolationValue < 1)
                        {
                            this.LumberResourceInstance.ResourceText = "9,999";
                        }
                        setLumberResourceInstanceXFirstValue = true;
                        LumberResourceInstanceXFirstValue = 10f;
                        if (interpolationValue < 1)
                        {
                            this.LumberResourceInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        if (interpolationValue < 1)
                        {
                            this.LumberResourceInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        setLumberResourceInstanceYFirstValue = true;
                        LumberResourceInstanceYFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.LumberResourceInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.LumberResourceInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setStoneResourceInstanceCurrentIconStateStateFirstValue = true;
                        StoneResourceInstanceCurrentIconStateStateFirstValue = TownRaiserImGui.GumRuntimes.ResourceRuntime.IconState.Stone;
                        if (interpolationValue < 1)
                        {
                            this.StoneResourceInstance.ResourceText = "99,999";
                        }
                        setStoneResourceInstanceXFirstValue = true;
                        StoneResourceInstanceXFirstValue = 10f;
                        if (interpolationValue < 1)
                        {
                            this.StoneResourceInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        if (interpolationValue < 1)
                        {
                            this.StoneResourceInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        setStoneResourceInstanceYFirstValue = true;
                        StoneResourceInstanceYFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.StoneResourceInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.StoneResourceInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        if (interpolationValue < 1)
                        {
                            this.Visible = true;
                        }
                        setWidthFirstValue = true;
                        WidthFirstValue = 323f;
                        if (interpolationValue < 1)
                        {
                            this.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        if (interpolationValue < 1)
                        {
                            this.WrapsChildren = false;
                        }
                        setXFirstValue = true;
                        XFirstValue = 1f;
                        if (interpolationValue < 1)
                        {
                            this.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        if (interpolationValue < 1)
                        {
                            this.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        setYFirstValue = true;
                        YFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                        }
                        if (interpolationValue < 1)
                        {
                            this.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        break;
                }
                switch(secondState)
                {
                    case  VariableState.Default:
                        setCapacityResourceInstanceCurrentIconStateStateSecondValue = true;
                        CapacityResourceInstanceCurrentIconStateStateSecondValue = TownRaiserImGui.GumRuntimes.ResourceRuntime.IconState.Capacity;
                        if (interpolationValue >= 1)
                        {
                            this.CapacityResourceInstance.ResourceText = "0";
                        }
                        setCapacityResourceInstanceXSecondValue = true;
                        CapacityResourceInstanceXSecondValue = 10f;
                        if (interpolationValue >= 1)
                        {
                            this.CapacityResourceInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.CapacityResourceInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        setCapacityResourceInstanceYSecondValue = true;
                        CapacityResourceInstanceYSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.CapacityResourceInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.CapacityResourceInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ChildrenLayout = Gum.Managers.ChildrenLayout.LeftToRightStack;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ClipsChildren = false;
                        }
                        setGoldResourceInstanceCurrentIconStateStateSecondValue = true;
                        GoldResourceInstanceCurrentIconStateStateSecondValue = TownRaiserImGui.GumRuntimes.ResourceRuntime.IconState.Gold;
                        setGoldResourceInstanceXSecondValue = true;
                        GoldResourceInstanceXSecondValue = 10f;
                        if (interpolationValue >= 1)
                        {
                            this.GoldResourceInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.GoldResourceInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        setGoldResourceInstanceYSecondValue = true;
                        GoldResourceInstanceYSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.GoldResourceInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.GoldResourceInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setHeightSecondValue = true;
                        HeightSecondValue = 24f;
                        if (interpolationValue >= 1)
                        {
                            this.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        setLumberResourceInstanceCurrentIconStateStateSecondValue = true;
                        LumberResourceInstanceCurrentIconStateStateSecondValue = TownRaiserImGui.GumRuntimes.ResourceRuntime.IconState.Lumber;
                        if (interpolationValue >= 1)
                        {
                            this.LumberResourceInstance.ResourceText = "9,999";
                        }
                        setLumberResourceInstanceXSecondValue = true;
                        LumberResourceInstanceXSecondValue = 10f;
                        if (interpolationValue >= 1)
                        {
                            this.LumberResourceInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.LumberResourceInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        setLumberResourceInstanceYSecondValue = true;
                        LumberResourceInstanceYSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.LumberResourceInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.LumberResourceInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setStoneResourceInstanceCurrentIconStateStateSecondValue = true;
                        StoneResourceInstanceCurrentIconStateStateSecondValue = TownRaiserImGui.GumRuntimes.ResourceRuntime.IconState.Stone;
                        if (interpolationValue >= 1)
                        {
                            this.StoneResourceInstance.ResourceText = "99,999";
                        }
                        setStoneResourceInstanceXSecondValue = true;
                        StoneResourceInstanceXSecondValue = 10f;
                        if (interpolationValue >= 1)
                        {
                            this.StoneResourceInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.StoneResourceInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        setStoneResourceInstanceYSecondValue = true;
                        StoneResourceInstanceYSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.StoneResourceInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.StoneResourceInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.Visible = true;
                        }
                        setWidthSecondValue = true;
                        WidthSecondValue = 323f;
                        if (interpolationValue >= 1)
                        {
                            this.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.WrapsChildren = false;
                        }
                        setXSecondValue = true;
                        XSecondValue = 1f;
                        if (interpolationValue >= 1)
                        {
                            this.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        setYSecondValue = true;
                        YSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        break;
                }
                if (setCapacityResourceInstanceCurrentIconStateStateFirstValue && setCapacityResourceInstanceCurrentIconStateStateSecondValue)
                {
                    CapacityResourceInstance.InterpolateBetween(CapacityResourceInstanceCurrentIconStateStateFirstValue, CapacityResourceInstanceCurrentIconStateStateSecondValue, interpolationValue);
                }
                if (setCapacityResourceInstanceXFirstValue && setCapacityResourceInstanceXSecondValue)
                {
                    CapacityResourceInstance.X = CapacityResourceInstanceXFirstValue * (1 - interpolationValue) + CapacityResourceInstanceXSecondValue * interpolationValue;
                }
                if (setCapacityResourceInstanceYFirstValue && setCapacityResourceInstanceYSecondValue)
                {
                    CapacityResourceInstance.Y = CapacityResourceInstanceYFirstValue * (1 - interpolationValue) + CapacityResourceInstanceYSecondValue * interpolationValue;
                }
                if (setGoldResourceInstanceCurrentIconStateStateFirstValue && setGoldResourceInstanceCurrentIconStateStateSecondValue)
                {
                    GoldResourceInstance.InterpolateBetween(GoldResourceInstanceCurrentIconStateStateFirstValue, GoldResourceInstanceCurrentIconStateStateSecondValue, interpolationValue);
                }
                if (setGoldResourceInstanceXFirstValue && setGoldResourceInstanceXSecondValue)
                {
                    GoldResourceInstance.X = GoldResourceInstanceXFirstValue * (1 - interpolationValue) + GoldResourceInstanceXSecondValue * interpolationValue;
                }
                if (setGoldResourceInstanceYFirstValue && setGoldResourceInstanceYSecondValue)
                {
                    GoldResourceInstance.Y = GoldResourceInstanceYFirstValue * (1 - interpolationValue) + GoldResourceInstanceYSecondValue * interpolationValue;
                }
                if (setHeightFirstValue && setHeightSecondValue)
                {
                    Height = HeightFirstValue * (1 - interpolationValue) + HeightSecondValue * interpolationValue;
                }
                if (setLumberResourceInstanceCurrentIconStateStateFirstValue && setLumberResourceInstanceCurrentIconStateStateSecondValue)
                {
                    LumberResourceInstance.InterpolateBetween(LumberResourceInstanceCurrentIconStateStateFirstValue, LumberResourceInstanceCurrentIconStateStateSecondValue, interpolationValue);
                }
                if (setLumberResourceInstanceXFirstValue && setLumberResourceInstanceXSecondValue)
                {
                    LumberResourceInstance.X = LumberResourceInstanceXFirstValue * (1 - interpolationValue) + LumberResourceInstanceXSecondValue * interpolationValue;
                }
                if (setLumberResourceInstanceYFirstValue && setLumberResourceInstanceYSecondValue)
                {
                    LumberResourceInstance.Y = LumberResourceInstanceYFirstValue * (1 - interpolationValue) + LumberResourceInstanceYSecondValue * interpolationValue;
                }
                if (setStoneResourceInstanceCurrentIconStateStateFirstValue && setStoneResourceInstanceCurrentIconStateStateSecondValue)
                {
                    StoneResourceInstance.InterpolateBetween(StoneResourceInstanceCurrentIconStateStateFirstValue, StoneResourceInstanceCurrentIconStateStateSecondValue, interpolationValue);
                }
                if (setStoneResourceInstanceXFirstValue && setStoneResourceInstanceXSecondValue)
                {
                    StoneResourceInstance.X = StoneResourceInstanceXFirstValue * (1 - interpolationValue) + StoneResourceInstanceXSecondValue * interpolationValue;
                }
                if (setStoneResourceInstanceYFirstValue && setStoneResourceInstanceYSecondValue)
                {
                    StoneResourceInstance.Y = StoneResourceInstanceYFirstValue * (1 - interpolationValue) + StoneResourceInstanceYSecondValue * interpolationValue;
                }
                if (setWidthFirstValue && setWidthSecondValue)
                {
                    Width = WidthFirstValue * (1 - interpolationValue) + WidthSecondValue * interpolationValue;
                }
                if (setXFirstValue && setXSecondValue)
                {
                    X = XFirstValue * (1 - interpolationValue) + XSecondValue * interpolationValue;
                }
                if (setYFirstValue && setYSecondValue)
                {
                    Y = YFirstValue * (1 - interpolationValue) + YSecondValue * interpolationValue;
                }
                if (interpolationValue < 1)
                {
                    mCurrentVariableState = firstState;
                }
                else
                {
                    mCurrentVariableState = secondState;
                }
            }
            #endregion
            #region State Interpolate To
            public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateTo (TownRaiserImGui.GumRuntimes.ResourceDisplayRuntime.VariableState fromState,TownRaiserImGui.GumRuntimes.ResourceDisplayRuntime.VariableState toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null) 
            {
                FlatRedBall.Glue.StateInterpolation.Tweener tweener = new FlatRedBall.Glue.StateInterpolation.Tweener(from:0, to:1, duration:(float)secondsToTake, type:interpolationType, easing:easing );
                if (owner == null)
                {
                    tweener.Owner = this;
                }
                else
                {
                    tweener.Owner = owner;
                }
                tweener.PositionChanged = newPosition => this.InterpolateBetween(fromState, toState, newPosition);
                tweener.Start();
                StateInterpolationPlugin.TweenerManager.Self.Add(tweener);
                return tweener;
            }
            public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateTo (VariableState toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null ) 
            {
                Gum.DataTypes.Variables.StateSave current = GetCurrentValuesOnState(toState);
                Gum.DataTypes.Variables.StateSave toAsStateSave = this.ElementSave.States.First(item => item.Name == toState.ToString());
                FlatRedBall.Glue.StateInterpolation.Tweener tweener = new FlatRedBall.Glue.StateInterpolation.Tweener(from: 0, to: 1, duration: (float)secondsToTake, type: interpolationType, easing: easing);
                if (owner == null)
                {
                    tweener.Owner = this;
                }
                else
                {
                    tweener.Owner = owner;
                }
                tweener.PositionChanged = newPosition => this.InterpolateBetween(current, toAsStateSave, newPosition);
                tweener.Ended += ()=> this.CurrentVariableState = toState;
                tweener.Start();
                StateInterpolationPlugin.TweenerManager.Self.Add(tweener);
                return tweener;
            }
            public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateToRelative (VariableState toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null ) 
            {
                Gum.DataTypes.Variables.StateSave current = GetCurrentValuesOnState(toState);
                Gum.DataTypes.Variables.StateSave toAsStateSave = AddToCurrentValuesWithState(toState);
                FlatRedBall.Glue.StateInterpolation.Tweener tweener = new FlatRedBall.Glue.StateInterpolation.Tweener(from: 0, to: 1, duration: (float)secondsToTake, type: interpolationType, easing: easing);
                if (owner == null)
                {
                    tweener.Owner = this;
                }
                else
                {
                    tweener.Owner = owner;
                }
                tweener.PositionChanged = newPosition => this.InterpolateBetween(current, toAsStateSave, newPosition);
                tweener.Ended += ()=> this.CurrentVariableState = toState;
                tweener.Start();
                StateInterpolationPlugin.TweenerManager.Self.Add(tweener);
                return tweener;
            }
            #endregion
            #region State Animations
            #endregion
            public override void StopAnimations () 
            {
                base.StopAnimations();
                CapacityResourceInstance.StopAnimations();
                GoldResourceInstance.StopAnimations();
                LumberResourceInstance.StopAnimations();
                StoneResourceInstance.StopAnimations();
            }
            #region Get Current Values on State
            private Gum.DataTypes.Variables.StateSave GetCurrentValuesOnState (VariableState state) 
            {
                Gum.DataTypes.Variables.StateSave newState = new Gum.DataTypes.Variables.StateSave();
                switch(state)
                {
                    case  VariableState.Default:
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Children Layout",
                            Type = "ChildrenLayout",
                            Value = ChildrenLayout
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Clips Children",
                            Type = "bool",
                            Value = ClipsChildren
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Height",
                            Type = "float",
                            Value = Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Height Units",
                            Type = "DimensionUnitType",
                            Value = HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Visible",
                            Type = "bool",
                            Value = Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Width",
                            Type = "float",
                            Value = Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Width Units",
                            Type = "DimensionUnitType",
                            Value = WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Wraps Children",
                            Type = "bool",
                            Value = WrapsChildren
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "X",
                            Type = "float",
                            Value = X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "X Origin",
                            Type = "HorizontalAlignment",
                            Value = XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "X Units",
                            Type = "PositionUnitType",
                            Value = XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Y",
                            Type = "float",
                            Value = Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Y Origin",
                            Type = "VerticalAlignment",
                            Value = YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Y Units",
                            Type = "PositionUnitType",
                            Value = YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CapacityResourceInstance.IconStateState",
                            Type = "IconStateState",
                            Value = CapacityResourceInstance.CurrentIconStateState
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CapacityResourceInstance.ResourceText",
                            Type = "string",
                            Value = CapacityResourceInstance.ResourceText
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CapacityResourceInstance.X",
                            Type = "float",
                            Value = CapacityResourceInstance.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CapacityResourceInstance.X Origin",
                            Type = "HorizontalAlignment",
                            Value = CapacityResourceInstance.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CapacityResourceInstance.X Units",
                            Type = "PositionUnitType",
                            Value = CapacityResourceInstance.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CapacityResourceInstance.Y",
                            Type = "float",
                            Value = CapacityResourceInstance.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CapacityResourceInstance.Y Origin",
                            Type = "VerticalAlignment",
                            Value = CapacityResourceInstance.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CapacityResourceInstance.Y Units",
                            Type = "PositionUnitType",
                            Value = CapacityResourceInstance.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "GoldResourceInstance.IconStateState",
                            Type = "IconStateState",
                            Value = GoldResourceInstance.CurrentIconStateState
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "GoldResourceInstance.X",
                            Type = "float",
                            Value = GoldResourceInstance.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "GoldResourceInstance.X Origin",
                            Type = "HorizontalAlignment",
                            Value = GoldResourceInstance.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "GoldResourceInstance.X Units",
                            Type = "PositionUnitType",
                            Value = GoldResourceInstance.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "GoldResourceInstance.Y",
                            Type = "float",
                            Value = GoldResourceInstance.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "GoldResourceInstance.Y Origin",
                            Type = "VerticalAlignment",
                            Value = GoldResourceInstance.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "GoldResourceInstance.Y Units",
                            Type = "PositionUnitType",
                            Value = GoldResourceInstance.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LumberResourceInstance.IconStateState",
                            Type = "IconStateState",
                            Value = LumberResourceInstance.CurrentIconStateState
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LumberResourceInstance.ResourceText",
                            Type = "string",
                            Value = LumberResourceInstance.ResourceText
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LumberResourceInstance.X",
                            Type = "float",
                            Value = LumberResourceInstance.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LumberResourceInstance.X Origin",
                            Type = "HorizontalAlignment",
                            Value = LumberResourceInstance.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LumberResourceInstance.X Units",
                            Type = "PositionUnitType",
                            Value = LumberResourceInstance.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LumberResourceInstance.Y",
                            Type = "float",
                            Value = LumberResourceInstance.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LumberResourceInstance.Y Origin",
                            Type = "VerticalAlignment",
                            Value = LumberResourceInstance.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LumberResourceInstance.Y Units",
                            Type = "PositionUnitType",
                            Value = LumberResourceInstance.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "StoneResourceInstance.IconStateState",
                            Type = "IconStateState",
                            Value = StoneResourceInstance.CurrentIconStateState
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "StoneResourceInstance.ResourceText",
                            Type = "string",
                            Value = StoneResourceInstance.ResourceText
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "StoneResourceInstance.X",
                            Type = "float",
                            Value = StoneResourceInstance.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "StoneResourceInstance.X Origin",
                            Type = "HorizontalAlignment",
                            Value = StoneResourceInstance.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "StoneResourceInstance.X Units",
                            Type = "PositionUnitType",
                            Value = StoneResourceInstance.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "StoneResourceInstance.Y",
                            Type = "float",
                            Value = StoneResourceInstance.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "StoneResourceInstance.Y Origin",
                            Type = "VerticalAlignment",
                            Value = StoneResourceInstance.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "StoneResourceInstance.Y Units",
                            Type = "PositionUnitType",
                            Value = StoneResourceInstance.YUnits
                        }
                        );
                        break;
                }
                return newState;
            }
            private Gum.DataTypes.Variables.StateSave AddToCurrentValuesWithState (VariableState state) 
            {
                Gum.DataTypes.Variables.StateSave newState = new Gum.DataTypes.Variables.StateSave();
                switch(state)
                {
                    case  VariableState.Default:
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Children Layout",
                            Type = "ChildrenLayout",
                            Value = ChildrenLayout
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Clips Children",
                            Type = "bool",
                            Value = ClipsChildren
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Height",
                            Type = "float",
                            Value = Height + 24f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Height Units",
                            Type = "DimensionUnitType",
                            Value = HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Visible",
                            Type = "bool",
                            Value = Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Width",
                            Type = "float",
                            Value = Width + 323f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Width Units",
                            Type = "DimensionUnitType",
                            Value = WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Wraps Children",
                            Type = "bool",
                            Value = WrapsChildren
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "X",
                            Type = "float",
                            Value = X + 1f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "X Origin",
                            Type = "HorizontalAlignment",
                            Value = XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "X Units",
                            Type = "PositionUnitType",
                            Value = XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Y",
                            Type = "float",
                            Value = Y + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Y Origin",
                            Type = "VerticalAlignment",
                            Value = YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Y Units",
                            Type = "PositionUnitType",
                            Value = YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CapacityResourceInstance.IconStateState",
                            Type = "IconStateState",
                            Value = CapacityResourceInstance.CurrentIconStateState
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CapacityResourceInstance.ResourceText",
                            Type = "string",
                            Value = CapacityResourceInstance.ResourceText
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CapacityResourceInstance.X",
                            Type = "float",
                            Value = CapacityResourceInstance.X + 10f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CapacityResourceInstance.X Origin",
                            Type = "HorizontalAlignment",
                            Value = CapacityResourceInstance.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CapacityResourceInstance.X Units",
                            Type = "PositionUnitType",
                            Value = CapacityResourceInstance.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CapacityResourceInstance.Y",
                            Type = "float",
                            Value = CapacityResourceInstance.Y + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CapacityResourceInstance.Y Origin",
                            Type = "VerticalAlignment",
                            Value = CapacityResourceInstance.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CapacityResourceInstance.Y Units",
                            Type = "PositionUnitType",
                            Value = CapacityResourceInstance.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "GoldResourceInstance.IconStateState",
                            Type = "IconStateState",
                            Value = GoldResourceInstance.CurrentIconStateState
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "GoldResourceInstance.X",
                            Type = "float",
                            Value = GoldResourceInstance.X + 10f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "GoldResourceInstance.X Origin",
                            Type = "HorizontalAlignment",
                            Value = GoldResourceInstance.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "GoldResourceInstance.X Units",
                            Type = "PositionUnitType",
                            Value = GoldResourceInstance.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "GoldResourceInstance.Y",
                            Type = "float",
                            Value = GoldResourceInstance.Y + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "GoldResourceInstance.Y Origin",
                            Type = "VerticalAlignment",
                            Value = GoldResourceInstance.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "GoldResourceInstance.Y Units",
                            Type = "PositionUnitType",
                            Value = GoldResourceInstance.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LumberResourceInstance.IconStateState",
                            Type = "IconStateState",
                            Value = LumberResourceInstance.CurrentIconStateState
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LumberResourceInstance.ResourceText",
                            Type = "string",
                            Value = LumberResourceInstance.ResourceText
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LumberResourceInstance.X",
                            Type = "float",
                            Value = LumberResourceInstance.X + 10f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LumberResourceInstance.X Origin",
                            Type = "HorizontalAlignment",
                            Value = LumberResourceInstance.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LumberResourceInstance.X Units",
                            Type = "PositionUnitType",
                            Value = LumberResourceInstance.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LumberResourceInstance.Y",
                            Type = "float",
                            Value = LumberResourceInstance.Y + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LumberResourceInstance.Y Origin",
                            Type = "VerticalAlignment",
                            Value = LumberResourceInstance.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "LumberResourceInstance.Y Units",
                            Type = "PositionUnitType",
                            Value = LumberResourceInstance.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "StoneResourceInstance.IconStateState",
                            Type = "IconStateState",
                            Value = StoneResourceInstance.CurrentIconStateState
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "StoneResourceInstance.ResourceText",
                            Type = "string",
                            Value = StoneResourceInstance.ResourceText
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "StoneResourceInstance.X",
                            Type = "float",
                            Value = StoneResourceInstance.X + 10f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "StoneResourceInstance.X Origin",
                            Type = "HorizontalAlignment",
                            Value = StoneResourceInstance.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "StoneResourceInstance.X Units",
                            Type = "PositionUnitType",
                            Value = StoneResourceInstance.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "StoneResourceInstance.Y",
                            Type = "float",
                            Value = StoneResourceInstance.Y + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "StoneResourceInstance.Y Origin",
                            Type = "VerticalAlignment",
                            Value = StoneResourceInstance.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "StoneResourceInstance.Y Units",
                            Type = "PositionUnitType",
                            Value = StoneResourceInstance.YUnits
                        }
                        );
                        break;
                }
                return newState;
            }
            #endregion
            public override void ApplyState (Gum.DataTypes.Variables.StateSave state) 
            {
                bool matches = this.ElementSave.AllStates.Contains(state);
                if (matches)
                {
                    var category = this.ElementSave.Categories.FirstOrDefault(item => item.States.Contains(state));
                    if (category == null)
                    {
                        if (state.Name == "Default") this.mCurrentVariableState = VariableState.Default;
                    }
                }
                base.ApplyState(state);
            }
            private TownRaiserImGui.GumRuntimes.ResourceRuntime CapacityResourceInstance { get; set; }
            private TownRaiserImGui.GumRuntimes.ResourceRuntime GoldResourceInstance { get; set; }
            private TownRaiserImGui.GumRuntimes.ResourceRuntime LumberResourceInstance { get; set; }
            private TownRaiserImGui.GumRuntimes.ResourceRuntime StoneResourceInstance { get; set; }
            public string CapacityText
            {
                get
                {
                    return CapacityResourceInstance.ResourceText;
                }
                set
                {
                    if (CapacityResourceInstance.ResourceText != value)
                    {
                        CapacityResourceInstance.ResourceText = value;
                        CapacityTextChanged?.Invoke(this, null);
                    }
                }
            }
            public string GoldText
            {
                get
                {
                    return GoldResourceInstance.ResourceText;
                }
                set
                {
                    if (GoldResourceInstance.ResourceText != value)
                    {
                        GoldResourceInstance.ResourceText = value;
                        GoldTextChanged?.Invoke(this, null);
                    }
                }
            }
            public string LumberText
            {
                get
                {
                    return LumberResourceInstance.ResourceText;
                }
                set
                {
                    if (LumberResourceInstance.ResourceText != value)
                    {
                        LumberResourceInstance.ResourceText = value;
                        LumberTextChanged?.Invoke(this, null);
                    }
                }
            }
            public string StoneText
            {
                get
                {
                    return StoneResourceInstance.ResourceText;
                }
                set
                {
                    if (StoneResourceInstance.ResourceText != value)
                    {
                        StoneResourceInstance.ResourceText = value;
                        StoneTextChanged?.Invoke(this, null);
                    }
                }
            }
            public event FlatRedBall.Gui.WindowEvent CapacityResourceInstanceClick;
            public event FlatRedBall.Gui.WindowEvent GoldResourceInstanceClick;
            public event FlatRedBall.Gui.WindowEvent LumberResourceInstanceClick;
            public event FlatRedBall.Gui.WindowEvent StoneResourceInstanceClick;
            public event System.EventHandler CapacityTextChanged;
            public event System.EventHandler GoldTextChanged;
            public event System.EventHandler LumberTextChanged;
            public event System.EventHandler StoneTextChanged;
            public ResourceDisplayRuntime (bool fullInstantiation = true, bool tryCreateFormsObject = true) 
            	: base(false, tryCreateFormsObject)
            {
                this.HasEvents = false;
                this.ExposeChildrenEvents = true;
                if (fullInstantiation)
                {
                    Gum.DataTypes.ElementSave elementSave = Gum.Managers.ObjectFinder.Self.GumProjectSave.Components.First(item => item.Name == "ResourceDisplay");
                    this.ElementSave = elementSave;
                    string oldDirectory = FlatRedBall.IO.FileManager.RelativeDirectory;
                    FlatRedBall.IO.FileManager.RelativeDirectory = FlatRedBall.IO.FileManager.GetDirectory(Gum.Managers.ObjectFinder.Self.GumProjectSave.FullFileName);
                    GumRuntime.ElementSaveExtensions.SetGraphicalUiElement(elementSave, this, RenderingLibrary.SystemManagers.Default);
                    FlatRedBall.IO.FileManager.RelativeDirectory = oldDirectory;
                }
            }
            public override void SetInitialState () 
            {
                base.SetInitialState();
                this.CurrentVariableState = VariableState.Default;
                CallCustomInitialize();
            }
            public override void CreateChildrenRecursively (Gum.DataTypes.ElementSave elementSave, RenderingLibrary.SystemManagers systemManagers) 
            {
                base.CreateChildrenRecursively(elementSave, systemManagers);
                this.AssignReferences();
            }
            private void AssignReferences () 
            {
                CapacityResourceInstance = this.GetGraphicalUiElementByName("CapacityResourceInstance") as TownRaiserImGui.GumRuntimes.ResourceRuntime;
                GoldResourceInstance = this.GetGraphicalUiElementByName("GoldResourceInstance") as TownRaiserImGui.GumRuntimes.ResourceRuntime;
                LumberResourceInstance = this.GetGraphicalUiElementByName("LumberResourceInstance") as TownRaiserImGui.GumRuntimes.ResourceRuntime;
                StoneResourceInstance = this.GetGraphicalUiElementByName("StoneResourceInstance") as TownRaiserImGui.GumRuntimes.ResourceRuntime;
                CapacityResourceInstance.Click += (unused) => CapacityResourceInstanceClick?.Invoke(this);
                GoldResourceInstance.Click += (unused) => GoldResourceInstanceClick?.Invoke(this);
                LumberResourceInstance.Click += (unused) => LumberResourceInstanceClick?.Invoke(this);
                StoneResourceInstance.Click += (unused) => StoneResourceInstanceClick?.Invoke(this);
            }
            public override void AddToManagers (RenderingLibrary.SystemManagers managers, RenderingLibrary.Graphics.Layer layer) 
            {
                base.AddToManagers(managers, layer);
            }
            private void CallCustomInitialize () 
            {
                CustomInitialize();
            }
            partial void CustomInitialize();
        }
    }
