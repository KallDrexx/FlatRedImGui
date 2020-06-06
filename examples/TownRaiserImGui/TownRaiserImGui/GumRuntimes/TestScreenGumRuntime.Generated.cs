    using System.Linq;
    namespace TownRaiserImGui.GumRuntimes
    {
        public partial class TestScreenGumRuntime : Gum.Wireframe.GraphicalUiElement
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
                            ColoredRectangleInstance1.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "Container");
                            StackingContainer.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "Container");
                            Container.ChildrenLayout = Gum.Managers.ChildrenLayout.Regular;
                            Container.Height = 6f;
                            Container.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToChildren;
                            Container.Width = 80f;
                            Container.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                            Container.X = 143f;
                            Container.Y = 49f;
                            ColoredRectangleInstance1.Blue = 92;
                            ColoredRectangleInstance1.Green = 92;
                            ColoredRectangleInstance1.Height = 0f;
                            ColoredRectangleInstance1.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                            ColoredRectangleInstance1.Red = 205;
                            ColoredRectangleInstance1.Width = 0f;
                            ColoredRectangleInstance1.WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                            ColoredRectangleInstance1.X = 0f;
                            ColoredRectangleInstance1.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                            ColoredRectangleInstance1.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            ColoredRectangleInstance1.Y = 0f;
                            ColoredRectangleInstance1.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                            ColoredRectangleInstance1.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            StackingContainer.ChildrenLayout = Gum.Managers.ChildrenLayout.TopToBottomStack;
                            StackingContainer.Height = 5f;
                            StackingContainer.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToChildren;
                            StackingContainer.Width = 67f;
                            StackingContainer.X = 6f;
                            StackingContainer.Y = 6f;
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
                bool setColoredRectangleInstance1BlueFirstValue = false;
                bool setColoredRectangleInstance1BlueSecondValue = false;
                int ColoredRectangleInstance1BlueFirstValue= 0;
                int ColoredRectangleInstance1BlueSecondValue= 0;
                bool setColoredRectangleInstance1GreenFirstValue = false;
                bool setColoredRectangleInstance1GreenSecondValue = false;
                int ColoredRectangleInstance1GreenFirstValue= 0;
                int ColoredRectangleInstance1GreenSecondValue= 0;
                bool setColoredRectangleInstance1HeightFirstValue = false;
                bool setColoredRectangleInstance1HeightSecondValue = false;
                float ColoredRectangleInstance1HeightFirstValue= 0;
                float ColoredRectangleInstance1HeightSecondValue= 0;
                bool setColoredRectangleInstance1RedFirstValue = false;
                bool setColoredRectangleInstance1RedSecondValue = false;
                int ColoredRectangleInstance1RedFirstValue= 0;
                int ColoredRectangleInstance1RedSecondValue= 0;
                bool setColoredRectangleInstance1WidthFirstValue = false;
                bool setColoredRectangleInstance1WidthSecondValue = false;
                float ColoredRectangleInstance1WidthFirstValue= 0;
                float ColoredRectangleInstance1WidthSecondValue= 0;
                bool setColoredRectangleInstance1XFirstValue = false;
                bool setColoredRectangleInstance1XSecondValue = false;
                float ColoredRectangleInstance1XFirstValue= 0;
                float ColoredRectangleInstance1XSecondValue= 0;
                bool setColoredRectangleInstance1YFirstValue = false;
                bool setColoredRectangleInstance1YSecondValue = false;
                float ColoredRectangleInstance1YFirstValue= 0;
                float ColoredRectangleInstance1YSecondValue= 0;
                bool setContainerHeightFirstValue = false;
                bool setContainerHeightSecondValue = false;
                float ContainerHeightFirstValue= 0;
                float ContainerHeightSecondValue= 0;
                bool setContainerWidthFirstValue = false;
                bool setContainerWidthSecondValue = false;
                float ContainerWidthFirstValue= 0;
                float ContainerWidthSecondValue= 0;
                bool setContainerXFirstValue = false;
                bool setContainerXSecondValue = false;
                float ContainerXFirstValue= 0;
                float ContainerXSecondValue= 0;
                bool setContainerYFirstValue = false;
                bool setContainerYSecondValue = false;
                float ContainerYFirstValue= 0;
                float ContainerYSecondValue= 0;
                bool setStackingContainerHeightFirstValue = false;
                bool setStackingContainerHeightSecondValue = false;
                float StackingContainerHeightFirstValue= 0;
                float StackingContainerHeightSecondValue= 0;
                bool setStackingContainerWidthFirstValue = false;
                bool setStackingContainerWidthSecondValue = false;
                float StackingContainerWidthFirstValue= 0;
                float StackingContainerWidthSecondValue= 0;
                bool setStackingContainerXFirstValue = false;
                bool setStackingContainerXSecondValue = false;
                float StackingContainerXFirstValue= 0;
                float StackingContainerXSecondValue= 0;
                bool setStackingContainerYFirstValue = false;
                bool setStackingContainerYSecondValue = false;
                float StackingContainerYFirstValue= 0;
                float StackingContainerYSecondValue= 0;
                switch(firstState)
                {
                    case  VariableState.Default:
                        setColoredRectangleInstance1BlueFirstValue = true;
                        ColoredRectangleInstance1BlueFirstValue = 92;
                        setColoredRectangleInstance1GreenFirstValue = true;
                        ColoredRectangleInstance1GreenFirstValue = 92;
                        setColoredRectangleInstance1HeightFirstValue = true;
                        ColoredRectangleInstance1HeightFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.ColoredRectangleInstance1.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ColoredRectangleInstance1.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "Container");
                        }
                        setColoredRectangleInstance1RedFirstValue = true;
                        ColoredRectangleInstance1RedFirstValue = 205;
                        setColoredRectangleInstance1WidthFirstValue = true;
                        ColoredRectangleInstance1WidthFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.ColoredRectangleInstance1.WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        setColoredRectangleInstance1XFirstValue = true;
                        ColoredRectangleInstance1XFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.ColoredRectangleInstance1.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ColoredRectangleInstance1.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setColoredRectangleInstance1YFirstValue = true;
                        ColoredRectangleInstance1YFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.ColoredRectangleInstance1.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ColoredRectangleInstance1.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        if (interpolationValue < 1)
                        {
                            this.Container.ChildrenLayout = Gum.Managers.ChildrenLayout.Regular;
                        }
                        setContainerHeightFirstValue = true;
                        ContainerHeightFirstValue = 6f;
                        if (interpolationValue < 1)
                        {
                            this.Container.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToChildren;
                        }
                        setContainerWidthFirstValue = true;
                        ContainerWidthFirstValue = 80f;
                        if (interpolationValue < 1)
                        {
                            this.Container.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        setContainerXFirstValue = true;
                        ContainerXFirstValue = 143f;
                        setContainerYFirstValue = true;
                        ContainerYFirstValue = 49f;
                        if (interpolationValue < 1)
                        {
                            this.StackingContainer.ChildrenLayout = Gum.Managers.ChildrenLayout.TopToBottomStack;
                        }
                        setStackingContainerHeightFirstValue = true;
                        StackingContainerHeightFirstValue = 5f;
                        if (interpolationValue < 1)
                        {
                            this.StackingContainer.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToChildren;
                        }
                        if (interpolationValue < 1)
                        {
                            this.StackingContainer.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "Container");
                        }
                        setStackingContainerWidthFirstValue = true;
                        StackingContainerWidthFirstValue = 67f;
                        setStackingContainerXFirstValue = true;
                        StackingContainerXFirstValue = 6f;
                        setStackingContainerYFirstValue = true;
                        StackingContainerYFirstValue = 6f;
                        break;
                }
                switch(secondState)
                {
                    case  VariableState.Default:
                        setColoredRectangleInstance1BlueSecondValue = true;
                        ColoredRectangleInstance1BlueSecondValue = 92;
                        setColoredRectangleInstance1GreenSecondValue = true;
                        ColoredRectangleInstance1GreenSecondValue = 92;
                        setColoredRectangleInstance1HeightSecondValue = true;
                        ColoredRectangleInstance1HeightSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.ColoredRectangleInstance1.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ColoredRectangleInstance1.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "Container");
                        }
                        setColoredRectangleInstance1RedSecondValue = true;
                        ColoredRectangleInstance1RedSecondValue = 205;
                        setColoredRectangleInstance1WidthSecondValue = true;
                        ColoredRectangleInstance1WidthSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.ColoredRectangleInstance1.WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        setColoredRectangleInstance1XSecondValue = true;
                        ColoredRectangleInstance1XSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.ColoredRectangleInstance1.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ColoredRectangleInstance1.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setColoredRectangleInstance1YSecondValue = true;
                        ColoredRectangleInstance1YSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.ColoredRectangleInstance1.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ColoredRectangleInstance1.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.Container.ChildrenLayout = Gum.Managers.ChildrenLayout.Regular;
                        }
                        setContainerHeightSecondValue = true;
                        ContainerHeightSecondValue = 6f;
                        if (interpolationValue >= 1)
                        {
                            this.Container.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToChildren;
                        }
                        setContainerWidthSecondValue = true;
                        ContainerWidthSecondValue = 80f;
                        if (interpolationValue >= 1)
                        {
                            this.Container.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        setContainerXSecondValue = true;
                        ContainerXSecondValue = 143f;
                        setContainerYSecondValue = true;
                        ContainerYSecondValue = 49f;
                        if (interpolationValue >= 1)
                        {
                            this.StackingContainer.ChildrenLayout = Gum.Managers.ChildrenLayout.TopToBottomStack;
                        }
                        setStackingContainerHeightSecondValue = true;
                        StackingContainerHeightSecondValue = 5f;
                        if (interpolationValue >= 1)
                        {
                            this.StackingContainer.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToChildren;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.StackingContainer.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "Container");
                        }
                        setStackingContainerWidthSecondValue = true;
                        StackingContainerWidthSecondValue = 67f;
                        setStackingContainerXSecondValue = true;
                        StackingContainerXSecondValue = 6f;
                        setStackingContainerYSecondValue = true;
                        StackingContainerYSecondValue = 6f;
                        break;
                }
                if (setColoredRectangleInstance1BlueFirstValue && setColoredRectangleInstance1BlueSecondValue)
                {
                    ColoredRectangleInstance1.Blue = FlatRedBall.Math.MathFunctions.RoundToInt(ColoredRectangleInstance1BlueFirstValue* (1 - interpolationValue) + ColoredRectangleInstance1BlueSecondValue * interpolationValue);
                }
                if (setColoredRectangleInstance1GreenFirstValue && setColoredRectangleInstance1GreenSecondValue)
                {
                    ColoredRectangleInstance1.Green = FlatRedBall.Math.MathFunctions.RoundToInt(ColoredRectangleInstance1GreenFirstValue* (1 - interpolationValue) + ColoredRectangleInstance1GreenSecondValue * interpolationValue);
                }
                if (setColoredRectangleInstance1HeightFirstValue && setColoredRectangleInstance1HeightSecondValue)
                {
                    ColoredRectangleInstance1.Height = ColoredRectangleInstance1HeightFirstValue * (1 - interpolationValue) + ColoredRectangleInstance1HeightSecondValue * interpolationValue;
                }
                if (setColoredRectangleInstance1RedFirstValue && setColoredRectangleInstance1RedSecondValue)
                {
                    ColoredRectangleInstance1.Red = FlatRedBall.Math.MathFunctions.RoundToInt(ColoredRectangleInstance1RedFirstValue* (1 - interpolationValue) + ColoredRectangleInstance1RedSecondValue * interpolationValue);
                }
                if (setColoredRectangleInstance1WidthFirstValue && setColoredRectangleInstance1WidthSecondValue)
                {
                    ColoredRectangleInstance1.Width = ColoredRectangleInstance1WidthFirstValue * (1 - interpolationValue) + ColoredRectangleInstance1WidthSecondValue * interpolationValue;
                }
                if (setColoredRectangleInstance1XFirstValue && setColoredRectangleInstance1XSecondValue)
                {
                    ColoredRectangleInstance1.X = ColoredRectangleInstance1XFirstValue * (1 - interpolationValue) + ColoredRectangleInstance1XSecondValue * interpolationValue;
                }
                if (setColoredRectangleInstance1YFirstValue && setColoredRectangleInstance1YSecondValue)
                {
                    ColoredRectangleInstance1.Y = ColoredRectangleInstance1YFirstValue * (1 - interpolationValue) + ColoredRectangleInstance1YSecondValue * interpolationValue;
                }
                if (setContainerHeightFirstValue && setContainerHeightSecondValue)
                {
                    Container.Height = ContainerHeightFirstValue * (1 - interpolationValue) + ContainerHeightSecondValue * interpolationValue;
                }
                if (setContainerWidthFirstValue && setContainerWidthSecondValue)
                {
                    Container.Width = ContainerWidthFirstValue * (1 - interpolationValue) + ContainerWidthSecondValue * interpolationValue;
                }
                if (setContainerXFirstValue && setContainerXSecondValue)
                {
                    Container.X = ContainerXFirstValue * (1 - interpolationValue) + ContainerXSecondValue * interpolationValue;
                }
                if (setContainerYFirstValue && setContainerYSecondValue)
                {
                    Container.Y = ContainerYFirstValue * (1 - interpolationValue) + ContainerYSecondValue * interpolationValue;
                }
                if (setStackingContainerHeightFirstValue && setStackingContainerHeightSecondValue)
                {
                    StackingContainer.Height = StackingContainerHeightFirstValue * (1 - interpolationValue) + StackingContainerHeightSecondValue * interpolationValue;
                }
                if (setStackingContainerWidthFirstValue && setStackingContainerWidthSecondValue)
                {
                    StackingContainer.Width = StackingContainerWidthFirstValue * (1 - interpolationValue) + StackingContainerWidthSecondValue * interpolationValue;
                }
                if (setStackingContainerXFirstValue && setStackingContainerXSecondValue)
                {
                    StackingContainer.X = StackingContainerXFirstValue * (1 - interpolationValue) + StackingContainerXSecondValue * interpolationValue;
                }
                if (setStackingContainerYFirstValue && setStackingContainerYSecondValue)
                {
                    StackingContainer.Y = StackingContainerYFirstValue * (1 - interpolationValue) + StackingContainerYSecondValue * interpolationValue;
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
            public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateTo (TownRaiserImGui.GumRuntimes.TestScreenGumRuntime.VariableState fromState,TownRaiserImGui.GumRuntimes.TestScreenGumRuntime.VariableState toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null) 
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
                ActionToolbarInstance.StopAnimations();
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
                            Name = "Container.Children Layout",
                            Type = "ChildrenLayout",
                            Value = Container.ChildrenLayout
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Container.Height",
                            Type = "float",
                            Value = Container.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Container.Height Units",
                            Type = "DimensionUnitType",
                            Value = Container.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Container.Width",
                            Type = "float",
                            Value = Container.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Container.Width Units",
                            Type = "DimensionUnitType",
                            Value = Container.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Container.X",
                            Type = "float",
                            Value = Container.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Container.Y",
                            Type = "float",
                            Value = Container.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance1.Blue",
                            Type = "int",
                            Value = ColoredRectangleInstance1.Blue
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance1.Green",
                            Type = "int",
                            Value = ColoredRectangleInstance1.Green
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance1.Height",
                            Type = "float",
                            Value = ColoredRectangleInstance1.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance1.Height Units",
                            Type = "DimensionUnitType",
                            Value = ColoredRectangleInstance1.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance1.Parent",
                            Type = "string",
                            Value = ColoredRectangleInstance1.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance1.Red",
                            Type = "int",
                            Value = ColoredRectangleInstance1.Red
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance1.Width",
                            Type = "float",
                            Value = ColoredRectangleInstance1.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance1.Width Units",
                            Type = "DimensionUnitType",
                            Value = ColoredRectangleInstance1.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance1.X",
                            Type = "float",
                            Value = ColoredRectangleInstance1.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance1.X Origin",
                            Type = "HorizontalAlignment",
                            Value = ColoredRectangleInstance1.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance1.X Units",
                            Type = "PositionUnitType",
                            Value = ColoredRectangleInstance1.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance1.Y",
                            Type = "float",
                            Value = ColoredRectangleInstance1.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance1.Y Origin",
                            Type = "VerticalAlignment",
                            Value = ColoredRectangleInstance1.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance1.Y Units",
                            Type = "PositionUnitType",
                            Value = ColoredRectangleInstance1.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "StackingContainer.Children Layout",
                            Type = "ChildrenLayout",
                            Value = StackingContainer.ChildrenLayout
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "StackingContainer.Height",
                            Type = "float",
                            Value = StackingContainer.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "StackingContainer.Height Units",
                            Type = "DimensionUnitType",
                            Value = StackingContainer.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "StackingContainer.Parent",
                            Type = "string",
                            Value = StackingContainer.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "StackingContainer.Width",
                            Type = "float",
                            Value = StackingContainer.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "StackingContainer.X",
                            Type = "float",
                            Value = StackingContainer.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "StackingContainer.Y",
                            Type = "float",
                            Value = StackingContainer.Y
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
                            Name = "Container.Children Layout",
                            Type = "ChildrenLayout",
                            Value = Container.ChildrenLayout
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Container.Height",
                            Type = "float",
                            Value = Container.Height + 6f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Container.Height Units",
                            Type = "DimensionUnitType",
                            Value = Container.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Container.Width",
                            Type = "float",
                            Value = Container.Width + 80f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Container.Width Units",
                            Type = "DimensionUnitType",
                            Value = Container.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Container.X",
                            Type = "float",
                            Value = Container.X + 143f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Container.Y",
                            Type = "float",
                            Value = Container.Y + 49f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance1.Blue",
                            Type = "int",
                            Value = ColoredRectangleInstance1.Blue + 92
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance1.Green",
                            Type = "int",
                            Value = ColoredRectangleInstance1.Green + 92
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance1.Height",
                            Type = "float",
                            Value = ColoredRectangleInstance1.Height + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance1.Height Units",
                            Type = "DimensionUnitType",
                            Value = ColoredRectangleInstance1.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance1.Parent",
                            Type = "string",
                            Value = ColoredRectangleInstance1.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance1.Red",
                            Type = "int",
                            Value = ColoredRectangleInstance1.Red + 205
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance1.Width",
                            Type = "float",
                            Value = ColoredRectangleInstance1.Width + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance1.Width Units",
                            Type = "DimensionUnitType",
                            Value = ColoredRectangleInstance1.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance1.X",
                            Type = "float",
                            Value = ColoredRectangleInstance1.X + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance1.X Origin",
                            Type = "HorizontalAlignment",
                            Value = ColoredRectangleInstance1.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance1.X Units",
                            Type = "PositionUnitType",
                            Value = ColoredRectangleInstance1.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance1.Y",
                            Type = "float",
                            Value = ColoredRectangleInstance1.Y + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance1.Y Origin",
                            Type = "VerticalAlignment",
                            Value = ColoredRectangleInstance1.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance1.Y Units",
                            Type = "PositionUnitType",
                            Value = ColoredRectangleInstance1.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "StackingContainer.Children Layout",
                            Type = "ChildrenLayout",
                            Value = StackingContainer.ChildrenLayout
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "StackingContainer.Height",
                            Type = "float",
                            Value = StackingContainer.Height + 5f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "StackingContainer.Height Units",
                            Type = "DimensionUnitType",
                            Value = StackingContainer.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "StackingContainer.Parent",
                            Type = "string",
                            Value = StackingContainer.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "StackingContainer.Width",
                            Type = "float",
                            Value = StackingContainer.Width + 67f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "StackingContainer.X",
                            Type = "float",
                            Value = StackingContainer.X + 6f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "StackingContainer.Y",
                            Type = "float",
                            Value = StackingContainer.Y + 6f
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
            public TownRaiserImGui.GumRuntimes.ContainerRuntime Container { get; set; }
            public TownRaiserImGui.GumRuntimes.ColoredRectangleRuntime ColoredRectangleInstance1 { get; set; }
            public TownRaiserImGui.GumRuntimes.ContainerRuntime StackingContainer { get; set; }
            public TownRaiserImGui.GumRuntimes.ActionToolbarRuntime ActionToolbarInstance { get; set; }
            public TestScreenGumRuntime (bool fullInstantiation = true, bool tryCreateFormsObject = true) 
            {
                if (fullInstantiation)
                {
                    Gum.DataTypes.ElementSave elementSave = Gum.Managers.ObjectFinder.Self.GumProjectSave.Screens.First(item => item.Name == "TestScreenGum");
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
                Container = this.GetGraphicalUiElementByName("Container") as TownRaiserImGui.GumRuntimes.ContainerRuntime;
                ColoredRectangleInstance1 = this.GetGraphicalUiElementByName("ColoredRectangleInstance1") as TownRaiserImGui.GumRuntimes.ColoredRectangleRuntime;
                StackingContainer = this.GetGraphicalUiElementByName("StackingContainer") as TownRaiserImGui.GumRuntimes.ContainerRuntime;
                ActionToolbarInstance = this.GetGraphicalUiElementByName("ActionToolbarInstance") as TownRaiserImGui.GumRuntimes.ActionToolbarRuntime;
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
