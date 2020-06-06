    using System.Linq;
    namespace TownRaiserImGui.GumRuntimes
    {
        public partial class GameScreenGumRuntime : Gum.Wireframe.GraphicalUiElement
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
                            MinimapButtonInstance.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "ActionToolbarInstance");
                            GroupSelectorInstance.Width = 61f;
                            GroupSelectorInstance.X = 29f;
                            GroupSelectorInstance.Y = 70f;
                            MinimapContentsInstance.Visible = false;
                            MinimapContentsInstance.X = 0f;
                            MinimapContentsInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                            MinimapContentsInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            MinimapContentsInstance.Y = 0f;
                            MinimapContentsInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                            MinimapContentsInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            MinimapButtonInstance.SpriteInstanceTexture_Height = 26;
                            MinimapButtonInstance.SpriteInstanceTexture_Left = 387;
                            MinimapButtonInstance.SpriteInstanceTexture_Top = 83;
                            MinimapButtonInstance.SpriteInstanceTexture_Width = 26;
                            MinimapButtonInstance.X = 0f;
                            MinimapButtonInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Right;
                            MinimapButtonInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                            MinimapButtonInstance.Y = -4f;
                            MinimapButtonInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Bottom;
                            MinimapButtonInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
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
                bool setGroupSelectorInstanceWidthFirstValue = false;
                bool setGroupSelectorInstanceWidthSecondValue = false;
                float GroupSelectorInstanceWidthFirstValue= 0;
                float GroupSelectorInstanceWidthSecondValue= 0;
                bool setGroupSelectorInstanceXFirstValue = false;
                bool setGroupSelectorInstanceXSecondValue = false;
                float GroupSelectorInstanceXFirstValue= 0;
                float GroupSelectorInstanceXSecondValue= 0;
                bool setGroupSelectorInstanceYFirstValue = false;
                bool setGroupSelectorInstanceYSecondValue = false;
                float GroupSelectorInstanceYFirstValue= 0;
                float GroupSelectorInstanceYSecondValue= 0;
                bool setMinimapButtonInstanceSpriteInstanceTexture_HeightFirstValue = false;
                bool setMinimapButtonInstanceSpriteInstanceTexture_HeightSecondValue = false;
                int MinimapButtonInstanceSpriteInstanceTexture_HeightFirstValue= 0;
                int MinimapButtonInstanceSpriteInstanceTexture_HeightSecondValue= 0;
                bool setMinimapButtonInstanceSpriteInstanceTexture_LeftFirstValue = false;
                bool setMinimapButtonInstanceSpriteInstanceTexture_LeftSecondValue = false;
                int MinimapButtonInstanceSpriteInstanceTexture_LeftFirstValue= 0;
                int MinimapButtonInstanceSpriteInstanceTexture_LeftSecondValue= 0;
                bool setMinimapButtonInstanceSpriteInstanceTexture_TopFirstValue = false;
                bool setMinimapButtonInstanceSpriteInstanceTexture_TopSecondValue = false;
                int MinimapButtonInstanceSpriteInstanceTexture_TopFirstValue= 0;
                int MinimapButtonInstanceSpriteInstanceTexture_TopSecondValue= 0;
                bool setMinimapButtonInstanceSpriteInstanceTexture_WidthFirstValue = false;
                bool setMinimapButtonInstanceSpriteInstanceTexture_WidthSecondValue = false;
                int MinimapButtonInstanceSpriteInstanceTexture_WidthFirstValue= 0;
                int MinimapButtonInstanceSpriteInstanceTexture_WidthSecondValue= 0;
                bool setMinimapButtonInstanceXFirstValue = false;
                bool setMinimapButtonInstanceXSecondValue = false;
                float MinimapButtonInstanceXFirstValue= 0;
                float MinimapButtonInstanceXSecondValue= 0;
                bool setMinimapButtonInstanceYFirstValue = false;
                bool setMinimapButtonInstanceYSecondValue = false;
                float MinimapButtonInstanceYFirstValue= 0;
                float MinimapButtonInstanceYSecondValue= 0;
                bool setMinimapContentsInstanceXFirstValue = false;
                bool setMinimapContentsInstanceXSecondValue = false;
                float MinimapContentsInstanceXFirstValue= 0;
                float MinimapContentsInstanceXSecondValue= 0;
                bool setMinimapContentsInstanceYFirstValue = false;
                bool setMinimapContentsInstanceYSecondValue = false;
                float MinimapContentsInstanceYFirstValue= 0;
                float MinimapContentsInstanceYSecondValue= 0;
                switch(firstState)
                {
                    case  VariableState.Default:
                        setGroupSelectorInstanceWidthFirstValue = true;
                        GroupSelectorInstanceWidthFirstValue = 61f;
                        setGroupSelectorInstanceXFirstValue = true;
                        GroupSelectorInstanceXFirstValue = 29f;
                        setGroupSelectorInstanceYFirstValue = true;
                        GroupSelectorInstanceYFirstValue = 70f;
                        if (interpolationValue < 1)
                        {
                            this.MinimapButtonInstance.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "ActionToolbarInstance");
                        }
                        setMinimapButtonInstanceSpriteInstanceTexture_HeightFirstValue = true;
                        MinimapButtonInstanceSpriteInstanceTexture_HeightFirstValue = 26;
                        setMinimapButtonInstanceSpriteInstanceTexture_LeftFirstValue = true;
                        MinimapButtonInstanceSpriteInstanceTexture_LeftFirstValue = 387;
                        setMinimapButtonInstanceSpriteInstanceTexture_TopFirstValue = true;
                        MinimapButtonInstanceSpriteInstanceTexture_TopFirstValue = 83;
                        setMinimapButtonInstanceSpriteInstanceTexture_WidthFirstValue = true;
                        MinimapButtonInstanceSpriteInstanceTexture_WidthFirstValue = 26;
                        setMinimapButtonInstanceXFirstValue = true;
                        MinimapButtonInstanceXFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.MinimapButtonInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Right;
                        }
                        if (interpolationValue < 1)
                        {
                            this.MinimapButtonInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        setMinimapButtonInstanceYFirstValue = true;
                        MinimapButtonInstanceYFirstValue = -4f;
                        if (interpolationValue < 1)
                        {
                            this.MinimapButtonInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Bottom;
                        }
                        if (interpolationValue < 1)
                        {
                            this.MinimapButtonInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        if (interpolationValue < 1)
                        {
                            this.MinimapContentsInstance.Visible = false;
                        }
                        setMinimapContentsInstanceXFirstValue = true;
                        MinimapContentsInstanceXFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.MinimapContentsInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.MinimapContentsInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setMinimapContentsInstanceYFirstValue = true;
                        MinimapContentsInstanceYFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.MinimapContentsInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.MinimapContentsInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        break;
                }
                switch(secondState)
                {
                    case  VariableState.Default:
                        setGroupSelectorInstanceWidthSecondValue = true;
                        GroupSelectorInstanceWidthSecondValue = 61f;
                        setGroupSelectorInstanceXSecondValue = true;
                        GroupSelectorInstanceXSecondValue = 29f;
                        setGroupSelectorInstanceYSecondValue = true;
                        GroupSelectorInstanceYSecondValue = 70f;
                        if (interpolationValue >= 1)
                        {
                            this.MinimapButtonInstance.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "ActionToolbarInstance");
                        }
                        setMinimapButtonInstanceSpriteInstanceTexture_HeightSecondValue = true;
                        MinimapButtonInstanceSpriteInstanceTexture_HeightSecondValue = 26;
                        setMinimapButtonInstanceSpriteInstanceTexture_LeftSecondValue = true;
                        MinimapButtonInstanceSpriteInstanceTexture_LeftSecondValue = 387;
                        setMinimapButtonInstanceSpriteInstanceTexture_TopSecondValue = true;
                        MinimapButtonInstanceSpriteInstanceTexture_TopSecondValue = 83;
                        setMinimapButtonInstanceSpriteInstanceTexture_WidthSecondValue = true;
                        MinimapButtonInstanceSpriteInstanceTexture_WidthSecondValue = 26;
                        setMinimapButtonInstanceXSecondValue = true;
                        MinimapButtonInstanceXSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.MinimapButtonInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Right;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.MinimapButtonInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        setMinimapButtonInstanceYSecondValue = true;
                        MinimapButtonInstanceYSecondValue = -4f;
                        if (interpolationValue >= 1)
                        {
                            this.MinimapButtonInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Bottom;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.MinimapButtonInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.MinimapContentsInstance.Visible = false;
                        }
                        setMinimapContentsInstanceXSecondValue = true;
                        MinimapContentsInstanceXSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.MinimapContentsInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.MinimapContentsInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setMinimapContentsInstanceYSecondValue = true;
                        MinimapContentsInstanceYSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.MinimapContentsInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.MinimapContentsInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        break;
                }
                if (setGroupSelectorInstanceWidthFirstValue && setGroupSelectorInstanceWidthSecondValue)
                {
                    GroupSelectorInstance.Width = GroupSelectorInstanceWidthFirstValue * (1 - interpolationValue) + GroupSelectorInstanceWidthSecondValue * interpolationValue;
                }
                if (setGroupSelectorInstanceXFirstValue && setGroupSelectorInstanceXSecondValue)
                {
                    GroupSelectorInstance.X = GroupSelectorInstanceXFirstValue * (1 - interpolationValue) + GroupSelectorInstanceXSecondValue * interpolationValue;
                }
                if (setGroupSelectorInstanceYFirstValue && setGroupSelectorInstanceYSecondValue)
                {
                    GroupSelectorInstance.Y = GroupSelectorInstanceYFirstValue * (1 - interpolationValue) + GroupSelectorInstanceYSecondValue * interpolationValue;
                }
                if (setMinimapButtonInstanceSpriteInstanceTexture_HeightFirstValue && setMinimapButtonInstanceSpriteInstanceTexture_HeightSecondValue)
                {
                    MinimapButtonInstance.SpriteInstanceTexture_Height = FlatRedBall.Math.MathFunctions.RoundToInt(MinimapButtonInstanceSpriteInstanceTexture_HeightFirstValue* (1 - interpolationValue) + MinimapButtonInstanceSpriteInstanceTexture_HeightSecondValue * interpolationValue);
                }
                if (setMinimapButtonInstanceSpriteInstanceTexture_LeftFirstValue && setMinimapButtonInstanceSpriteInstanceTexture_LeftSecondValue)
                {
                    MinimapButtonInstance.SpriteInstanceTexture_Left = FlatRedBall.Math.MathFunctions.RoundToInt(MinimapButtonInstanceSpriteInstanceTexture_LeftFirstValue* (1 - interpolationValue) + MinimapButtonInstanceSpriteInstanceTexture_LeftSecondValue * interpolationValue);
                }
                if (setMinimapButtonInstanceSpriteInstanceTexture_TopFirstValue && setMinimapButtonInstanceSpriteInstanceTexture_TopSecondValue)
                {
                    MinimapButtonInstance.SpriteInstanceTexture_Top = FlatRedBall.Math.MathFunctions.RoundToInt(MinimapButtonInstanceSpriteInstanceTexture_TopFirstValue* (1 - interpolationValue) + MinimapButtonInstanceSpriteInstanceTexture_TopSecondValue * interpolationValue);
                }
                if (setMinimapButtonInstanceSpriteInstanceTexture_WidthFirstValue && setMinimapButtonInstanceSpriteInstanceTexture_WidthSecondValue)
                {
                    MinimapButtonInstance.SpriteInstanceTexture_Width = FlatRedBall.Math.MathFunctions.RoundToInt(MinimapButtonInstanceSpriteInstanceTexture_WidthFirstValue* (1 - interpolationValue) + MinimapButtonInstanceSpriteInstanceTexture_WidthSecondValue * interpolationValue);
                }
                if (setMinimapButtonInstanceXFirstValue && setMinimapButtonInstanceXSecondValue)
                {
                    MinimapButtonInstance.X = MinimapButtonInstanceXFirstValue * (1 - interpolationValue) + MinimapButtonInstanceXSecondValue * interpolationValue;
                }
                if (setMinimapButtonInstanceYFirstValue && setMinimapButtonInstanceYSecondValue)
                {
                    MinimapButtonInstance.Y = MinimapButtonInstanceYFirstValue * (1 - interpolationValue) + MinimapButtonInstanceYSecondValue * interpolationValue;
                }
                if (setMinimapContentsInstanceXFirstValue && setMinimapContentsInstanceXSecondValue)
                {
                    MinimapContentsInstance.X = MinimapContentsInstanceXFirstValue * (1 - interpolationValue) + MinimapContentsInstanceXSecondValue * interpolationValue;
                }
                if (setMinimapContentsInstanceYFirstValue && setMinimapContentsInstanceYSecondValue)
                {
                    MinimapContentsInstance.Y = MinimapContentsInstanceYFirstValue * (1 - interpolationValue) + MinimapContentsInstanceYSecondValue * interpolationValue;
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
            public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateTo (TownRaiserImGui.GumRuntimes.GameScreenGumRuntime.VariableState fromState,TownRaiserImGui.GumRuntimes.GameScreenGumRuntime.VariableState toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null) 
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
                ResourceDisplayInstance.StopAnimations();
                ActionToolbarInstance.StopAnimations();
                GroupSelectorInstance.StopAnimations();
                MinimapContentsInstance.StopAnimations();
                MinimapButtonInstance.StopAnimations();
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
                            Name = "GroupSelectorInstance.Width",
                            Type = "float",
                            Value = GroupSelectorInstance.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "GroupSelectorInstance.X",
                            Type = "float",
                            Value = GroupSelectorInstance.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "GroupSelectorInstance.Y",
                            Type = "float",
                            Value = GroupSelectorInstance.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MinimapContentsInstance.Visible",
                            Type = "bool",
                            Value = MinimapContentsInstance.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MinimapContentsInstance.X",
                            Type = "float",
                            Value = MinimapContentsInstance.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MinimapContentsInstance.X Origin",
                            Type = "HorizontalAlignment",
                            Value = MinimapContentsInstance.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MinimapContentsInstance.X Units",
                            Type = "PositionUnitType",
                            Value = MinimapContentsInstance.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MinimapContentsInstance.Y",
                            Type = "float",
                            Value = MinimapContentsInstance.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MinimapContentsInstance.Y Origin",
                            Type = "VerticalAlignment",
                            Value = MinimapContentsInstance.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MinimapContentsInstance.Y Units",
                            Type = "PositionUnitType",
                            Value = MinimapContentsInstance.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MinimapButtonInstance.Parent",
                            Type = "string",
                            Value = MinimapButtonInstance.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MinimapButtonInstance.SpriteInstanceTexture Height",
                            Type = "int",
                            Value = MinimapButtonInstance.SpriteInstanceTexture_Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MinimapButtonInstance.SpriteInstanceTexture Left",
                            Type = "int",
                            Value = MinimapButtonInstance.SpriteInstanceTexture_Left
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MinimapButtonInstance.SpriteInstanceTexture Top",
                            Type = "int",
                            Value = MinimapButtonInstance.SpriteInstanceTexture_Top
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MinimapButtonInstance.SpriteInstanceTexture Width",
                            Type = "int",
                            Value = MinimapButtonInstance.SpriteInstanceTexture_Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MinimapButtonInstance.X",
                            Type = "float",
                            Value = MinimapButtonInstance.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MinimapButtonInstance.X Origin",
                            Type = "HorizontalAlignment",
                            Value = MinimapButtonInstance.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MinimapButtonInstance.X Units",
                            Type = "PositionUnitType",
                            Value = MinimapButtonInstance.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MinimapButtonInstance.Y",
                            Type = "float",
                            Value = MinimapButtonInstance.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MinimapButtonInstance.Y Origin",
                            Type = "VerticalAlignment",
                            Value = MinimapButtonInstance.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MinimapButtonInstance.Y Units",
                            Type = "PositionUnitType",
                            Value = MinimapButtonInstance.YUnits
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
                            Name = "GroupSelectorInstance.Width",
                            Type = "float",
                            Value = GroupSelectorInstance.Width + 61f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "GroupSelectorInstance.X",
                            Type = "float",
                            Value = GroupSelectorInstance.X + 29f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "GroupSelectorInstance.Y",
                            Type = "float",
                            Value = GroupSelectorInstance.Y + 70f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MinimapContentsInstance.Visible",
                            Type = "bool",
                            Value = MinimapContentsInstance.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MinimapContentsInstance.X",
                            Type = "float",
                            Value = MinimapContentsInstance.X + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MinimapContentsInstance.X Origin",
                            Type = "HorizontalAlignment",
                            Value = MinimapContentsInstance.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MinimapContentsInstance.X Units",
                            Type = "PositionUnitType",
                            Value = MinimapContentsInstance.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MinimapContentsInstance.Y",
                            Type = "float",
                            Value = MinimapContentsInstance.Y + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MinimapContentsInstance.Y Origin",
                            Type = "VerticalAlignment",
                            Value = MinimapContentsInstance.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MinimapContentsInstance.Y Units",
                            Type = "PositionUnitType",
                            Value = MinimapContentsInstance.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MinimapButtonInstance.Parent",
                            Type = "string",
                            Value = MinimapButtonInstance.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MinimapButtonInstance.SpriteInstanceTexture Height",
                            Type = "int",
                            Value = MinimapButtonInstance.SpriteInstanceTexture_Height + 26
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MinimapButtonInstance.SpriteInstanceTexture Left",
                            Type = "int",
                            Value = MinimapButtonInstance.SpriteInstanceTexture_Left + 387
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MinimapButtonInstance.SpriteInstanceTexture Top",
                            Type = "int",
                            Value = MinimapButtonInstance.SpriteInstanceTexture_Top + 83
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MinimapButtonInstance.SpriteInstanceTexture Width",
                            Type = "int",
                            Value = MinimapButtonInstance.SpriteInstanceTexture_Width + 26
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MinimapButtonInstance.X",
                            Type = "float",
                            Value = MinimapButtonInstance.X + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MinimapButtonInstance.X Origin",
                            Type = "HorizontalAlignment",
                            Value = MinimapButtonInstance.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MinimapButtonInstance.X Units",
                            Type = "PositionUnitType",
                            Value = MinimapButtonInstance.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MinimapButtonInstance.Y",
                            Type = "float",
                            Value = MinimapButtonInstance.Y + -4f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MinimapButtonInstance.Y Origin",
                            Type = "VerticalAlignment",
                            Value = MinimapButtonInstance.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MinimapButtonInstance.Y Units",
                            Type = "PositionUnitType",
                            Value = MinimapButtonInstance.YUnits
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
            public TownRaiserImGui.GumRuntimes.ResourceDisplayRuntime ResourceDisplayInstance { get; set; }
            public TownRaiserImGui.GumRuntimes.ActionToolbarRuntime ActionToolbarInstance { get; set; }
            public TownRaiserImGui.GumRuntimes.GroupSelectorRuntime GroupSelectorInstance { get; set; }
            public TownRaiserImGui.GumRuntimes.MinimapContentsRuntime MinimapContentsInstance { get; set; }
            public TownRaiserImGui.GumRuntimes.FramedButtonRuntime MinimapButtonInstance { get; set; }
            public GameScreenGumRuntime (bool fullInstantiation = true, bool tryCreateFormsObject = true) 
            {
                if (fullInstantiation)
                {
                    Gum.DataTypes.ElementSave elementSave = Gum.Managers.ObjectFinder.Self.GumProjectSave.Screens.First(item => item.Name == "GameScreenGum");
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
                ResourceDisplayInstance = this.GetGraphicalUiElementByName("ResourceDisplayInstance") as TownRaiserImGui.GumRuntimes.ResourceDisplayRuntime;
                ActionToolbarInstance = this.GetGraphicalUiElementByName("ActionToolbarInstance") as TownRaiserImGui.GumRuntimes.ActionToolbarRuntime;
                GroupSelectorInstance = this.GetGraphicalUiElementByName("GroupSelectorInstance") as TownRaiserImGui.GumRuntimes.GroupSelectorRuntime;
                MinimapContentsInstance = this.GetGraphicalUiElementByName("MinimapContentsInstance") as TownRaiserImGui.GumRuntimes.MinimapContentsRuntime;
                MinimapButtonInstance = this.GetGraphicalUiElementByName("MinimapButtonInstance") as TownRaiserImGui.GumRuntimes.FramedButtonRuntime;
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
