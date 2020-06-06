    using System.Linq;
    namespace TownRaiserImGui.GumRuntimes
    {
        public partial class GroupSelectorRuntime : TownRaiserImGui.GumRuntimes.ContainerRuntime
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
                            ChildrenLayout = Gum.Managers.ChildrenLayout.Regular;
                            ClipsChildren = false;
                            Height = 150f;
                            HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                            Visible = true;
                            Width = 150f;
                            WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                            WrapsChildren = false;
                            XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                            XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                            YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                            YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                            ColoredRectangleInstance.Alpha = 80;
                            ColoredRectangleInstance.Blue = 0;
                            ColoredRectangleInstance.Green = 255;
                            ColoredRectangleInstance.Height = 0f;
                            ColoredRectangleInstance.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                            ColoredRectangleInstance.Red = 255;
                            ColoredRectangleInstance.Width = 0f;
                            ColoredRectangleInstance.WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                            ColoredRectangleInstance.X = 0f;
                            ColoredRectangleInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                            ColoredRectangleInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            ColoredRectangleInstance.Y = 0f;
                            ColoredRectangleInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                            ColoredRectangleInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            ColoredRectangleInstance1.Height = 2f;
                            ColoredRectangleInstance1.Width = 0f;
                            ColoredRectangleInstance1.WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                            ColoredRectangleInstance1.X = 0f;
                            ColoredRectangleInstance1.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                            ColoredRectangleInstance1.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            ColoredRectangleInstance1.Y = 0f;
                            ColoredRectangleInstance1.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Bottom;
                            ColoredRectangleInstance1.YUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                            ColoredRectangleInstance2.Height = 2f;
                            ColoredRectangleInstance2.Width = 0f;
                            ColoredRectangleInstance2.WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                            ColoredRectangleInstance2.X = 0f;
                            ColoredRectangleInstance2.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                            ColoredRectangleInstance2.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            ColoredRectangleInstance2.Y = 0f;
                            ColoredRectangleInstance2.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                            ColoredRectangleInstance2.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                            ColoredRectangleInstance3.Height = 0f;
                            ColoredRectangleInstance3.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                            ColoredRectangleInstance3.Width = 2f;
                            ColoredRectangleInstance3.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                            ColoredRectangleInstance3.X = 0f;
                            ColoredRectangleInstance3.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Right;
                            ColoredRectangleInstance3.XUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                            ColoredRectangleInstance3.Y = 0f;
                            ColoredRectangleInstance3.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                            ColoredRectangleInstance3.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            ColoredRectangleInstance4.Height = 0f;
                            ColoredRectangleInstance4.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                            ColoredRectangleInstance4.Width = 2f;
                            ColoredRectangleInstance4.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                            ColoredRectangleInstance4.X = 0f;
                            ColoredRectangleInstance4.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                            ColoredRectangleInstance4.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                            ColoredRectangleInstance4.Y = 0f;
                            ColoredRectangleInstance4.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                            ColoredRectangleInstance4.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
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
                bool setColoredRectangleInstanceAlphaFirstValue = false;
                bool setColoredRectangleInstanceAlphaSecondValue = false;
                int ColoredRectangleInstanceAlphaFirstValue= 0;
                int ColoredRectangleInstanceAlphaSecondValue= 0;
                bool setColoredRectangleInstanceBlueFirstValue = false;
                bool setColoredRectangleInstanceBlueSecondValue = false;
                int ColoredRectangleInstanceBlueFirstValue= 0;
                int ColoredRectangleInstanceBlueSecondValue= 0;
                bool setColoredRectangleInstanceGreenFirstValue = false;
                bool setColoredRectangleInstanceGreenSecondValue = false;
                int ColoredRectangleInstanceGreenFirstValue= 0;
                int ColoredRectangleInstanceGreenSecondValue= 0;
                bool setColoredRectangleInstanceHeightFirstValue = false;
                bool setColoredRectangleInstanceHeightSecondValue = false;
                float ColoredRectangleInstanceHeightFirstValue= 0;
                float ColoredRectangleInstanceHeightSecondValue= 0;
                bool setColoredRectangleInstanceRedFirstValue = false;
                bool setColoredRectangleInstanceRedSecondValue = false;
                int ColoredRectangleInstanceRedFirstValue= 0;
                int ColoredRectangleInstanceRedSecondValue= 0;
                bool setColoredRectangleInstanceWidthFirstValue = false;
                bool setColoredRectangleInstanceWidthSecondValue = false;
                float ColoredRectangleInstanceWidthFirstValue= 0;
                float ColoredRectangleInstanceWidthSecondValue= 0;
                bool setColoredRectangleInstanceXFirstValue = false;
                bool setColoredRectangleInstanceXSecondValue = false;
                float ColoredRectangleInstanceXFirstValue= 0;
                float ColoredRectangleInstanceXSecondValue= 0;
                bool setColoredRectangleInstanceYFirstValue = false;
                bool setColoredRectangleInstanceYSecondValue = false;
                float ColoredRectangleInstanceYFirstValue= 0;
                float ColoredRectangleInstanceYSecondValue= 0;
                bool setColoredRectangleInstance1HeightFirstValue = false;
                bool setColoredRectangleInstance1HeightSecondValue = false;
                float ColoredRectangleInstance1HeightFirstValue= 0;
                float ColoredRectangleInstance1HeightSecondValue= 0;
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
                bool setColoredRectangleInstance2HeightFirstValue = false;
                bool setColoredRectangleInstance2HeightSecondValue = false;
                float ColoredRectangleInstance2HeightFirstValue= 0;
                float ColoredRectangleInstance2HeightSecondValue= 0;
                bool setColoredRectangleInstance2WidthFirstValue = false;
                bool setColoredRectangleInstance2WidthSecondValue = false;
                float ColoredRectangleInstance2WidthFirstValue= 0;
                float ColoredRectangleInstance2WidthSecondValue= 0;
                bool setColoredRectangleInstance2XFirstValue = false;
                bool setColoredRectangleInstance2XSecondValue = false;
                float ColoredRectangleInstance2XFirstValue= 0;
                float ColoredRectangleInstance2XSecondValue= 0;
                bool setColoredRectangleInstance2YFirstValue = false;
                bool setColoredRectangleInstance2YSecondValue = false;
                float ColoredRectangleInstance2YFirstValue= 0;
                float ColoredRectangleInstance2YSecondValue= 0;
                bool setColoredRectangleInstance3HeightFirstValue = false;
                bool setColoredRectangleInstance3HeightSecondValue = false;
                float ColoredRectangleInstance3HeightFirstValue= 0;
                float ColoredRectangleInstance3HeightSecondValue= 0;
                bool setColoredRectangleInstance3WidthFirstValue = false;
                bool setColoredRectangleInstance3WidthSecondValue = false;
                float ColoredRectangleInstance3WidthFirstValue= 0;
                float ColoredRectangleInstance3WidthSecondValue= 0;
                bool setColoredRectangleInstance3XFirstValue = false;
                bool setColoredRectangleInstance3XSecondValue = false;
                float ColoredRectangleInstance3XFirstValue= 0;
                float ColoredRectangleInstance3XSecondValue= 0;
                bool setColoredRectangleInstance3YFirstValue = false;
                bool setColoredRectangleInstance3YSecondValue = false;
                float ColoredRectangleInstance3YFirstValue= 0;
                float ColoredRectangleInstance3YSecondValue= 0;
                bool setColoredRectangleInstance4HeightFirstValue = false;
                bool setColoredRectangleInstance4HeightSecondValue = false;
                float ColoredRectangleInstance4HeightFirstValue= 0;
                float ColoredRectangleInstance4HeightSecondValue= 0;
                bool setColoredRectangleInstance4WidthFirstValue = false;
                bool setColoredRectangleInstance4WidthSecondValue = false;
                float ColoredRectangleInstance4WidthFirstValue= 0;
                float ColoredRectangleInstance4WidthSecondValue= 0;
                bool setColoredRectangleInstance4XFirstValue = false;
                bool setColoredRectangleInstance4XSecondValue = false;
                float ColoredRectangleInstance4XFirstValue= 0;
                float ColoredRectangleInstance4XSecondValue= 0;
                bool setColoredRectangleInstance4YFirstValue = false;
                bool setColoredRectangleInstance4YSecondValue = false;
                float ColoredRectangleInstance4YFirstValue= 0;
                float ColoredRectangleInstance4YSecondValue= 0;
                bool setHeightFirstValue = false;
                bool setHeightSecondValue = false;
                float HeightFirstValue= 0;
                float HeightSecondValue= 0;
                bool setWidthFirstValue = false;
                bool setWidthSecondValue = false;
                float WidthFirstValue= 0;
                float WidthSecondValue= 0;
                switch(firstState)
                {
                    case  VariableState.Default:
                        if (interpolationValue < 1)
                        {
                            this.ChildrenLayout = Gum.Managers.ChildrenLayout.Regular;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ClipsChildren = false;
                        }
                        setColoredRectangleInstanceAlphaFirstValue = true;
                        ColoredRectangleInstanceAlphaFirstValue = 80;
                        setColoredRectangleInstanceBlueFirstValue = true;
                        ColoredRectangleInstanceBlueFirstValue = 0;
                        setColoredRectangleInstanceGreenFirstValue = true;
                        ColoredRectangleInstanceGreenFirstValue = 255;
                        setColoredRectangleInstanceHeightFirstValue = true;
                        ColoredRectangleInstanceHeightFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.ColoredRectangleInstance.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        setColoredRectangleInstanceRedFirstValue = true;
                        ColoredRectangleInstanceRedFirstValue = 255;
                        setColoredRectangleInstanceWidthFirstValue = true;
                        ColoredRectangleInstanceWidthFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.ColoredRectangleInstance.WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        setColoredRectangleInstanceXFirstValue = true;
                        ColoredRectangleInstanceXFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.ColoredRectangleInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ColoredRectangleInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setColoredRectangleInstanceYFirstValue = true;
                        ColoredRectangleInstanceYFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.ColoredRectangleInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ColoredRectangleInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setColoredRectangleInstance1HeightFirstValue = true;
                        ColoredRectangleInstance1HeightFirstValue = 2f;
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
                            this.ColoredRectangleInstance1.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Bottom;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ColoredRectangleInstance1.YUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        setColoredRectangleInstance2HeightFirstValue = true;
                        ColoredRectangleInstance2HeightFirstValue = 2f;
                        setColoredRectangleInstance2WidthFirstValue = true;
                        ColoredRectangleInstance2WidthFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.ColoredRectangleInstance2.WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        setColoredRectangleInstance2XFirstValue = true;
                        ColoredRectangleInstance2XFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.ColoredRectangleInstance2.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ColoredRectangleInstance2.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setColoredRectangleInstance2YFirstValue = true;
                        ColoredRectangleInstance2YFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.ColoredRectangleInstance2.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ColoredRectangleInstance2.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        setColoredRectangleInstance3HeightFirstValue = true;
                        ColoredRectangleInstance3HeightFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.ColoredRectangleInstance3.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        setColoredRectangleInstance3WidthFirstValue = true;
                        ColoredRectangleInstance3WidthFirstValue = 2f;
                        if (interpolationValue < 1)
                        {
                            this.ColoredRectangleInstance3.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        setColoredRectangleInstance3XFirstValue = true;
                        ColoredRectangleInstance3XFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.ColoredRectangleInstance3.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Right;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ColoredRectangleInstance3.XUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        setColoredRectangleInstance3YFirstValue = true;
                        ColoredRectangleInstance3YFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.ColoredRectangleInstance3.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ColoredRectangleInstance3.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setColoredRectangleInstance4HeightFirstValue = true;
                        ColoredRectangleInstance4HeightFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.ColoredRectangleInstance4.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        setColoredRectangleInstance4WidthFirstValue = true;
                        ColoredRectangleInstance4WidthFirstValue = 2f;
                        if (interpolationValue < 1)
                        {
                            this.ColoredRectangleInstance4.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        setColoredRectangleInstance4XFirstValue = true;
                        ColoredRectangleInstance4XFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.ColoredRectangleInstance4.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ColoredRectangleInstance4.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        setColoredRectangleInstance4YFirstValue = true;
                        ColoredRectangleInstance4YFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.ColoredRectangleInstance4.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ColoredRectangleInstance4.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setHeightFirstValue = true;
                        HeightFirstValue = 150f;
                        if (interpolationValue < 1)
                        {
                            this.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        if (interpolationValue < 1)
                        {
                            this.Visible = true;
                        }
                        setWidthFirstValue = true;
                        WidthFirstValue = 150f;
                        if (interpolationValue < 1)
                        {
                            this.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        if (interpolationValue < 1)
                        {
                            this.WrapsChildren = false;
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
                        if (interpolationValue >= 1)
                        {
                            this.ChildrenLayout = Gum.Managers.ChildrenLayout.Regular;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ClipsChildren = false;
                        }
                        setColoredRectangleInstanceAlphaSecondValue = true;
                        ColoredRectangleInstanceAlphaSecondValue = 80;
                        setColoredRectangleInstanceBlueSecondValue = true;
                        ColoredRectangleInstanceBlueSecondValue = 0;
                        setColoredRectangleInstanceGreenSecondValue = true;
                        ColoredRectangleInstanceGreenSecondValue = 255;
                        setColoredRectangleInstanceHeightSecondValue = true;
                        ColoredRectangleInstanceHeightSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.ColoredRectangleInstance.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        setColoredRectangleInstanceRedSecondValue = true;
                        ColoredRectangleInstanceRedSecondValue = 255;
                        setColoredRectangleInstanceWidthSecondValue = true;
                        ColoredRectangleInstanceWidthSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.ColoredRectangleInstance.WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        setColoredRectangleInstanceXSecondValue = true;
                        ColoredRectangleInstanceXSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.ColoredRectangleInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ColoredRectangleInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setColoredRectangleInstanceYSecondValue = true;
                        ColoredRectangleInstanceYSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.ColoredRectangleInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ColoredRectangleInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setColoredRectangleInstance1HeightSecondValue = true;
                        ColoredRectangleInstance1HeightSecondValue = 2f;
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
                            this.ColoredRectangleInstance1.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Bottom;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ColoredRectangleInstance1.YUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        setColoredRectangleInstance2HeightSecondValue = true;
                        ColoredRectangleInstance2HeightSecondValue = 2f;
                        setColoredRectangleInstance2WidthSecondValue = true;
                        ColoredRectangleInstance2WidthSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.ColoredRectangleInstance2.WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        setColoredRectangleInstance2XSecondValue = true;
                        ColoredRectangleInstance2XSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.ColoredRectangleInstance2.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ColoredRectangleInstance2.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setColoredRectangleInstance2YSecondValue = true;
                        ColoredRectangleInstance2YSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.ColoredRectangleInstance2.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ColoredRectangleInstance2.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        setColoredRectangleInstance3HeightSecondValue = true;
                        ColoredRectangleInstance3HeightSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.ColoredRectangleInstance3.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        setColoredRectangleInstance3WidthSecondValue = true;
                        ColoredRectangleInstance3WidthSecondValue = 2f;
                        if (interpolationValue >= 1)
                        {
                            this.ColoredRectangleInstance3.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        setColoredRectangleInstance3XSecondValue = true;
                        ColoredRectangleInstance3XSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.ColoredRectangleInstance3.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Right;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ColoredRectangleInstance3.XUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        setColoredRectangleInstance3YSecondValue = true;
                        ColoredRectangleInstance3YSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.ColoredRectangleInstance3.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ColoredRectangleInstance3.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setColoredRectangleInstance4HeightSecondValue = true;
                        ColoredRectangleInstance4HeightSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.ColoredRectangleInstance4.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        setColoredRectangleInstance4WidthSecondValue = true;
                        ColoredRectangleInstance4WidthSecondValue = 2f;
                        if (interpolationValue >= 1)
                        {
                            this.ColoredRectangleInstance4.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        setColoredRectangleInstance4XSecondValue = true;
                        ColoredRectangleInstance4XSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.ColoredRectangleInstance4.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ColoredRectangleInstance4.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        setColoredRectangleInstance4YSecondValue = true;
                        ColoredRectangleInstance4YSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.ColoredRectangleInstance4.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ColoredRectangleInstance4.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setHeightSecondValue = true;
                        HeightSecondValue = 150f;
                        if (interpolationValue >= 1)
                        {
                            this.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.Visible = true;
                        }
                        setWidthSecondValue = true;
                        WidthSecondValue = 150f;
                        if (interpolationValue >= 1)
                        {
                            this.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.WrapsChildren = false;
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
                if (setColoredRectangleInstanceAlphaFirstValue && setColoredRectangleInstanceAlphaSecondValue)
                {
                    ColoredRectangleInstance.Alpha = FlatRedBall.Math.MathFunctions.RoundToInt(ColoredRectangleInstanceAlphaFirstValue* (1 - interpolationValue) + ColoredRectangleInstanceAlphaSecondValue * interpolationValue);
                }
                if (setColoredRectangleInstanceBlueFirstValue && setColoredRectangleInstanceBlueSecondValue)
                {
                    ColoredRectangleInstance.Blue = FlatRedBall.Math.MathFunctions.RoundToInt(ColoredRectangleInstanceBlueFirstValue* (1 - interpolationValue) + ColoredRectangleInstanceBlueSecondValue * interpolationValue);
                }
                if (setColoredRectangleInstanceGreenFirstValue && setColoredRectangleInstanceGreenSecondValue)
                {
                    ColoredRectangleInstance.Green = FlatRedBall.Math.MathFunctions.RoundToInt(ColoredRectangleInstanceGreenFirstValue* (1 - interpolationValue) + ColoredRectangleInstanceGreenSecondValue * interpolationValue);
                }
                if (setColoredRectangleInstanceHeightFirstValue && setColoredRectangleInstanceHeightSecondValue)
                {
                    ColoredRectangleInstance.Height = ColoredRectangleInstanceHeightFirstValue * (1 - interpolationValue) + ColoredRectangleInstanceHeightSecondValue * interpolationValue;
                }
                if (setColoredRectangleInstanceRedFirstValue && setColoredRectangleInstanceRedSecondValue)
                {
                    ColoredRectangleInstance.Red = FlatRedBall.Math.MathFunctions.RoundToInt(ColoredRectangleInstanceRedFirstValue* (1 - interpolationValue) + ColoredRectangleInstanceRedSecondValue * interpolationValue);
                }
                if (setColoredRectangleInstanceWidthFirstValue && setColoredRectangleInstanceWidthSecondValue)
                {
                    ColoredRectangleInstance.Width = ColoredRectangleInstanceWidthFirstValue * (1 - interpolationValue) + ColoredRectangleInstanceWidthSecondValue * interpolationValue;
                }
                if (setColoredRectangleInstanceXFirstValue && setColoredRectangleInstanceXSecondValue)
                {
                    ColoredRectangleInstance.X = ColoredRectangleInstanceXFirstValue * (1 - interpolationValue) + ColoredRectangleInstanceXSecondValue * interpolationValue;
                }
                if (setColoredRectangleInstanceYFirstValue && setColoredRectangleInstanceYSecondValue)
                {
                    ColoredRectangleInstance.Y = ColoredRectangleInstanceYFirstValue * (1 - interpolationValue) + ColoredRectangleInstanceYSecondValue * interpolationValue;
                }
                if (setColoredRectangleInstance1HeightFirstValue && setColoredRectangleInstance1HeightSecondValue)
                {
                    ColoredRectangleInstance1.Height = ColoredRectangleInstance1HeightFirstValue * (1 - interpolationValue) + ColoredRectangleInstance1HeightSecondValue * interpolationValue;
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
                if (setColoredRectangleInstance2HeightFirstValue && setColoredRectangleInstance2HeightSecondValue)
                {
                    ColoredRectangleInstance2.Height = ColoredRectangleInstance2HeightFirstValue * (1 - interpolationValue) + ColoredRectangleInstance2HeightSecondValue * interpolationValue;
                }
                if (setColoredRectangleInstance2WidthFirstValue && setColoredRectangleInstance2WidthSecondValue)
                {
                    ColoredRectangleInstance2.Width = ColoredRectangleInstance2WidthFirstValue * (1 - interpolationValue) + ColoredRectangleInstance2WidthSecondValue * interpolationValue;
                }
                if (setColoredRectangleInstance2XFirstValue && setColoredRectangleInstance2XSecondValue)
                {
                    ColoredRectangleInstance2.X = ColoredRectangleInstance2XFirstValue * (1 - interpolationValue) + ColoredRectangleInstance2XSecondValue * interpolationValue;
                }
                if (setColoredRectangleInstance2YFirstValue && setColoredRectangleInstance2YSecondValue)
                {
                    ColoredRectangleInstance2.Y = ColoredRectangleInstance2YFirstValue * (1 - interpolationValue) + ColoredRectangleInstance2YSecondValue * interpolationValue;
                }
                if (setColoredRectangleInstance3HeightFirstValue && setColoredRectangleInstance3HeightSecondValue)
                {
                    ColoredRectangleInstance3.Height = ColoredRectangleInstance3HeightFirstValue * (1 - interpolationValue) + ColoredRectangleInstance3HeightSecondValue * interpolationValue;
                }
                if (setColoredRectangleInstance3WidthFirstValue && setColoredRectangleInstance3WidthSecondValue)
                {
                    ColoredRectangleInstance3.Width = ColoredRectangleInstance3WidthFirstValue * (1 - interpolationValue) + ColoredRectangleInstance3WidthSecondValue * interpolationValue;
                }
                if (setColoredRectangleInstance3XFirstValue && setColoredRectangleInstance3XSecondValue)
                {
                    ColoredRectangleInstance3.X = ColoredRectangleInstance3XFirstValue * (1 - interpolationValue) + ColoredRectangleInstance3XSecondValue * interpolationValue;
                }
                if (setColoredRectangleInstance3YFirstValue && setColoredRectangleInstance3YSecondValue)
                {
                    ColoredRectangleInstance3.Y = ColoredRectangleInstance3YFirstValue * (1 - interpolationValue) + ColoredRectangleInstance3YSecondValue * interpolationValue;
                }
                if (setColoredRectangleInstance4HeightFirstValue && setColoredRectangleInstance4HeightSecondValue)
                {
                    ColoredRectangleInstance4.Height = ColoredRectangleInstance4HeightFirstValue * (1 - interpolationValue) + ColoredRectangleInstance4HeightSecondValue * interpolationValue;
                }
                if (setColoredRectangleInstance4WidthFirstValue && setColoredRectangleInstance4WidthSecondValue)
                {
                    ColoredRectangleInstance4.Width = ColoredRectangleInstance4WidthFirstValue * (1 - interpolationValue) + ColoredRectangleInstance4WidthSecondValue * interpolationValue;
                }
                if (setColoredRectangleInstance4XFirstValue && setColoredRectangleInstance4XSecondValue)
                {
                    ColoredRectangleInstance4.X = ColoredRectangleInstance4XFirstValue * (1 - interpolationValue) + ColoredRectangleInstance4XSecondValue * interpolationValue;
                }
                if (setColoredRectangleInstance4YFirstValue && setColoredRectangleInstance4YSecondValue)
                {
                    ColoredRectangleInstance4.Y = ColoredRectangleInstance4YFirstValue * (1 - interpolationValue) + ColoredRectangleInstance4YSecondValue * interpolationValue;
                }
                if (setHeightFirstValue && setHeightSecondValue)
                {
                    Height = HeightFirstValue * (1 - interpolationValue) + HeightSecondValue * interpolationValue;
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
            #endregion
            #region State Interpolate To
            public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateTo (TownRaiserImGui.GumRuntimes.GroupSelectorRuntime.VariableState fromState,TownRaiserImGui.GumRuntimes.GroupSelectorRuntime.VariableState toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null) 
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
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance.Alpha",
                            Type = "int",
                            Value = ColoredRectangleInstance.Alpha
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance.Blue",
                            Type = "int",
                            Value = ColoredRectangleInstance.Blue
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance.Green",
                            Type = "int",
                            Value = ColoredRectangleInstance.Green
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance.Height",
                            Type = "float",
                            Value = ColoredRectangleInstance.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance.Height Units",
                            Type = "DimensionUnitType",
                            Value = ColoredRectangleInstance.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance.Red",
                            Type = "int",
                            Value = ColoredRectangleInstance.Red
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance.Width",
                            Type = "float",
                            Value = ColoredRectangleInstance.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance.Width Units",
                            Type = "DimensionUnitType",
                            Value = ColoredRectangleInstance.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance.X",
                            Type = "float",
                            Value = ColoredRectangleInstance.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance.X Origin",
                            Type = "HorizontalAlignment",
                            Value = ColoredRectangleInstance.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance.X Units",
                            Type = "PositionUnitType",
                            Value = ColoredRectangleInstance.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance.Y",
                            Type = "float",
                            Value = ColoredRectangleInstance.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance.Y Origin",
                            Type = "VerticalAlignment",
                            Value = ColoredRectangleInstance.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance.Y Units",
                            Type = "PositionUnitType",
                            Value = ColoredRectangleInstance.YUnits
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
                            Name = "ColoredRectangleInstance2.Height",
                            Type = "float",
                            Value = ColoredRectangleInstance2.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance2.Width",
                            Type = "float",
                            Value = ColoredRectangleInstance2.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance2.Width Units",
                            Type = "DimensionUnitType",
                            Value = ColoredRectangleInstance2.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance2.X",
                            Type = "float",
                            Value = ColoredRectangleInstance2.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance2.X Origin",
                            Type = "HorizontalAlignment",
                            Value = ColoredRectangleInstance2.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance2.X Units",
                            Type = "PositionUnitType",
                            Value = ColoredRectangleInstance2.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance2.Y",
                            Type = "float",
                            Value = ColoredRectangleInstance2.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance2.Y Origin",
                            Type = "VerticalAlignment",
                            Value = ColoredRectangleInstance2.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance2.Y Units",
                            Type = "PositionUnitType",
                            Value = ColoredRectangleInstance2.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance3.Height",
                            Type = "float",
                            Value = ColoredRectangleInstance3.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance3.Height Units",
                            Type = "DimensionUnitType",
                            Value = ColoredRectangleInstance3.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance3.Width",
                            Type = "float",
                            Value = ColoredRectangleInstance3.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance3.Width Units",
                            Type = "DimensionUnitType",
                            Value = ColoredRectangleInstance3.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance3.X",
                            Type = "float",
                            Value = ColoredRectangleInstance3.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance3.X Origin",
                            Type = "HorizontalAlignment",
                            Value = ColoredRectangleInstance3.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance3.X Units",
                            Type = "PositionUnitType",
                            Value = ColoredRectangleInstance3.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance3.Y",
                            Type = "float",
                            Value = ColoredRectangleInstance3.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance3.Y Origin",
                            Type = "VerticalAlignment",
                            Value = ColoredRectangleInstance3.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance3.Y Units",
                            Type = "PositionUnitType",
                            Value = ColoredRectangleInstance3.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance4.Height",
                            Type = "float",
                            Value = ColoredRectangleInstance4.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance4.Height Units",
                            Type = "DimensionUnitType",
                            Value = ColoredRectangleInstance4.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance4.Width",
                            Type = "float",
                            Value = ColoredRectangleInstance4.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance4.Width Units",
                            Type = "DimensionUnitType",
                            Value = ColoredRectangleInstance4.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance4.X",
                            Type = "float",
                            Value = ColoredRectangleInstance4.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance4.X Origin",
                            Type = "HorizontalAlignment",
                            Value = ColoredRectangleInstance4.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance4.X Units",
                            Type = "PositionUnitType",
                            Value = ColoredRectangleInstance4.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance4.Y",
                            Type = "float",
                            Value = ColoredRectangleInstance4.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance4.Y Origin",
                            Type = "VerticalAlignment",
                            Value = ColoredRectangleInstance4.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance4.Y Units",
                            Type = "PositionUnitType",
                            Value = ColoredRectangleInstance4.YUnits
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
                            Value = Height + 150f
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
                            Value = Width + 150f
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
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance.Alpha",
                            Type = "int",
                            Value = ColoredRectangleInstance.Alpha + 80
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance.Blue",
                            Type = "int",
                            Value = ColoredRectangleInstance.Blue + 0
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance.Green",
                            Type = "int",
                            Value = ColoredRectangleInstance.Green + 255
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance.Height",
                            Type = "float",
                            Value = ColoredRectangleInstance.Height + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance.Height Units",
                            Type = "DimensionUnitType",
                            Value = ColoredRectangleInstance.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance.Red",
                            Type = "int",
                            Value = ColoredRectangleInstance.Red + 255
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance.Width",
                            Type = "float",
                            Value = ColoredRectangleInstance.Width + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance.Width Units",
                            Type = "DimensionUnitType",
                            Value = ColoredRectangleInstance.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance.X",
                            Type = "float",
                            Value = ColoredRectangleInstance.X + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance.X Origin",
                            Type = "HorizontalAlignment",
                            Value = ColoredRectangleInstance.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance.X Units",
                            Type = "PositionUnitType",
                            Value = ColoredRectangleInstance.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance.Y",
                            Type = "float",
                            Value = ColoredRectangleInstance.Y + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance.Y Origin",
                            Type = "VerticalAlignment",
                            Value = ColoredRectangleInstance.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance.Y Units",
                            Type = "PositionUnitType",
                            Value = ColoredRectangleInstance.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance1.Height",
                            Type = "float",
                            Value = ColoredRectangleInstance1.Height + 2f
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
                            Name = "ColoredRectangleInstance2.Height",
                            Type = "float",
                            Value = ColoredRectangleInstance2.Height + 2f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance2.Width",
                            Type = "float",
                            Value = ColoredRectangleInstance2.Width + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance2.Width Units",
                            Type = "DimensionUnitType",
                            Value = ColoredRectangleInstance2.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance2.X",
                            Type = "float",
                            Value = ColoredRectangleInstance2.X + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance2.X Origin",
                            Type = "HorizontalAlignment",
                            Value = ColoredRectangleInstance2.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance2.X Units",
                            Type = "PositionUnitType",
                            Value = ColoredRectangleInstance2.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance2.Y",
                            Type = "float",
                            Value = ColoredRectangleInstance2.Y + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance2.Y Origin",
                            Type = "VerticalAlignment",
                            Value = ColoredRectangleInstance2.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance2.Y Units",
                            Type = "PositionUnitType",
                            Value = ColoredRectangleInstance2.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance3.Height",
                            Type = "float",
                            Value = ColoredRectangleInstance3.Height + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance3.Height Units",
                            Type = "DimensionUnitType",
                            Value = ColoredRectangleInstance3.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance3.Width",
                            Type = "float",
                            Value = ColoredRectangleInstance3.Width + 2f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance3.Width Units",
                            Type = "DimensionUnitType",
                            Value = ColoredRectangleInstance3.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance3.X",
                            Type = "float",
                            Value = ColoredRectangleInstance3.X + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance3.X Origin",
                            Type = "HorizontalAlignment",
                            Value = ColoredRectangleInstance3.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance3.X Units",
                            Type = "PositionUnitType",
                            Value = ColoredRectangleInstance3.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance3.Y",
                            Type = "float",
                            Value = ColoredRectangleInstance3.Y + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance3.Y Origin",
                            Type = "VerticalAlignment",
                            Value = ColoredRectangleInstance3.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance3.Y Units",
                            Type = "PositionUnitType",
                            Value = ColoredRectangleInstance3.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance4.Height",
                            Type = "float",
                            Value = ColoredRectangleInstance4.Height + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance4.Height Units",
                            Type = "DimensionUnitType",
                            Value = ColoredRectangleInstance4.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance4.Width",
                            Type = "float",
                            Value = ColoredRectangleInstance4.Width + 2f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance4.Width Units",
                            Type = "DimensionUnitType",
                            Value = ColoredRectangleInstance4.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance4.X",
                            Type = "float",
                            Value = ColoredRectangleInstance4.X + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance4.X Origin",
                            Type = "HorizontalAlignment",
                            Value = ColoredRectangleInstance4.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance4.X Units",
                            Type = "PositionUnitType",
                            Value = ColoredRectangleInstance4.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance4.Y",
                            Type = "float",
                            Value = ColoredRectangleInstance4.Y + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance4.Y Origin",
                            Type = "VerticalAlignment",
                            Value = ColoredRectangleInstance4.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ColoredRectangleInstance4.Y Units",
                            Type = "PositionUnitType",
                            Value = ColoredRectangleInstance4.YUnits
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
            private TownRaiserImGui.GumRuntimes.ColoredRectangleRuntime ColoredRectangleInstance { get; set; }
            private TownRaiserImGui.GumRuntimes.ColoredRectangleRuntime ColoredRectangleInstance1 { get; set; }
            private TownRaiserImGui.GumRuntimes.ColoredRectangleRuntime ColoredRectangleInstance2 { get; set; }
            private TownRaiserImGui.GumRuntimes.ColoredRectangleRuntime ColoredRectangleInstance3 { get; set; }
            private TownRaiserImGui.GumRuntimes.ColoredRectangleRuntime ColoredRectangleInstance4 { get; set; }
            public GroupSelectorRuntime (bool fullInstantiation = true, bool tryCreateFormsObject = true) 
            	: base(false, tryCreateFormsObject)
            {
                this.HasEvents = true;
                this.ExposeChildrenEvents = true;
                if (fullInstantiation)
                {
                    Gum.DataTypes.ElementSave elementSave = Gum.Managers.ObjectFinder.Self.GumProjectSave.Components.First(item => item.Name == "GroupSelector");
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
                ColoredRectangleInstance = this.GetGraphicalUiElementByName("ColoredRectangleInstance") as TownRaiserImGui.GumRuntimes.ColoredRectangleRuntime;
                ColoredRectangleInstance1 = this.GetGraphicalUiElementByName("ColoredRectangleInstance1") as TownRaiserImGui.GumRuntimes.ColoredRectangleRuntime;
                ColoredRectangleInstance2 = this.GetGraphicalUiElementByName("ColoredRectangleInstance2") as TownRaiserImGui.GumRuntimes.ColoredRectangleRuntime;
                ColoredRectangleInstance3 = this.GetGraphicalUiElementByName("ColoredRectangleInstance3") as TownRaiserImGui.GumRuntimes.ColoredRectangleRuntime;
                ColoredRectangleInstance4 = this.GetGraphicalUiElementByName("ColoredRectangleInstance4") as TownRaiserImGui.GumRuntimes.ColoredRectangleRuntime;
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
