    using System.Linq;
    namespace TownRaiserImGui.GumRuntimes
    {
        public partial class MinimapContentsRuntime : TownRaiserImGui.GumRuntimes.ContainerRuntime
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
                            Height = 200f;
                            HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                            Visible = true;
                            Width = 200f;
                            WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                            WrapsChildren = false;
                            X = 0f;
                            XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Right;
                            XUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                            Y = 0f;
                            YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Bottom;
                            YUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                            SetProperty("minimapbackground.SourceFile", "components\\graphics\\minimapbackground.png");
                            minimapbackground.X = 0f;
                            minimapbackground.Y = 0f;
                            Frame.Height = 6f;
                            Frame.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                            SetProperty("Frame.SourceFile", "..\\maintileset.png");
                            Frame.TextureAddress = Gum.Managers.TextureAddress.Custom;
                            Frame.TextureHeight = 16;
                            Frame.TextureLeft = 480;
                            Frame.TextureTop = 208;
                            Frame.TextureWidth = 16;
                            Frame.Width = 6f;
                            Frame.WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                            Frame.X = 0f;
                            Frame.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                            Frame.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            Frame.Y = 0f;
                            Frame.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                            Frame.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            CameraFrame.Height = 34f;
                            CameraFrame.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                            SetProperty("CameraFrame.SourceFile", "..\\maintileset.png");
                            CameraFrame.TextureAddress = Gum.Managers.TextureAddress.Custom;
                            CameraFrame.TextureHeight = 16;
                            CameraFrame.TextureLeft = 480;
                            CameraFrame.TextureTop = 192;
                            CameraFrame.TextureWidth = 16;
                            CameraFrame.Width = 49f;
                            CameraFrame.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                            CameraFrame.X = 110f;
                            CameraFrame.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                            CameraFrame.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                            CameraFrame.Y = 83f;
                            CameraFrame.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                            CameraFrame.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
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
                bool setCameraFrameHeightFirstValue = false;
                bool setCameraFrameHeightSecondValue = false;
                float CameraFrameHeightFirstValue= 0;
                float CameraFrameHeightSecondValue= 0;
                bool setCameraFrameTextureHeightFirstValue = false;
                bool setCameraFrameTextureHeightSecondValue = false;
                int CameraFrameTextureHeightFirstValue= 0;
                int CameraFrameTextureHeightSecondValue= 0;
                bool setCameraFrameTextureLeftFirstValue = false;
                bool setCameraFrameTextureLeftSecondValue = false;
                int CameraFrameTextureLeftFirstValue= 0;
                int CameraFrameTextureLeftSecondValue= 0;
                bool setCameraFrameTextureTopFirstValue = false;
                bool setCameraFrameTextureTopSecondValue = false;
                int CameraFrameTextureTopFirstValue= 0;
                int CameraFrameTextureTopSecondValue= 0;
                bool setCameraFrameTextureWidthFirstValue = false;
                bool setCameraFrameTextureWidthSecondValue = false;
                int CameraFrameTextureWidthFirstValue= 0;
                int CameraFrameTextureWidthSecondValue= 0;
                bool setCameraFrameWidthFirstValue = false;
                bool setCameraFrameWidthSecondValue = false;
                float CameraFrameWidthFirstValue= 0;
                float CameraFrameWidthSecondValue= 0;
                bool setCameraFrameXFirstValue = false;
                bool setCameraFrameXSecondValue = false;
                float CameraFrameXFirstValue= 0;
                float CameraFrameXSecondValue= 0;
                bool setCameraFrameYFirstValue = false;
                bool setCameraFrameYSecondValue = false;
                float CameraFrameYFirstValue= 0;
                float CameraFrameYSecondValue= 0;
                bool setFrameHeightFirstValue = false;
                bool setFrameHeightSecondValue = false;
                float FrameHeightFirstValue= 0;
                float FrameHeightSecondValue= 0;
                bool setFrameTextureHeightFirstValue = false;
                bool setFrameTextureHeightSecondValue = false;
                int FrameTextureHeightFirstValue= 0;
                int FrameTextureHeightSecondValue= 0;
                bool setFrameTextureLeftFirstValue = false;
                bool setFrameTextureLeftSecondValue = false;
                int FrameTextureLeftFirstValue= 0;
                int FrameTextureLeftSecondValue= 0;
                bool setFrameTextureTopFirstValue = false;
                bool setFrameTextureTopSecondValue = false;
                int FrameTextureTopFirstValue= 0;
                int FrameTextureTopSecondValue= 0;
                bool setFrameTextureWidthFirstValue = false;
                bool setFrameTextureWidthSecondValue = false;
                int FrameTextureWidthFirstValue= 0;
                int FrameTextureWidthSecondValue= 0;
                bool setFrameWidthFirstValue = false;
                bool setFrameWidthSecondValue = false;
                float FrameWidthFirstValue= 0;
                float FrameWidthSecondValue= 0;
                bool setFrameXFirstValue = false;
                bool setFrameXSecondValue = false;
                float FrameXFirstValue= 0;
                float FrameXSecondValue= 0;
                bool setFrameYFirstValue = false;
                bool setFrameYSecondValue = false;
                float FrameYFirstValue= 0;
                float FrameYSecondValue= 0;
                bool setHeightFirstValue = false;
                bool setHeightSecondValue = false;
                float HeightFirstValue= 0;
                float HeightSecondValue= 0;
                bool setminimapbackgroundXFirstValue = false;
                bool setminimapbackgroundXSecondValue = false;
                float minimapbackgroundXFirstValue= 0;
                float minimapbackgroundXSecondValue= 0;
                bool setminimapbackgroundYFirstValue = false;
                bool setminimapbackgroundYSecondValue = false;
                float minimapbackgroundYFirstValue= 0;
                float minimapbackgroundYSecondValue= 0;
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
                        setCameraFrameHeightFirstValue = true;
                        CameraFrameHeightFirstValue = 34f;
                        if (interpolationValue < 1)
                        {
                            this.CameraFrame.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        if (interpolationValue < 1)
                        {
                            SetProperty("CameraFrame.SourceFile", "..\\maintileset.png");
                        }
                        if (interpolationValue < 1)
                        {
                            this.CameraFrame.TextureAddress = Gum.Managers.TextureAddress.Custom;
                        }
                        setCameraFrameTextureHeightFirstValue = true;
                        CameraFrameTextureHeightFirstValue = 16;
                        setCameraFrameTextureLeftFirstValue = true;
                        CameraFrameTextureLeftFirstValue = 480;
                        setCameraFrameTextureTopFirstValue = true;
                        CameraFrameTextureTopFirstValue = 192;
                        setCameraFrameTextureWidthFirstValue = true;
                        CameraFrameTextureWidthFirstValue = 16;
                        setCameraFrameWidthFirstValue = true;
                        CameraFrameWidthFirstValue = 49f;
                        if (interpolationValue < 1)
                        {
                            this.CameraFrame.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        setCameraFrameXFirstValue = true;
                        CameraFrameXFirstValue = 110f;
                        if (interpolationValue < 1)
                        {
                            this.CameraFrame.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.CameraFrame.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        setCameraFrameYFirstValue = true;
                        CameraFrameYFirstValue = 83f;
                        if (interpolationValue < 1)
                        {
                            this.CameraFrame.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.CameraFrame.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ChildrenLayout = Gum.Managers.ChildrenLayout.Regular;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ClipsChildren = false;
                        }
                        setFrameHeightFirstValue = true;
                        FrameHeightFirstValue = 6f;
                        if (interpolationValue < 1)
                        {
                            this.Frame.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        if (interpolationValue < 1)
                        {
                            SetProperty("Frame.SourceFile", "..\\maintileset.png");
                        }
                        if (interpolationValue < 1)
                        {
                            this.Frame.TextureAddress = Gum.Managers.TextureAddress.Custom;
                        }
                        setFrameTextureHeightFirstValue = true;
                        FrameTextureHeightFirstValue = 16;
                        setFrameTextureLeftFirstValue = true;
                        FrameTextureLeftFirstValue = 480;
                        setFrameTextureTopFirstValue = true;
                        FrameTextureTopFirstValue = 208;
                        setFrameTextureWidthFirstValue = true;
                        FrameTextureWidthFirstValue = 16;
                        setFrameWidthFirstValue = true;
                        FrameWidthFirstValue = 6f;
                        if (interpolationValue < 1)
                        {
                            this.Frame.WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        setFrameXFirstValue = true;
                        FrameXFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.Frame.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.Frame.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setFrameYFirstValue = true;
                        FrameYFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.Frame.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.Frame.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setHeightFirstValue = true;
                        HeightFirstValue = 200f;
                        if (interpolationValue < 1)
                        {
                            this.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        if (interpolationValue < 1)
                        {
                            SetProperty("minimapbackground.SourceFile", "components\\graphics\\minimapbackground.png");
                        }
                        setminimapbackgroundXFirstValue = true;
                        minimapbackgroundXFirstValue = 0f;
                        setminimapbackgroundYFirstValue = true;
                        minimapbackgroundYFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.Visible = true;
                        }
                        setWidthFirstValue = true;
                        WidthFirstValue = 200f;
                        if (interpolationValue < 1)
                        {
                            this.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        if (interpolationValue < 1)
                        {
                            this.WrapsChildren = false;
                        }
                        setXFirstValue = true;
                        XFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Right;
                        }
                        if (interpolationValue < 1)
                        {
                            this.XUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        setYFirstValue = true;
                        YFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Bottom;
                        }
                        if (interpolationValue < 1)
                        {
                            this.YUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        break;
                }
                switch(secondState)
                {
                    case  VariableState.Default:
                        setCameraFrameHeightSecondValue = true;
                        CameraFrameHeightSecondValue = 34f;
                        if (interpolationValue >= 1)
                        {
                            this.CameraFrame.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        if (interpolationValue >= 1)
                        {
                            SetProperty("CameraFrame.SourceFile", "..\\maintileset.png");
                        }
                        if (interpolationValue >= 1)
                        {
                            this.CameraFrame.TextureAddress = Gum.Managers.TextureAddress.Custom;
                        }
                        setCameraFrameTextureHeightSecondValue = true;
                        CameraFrameTextureHeightSecondValue = 16;
                        setCameraFrameTextureLeftSecondValue = true;
                        CameraFrameTextureLeftSecondValue = 480;
                        setCameraFrameTextureTopSecondValue = true;
                        CameraFrameTextureTopSecondValue = 192;
                        setCameraFrameTextureWidthSecondValue = true;
                        CameraFrameTextureWidthSecondValue = 16;
                        setCameraFrameWidthSecondValue = true;
                        CameraFrameWidthSecondValue = 49f;
                        if (interpolationValue >= 1)
                        {
                            this.CameraFrame.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        setCameraFrameXSecondValue = true;
                        CameraFrameXSecondValue = 110f;
                        if (interpolationValue >= 1)
                        {
                            this.CameraFrame.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.CameraFrame.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        setCameraFrameYSecondValue = true;
                        CameraFrameYSecondValue = 83f;
                        if (interpolationValue >= 1)
                        {
                            this.CameraFrame.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.CameraFrame.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ChildrenLayout = Gum.Managers.ChildrenLayout.Regular;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ClipsChildren = false;
                        }
                        setFrameHeightSecondValue = true;
                        FrameHeightSecondValue = 6f;
                        if (interpolationValue >= 1)
                        {
                            this.Frame.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        if (interpolationValue >= 1)
                        {
                            SetProperty("Frame.SourceFile", "..\\maintileset.png");
                        }
                        if (interpolationValue >= 1)
                        {
                            this.Frame.TextureAddress = Gum.Managers.TextureAddress.Custom;
                        }
                        setFrameTextureHeightSecondValue = true;
                        FrameTextureHeightSecondValue = 16;
                        setFrameTextureLeftSecondValue = true;
                        FrameTextureLeftSecondValue = 480;
                        setFrameTextureTopSecondValue = true;
                        FrameTextureTopSecondValue = 208;
                        setFrameTextureWidthSecondValue = true;
                        FrameTextureWidthSecondValue = 16;
                        setFrameWidthSecondValue = true;
                        FrameWidthSecondValue = 6f;
                        if (interpolationValue >= 1)
                        {
                            this.Frame.WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        setFrameXSecondValue = true;
                        FrameXSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.Frame.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.Frame.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setFrameYSecondValue = true;
                        FrameYSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.Frame.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.Frame.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setHeightSecondValue = true;
                        HeightSecondValue = 200f;
                        if (interpolationValue >= 1)
                        {
                            this.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        if (interpolationValue >= 1)
                        {
                            SetProperty("minimapbackground.SourceFile", "components\\graphics\\minimapbackground.png");
                        }
                        setminimapbackgroundXSecondValue = true;
                        minimapbackgroundXSecondValue = 0f;
                        setminimapbackgroundYSecondValue = true;
                        minimapbackgroundYSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.Visible = true;
                        }
                        setWidthSecondValue = true;
                        WidthSecondValue = 200f;
                        if (interpolationValue >= 1)
                        {
                            this.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.WrapsChildren = false;
                        }
                        setXSecondValue = true;
                        XSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Right;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.XUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        setYSecondValue = true;
                        YSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Bottom;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.YUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        break;
                }
                if (setCameraFrameHeightFirstValue && setCameraFrameHeightSecondValue)
                {
                    CameraFrame.Height = CameraFrameHeightFirstValue * (1 - interpolationValue) + CameraFrameHeightSecondValue * interpolationValue;
                }
                if (setCameraFrameTextureHeightFirstValue && setCameraFrameTextureHeightSecondValue)
                {
                    CameraFrame.TextureHeight = FlatRedBall.Math.MathFunctions.RoundToInt(CameraFrameTextureHeightFirstValue* (1 - interpolationValue) + CameraFrameTextureHeightSecondValue * interpolationValue);
                }
                if (setCameraFrameTextureLeftFirstValue && setCameraFrameTextureLeftSecondValue)
                {
                    CameraFrame.TextureLeft = FlatRedBall.Math.MathFunctions.RoundToInt(CameraFrameTextureLeftFirstValue* (1 - interpolationValue) + CameraFrameTextureLeftSecondValue * interpolationValue);
                }
                if (setCameraFrameTextureTopFirstValue && setCameraFrameTextureTopSecondValue)
                {
                    CameraFrame.TextureTop = FlatRedBall.Math.MathFunctions.RoundToInt(CameraFrameTextureTopFirstValue* (1 - interpolationValue) + CameraFrameTextureTopSecondValue * interpolationValue);
                }
                if (setCameraFrameTextureWidthFirstValue && setCameraFrameTextureWidthSecondValue)
                {
                    CameraFrame.TextureWidth = FlatRedBall.Math.MathFunctions.RoundToInt(CameraFrameTextureWidthFirstValue* (1 - interpolationValue) + CameraFrameTextureWidthSecondValue * interpolationValue);
                }
                if (setCameraFrameWidthFirstValue && setCameraFrameWidthSecondValue)
                {
                    CameraFrame.Width = CameraFrameWidthFirstValue * (1 - interpolationValue) + CameraFrameWidthSecondValue * interpolationValue;
                }
                if (setCameraFrameXFirstValue && setCameraFrameXSecondValue)
                {
                    CameraFrame.X = CameraFrameXFirstValue * (1 - interpolationValue) + CameraFrameXSecondValue * interpolationValue;
                }
                if (setCameraFrameYFirstValue && setCameraFrameYSecondValue)
                {
                    CameraFrame.Y = CameraFrameYFirstValue * (1 - interpolationValue) + CameraFrameYSecondValue * interpolationValue;
                }
                if (setFrameHeightFirstValue && setFrameHeightSecondValue)
                {
                    Frame.Height = FrameHeightFirstValue * (1 - interpolationValue) + FrameHeightSecondValue * interpolationValue;
                }
                if (setFrameTextureHeightFirstValue && setFrameTextureHeightSecondValue)
                {
                    Frame.TextureHeight = FlatRedBall.Math.MathFunctions.RoundToInt(FrameTextureHeightFirstValue* (1 - interpolationValue) + FrameTextureHeightSecondValue * interpolationValue);
                }
                if (setFrameTextureLeftFirstValue && setFrameTextureLeftSecondValue)
                {
                    Frame.TextureLeft = FlatRedBall.Math.MathFunctions.RoundToInt(FrameTextureLeftFirstValue* (1 - interpolationValue) + FrameTextureLeftSecondValue * interpolationValue);
                }
                if (setFrameTextureTopFirstValue && setFrameTextureTopSecondValue)
                {
                    Frame.TextureTop = FlatRedBall.Math.MathFunctions.RoundToInt(FrameTextureTopFirstValue* (1 - interpolationValue) + FrameTextureTopSecondValue * interpolationValue);
                }
                if (setFrameTextureWidthFirstValue && setFrameTextureWidthSecondValue)
                {
                    Frame.TextureWidth = FlatRedBall.Math.MathFunctions.RoundToInt(FrameTextureWidthFirstValue* (1 - interpolationValue) + FrameTextureWidthSecondValue * interpolationValue);
                }
                if (setFrameWidthFirstValue && setFrameWidthSecondValue)
                {
                    Frame.Width = FrameWidthFirstValue * (1 - interpolationValue) + FrameWidthSecondValue * interpolationValue;
                }
                if (setFrameXFirstValue && setFrameXSecondValue)
                {
                    Frame.X = FrameXFirstValue * (1 - interpolationValue) + FrameXSecondValue * interpolationValue;
                }
                if (setFrameYFirstValue && setFrameYSecondValue)
                {
                    Frame.Y = FrameYFirstValue * (1 - interpolationValue) + FrameYSecondValue * interpolationValue;
                }
                if (setHeightFirstValue && setHeightSecondValue)
                {
                    Height = HeightFirstValue * (1 - interpolationValue) + HeightSecondValue * interpolationValue;
                }
                if (setminimapbackgroundXFirstValue && setminimapbackgroundXSecondValue)
                {
                    minimapbackground.X = minimapbackgroundXFirstValue * (1 - interpolationValue) + minimapbackgroundXSecondValue * interpolationValue;
                }
                if (setminimapbackgroundYFirstValue && setminimapbackgroundYSecondValue)
                {
                    minimapbackground.Y = minimapbackgroundYFirstValue * (1 - interpolationValue) + minimapbackgroundYSecondValue * interpolationValue;
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
            public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateTo (TownRaiserImGui.GumRuntimes.MinimapContentsRuntime.VariableState fromState,TownRaiserImGui.GumRuntimes.MinimapContentsRuntime.VariableState toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null) 
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
                            Name = "minimapbackground.SourceFile",
                            Type = "string",
                            Value = minimapbackground.SourceFile
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "minimapbackground.X",
                            Type = "float",
                            Value = minimapbackground.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "minimapbackground.Y",
                            Type = "float",
                            Value = minimapbackground.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Frame.Height",
                            Type = "float",
                            Value = Frame.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Frame.Height Units",
                            Type = "DimensionUnitType",
                            Value = Frame.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Frame.SourceFile",
                            Type = "string",
                            Value = Frame.SourceFile
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Frame.Texture Address",
                            Type = "TextureAddress",
                            Value = Frame.TextureAddress
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Frame.Texture Height",
                            Type = "int",
                            Value = Frame.TextureHeight
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Frame.Texture Left",
                            Type = "int",
                            Value = Frame.TextureLeft
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Frame.Texture Top",
                            Type = "int",
                            Value = Frame.TextureTop
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Frame.Texture Width",
                            Type = "int",
                            Value = Frame.TextureWidth
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Frame.Width",
                            Type = "float",
                            Value = Frame.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Frame.Width Units",
                            Type = "DimensionUnitType",
                            Value = Frame.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Frame.X",
                            Type = "float",
                            Value = Frame.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Frame.X Origin",
                            Type = "HorizontalAlignment",
                            Value = Frame.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Frame.X Units",
                            Type = "PositionUnitType",
                            Value = Frame.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Frame.Y",
                            Type = "float",
                            Value = Frame.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Frame.Y Origin",
                            Type = "VerticalAlignment",
                            Value = Frame.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Frame.Y Units",
                            Type = "PositionUnitType",
                            Value = Frame.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CameraFrame.Height",
                            Type = "float",
                            Value = CameraFrame.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CameraFrame.Height Units",
                            Type = "DimensionUnitType",
                            Value = CameraFrame.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CameraFrame.SourceFile",
                            Type = "string",
                            Value = CameraFrame.SourceFile
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CameraFrame.Texture Address",
                            Type = "TextureAddress",
                            Value = CameraFrame.TextureAddress
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CameraFrame.Texture Height",
                            Type = "int",
                            Value = CameraFrame.TextureHeight
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CameraFrame.Texture Left",
                            Type = "int",
                            Value = CameraFrame.TextureLeft
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CameraFrame.Texture Top",
                            Type = "int",
                            Value = CameraFrame.TextureTop
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CameraFrame.Texture Width",
                            Type = "int",
                            Value = CameraFrame.TextureWidth
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CameraFrame.Width",
                            Type = "float",
                            Value = CameraFrame.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CameraFrame.Width Units",
                            Type = "DimensionUnitType",
                            Value = CameraFrame.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CameraFrame.X",
                            Type = "float",
                            Value = CameraFrame.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CameraFrame.X Origin",
                            Type = "HorizontalAlignment",
                            Value = CameraFrame.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CameraFrame.X Units",
                            Type = "PositionUnitType",
                            Value = CameraFrame.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CameraFrame.Y",
                            Type = "float",
                            Value = CameraFrame.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CameraFrame.Y Origin",
                            Type = "VerticalAlignment",
                            Value = CameraFrame.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CameraFrame.Y Units",
                            Type = "PositionUnitType",
                            Value = CameraFrame.YUnits
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
                            Value = Height + 200f
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
                            Value = Width + 200f
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
                            Value = X + 0f
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
                            Name = "minimapbackground.SourceFile",
                            Type = "string",
                            Value = minimapbackground.SourceFile
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "minimapbackground.X",
                            Type = "float",
                            Value = minimapbackground.X + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "minimapbackground.Y",
                            Type = "float",
                            Value = minimapbackground.Y + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Frame.Height",
                            Type = "float",
                            Value = Frame.Height + 6f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Frame.Height Units",
                            Type = "DimensionUnitType",
                            Value = Frame.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Frame.SourceFile",
                            Type = "string",
                            Value = Frame.SourceFile
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Frame.Texture Address",
                            Type = "TextureAddress",
                            Value = Frame.TextureAddress
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Frame.Texture Height",
                            Type = "int",
                            Value = Frame.TextureHeight + 16
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Frame.Texture Left",
                            Type = "int",
                            Value = Frame.TextureLeft + 480
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Frame.Texture Top",
                            Type = "int",
                            Value = Frame.TextureTop + 208
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Frame.Texture Width",
                            Type = "int",
                            Value = Frame.TextureWidth + 16
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Frame.Width",
                            Type = "float",
                            Value = Frame.Width + 6f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Frame.Width Units",
                            Type = "DimensionUnitType",
                            Value = Frame.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Frame.X",
                            Type = "float",
                            Value = Frame.X + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Frame.X Origin",
                            Type = "HorizontalAlignment",
                            Value = Frame.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Frame.X Units",
                            Type = "PositionUnitType",
                            Value = Frame.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Frame.Y",
                            Type = "float",
                            Value = Frame.Y + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Frame.Y Origin",
                            Type = "VerticalAlignment",
                            Value = Frame.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Frame.Y Units",
                            Type = "PositionUnitType",
                            Value = Frame.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CameraFrame.Height",
                            Type = "float",
                            Value = CameraFrame.Height + 34f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CameraFrame.Height Units",
                            Type = "DimensionUnitType",
                            Value = CameraFrame.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CameraFrame.SourceFile",
                            Type = "string",
                            Value = CameraFrame.SourceFile
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CameraFrame.Texture Address",
                            Type = "TextureAddress",
                            Value = CameraFrame.TextureAddress
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CameraFrame.Texture Height",
                            Type = "int",
                            Value = CameraFrame.TextureHeight + 16
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CameraFrame.Texture Left",
                            Type = "int",
                            Value = CameraFrame.TextureLeft + 480
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CameraFrame.Texture Top",
                            Type = "int",
                            Value = CameraFrame.TextureTop + 192
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CameraFrame.Texture Width",
                            Type = "int",
                            Value = CameraFrame.TextureWidth + 16
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CameraFrame.Width",
                            Type = "float",
                            Value = CameraFrame.Width + 49f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CameraFrame.Width Units",
                            Type = "DimensionUnitType",
                            Value = CameraFrame.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CameraFrame.X",
                            Type = "float",
                            Value = CameraFrame.X + 110f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CameraFrame.X Origin",
                            Type = "HorizontalAlignment",
                            Value = CameraFrame.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CameraFrame.X Units",
                            Type = "PositionUnitType",
                            Value = CameraFrame.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CameraFrame.Y",
                            Type = "float",
                            Value = CameraFrame.Y + 83f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CameraFrame.Y Origin",
                            Type = "VerticalAlignment",
                            Value = CameraFrame.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "CameraFrame.Y Units",
                            Type = "PositionUnitType",
                            Value = CameraFrame.YUnits
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
            private TownRaiserImGui.GumRuntimes.SpriteRuntime minimapbackground { get; set; }
            private TownRaiserImGui.GumRuntimes.NineSliceRuntime Frame { get; set; }
            private TownRaiserImGui.GumRuntimes.NineSliceRuntime CameraFrame { get; set; }
            public MinimapContentsRuntime (bool fullInstantiation = true, bool tryCreateFormsObject = true) 
            	: base(false, tryCreateFormsObject)
            {
                this.HasEvents = true;
                this.ExposeChildrenEvents = true;
                if (fullInstantiation)
                {
                    Gum.DataTypes.ElementSave elementSave = Gum.Managers.ObjectFinder.Self.GumProjectSave.Components.First(item => item.Name == "MinimapContents");
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
                minimapbackground = this.GetGraphicalUiElementByName("minimapbackground") as TownRaiserImGui.GumRuntimes.SpriteRuntime;
                Frame = this.GetGraphicalUiElementByName("Frame") as TownRaiserImGui.GumRuntimes.NineSliceRuntime;
                CameraFrame = this.GetGraphicalUiElementByName("CameraFrame") as TownRaiserImGui.GumRuntimes.NineSliceRuntime;
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
