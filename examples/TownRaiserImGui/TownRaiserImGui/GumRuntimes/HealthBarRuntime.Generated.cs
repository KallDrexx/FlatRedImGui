    using System.Linq;
    namespace TownRaiserImGui.GumRuntimes
    {
        public partial class HealthBarRuntime : TownRaiserImGui.GumRuntimes.ContainerRuntime
        {
            #region State Enums
            public enum VariableState
            {
                Default
            }
            public enum HealthStatus
            {
                TwoThird,
                Full,
                OneThird
            }
            #endregion
            #region State Fields
            VariableState mCurrentVariableState;
            HealthStatus? mCurrentHealthStatusState;
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
                            FillBar.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "FillBarContainer") ?? this;
                            ChildrenLayout = Gum.Managers.ChildrenLayout.Regular;
                            ClipsChildren = false;
                            Height = 3f;
                            HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                            Visible = true;
                            Width = 12f;
                            WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                            WrapsChildren = false;
                            XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                            XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                            YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                            YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                            NineSliceInstance.Height = 0f;
                            NineSliceInstance.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                            SetProperty("NineSliceInstance.SourceFile", "..\\MainTileset.png");
                            NineSliceInstance.TextureAddress = Gum.Managers.TextureAddress.Custom;
                            NineSliceInstance.TextureHeight = 4;
                            NineSliceInstance.TextureLeft = 374;
                            NineSliceInstance.TextureTop = 0;
                            NineSliceInstance.TextureWidth = 26;
                            NineSliceInstance.Width = 0f;
                            NineSliceInstance.WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                            NineSliceInstance.X = 0f;
                            NineSliceInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                            NineSliceInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            NineSliceInstance.Y = 0f;
                            NineSliceInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                            NineSliceInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            FillBarContainer.Height = -2f;
                            FillBarContainer.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                            FillBarContainer.Width = -2f;
                            FillBarContainer.WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                            FillBarContainer.X = 0f;
                            FillBarContainer.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                            FillBarContainer.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            FillBarContainer.Y = 0f;
                            FillBarContainer.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                            FillBarContainer.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            FillBar.Animate = true;
                            FillBar.Height = 0f;
                            FillBar.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                            SetProperty("FillBar.SourceFile", "..\\MainTileset.png");
                            FillBar.TextureAddress = Gum.Managers.TextureAddress.Custom;
                            FillBar.TextureHeight = 2;
                            FillBar.TextureLeft = 374;
                            FillBar.TextureTop = 4;
                            FillBar.TextureWidth = 24;
                            FillBar.Width = 50f;
                            FillBar.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                            FillBar.X = 0f;
                            FillBar.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                            FillBar.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                            FillBar.Y = 0f;
                            FillBar.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                            FillBar.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            break;
                    }
                }
            }
            public HealthStatus? CurrentHealthStatusState
            {
                get
                {
                    return mCurrentHealthStatusState;
                }
                set
                {
                    if (value != null)
                    {
                        mCurrentHealthStatusState = value;
                        switch(mCurrentHealthStatusState)
                        {
                            case  HealthStatus.TwoThird:
                                FillBar.TextureTop = 6;
                                break;
                            case  HealthStatus.Full:
                                FillBar.TextureTop = 4;
                                break;
                            case  HealthStatus.OneThird:
                                FillBar.TextureTop = 8;
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
                bool setFillBarHeightFirstValue = false;
                bool setFillBarHeightSecondValue = false;
                float FillBarHeightFirstValue= 0;
                float FillBarHeightSecondValue= 0;
                bool setFillBarTextureHeightFirstValue = false;
                bool setFillBarTextureHeightSecondValue = false;
                int FillBarTextureHeightFirstValue= 0;
                int FillBarTextureHeightSecondValue= 0;
                bool setFillBarTextureLeftFirstValue = false;
                bool setFillBarTextureLeftSecondValue = false;
                int FillBarTextureLeftFirstValue= 0;
                int FillBarTextureLeftSecondValue= 0;
                bool setFillBarTextureTopFirstValue = false;
                bool setFillBarTextureTopSecondValue = false;
                int FillBarTextureTopFirstValue= 0;
                int FillBarTextureTopSecondValue= 0;
                bool setFillBarTextureWidthFirstValue = false;
                bool setFillBarTextureWidthSecondValue = false;
                int FillBarTextureWidthFirstValue= 0;
                int FillBarTextureWidthSecondValue= 0;
                bool setFillBarWidthFirstValue = false;
                bool setFillBarWidthSecondValue = false;
                float FillBarWidthFirstValue= 0;
                float FillBarWidthSecondValue= 0;
                bool setFillBarXFirstValue = false;
                bool setFillBarXSecondValue = false;
                float FillBarXFirstValue= 0;
                float FillBarXSecondValue= 0;
                bool setFillBarYFirstValue = false;
                bool setFillBarYSecondValue = false;
                float FillBarYFirstValue= 0;
                float FillBarYSecondValue= 0;
                bool setFillBarContainerHeightFirstValue = false;
                bool setFillBarContainerHeightSecondValue = false;
                float FillBarContainerHeightFirstValue= 0;
                float FillBarContainerHeightSecondValue= 0;
                bool setFillBarContainerWidthFirstValue = false;
                bool setFillBarContainerWidthSecondValue = false;
                float FillBarContainerWidthFirstValue= 0;
                float FillBarContainerWidthSecondValue= 0;
                bool setFillBarContainerXFirstValue = false;
                bool setFillBarContainerXSecondValue = false;
                float FillBarContainerXFirstValue= 0;
                float FillBarContainerXSecondValue= 0;
                bool setFillBarContainerYFirstValue = false;
                bool setFillBarContainerYSecondValue = false;
                float FillBarContainerYFirstValue= 0;
                float FillBarContainerYSecondValue= 0;
                bool setHeightFirstValue = false;
                bool setHeightSecondValue = false;
                float HeightFirstValue= 0;
                float HeightSecondValue= 0;
                bool setNineSliceInstanceHeightFirstValue = false;
                bool setNineSliceInstanceHeightSecondValue = false;
                float NineSliceInstanceHeightFirstValue= 0;
                float NineSliceInstanceHeightSecondValue= 0;
                bool setNineSliceInstanceTextureHeightFirstValue = false;
                bool setNineSliceInstanceTextureHeightSecondValue = false;
                int NineSliceInstanceTextureHeightFirstValue= 0;
                int NineSliceInstanceTextureHeightSecondValue= 0;
                bool setNineSliceInstanceTextureLeftFirstValue = false;
                bool setNineSliceInstanceTextureLeftSecondValue = false;
                int NineSliceInstanceTextureLeftFirstValue= 0;
                int NineSliceInstanceTextureLeftSecondValue= 0;
                bool setNineSliceInstanceTextureTopFirstValue = false;
                bool setNineSliceInstanceTextureTopSecondValue = false;
                int NineSliceInstanceTextureTopFirstValue= 0;
                int NineSliceInstanceTextureTopSecondValue= 0;
                bool setNineSliceInstanceTextureWidthFirstValue = false;
                bool setNineSliceInstanceTextureWidthSecondValue = false;
                int NineSliceInstanceTextureWidthFirstValue= 0;
                int NineSliceInstanceTextureWidthSecondValue= 0;
                bool setNineSliceInstanceWidthFirstValue = false;
                bool setNineSliceInstanceWidthSecondValue = false;
                float NineSliceInstanceWidthFirstValue= 0;
                float NineSliceInstanceWidthSecondValue= 0;
                bool setNineSliceInstanceXFirstValue = false;
                bool setNineSliceInstanceXSecondValue = false;
                float NineSliceInstanceXFirstValue= 0;
                float NineSliceInstanceXSecondValue= 0;
                bool setNineSliceInstanceYFirstValue = false;
                bool setNineSliceInstanceYSecondValue = false;
                float NineSliceInstanceYFirstValue= 0;
                float NineSliceInstanceYSecondValue= 0;
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
                        if (interpolationValue < 1)
                        {
                            this.FillBar.Animate = true;
                        }
                        setFillBarHeightFirstValue = true;
                        FillBarHeightFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.FillBar.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        if (interpolationValue < 1)
                        {
                            this.FillBar.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "FillBarContainer") ?? this;
                        }
                        if (interpolationValue < 1)
                        {
                            SetProperty("FillBar.SourceFile", "..\\MainTileset.png");
                        }
                        if (interpolationValue < 1)
                        {
                            this.FillBar.TextureAddress = Gum.Managers.TextureAddress.Custom;
                        }
                        setFillBarTextureHeightFirstValue = true;
                        FillBarTextureHeightFirstValue = 2;
                        setFillBarTextureLeftFirstValue = true;
                        FillBarTextureLeftFirstValue = 374;
                        setFillBarTextureTopFirstValue = true;
                        FillBarTextureTopFirstValue = 4;
                        setFillBarTextureWidthFirstValue = true;
                        FillBarTextureWidthFirstValue = 24;
                        setFillBarWidthFirstValue = true;
                        FillBarWidthFirstValue = 50f;
                        if (interpolationValue < 1)
                        {
                            this.FillBar.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        setFillBarXFirstValue = true;
                        FillBarXFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.FillBar.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        if (interpolationValue < 1)
                        {
                            this.FillBar.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        setFillBarYFirstValue = true;
                        FillBarYFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.FillBar.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.FillBar.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setFillBarContainerHeightFirstValue = true;
                        FillBarContainerHeightFirstValue = -2f;
                        if (interpolationValue < 1)
                        {
                            this.FillBarContainer.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        setFillBarContainerWidthFirstValue = true;
                        FillBarContainerWidthFirstValue = -2f;
                        if (interpolationValue < 1)
                        {
                            this.FillBarContainer.WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        setFillBarContainerXFirstValue = true;
                        FillBarContainerXFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.FillBarContainer.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.FillBarContainer.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setFillBarContainerYFirstValue = true;
                        FillBarContainerYFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.FillBarContainer.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.FillBarContainer.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setHeightFirstValue = true;
                        HeightFirstValue = 3f;
                        if (interpolationValue < 1)
                        {
                            this.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        setNineSliceInstanceHeightFirstValue = true;
                        NineSliceInstanceHeightFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.NineSliceInstance.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        if (interpolationValue < 1)
                        {
                            SetProperty("NineSliceInstance.SourceFile", "..\\MainTileset.png");
                        }
                        if (interpolationValue < 1)
                        {
                            this.NineSliceInstance.TextureAddress = Gum.Managers.TextureAddress.Custom;
                        }
                        setNineSliceInstanceTextureHeightFirstValue = true;
                        NineSliceInstanceTextureHeightFirstValue = 4;
                        setNineSliceInstanceTextureLeftFirstValue = true;
                        NineSliceInstanceTextureLeftFirstValue = 374;
                        setNineSliceInstanceTextureTopFirstValue = true;
                        NineSliceInstanceTextureTopFirstValue = 0;
                        setNineSliceInstanceTextureWidthFirstValue = true;
                        NineSliceInstanceTextureWidthFirstValue = 26;
                        setNineSliceInstanceWidthFirstValue = true;
                        NineSliceInstanceWidthFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.NineSliceInstance.WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        setNineSliceInstanceXFirstValue = true;
                        NineSliceInstanceXFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.NineSliceInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.NineSliceInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setNineSliceInstanceYFirstValue = true;
                        NineSliceInstanceYFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.NineSliceInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.NineSliceInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        if (interpolationValue < 1)
                        {
                            this.Visible = true;
                        }
                        setWidthFirstValue = true;
                        WidthFirstValue = 12f;
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
                        if (interpolationValue >= 1)
                        {
                            this.FillBar.Animate = true;
                        }
                        setFillBarHeightSecondValue = true;
                        FillBarHeightSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.FillBar.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.FillBar.Parent = this.ContainedElements.FirstOrDefault(item =>item.Name == "FillBarContainer") ?? this;
                        }
                        if (interpolationValue >= 1)
                        {
                            SetProperty("FillBar.SourceFile", "..\\MainTileset.png");
                        }
                        if (interpolationValue >= 1)
                        {
                            this.FillBar.TextureAddress = Gum.Managers.TextureAddress.Custom;
                        }
                        setFillBarTextureHeightSecondValue = true;
                        FillBarTextureHeightSecondValue = 2;
                        setFillBarTextureLeftSecondValue = true;
                        FillBarTextureLeftSecondValue = 374;
                        setFillBarTextureTopSecondValue = true;
                        FillBarTextureTopSecondValue = 4;
                        setFillBarTextureWidthSecondValue = true;
                        FillBarTextureWidthSecondValue = 24;
                        setFillBarWidthSecondValue = true;
                        FillBarWidthSecondValue = 50f;
                        if (interpolationValue >= 1)
                        {
                            this.FillBar.WidthUnits = Gum.DataTypes.DimensionUnitType.Percentage;
                        }
                        setFillBarXSecondValue = true;
                        FillBarXSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.FillBar.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.FillBar.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        setFillBarYSecondValue = true;
                        FillBarYSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.FillBar.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.FillBar.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setFillBarContainerHeightSecondValue = true;
                        FillBarContainerHeightSecondValue = -2f;
                        if (interpolationValue >= 1)
                        {
                            this.FillBarContainer.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        setFillBarContainerWidthSecondValue = true;
                        FillBarContainerWidthSecondValue = -2f;
                        if (interpolationValue >= 1)
                        {
                            this.FillBarContainer.WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        setFillBarContainerXSecondValue = true;
                        FillBarContainerXSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.FillBarContainer.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.FillBarContainer.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setFillBarContainerYSecondValue = true;
                        FillBarContainerYSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.FillBarContainer.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.FillBarContainer.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setHeightSecondValue = true;
                        HeightSecondValue = 3f;
                        if (interpolationValue >= 1)
                        {
                            this.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        setNineSliceInstanceHeightSecondValue = true;
                        NineSliceInstanceHeightSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.NineSliceInstance.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        if (interpolationValue >= 1)
                        {
                            SetProperty("NineSliceInstance.SourceFile", "..\\MainTileset.png");
                        }
                        if (interpolationValue >= 1)
                        {
                            this.NineSliceInstance.TextureAddress = Gum.Managers.TextureAddress.Custom;
                        }
                        setNineSliceInstanceTextureHeightSecondValue = true;
                        NineSliceInstanceTextureHeightSecondValue = 4;
                        setNineSliceInstanceTextureLeftSecondValue = true;
                        NineSliceInstanceTextureLeftSecondValue = 374;
                        setNineSliceInstanceTextureTopSecondValue = true;
                        NineSliceInstanceTextureTopSecondValue = 0;
                        setNineSliceInstanceTextureWidthSecondValue = true;
                        NineSliceInstanceTextureWidthSecondValue = 26;
                        setNineSliceInstanceWidthSecondValue = true;
                        NineSliceInstanceWidthSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.NineSliceInstance.WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        setNineSliceInstanceXSecondValue = true;
                        NineSliceInstanceXSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.NineSliceInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.NineSliceInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setNineSliceInstanceYSecondValue = true;
                        NineSliceInstanceYSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.NineSliceInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.NineSliceInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.Visible = true;
                        }
                        setWidthSecondValue = true;
                        WidthSecondValue = 12f;
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
                if (setFillBarHeightFirstValue && setFillBarHeightSecondValue)
                {
                    FillBar.Height = FillBarHeightFirstValue * (1 - interpolationValue) + FillBarHeightSecondValue * interpolationValue;
                }
                if (setFillBarTextureHeightFirstValue && setFillBarTextureHeightSecondValue)
                {
                    FillBar.TextureHeight = FlatRedBall.Math.MathFunctions.RoundToInt(FillBarTextureHeightFirstValue* (1 - interpolationValue) + FillBarTextureHeightSecondValue * interpolationValue);
                }
                if (setFillBarTextureLeftFirstValue && setFillBarTextureLeftSecondValue)
                {
                    FillBar.TextureLeft = FlatRedBall.Math.MathFunctions.RoundToInt(FillBarTextureLeftFirstValue* (1 - interpolationValue) + FillBarTextureLeftSecondValue * interpolationValue);
                }
                if (setFillBarTextureTopFirstValue && setFillBarTextureTopSecondValue)
                {
                    FillBar.TextureTop = FlatRedBall.Math.MathFunctions.RoundToInt(FillBarTextureTopFirstValue* (1 - interpolationValue) + FillBarTextureTopSecondValue * interpolationValue);
                }
                if (setFillBarTextureWidthFirstValue && setFillBarTextureWidthSecondValue)
                {
                    FillBar.TextureWidth = FlatRedBall.Math.MathFunctions.RoundToInt(FillBarTextureWidthFirstValue* (1 - interpolationValue) + FillBarTextureWidthSecondValue * interpolationValue);
                }
                if (setFillBarWidthFirstValue && setFillBarWidthSecondValue)
                {
                    FillBar.Width = FillBarWidthFirstValue * (1 - interpolationValue) + FillBarWidthSecondValue * interpolationValue;
                }
                if (setFillBarXFirstValue && setFillBarXSecondValue)
                {
                    FillBar.X = FillBarXFirstValue * (1 - interpolationValue) + FillBarXSecondValue * interpolationValue;
                }
                if (setFillBarYFirstValue && setFillBarYSecondValue)
                {
                    FillBar.Y = FillBarYFirstValue * (1 - interpolationValue) + FillBarYSecondValue * interpolationValue;
                }
                if (setFillBarContainerHeightFirstValue && setFillBarContainerHeightSecondValue)
                {
                    FillBarContainer.Height = FillBarContainerHeightFirstValue * (1 - interpolationValue) + FillBarContainerHeightSecondValue * interpolationValue;
                }
                if (setFillBarContainerWidthFirstValue && setFillBarContainerWidthSecondValue)
                {
                    FillBarContainer.Width = FillBarContainerWidthFirstValue * (1 - interpolationValue) + FillBarContainerWidthSecondValue * interpolationValue;
                }
                if (setFillBarContainerXFirstValue && setFillBarContainerXSecondValue)
                {
                    FillBarContainer.X = FillBarContainerXFirstValue * (1 - interpolationValue) + FillBarContainerXSecondValue * interpolationValue;
                }
                if (setFillBarContainerYFirstValue && setFillBarContainerYSecondValue)
                {
                    FillBarContainer.Y = FillBarContainerYFirstValue * (1 - interpolationValue) + FillBarContainerYSecondValue * interpolationValue;
                }
                if (setHeightFirstValue && setHeightSecondValue)
                {
                    Height = HeightFirstValue * (1 - interpolationValue) + HeightSecondValue * interpolationValue;
                }
                if (setNineSliceInstanceHeightFirstValue && setNineSliceInstanceHeightSecondValue)
                {
                    NineSliceInstance.Height = NineSliceInstanceHeightFirstValue * (1 - interpolationValue) + NineSliceInstanceHeightSecondValue * interpolationValue;
                }
                if (setNineSliceInstanceTextureHeightFirstValue && setNineSliceInstanceTextureHeightSecondValue)
                {
                    NineSliceInstance.TextureHeight = FlatRedBall.Math.MathFunctions.RoundToInt(NineSliceInstanceTextureHeightFirstValue* (1 - interpolationValue) + NineSliceInstanceTextureHeightSecondValue * interpolationValue);
                }
                if (setNineSliceInstanceTextureLeftFirstValue && setNineSliceInstanceTextureLeftSecondValue)
                {
                    NineSliceInstance.TextureLeft = FlatRedBall.Math.MathFunctions.RoundToInt(NineSliceInstanceTextureLeftFirstValue* (1 - interpolationValue) + NineSliceInstanceTextureLeftSecondValue * interpolationValue);
                }
                if (setNineSliceInstanceTextureTopFirstValue && setNineSliceInstanceTextureTopSecondValue)
                {
                    NineSliceInstance.TextureTop = FlatRedBall.Math.MathFunctions.RoundToInt(NineSliceInstanceTextureTopFirstValue* (1 - interpolationValue) + NineSliceInstanceTextureTopSecondValue * interpolationValue);
                }
                if (setNineSliceInstanceTextureWidthFirstValue && setNineSliceInstanceTextureWidthSecondValue)
                {
                    NineSliceInstance.TextureWidth = FlatRedBall.Math.MathFunctions.RoundToInt(NineSliceInstanceTextureWidthFirstValue* (1 - interpolationValue) + NineSliceInstanceTextureWidthSecondValue * interpolationValue);
                }
                if (setNineSliceInstanceWidthFirstValue && setNineSliceInstanceWidthSecondValue)
                {
                    NineSliceInstance.Width = NineSliceInstanceWidthFirstValue * (1 - interpolationValue) + NineSliceInstanceWidthSecondValue * interpolationValue;
                }
                if (setNineSliceInstanceXFirstValue && setNineSliceInstanceXSecondValue)
                {
                    NineSliceInstance.X = NineSliceInstanceXFirstValue * (1 - interpolationValue) + NineSliceInstanceXSecondValue * interpolationValue;
                }
                if (setNineSliceInstanceYFirstValue && setNineSliceInstanceYSecondValue)
                {
                    NineSliceInstance.Y = NineSliceInstanceYFirstValue * (1 - interpolationValue) + NineSliceInstanceYSecondValue * interpolationValue;
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
            public void InterpolateBetween (HealthStatus firstState, HealthStatus secondState, float interpolationValue) 
            {
                #if DEBUG
                if (float.IsNaN(interpolationValue))
                {
                    throw new System.Exception("interpolationValue cannot be NaN");
                }
                #endif
                bool setFillBarTextureTopFirstValue = false;
                bool setFillBarTextureTopSecondValue = false;
                int FillBarTextureTopFirstValue= 0;
                int FillBarTextureTopSecondValue= 0;
                switch(firstState)
                {
                    case  HealthStatus.TwoThird:
                        setFillBarTextureTopFirstValue = true;
                        FillBarTextureTopFirstValue = 6;
                        break;
                    case  HealthStatus.Full:
                        setFillBarTextureTopFirstValue = true;
                        FillBarTextureTopFirstValue = 4;
                        break;
                    case  HealthStatus.OneThird:
                        setFillBarTextureTopFirstValue = true;
                        FillBarTextureTopFirstValue = 8;
                        break;
                }
                switch(secondState)
                {
                    case  HealthStatus.TwoThird:
                        setFillBarTextureTopSecondValue = true;
                        FillBarTextureTopSecondValue = 6;
                        break;
                    case  HealthStatus.Full:
                        setFillBarTextureTopSecondValue = true;
                        FillBarTextureTopSecondValue = 4;
                        break;
                    case  HealthStatus.OneThird:
                        setFillBarTextureTopSecondValue = true;
                        FillBarTextureTopSecondValue = 8;
                        break;
                }
                if (setFillBarTextureTopFirstValue && setFillBarTextureTopSecondValue)
                {
                    FillBar.TextureTop = FlatRedBall.Math.MathFunctions.RoundToInt(FillBarTextureTopFirstValue* (1 - interpolationValue) + FillBarTextureTopSecondValue * interpolationValue);
                }
                if (interpolationValue < 1)
                {
                    mCurrentHealthStatusState = firstState;
                }
                else
                {
                    mCurrentHealthStatusState = secondState;
                }
            }
            #endregion
            #region State Interpolate To
            public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateTo (TownRaiserImGui.GumRuntimes.HealthBarRuntime.VariableState fromState,TownRaiserImGui.GumRuntimes.HealthBarRuntime.VariableState toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null) 
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
            public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateTo (TownRaiserImGui.GumRuntimes.HealthBarRuntime.HealthStatus fromState,TownRaiserImGui.GumRuntimes.HealthBarRuntime.HealthStatus toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null) 
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
            public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateTo (HealthStatus toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null ) 
            {
                Gum.DataTypes.Variables.StateSave current = GetCurrentValuesOnState(toState);
                Gum.DataTypes.Variables.StateSave toAsStateSave = this.ElementSave.Categories.First(item => item.Name == "HealthStatus").States.First(item => item.Name == toState.ToString());
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
                tweener.Ended += ()=> this.CurrentHealthStatusState = toState;
                tweener.Start();
                StateInterpolationPlugin.TweenerManager.Self.Add(tweener);
                return tweener;
            }
            public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateToRelative (HealthStatus toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null ) 
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
                tweener.Ended += ()=> this.CurrentHealthStatusState = toState;
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
                            Name = "NineSliceInstance.Height",
                            Type = "float",
                            Value = NineSliceInstance.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "NineSliceInstance.Height Units",
                            Type = "DimensionUnitType",
                            Value = NineSliceInstance.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "NineSliceInstance.SourceFile",
                            Type = "string",
                            Value = NineSliceInstance.SourceFile
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "NineSliceInstance.Texture Address",
                            Type = "TextureAddress",
                            Value = NineSliceInstance.TextureAddress
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "NineSliceInstance.Texture Height",
                            Type = "int",
                            Value = NineSliceInstance.TextureHeight
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "NineSliceInstance.Texture Left",
                            Type = "int",
                            Value = NineSliceInstance.TextureLeft
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "NineSliceInstance.Texture Top",
                            Type = "int",
                            Value = NineSliceInstance.TextureTop
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "NineSliceInstance.Texture Width",
                            Type = "int",
                            Value = NineSliceInstance.TextureWidth
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "NineSliceInstance.Width",
                            Type = "float",
                            Value = NineSliceInstance.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "NineSliceInstance.Width Units",
                            Type = "DimensionUnitType",
                            Value = NineSliceInstance.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "NineSliceInstance.X",
                            Type = "float",
                            Value = NineSliceInstance.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "NineSliceInstance.X Origin",
                            Type = "HorizontalAlignment",
                            Value = NineSliceInstance.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "NineSliceInstance.X Units",
                            Type = "PositionUnitType",
                            Value = NineSliceInstance.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "NineSliceInstance.Y",
                            Type = "float",
                            Value = NineSliceInstance.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "NineSliceInstance.Y Origin",
                            Type = "VerticalAlignment",
                            Value = NineSliceInstance.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "NineSliceInstance.Y Units",
                            Type = "PositionUnitType",
                            Value = NineSliceInstance.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBarContainer.Height",
                            Type = "float",
                            Value = FillBarContainer.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBarContainer.Height Units",
                            Type = "DimensionUnitType",
                            Value = FillBarContainer.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBarContainer.Width",
                            Type = "float",
                            Value = FillBarContainer.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBarContainer.Width Units",
                            Type = "DimensionUnitType",
                            Value = FillBarContainer.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBarContainer.X",
                            Type = "float",
                            Value = FillBarContainer.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBarContainer.X Origin",
                            Type = "HorizontalAlignment",
                            Value = FillBarContainer.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBarContainer.X Units",
                            Type = "PositionUnitType",
                            Value = FillBarContainer.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBarContainer.Y",
                            Type = "float",
                            Value = FillBarContainer.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBarContainer.Y Origin",
                            Type = "VerticalAlignment",
                            Value = FillBarContainer.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBarContainer.Y Units",
                            Type = "PositionUnitType",
                            Value = FillBarContainer.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBar.Animate",
                            Type = "bool",
                            Value = FillBar.Animate
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBar.Height",
                            Type = "float",
                            Value = FillBar.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBar.Height Units",
                            Type = "DimensionUnitType",
                            Value = FillBar.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBar.Parent",
                            Type = "string",
                            Value = FillBar.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBar.SourceFile",
                            Type = "string",
                            Value = FillBar.SourceFile
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBar.Texture Address",
                            Type = "TextureAddress",
                            Value = FillBar.TextureAddress
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBar.Texture Height",
                            Type = "int",
                            Value = FillBar.TextureHeight
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBar.Texture Left",
                            Type = "int",
                            Value = FillBar.TextureLeft
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBar.Texture Top",
                            Type = "int",
                            Value = FillBar.TextureTop
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBar.Texture Width",
                            Type = "int",
                            Value = FillBar.TextureWidth
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBar.Width",
                            Type = "float",
                            Value = FillBar.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBar.Width Units",
                            Type = "DimensionUnitType",
                            Value = FillBar.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBar.X",
                            Type = "float",
                            Value = FillBar.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBar.X Origin",
                            Type = "HorizontalAlignment",
                            Value = FillBar.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBar.X Units",
                            Type = "PositionUnitType",
                            Value = FillBar.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBar.Y",
                            Type = "float",
                            Value = FillBar.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBar.Y Origin",
                            Type = "VerticalAlignment",
                            Value = FillBar.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBar.Y Units",
                            Type = "PositionUnitType",
                            Value = FillBar.YUnits
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
                            Value = Height + 3f
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
                            Value = Width + 12f
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
                            Name = "NineSliceInstance.Height",
                            Type = "float",
                            Value = NineSliceInstance.Height + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "NineSliceInstance.Height Units",
                            Type = "DimensionUnitType",
                            Value = NineSliceInstance.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "NineSliceInstance.SourceFile",
                            Type = "string",
                            Value = NineSliceInstance.SourceFile
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "NineSliceInstance.Texture Address",
                            Type = "TextureAddress",
                            Value = NineSliceInstance.TextureAddress
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "NineSliceInstance.Texture Height",
                            Type = "int",
                            Value = NineSliceInstance.TextureHeight + 4
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "NineSliceInstance.Texture Left",
                            Type = "int",
                            Value = NineSliceInstance.TextureLeft + 374
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "NineSliceInstance.Texture Top",
                            Type = "int",
                            Value = NineSliceInstance.TextureTop + 0
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "NineSliceInstance.Texture Width",
                            Type = "int",
                            Value = NineSliceInstance.TextureWidth + 26
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "NineSliceInstance.Width",
                            Type = "float",
                            Value = NineSliceInstance.Width + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "NineSliceInstance.Width Units",
                            Type = "DimensionUnitType",
                            Value = NineSliceInstance.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "NineSliceInstance.X",
                            Type = "float",
                            Value = NineSliceInstance.X + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "NineSliceInstance.X Origin",
                            Type = "HorizontalAlignment",
                            Value = NineSliceInstance.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "NineSliceInstance.X Units",
                            Type = "PositionUnitType",
                            Value = NineSliceInstance.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "NineSliceInstance.Y",
                            Type = "float",
                            Value = NineSliceInstance.Y + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "NineSliceInstance.Y Origin",
                            Type = "VerticalAlignment",
                            Value = NineSliceInstance.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "NineSliceInstance.Y Units",
                            Type = "PositionUnitType",
                            Value = NineSliceInstance.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBarContainer.Height",
                            Type = "float",
                            Value = FillBarContainer.Height + -2f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBarContainer.Height Units",
                            Type = "DimensionUnitType",
                            Value = FillBarContainer.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBarContainer.Width",
                            Type = "float",
                            Value = FillBarContainer.Width + -2f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBarContainer.Width Units",
                            Type = "DimensionUnitType",
                            Value = FillBarContainer.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBarContainer.X",
                            Type = "float",
                            Value = FillBarContainer.X + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBarContainer.X Origin",
                            Type = "HorizontalAlignment",
                            Value = FillBarContainer.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBarContainer.X Units",
                            Type = "PositionUnitType",
                            Value = FillBarContainer.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBarContainer.Y",
                            Type = "float",
                            Value = FillBarContainer.Y + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBarContainer.Y Origin",
                            Type = "VerticalAlignment",
                            Value = FillBarContainer.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBarContainer.Y Units",
                            Type = "PositionUnitType",
                            Value = FillBarContainer.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBar.Animate",
                            Type = "bool",
                            Value = FillBar.Animate
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBar.Height",
                            Type = "float",
                            Value = FillBar.Height + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBar.Height Units",
                            Type = "DimensionUnitType",
                            Value = FillBar.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBar.Parent",
                            Type = "string",
                            Value = FillBar.Parent
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBar.SourceFile",
                            Type = "string",
                            Value = FillBar.SourceFile
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBar.Texture Address",
                            Type = "TextureAddress",
                            Value = FillBar.TextureAddress
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBar.Texture Height",
                            Type = "int",
                            Value = FillBar.TextureHeight + 2
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBar.Texture Left",
                            Type = "int",
                            Value = FillBar.TextureLeft + 374
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBar.Texture Top",
                            Type = "int",
                            Value = FillBar.TextureTop + 4
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBar.Texture Width",
                            Type = "int",
                            Value = FillBar.TextureWidth + 24
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBar.Width",
                            Type = "float",
                            Value = FillBar.Width + 50f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBar.Width Units",
                            Type = "DimensionUnitType",
                            Value = FillBar.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBar.X",
                            Type = "float",
                            Value = FillBar.X + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBar.X Origin",
                            Type = "HorizontalAlignment",
                            Value = FillBar.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBar.X Units",
                            Type = "PositionUnitType",
                            Value = FillBar.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBar.Y",
                            Type = "float",
                            Value = FillBar.Y + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBar.Y Origin",
                            Type = "VerticalAlignment",
                            Value = FillBar.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBar.Y Units",
                            Type = "PositionUnitType",
                            Value = FillBar.YUnits
                        }
                        );
                        break;
                }
                return newState;
            }
            private Gum.DataTypes.Variables.StateSave GetCurrentValuesOnState (HealthStatus state) 
            {
                Gum.DataTypes.Variables.StateSave newState = new Gum.DataTypes.Variables.StateSave();
                switch(state)
                {
                    case  HealthStatus.TwoThird:
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBar.Texture Top",
                            Type = "int",
                            Value = FillBar.TextureTop
                        }
                        );
                        break;
                    case  HealthStatus.Full:
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBar.Texture Top",
                            Type = "int",
                            Value = FillBar.TextureTop
                        }
                        );
                        break;
                    case  HealthStatus.OneThird:
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBar.Texture Top",
                            Type = "int",
                            Value = FillBar.TextureTop
                        }
                        );
                        break;
                }
                return newState;
            }
            private Gum.DataTypes.Variables.StateSave AddToCurrentValuesWithState (HealthStatus state) 
            {
                Gum.DataTypes.Variables.StateSave newState = new Gum.DataTypes.Variables.StateSave();
                switch(state)
                {
                    case  HealthStatus.TwoThird:
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBar.Texture Top",
                            Type = "int",
                            Value = FillBar.TextureTop + 6
                        }
                        );
                        break;
                    case  HealthStatus.Full:
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBar.Texture Top",
                            Type = "int",
                            Value = FillBar.TextureTop + 4
                        }
                        );
                        break;
                    case  HealthStatus.OneThird:
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "FillBar.Texture Top",
                            Type = "int",
                            Value = FillBar.TextureTop + 8
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
                    else if (category.Name == "HealthStatus")
                    {
                        if(state.Name == "TwoThird") this.mCurrentHealthStatusState = HealthStatus.TwoThird;
                        if(state.Name == "Full") this.mCurrentHealthStatusState = HealthStatus.Full;
                        if(state.Name == "OneThird") this.mCurrentHealthStatusState = HealthStatus.OneThird;
                    }
                }
                base.ApplyState(state);
            }
            private TownRaiserImGui.GumRuntimes.NineSliceRuntime NineSliceInstance { get; set; }
            private TownRaiserImGui.GumRuntimes.ContainerRuntime FillBarContainer { get; set; }
            private TownRaiserImGui.GumRuntimes.SpriteRuntime FillBar { get; set; }
            public float HealthPercentage
            {
                get
                {
                    return FillBar.Width;
                }
                set
                {
                    if (FillBar.Width != value)
                    {
                        FillBar.Width = value;
                        HealthPercentageChanged?.Invoke(this, null);
                    }
                }
            }
            public event System.EventHandler HealthPercentageChanged;
            public HealthBarRuntime (bool fullInstantiation = true, bool tryCreateFormsObject = true) 
            	: base(false, tryCreateFormsObject)
            {
                this.HasEvents = false;
                this.ExposeChildrenEvents = true;
                if (fullInstantiation)
                {
                    Gum.DataTypes.ElementSave elementSave = Gum.Managers.ObjectFinder.Self.GumProjectSave.Components.First(item => item.Name == "HealthBar");
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
                NineSliceInstance = this.GetGraphicalUiElementByName("NineSliceInstance") as TownRaiserImGui.GumRuntimes.NineSliceRuntime;
                FillBarContainer = this.GetGraphicalUiElementByName("FillBarContainer") as TownRaiserImGui.GumRuntimes.ContainerRuntime;
                FillBar = this.GetGraphicalUiElementByName("FillBar") as TownRaiserImGui.GumRuntimes.SpriteRuntime;
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
