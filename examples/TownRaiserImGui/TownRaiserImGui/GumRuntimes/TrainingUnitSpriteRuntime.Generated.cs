    using System.Linq;
    namespace TownRaiserImGui.GumRuntimes
    {
        public partial class TrainingUnitSpriteRuntime : TownRaiserImGui.GumRuntimes.SpriteRuntime
        {
            #region State Enums
            public enum VariableState
            {
                Default
            }
            public enum TrainingProgress
            {
                Waiting,
                Quarter,
                Half,
                ThreeQuarter,
                Finished
            }
            #endregion
            #region State Fields
            VariableState mCurrentVariableState;
            TrainingProgress? mCurrentTrainingProgressState;
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
                            Alpha = 255;
                            Animate = false;
                            Blue = 255;
                            FlipHorizontal = false;
                            FlipVertical = false;
                            Green = 255;
                            Height = 100f;
                            HeightUnits = Gum.DataTypes.DimensionUnitType.PercentageOfSourceFile;
                            Red = 255;
                            SetProperty("SourceFile", "..\\MainTileset.png");
                            TextureAddress = Gum.Managers.TextureAddress.Custom;
                            TextureHeight = 16;
                            TextureHeightScale = 1f;
                            TextureLeft = 48;
                            TextureTop = 178;
                            TextureWidth = 16;
                            TextureWidthScale = 1f;
                            Visible = true;
                            Width = 100f;
                            WidthUnits = Gum.DataTypes.DimensionUnitType.PercentageOfSourceFile;
                            Wrap = false;
                            XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                            XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                            YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                            YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                            break;
                    }
                }
            }
            public TrainingProgress? CurrentTrainingProgressState
            {
                get
                {
                    return mCurrentTrainingProgressState;
                }
                set
                {
                    if (value != null)
                    {
                        mCurrentTrainingProgressState = value;
                        switch(mCurrentTrainingProgressState)
                        {
                            case  TrainingProgress.Waiting:
                                Blue = 50;
                                Green = 50;
                                Red = 50;
                                break;
                            case  TrainingProgress.Quarter:
                                Blue = 0;
                                Green = 0;
                                Red = 255;
                                break;
                            case  TrainingProgress.Half:
                                Blue = 0;
                                Green = 165;
                                Red = 255;
                                break;
                            case  TrainingProgress.ThreeQuarter:
                                Blue = 0;
                                Green = 255;
                                Red = 255;
                                break;
                            case  TrainingProgress.Finished:
                                Blue = 255;
                                Green = 255;
                                Red = 255;
                                break;
                        }
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
                bool setAlphaFirstValue = false;
                bool setAlphaSecondValue = false;
                int AlphaFirstValue= 0;
                int AlphaSecondValue= 0;
                bool setBlueFirstValue = false;
                bool setBlueSecondValue = false;
                int BlueFirstValue= 0;
                int BlueSecondValue= 0;
                bool setGreenFirstValue = false;
                bool setGreenSecondValue = false;
                int GreenFirstValue= 0;
                int GreenSecondValue= 0;
                bool setHeightFirstValue = false;
                bool setHeightSecondValue = false;
                float HeightFirstValue= 0;
                float HeightSecondValue= 0;
                bool setRedFirstValue = false;
                bool setRedSecondValue = false;
                int RedFirstValue= 0;
                int RedSecondValue= 0;
                bool setTextureHeightFirstValue = false;
                bool setTextureHeightSecondValue = false;
                int TextureHeightFirstValue= 0;
                int TextureHeightSecondValue= 0;
                bool setTextureHeightScaleFirstValue = false;
                bool setTextureHeightScaleSecondValue = false;
                float TextureHeightScaleFirstValue= 0;
                float TextureHeightScaleSecondValue= 0;
                bool setTextureLeftFirstValue = false;
                bool setTextureLeftSecondValue = false;
                int TextureLeftFirstValue= 0;
                int TextureLeftSecondValue= 0;
                bool setTextureTopFirstValue = false;
                bool setTextureTopSecondValue = false;
                int TextureTopFirstValue= 0;
                int TextureTopSecondValue= 0;
                bool setTextureWidthFirstValue = false;
                bool setTextureWidthSecondValue = false;
                int TextureWidthFirstValue= 0;
                int TextureWidthSecondValue= 0;
                bool setTextureWidthScaleFirstValue = false;
                bool setTextureWidthScaleSecondValue = false;
                float TextureWidthScaleFirstValue= 0;
                float TextureWidthScaleSecondValue= 0;
                bool setWidthFirstValue = false;
                bool setWidthSecondValue = false;
                float WidthFirstValue= 0;
                float WidthSecondValue= 0;
                switch(firstState)
                {
                    case  VariableState.Default:
                        setAlphaFirstValue = true;
                        AlphaFirstValue = 255;
                        if (interpolationValue < 1)
                        {
                            this.Animate = false;
                        }
                        setBlueFirstValue = true;
                        BlueFirstValue = 255;
                        if (interpolationValue < 1)
                        {
                            this.FlipHorizontal = false;
                        }
                        if (interpolationValue < 1)
                        {
                            this.FlipVertical = false;
                        }
                        setGreenFirstValue = true;
                        GreenFirstValue = 255;
                        setHeightFirstValue = true;
                        HeightFirstValue = 100f;
                        if (interpolationValue < 1)
                        {
                            this.HeightUnits = Gum.DataTypes.DimensionUnitType.PercentageOfSourceFile;
                        }
                        setRedFirstValue = true;
                        RedFirstValue = 255;
                        if (interpolationValue < 1)
                        {
                            SetProperty("SourceFile", "..\\MainTileset.png");
                        }
                        if (interpolationValue < 1)
                        {
                            this.TextureAddress = Gum.Managers.TextureAddress.Custom;
                        }
                        setTextureHeightFirstValue = true;
                        TextureHeightFirstValue = 16;
                        setTextureHeightScaleFirstValue = true;
                        TextureHeightScaleFirstValue = 1f;
                        setTextureLeftFirstValue = true;
                        TextureLeftFirstValue = 48;
                        setTextureTopFirstValue = true;
                        TextureTopFirstValue = 178;
                        setTextureWidthFirstValue = true;
                        TextureWidthFirstValue = 16;
                        setTextureWidthScaleFirstValue = true;
                        TextureWidthScaleFirstValue = 1f;
                        if (interpolationValue < 1)
                        {
                            this.Visible = true;
                        }
                        setWidthFirstValue = true;
                        WidthFirstValue = 100f;
                        if (interpolationValue < 1)
                        {
                            this.WidthUnits = Gum.DataTypes.DimensionUnitType.PercentageOfSourceFile;
                        }
                        if (interpolationValue < 1)
                        {
                            this.Wrap = false;
                        }
                        if (interpolationValue < 1)
                        {
                            this.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        if (interpolationValue < 1)
                        {
                            this.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
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
                        setAlphaSecondValue = true;
                        AlphaSecondValue = 255;
                        if (interpolationValue >= 1)
                        {
                            this.Animate = false;
                        }
                        setBlueSecondValue = true;
                        BlueSecondValue = 255;
                        if (interpolationValue >= 1)
                        {
                            this.FlipHorizontal = false;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.FlipVertical = false;
                        }
                        setGreenSecondValue = true;
                        GreenSecondValue = 255;
                        setHeightSecondValue = true;
                        HeightSecondValue = 100f;
                        if (interpolationValue >= 1)
                        {
                            this.HeightUnits = Gum.DataTypes.DimensionUnitType.PercentageOfSourceFile;
                        }
                        setRedSecondValue = true;
                        RedSecondValue = 255;
                        if (interpolationValue >= 1)
                        {
                            SetProperty("SourceFile", "..\\MainTileset.png");
                        }
                        if (interpolationValue >= 1)
                        {
                            this.TextureAddress = Gum.Managers.TextureAddress.Custom;
                        }
                        setTextureHeightSecondValue = true;
                        TextureHeightSecondValue = 16;
                        setTextureHeightScaleSecondValue = true;
                        TextureHeightScaleSecondValue = 1f;
                        setTextureLeftSecondValue = true;
                        TextureLeftSecondValue = 48;
                        setTextureTopSecondValue = true;
                        TextureTopSecondValue = 178;
                        setTextureWidthSecondValue = true;
                        TextureWidthSecondValue = 16;
                        setTextureWidthScaleSecondValue = true;
                        TextureWidthScaleSecondValue = 1f;
                        if (interpolationValue >= 1)
                        {
                            this.Visible = true;
                        }
                        setWidthSecondValue = true;
                        WidthSecondValue = 100f;
                        if (interpolationValue >= 1)
                        {
                            this.WidthUnits = Gum.DataTypes.DimensionUnitType.PercentageOfSourceFile;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.Wrap = false;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
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
                if (setAlphaFirstValue && setAlphaSecondValue)
                {
                    Alpha = FlatRedBall.Math.MathFunctions.RoundToInt(AlphaFirstValue* (1 - interpolationValue) + AlphaSecondValue * interpolationValue);
                }
                if (setBlueFirstValue && setBlueSecondValue)
                {
                    Blue = FlatRedBall.Math.MathFunctions.RoundToInt(BlueFirstValue* (1 - interpolationValue) + BlueSecondValue * interpolationValue);
                }
                if (setGreenFirstValue && setGreenSecondValue)
                {
                    Green = FlatRedBall.Math.MathFunctions.RoundToInt(GreenFirstValue* (1 - interpolationValue) + GreenSecondValue * interpolationValue);
                }
                if (setHeightFirstValue && setHeightSecondValue)
                {
                    Height = HeightFirstValue * (1 - interpolationValue) + HeightSecondValue * interpolationValue;
                }
                if (setRedFirstValue && setRedSecondValue)
                {
                    Red = FlatRedBall.Math.MathFunctions.RoundToInt(RedFirstValue* (1 - interpolationValue) + RedSecondValue * interpolationValue);
                }
                if (setTextureHeightFirstValue && setTextureHeightSecondValue)
                {
                    TextureHeight = FlatRedBall.Math.MathFunctions.RoundToInt(TextureHeightFirstValue* (1 - interpolationValue) + TextureHeightSecondValue * interpolationValue);
                }
                if (setTextureHeightScaleFirstValue && setTextureHeightScaleSecondValue)
                {
                    TextureHeightScale = TextureHeightScaleFirstValue * (1 - interpolationValue) + TextureHeightScaleSecondValue * interpolationValue;
                }
                if (setTextureLeftFirstValue && setTextureLeftSecondValue)
                {
                    TextureLeft = FlatRedBall.Math.MathFunctions.RoundToInt(TextureLeftFirstValue* (1 - interpolationValue) + TextureLeftSecondValue * interpolationValue);
                }
                if (setTextureTopFirstValue && setTextureTopSecondValue)
                {
                    TextureTop = FlatRedBall.Math.MathFunctions.RoundToInt(TextureTopFirstValue* (1 - interpolationValue) + TextureTopSecondValue * interpolationValue);
                }
                if (setTextureWidthFirstValue && setTextureWidthSecondValue)
                {
                    TextureWidth = FlatRedBall.Math.MathFunctions.RoundToInt(TextureWidthFirstValue* (1 - interpolationValue) + TextureWidthSecondValue * interpolationValue);
                }
                if (setTextureWidthScaleFirstValue && setTextureWidthScaleSecondValue)
                {
                    TextureWidthScale = TextureWidthScaleFirstValue * (1 - interpolationValue) + TextureWidthScaleSecondValue * interpolationValue;
                }
                if (setWidthFirstValue && setWidthSecondValue)
                {
                    Width = WidthFirstValue * (1 - interpolationValue) + WidthSecondValue * interpolationValue;
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
            public void InterpolateBetween (TrainingProgress firstState, TrainingProgress secondState, float interpolationValue) 
            {
                #if DEBUG
                if (float.IsNaN(interpolationValue))
                {
                    throw new System.Exception("interpolationValue cannot be NaN");
                }
                #endif
                bool setBlueFirstValue = false;
                bool setBlueSecondValue = false;
                int BlueFirstValue= 0;
                int BlueSecondValue= 0;
                bool setGreenFirstValue = false;
                bool setGreenSecondValue = false;
                int GreenFirstValue= 0;
                int GreenSecondValue= 0;
                bool setRedFirstValue = false;
                bool setRedSecondValue = false;
                int RedFirstValue= 0;
                int RedSecondValue= 0;
                switch(firstState)
                {
                    case  TrainingProgress.Waiting:
                        setBlueFirstValue = true;
                        BlueFirstValue = 50;
                        setGreenFirstValue = true;
                        GreenFirstValue = 50;
                        setRedFirstValue = true;
                        RedFirstValue = 50;
                        break;
                    case  TrainingProgress.Quarter:
                        setBlueFirstValue = true;
                        BlueFirstValue = 0;
                        setGreenFirstValue = true;
                        GreenFirstValue = 0;
                        setRedFirstValue = true;
                        RedFirstValue = 255;
                        break;
                    case  TrainingProgress.Half:
                        setBlueFirstValue = true;
                        BlueFirstValue = 0;
                        setGreenFirstValue = true;
                        GreenFirstValue = 165;
                        setRedFirstValue = true;
                        RedFirstValue = 255;
                        break;
                    case  TrainingProgress.ThreeQuarter:
                        setBlueFirstValue = true;
                        BlueFirstValue = 0;
                        setGreenFirstValue = true;
                        GreenFirstValue = 255;
                        setRedFirstValue = true;
                        RedFirstValue = 255;
                        break;
                    case  TrainingProgress.Finished:
                        setBlueFirstValue = true;
                        BlueFirstValue = 255;
                        setGreenFirstValue = true;
                        GreenFirstValue = 255;
                        setRedFirstValue = true;
                        RedFirstValue = 255;
                        break;
                }
                switch(secondState)
                {
                    case  TrainingProgress.Waiting:
                        setBlueSecondValue = true;
                        BlueSecondValue = 50;
                        setGreenSecondValue = true;
                        GreenSecondValue = 50;
                        setRedSecondValue = true;
                        RedSecondValue = 50;
                        break;
                    case  TrainingProgress.Quarter:
                        setBlueSecondValue = true;
                        BlueSecondValue = 0;
                        setGreenSecondValue = true;
                        GreenSecondValue = 0;
                        setRedSecondValue = true;
                        RedSecondValue = 255;
                        break;
                    case  TrainingProgress.Half:
                        setBlueSecondValue = true;
                        BlueSecondValue = 0;
                        setGreenSecondValue = true;
                        GreenSecondValue = 165;
                        setRedSecondValue = true;
                        RedSecondValue = 255;
                        break;
                    case  TrainingProgress.ThreeQuarter:
                        setBlueSecondValue = true;
                        BlueSecondValue = 0;
                        setGreenSecondValue = true;
                        GreenSecondValue = 255;
                        setRedSecondValue = true;
                        RedSecondValue = 255;
                        break;
                    case  TrainingProgress.Finished:
                        setBlueSecondValue = true;
                        BlueSecondValue = 255;
                        setGreenSecondValue = true;
                        GreenSecondValue = 255;
                        setRedSecondValue = true;
                        RedSecondValue = 255;
                        break;
                }
                if (setBlueFirstValue && setBlueSecondValue)
                {
                    Blue = FlatRedBall.Math.MathFunctions.RoundToInt(BlueFirstValue* (1 - interpolationValue) + BlueSecondValue * interpolationValue);
                }
                if (setGreenFirstValue && setGreenSecondValue)
                {
                    Green = FlatRedBall.Math.MathFunctions.RoundToInt(GreenFirstValue* (1 - interpolationValue) + GreenSecondValue * interpolationValue);
                }
                if (setRedFirstValue && setRedSecondValue)
                {
                    Red = FlatRedBall.Math.MathFunctions.RoundToInt(RedFirstValue* (1 - interpolationValue) + RedSecondValue * interpolationValue);
                }
                if (interpolationValue < 1)
                {
                    mCurrentTrainingProgressState = firstState;
                }
                else
                {
                    mCurrentTrainingProgressState = secondState;
                }
            }
            #endregion
            #region State Interpolate To
            public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateTo (TownRaiserImGui.GumRuntimes.TrainingUnitSpriteRuntime.VariableState fromState,TownRaiserImGui.GumRuntimes.TrainingUnitSpriteRuntime.VariableState toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null) 
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
            public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateTo (TownRaiserImGui.GumRuntimes.TrainingUnitSpriteRuntime.TrainingProgress fromState,TownRaiserImGui.GumRuntimes.TrainingUnitSpriteRuntime.TrainingProgress toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null) 
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
            public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateTo (TrainingProgress toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null ) 
            {
                Gum.DataTypes.Variables.StateSave current = GetCurrentValuesOnState(toState);
                Gum.DataTypes.Variables.StateSave toAsStateSave = this.ElementSave.Categories.First(item => item.Name == "TrainingProgress").States.First(item => item.Name == toState.ToString());
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
                tweener.Ended += ()=> this.CurrentTrainingProgressState = toState;
                tweener.Start();
                StateInterpolationPlugin.TweenerManager.Self.Add(tweener);
                return tweener;
            }
            public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateToRelative (TrainingProgress toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null ) 
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
                tweener.Ended += ()=> this.CurrentTrainingProgressState = toState;
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
                            Name = "Alpha",
                            Type = "int",
                            Value = Alpha
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Animate",
                            Type = "bool",
                            Value = Animate
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Blue",
                            Type = "int",
                            Value = Blue
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FlipHorizontal",
                            Type = "bool",
                            Value = FlipHorizontal
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FlipVertical",
                            Type = "bool",
                            Value = FlipVertical
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Green",
                            Type = "int",
                            Value = Green
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
                            Name = "Red",
                            Type = "int",
                            Value = Red
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SourceFile",
                            Type = "string",
                            Value = SourceFile
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Texture Address",
                            Type = "TextureAddress",
                            Value = TextureAddress
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Texture Height",
                            Type = "int",
                            Value = TextureHeight
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Texture Height Scale",
                            Type = "float",
                            Value = TextureHeightScale
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Texture Left",
                            Type = "int",
                            Value = TextureLeft
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Texture Top",
                            Type = "int",
                            Value = TextureTop
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Texture Width",
                            Type = "int",
                            Value = TextureWidth
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Texture Width Scale",
                            Type = "float",
                            Value = TextureWidthScale
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
                            Name = "Wrap",
                            Type = "bool",
                            Value = Wrap
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
                            Name = "Alpha",
                            Type = "int",
                            Value = Alpha + 255
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Animate",
                            Type = "bool",
                            Value = Animate
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Blue",
                            Type = "int",
                            Value = Blue + 255
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FlipHorizontal",
                            Type = "bool",
                            Value = FlipHorizontal
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FlipVertical",
                            Type = "bool",
                            Value = FlipVertical
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Green",
                            Type = "int",
                            Value = Green + 255
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Height",
                            Type = "float",
                            Value = Height + 100f
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
                            Name = "Red",
                            Type = "int",
                            Value = Red + 255
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SourceFile",
                            Type = "string",
                            Value = SourceFile
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Texture Address",
                            Type = "TextureAddress",
                            Value = TextureAddress
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Texture Height",
                            Type = "int",
                            Value = TextureHeight + 16
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Texture Height Scale",
                            Type = "float",
                            Value = TextureHeightScale + 1f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Texture Left",
                            Type = "int",
                            Value = TextureLeft + 48
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Texture Top",
                            Type = "int",
                            Value = TextureTop + 178
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Texture Width",
                            Type = "int",
                            Value = TextureWidth + 16
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Texture Width Scale",
                            Type = "float",
                            Value = TextureWidthScale + 1f
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
                            Value = Width + 100f
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
                            Name = "Wrap",
                            Type = "bool",
                            Value = Wrap
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
                        break;
                }
                return newState;
            }
            private Gum.DataTypes.Variables.StateSave GetCurrentValuesOnState (TrainingProgress state) 
            {
                Gum.DataTypes.Variables.StateSave newState = new Gum.DataTypes.Variables.StateSave();
                switch(state)
                {
                    case  TrainingProgress.Waiting:
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Blue",
                            Type = "int",
                            Value = Blue
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Green",
                            Type = "int",
                            Value = Green
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Red",
                            Type = "int",
                            Value = Red
                        }
                        );
                        break;
                    case  TrainingProgress.Quarter:
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Blue",
                            Type = "int",
                            Value = Blue
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Green",
                            Type = "int",
                            Value = Green
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Red",
                            Type = "int",
                            Value = Red
                        }
                        );
                        break;
                    case  TrainingProgress.Half:
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Blue",
                            Type = "int",
                            Value = Blue
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Green",
                            Type = "int",
                            Value = Green
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Red",
                            Type = "int",
                            Value = Red
                        }
                        );
                        break;
                    case  TrainingProgress.ThreeQuarter:
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Blue",
                            Type = "int",
                            Value = Blue
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Green",
                            Type = "int",
                            Value = Green
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Red",
                            Type = "int",
                            Value = Red
                        }
                        );
                        break;
                    case  TrainingProgress.Finished:
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Blue",
                            Type = "int",
                            Value = Blue
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Green",
                            Type = "int",
                            Value = Green
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Red",
                            Type = "int",
                            Value = Red
                        }
                        );
                        break;
                }
                return newState;
            }
            private Gum.DataTypes.Variables.StateSave AddToCurrentValuesWithState (TrainingProgress state) 
            {
                Gum.DataTypes.Variables.StateSave newState = new Gum.DataTypes.Variables.StateSave();
                switch(state)
                {
                    case  TrainingProgress.Waiting:
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Blue",
                            Type = "int",
                            Value = Blue + 50
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Green",
                            Type = "int",
                            Value = Green + 50
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Red",
                            Type = "int",
                            Value = Red + 50
                        }
                        );
                        break;
                    case  TrainingProgress.Quarter:
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Blue",
                            Type = "int",
                            Value = Blue + 0
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Green",
                            Type = "int",
                            Value = Green + 0
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Red",
                            Type = "int",
                            Value = Red + 255
                        }
                        );
                        break;
                    case  TrainingProgress.Half:
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Blue",
                            Type = "int",
                            Value = Blue + 0
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Green",
                            Type = "int",
                            Value = Green + 165
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Red",
                            Type = "int",
                            Value = Red + 255
                        }
                        );
                        break;
                    case  TrainingProgress.ThreeQuarter:
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Blue",
                            Type = "int",
                            Value = Blue + 0
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Green",
                            Type = "int",
                            Value = Green + 255
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Red",
                            Type = "int",
                            Value = Red + 255
                        }
                        );
                        break;
                    case  TrainingProgress.Finished:
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Blue",
                            Type = "int",
                            Value = Blue + 255
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Green",
                            Type = "int",
                            Value = Green + 255
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Red",
                            Type = "int",
                            Value = Red + 255
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
                    else if (category.Name == "TrainingProgress")
                    {
                        if(state.Name == "Waiting") this.mCurrentTrainingProgressState = TrainingProgress.Waiting;
                        if(state.Name == "Quarter") this.mCurrentTrainingProgressState = TrainingProgress.Quarter;
                        if(state.Name == "Half") this.mCurrentTrainingProgressState = TrainingProgress.Half;
                        if(state.Name == "ThreeQuarter") this.mCurrentTrainingProgressState = TrainingProgress.ThreeQuarter;
                        if(state.Name == "Finished") this.mCurrentTrainingProgressState = TrainingProgress.Finished;
                    }
                }
                base.ApplyState(state);
            }
            public TrainingUnitSpriteRuntime (bool fullInstantiation = true, bool tryCreateFormsObject = true) 
            	: base(false, tryCreateFormsObject)
            {
                this.HasEvents = true;
                this.ExposeChildrenEvents = false;
                if (fullInstantiation)
                {
                    Gum.DataTypes.ElementSave elementSave = Gum.Managers.ObjectFinder.Self.GumProjectSave.Components.First(item => item.Name == "TrainingUnitSprite");
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
