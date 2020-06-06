    using System.Linq;
    namespace TownRaiserImGui.GumRuntimes
    {
        public partial class ActionToolbarRuntime : TownRaiserImGui.GumRuntimes.ContainerRuntime
        {
            #region State Enums
            public enum VariableState
            {
                Default,
                SelectModeView,
                BuildMenuSelected,
                SelectedEntity,
                PlacingBuilding
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
                            Height = 8f;
                            HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToChildren;
                            Visible = true;
                            Width = 8f;
                            WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToChildren;
                            WrapsChildren = false;
                            X = -5f;
                            XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Right;
                            XUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                            Y = -5f;
                            YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Bottom;
                            YUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                            Background.Height = 0f;
                            Background.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                            SetProperty("Background.SourceFile", "..\\MainTileset.png");
                            Background.TextureAddress = Gum.Managers.TextureAddress.Custom;
                            Background.TextureHeight = 32;
                            Background.TextureLeft = 480;
                            Background.TextureTop = 0;
                            Background.TextureWidth = 32;
                            Background.Width = 0f;
                            Background.WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                            MenuTitleDisplayInstance.DisplayText = "Barracks";
                            MenuTitleDisplayInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                            MenuTitleDisplayInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            ResourceCostContainer.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                            ResourceCostContainer.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            ActionStackContainerInstance.X = 0f;
                            ActionStackContainerInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                            ActionStackContainerInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            ActionStackContainerInstance.Y = 47f;
                            ActionStackContainerInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                            SelectedBuilding.Height = 100f;
                            SelectedBuilding.Width = 100f;
                            break;
                        case  VariableState.SelectModeView:
                            Height = 32f;
                            HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                            Width = 32f;
                            WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                            Background.Visible = false;
                            BuildMenuButtonInstance.Visible = true;
                            BuildMenuButtonInstance.X = 0f;
                            BuildMenuButtonInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                            BuildMenuButtonInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                            BuildMenuButtonInstance.Y = 0f;
                            BuildMenuButtonInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                            BuildMenuButtonInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                            MenuTitleDisplayInstance.Visible = false;
                            MenuTitleDisplayInstance.X = 0f;
                            MenuTitleDisplayInstance.Y = 0f;
                            ResourceCostContainer.Visible = false;
                            ActionStackContainerInstance.Visible = false;
                            SelectedBuilding.Visible = false;
                            XButtonInstance.Visible = false;
                            break;
                        case  VariableState.BuildMenuSelected:
                            Height = 8f;
                            HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToChildren;
                            Width = 8f;
                            WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToChildren;
                            Background.Visible = true;
                            BuildMenuButtonInstance.Visible = false;
                            MenuTitleDisplayInstance.Height = 16f;
                            MenuTitleDisplayInstance.Visible = true;
                            MenuTitleDisplayInstance.Width = 130f;
                            MenuTitleDisplayInstance.X = 1f;
                            MenuTitleDisplayInstance.Y = 8f;
                            ResourceCostContainer.Visible = true;
                            ResourceCostContainer.X = 1f;
                            ResourceCostContainer.Y = 28f;
                            ActionStackContainerInstance.Visible = true;
                            SelectedBuilding.Visible = false;
                            XButtonInstance.Visible = true;
                            XButtonInstance.X = -2f;
                            XButtonInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                            XButtonInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                            XButtonInstance.Y = 2f;
                            XButtonInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                            XButtonInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                            break;
                        case  VariableState.SelectedEntity:
                            Height = 8f;
                            HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToChildren;
                            Width = 8f;
                            WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToChildren;
                            Background.Visible = true;
                            BuildMenuButtonInstance.Visible = false;
                            MenuTitleDisplayInstance.Height = 16f;
                            MenuTitleDisplayInstance.Visible = true;
                            MenuTitleDisplayInstance.Width = 130f;
                            MenuTitleDisplayInstance.X = 1f;
                            MenuTitleDisplayInstance.Y = 8f;
                            ResourceCostContainer.Visible = true;
                            ResourceCostContainer.X = 1f;
                            ResourceCostContainer.Y = 28f;
                            ActionStackContainerInstance.Visible = true;
                            SelectedBuilding.Visible = false;
                            XButtonInstance.Visible = true;
                            XButtonInstance.X = -2f;
                            XButtonInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                            XButtonInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                            XButtonInstance.Y = 2f;
                            XButtonInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                            XButtonInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                            break;
                        case  VariableState.PlacingBuilding:
                            Height = 32f;
                            HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                            Width = 32f;
                            WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                            Background.Visible = false;
                            BuildMenuButtonInstance.Visible = false;
                            MenuTitleDisplayInstance.Visible = false;
                            ResourceCostContainer.Visible = false;
                            ActionStackContainerInstance.Visible = false;
                            SelectedBuilding.Visible = true;
                            XButtonInstance.X = -2f;
                            XButtonInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                            XButtonInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                            XButtonInstance.Y = 2f;
                            XButtonInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                            XButtonInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
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
                bool setActionStackContainerInstanceXFirstValue = false;
                bool setActionStackContainerInstanceXSecondValue = false;
                float ActionStackContainerInstanceXFirstValue= 0;
                float ActionStackContainerInstanceXSecondValue= 0;
                bool setActionStackContainerInstanceYFirstValue = false;
                bool setActionStackContainerInstanceYSecondValue = false;
                float ActionStackContainerInstanceYFirstValue= 0;
                float ActionStackContainerInstanceYSecondValue= 0;
                bool setBackgroundHeightFirstValue = false;
                bool setBackgroundHeightSecondValue = false;
                float BackgroundHeightFirstValue= 0;
                float BackgroundHeightSecondValue= 0;
                bool setBackgroundTextureHeightFirstValue = false;
                bool setBackgroundTextureHeightSecondValue = false;
                int BackgroundTextureHeightFirstValue= 0;
                int BackgroundTextureHeightSecondValue= 0;
                bool setBackgroundTextureLeftFirstValue = false;
                bool setBackgroundTextureLeftSecondValue = false;
                int BackgroundTextureLeftFirstValue= 0;
                int BackgroundTextureLeftSecondValue= 0;
                bool setBackgroundTextureTopFirstValue = false;
                bool setBackgroundTextureTopSecondValue = false;
                int BackgroundTextureTopFirstValue= 0;
                int BackgroundTextureTopSecondValue= 0;
                bool setBackgroundTextureWidthFirstValue = false;
                bool setBackgroundTextureWidthSecondValue = false;
                int BackgroundTextureWidthFirstValue= 0;
                int BackgroundTextureWidthSecondValue= 0;
                bool setBackgroundWidthFirstValue = false;
                bool setBackgroundWidthSecondValue = false;
                float BackgroundWidthFirstValue= 0;
                float BackgroundWidthSecondValue= 0;
                bool setHeightFirstValue = false;
                bool setHeightSecondValue = false;
                float HeightFirstValue= 0;
                float HeightSecondValue= 0;
                bool setSelectedBuildingHeightFirstValue = false;
                bool setSelectedBuildingHeightSecondValue = false;
                float SelectedBuildingHeightFirstValue= 0;
                float SelectedBuildingHeightSecondValue= 0;
                bool setSelectedBuildingWidthFirstValue = false;
                bool setSelectedBuildingWidthSecondValue = false;
                float SelectedBuildingWidthFirstValue= 0;
                float SelectedBuildingWidthSecondValue= 0;
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
                bool setBuildMenuButtonInstanceXFirstValue = false;
                bool setBuildMenuButtonInstanceXSecondValue = false;
                float BuildMenuButtonInstanceXFirstValue= 0;
                float BuildMenuButtonInstanceXSecondValue= 0;
                bool setBuildMenuButtonInstanceYFirstValue = false;
                bool setBuildMenuButtonInstanceYSecondValue = false;
                float BuildMenuButtonInstanceYFirstValue= 0;
                float BuildMenuButtonInstanceYSecondValue= 0;
                bool setMenuTitleDisplayInstanceXFirstValue = false;
                bool setMenuTitleDisplayInstanceXSecondValue = false;
                float MenuTitleDisplayInstanceXFirstValue= 0;
                float MenuTitleDisplayInstanceXSecondValue= 0;
                bool setMenuTitleDisplayInstanceYFirstValue = false;
                bool setMenuTitleDisplayInstanceYSecondValue = false;
                float MenuTitleDisplayInstanceYFirstValue= 0;
                float MenuTitleDisplayInstanceYSecondValue= 0;
                bool setMenuTitleDisplayInstanceHeightFirstValue = false;
                bool setMenuTitleDisplayInstanceHeightSecondValue = false;
                float MenuTitleDisplayInstanceHeightFirstValue= 0;
                float MenuTitleDisplayInstanceHeightSecondValue= 0;
                bool setMenuTitleDisplayInstanceWidthFirstValue = false;
                bool setMenuTitleDisplayInstanceWidthSecondValue = false;
                float MenuTitleDisplayInstanceWidthFirstValue= 0;
                float MenuTitleDisplayInstanceWidthSecondValue= 0;
                bool setResourceCostContainerXFirstValue = false;
                bool setResourceCostContainerXSecondValue = false;
                float ResourceCostContainerXFirstValue= 0;
                float ResourceCostContainerXSecondValue= 0;
                bool setResourceCostContainerYFirstValue = false;
                bool setResourceCostContainerYSecondValue = false;
                float ResourceCostContainerYFirstValue= 0;
                float ResourceCostContainerYSecondValue= 0;
                bool setXButtonInstanceXFirstValue = false;
                bool setXButtonInstanceXSecondValue = false;
                float XButtonInstanceXFirstValue= 0;
                float XButtonInstanceXSecondValue= 0;
                bool setXButtonInstanceYFirstValue = false;
                bool setXButtonInstanceYSecondValue = false;
                float XButtonInstanceYFirstValue= 0;
                float XButtonInstanceYSecondValue= 0;
                switch(firstState)
                {
                    case  VariableState.Default:
                        setActionStackContainerInstanceXFirstValue = true;
                        ActionStackContainerInstanceXFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.ActionStackContainerInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ActionStackContainerInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setActionStackContainerInstanceYFirstValue = true;
                        ActionStackContainerInstanceYFirstValue = 47f;
                        if (interpolationValue < 1)
                        {
                            this.ActionStackContainerInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        setBackgroundHeightFirstValue = true;
                        BackgroundHeightFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.Background.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        if (interpolationValue < 1)
                        {
                            SetProperty("Background.SourceFile", "..\\MainTileset.png");
                        }
                        if (interpolationValue < 1)
                        {
                            this.Background.TextureAddress = Gum.Managers.TextureAddress.Custom;
                        }
                        setBackgroundTextureHeightFirstValue = true;
                        BackgroundTextureHeightFirstValue = 32;
                        setBackgroundTextureLeftFirstValue = true;
                        BackgroundTextureLeftFirstValue = 480;
                        setBackgroundTextureTopFirstValue = true;
                        BackgroundTextureTopFirstValue = 0;
                        setBackgroundTextureWidthFirstValue = true;
                        BackgroundTextureWidthFirstValue = 32;
                        setBackgroundWidthFirstValue = true;
                        BackgroundWidthFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.Background.WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ChildrenLayout = Gum.Managers.ChildrenLayout.Regular;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ClipsChildren = false;
                        }
                        setHeightFirstValue = true;
                        HeightFirstValue = 8f;
                        if (interpolationValue < 1)
                        {
                            this.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToChildren;
                        }
                        if (interpolationValue < 1)
                        {
                            this.MenuTitleDisplayInstance.DisplayText = "Barracks";
                        }
                        if (interpolationValue < 1)
                        {
                            this.MenuTitleDisplayInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.MenuTitleDisplayInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ResourceCostContainer.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ResourceCostContainer.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setSelectedBuildingHeightFirstValue = true;
                        SelectedBuildingHeightFirstValue = 100f;
                        setSelectedBuildingWidthFirstValue = true;
                        SelectedBuildingWidthFirstValue = 100f;
                        if (interpolationValue < 1)
                        {
                            this.Visible = true;
                        }
                        setWidthFirstValue = true;
                        WidthFirstValue = 8f;
                        if (interpolationValue < 1)
                        {
                            this.WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToChildren;
                        }
                        if (interpolationValue < 1)
                        {
                            this.WrapsChildren = false;
                        }
                        setXFirstValue = true;
                        XFirstValue = -5f;
                        if (interpolationValue < 1)
                        {
                            this.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Right;
                        }
                        if (interpolationValue < 1)
                        {
                            this.XUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        setYFirstValue = true;
                        YFirstValue = -5f;
                        if (interpolationValue < 1)
                        {
                            this.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Bottom;
                        }
                        if (interpolationValue < 1)
                        {
                            this.YUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        break;
                    case  VariableState.SelectModeView:
                        if (interpolationValue < 1)
                        {
                            this.ActionStackContainerInstance.Visible = false;
                        }
                        if (interpolationValue < 1)
                        {
                            this.Background.Visible = false;
                        }
                        if (interpolationValue < 1)
                        {
                            this.BuildMenuButtonInstance.Visible = true;
                        }
                        setBuildMenuButtonInstanceXFirstValue = true;
                        BuildMenuButtonInstanceXFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.BuildMenuButtonInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        if (interpolationValue < 1)
                        {
                            this.BuildMenuButtonInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        setBuildMenuButtonInstanceYFirstValue = true;
                        BuildMenuButtonInstanceYFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.BuildMenuButtonInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                        }
                        if (interpolationValue < 1)
                        {
                            this.BuildMenuButtonInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        setHeightFirstValue = true;
                        HeightFirstValue = 32f;
                        if (interpolationValue < 1)
                        {
                            this.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        if (interpolationValue < 1)
                        {
                            this.MenuTitleDisplayInstance.Visible = false;
                        }
                        setMenuTitleDisplayInstanceXFirstValue = true;
                        MenuTitleDisplayInstanceXFirstValue = 0f;
                        setMenuTitleDisplayInstanceYFirstValue = true;
                        MenuTitleDisplayInstanceYFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.ResourceCostContainer.Visible = false;
                        }
                        if (interpolationValue < 1)
                        {
                            this.SelectedBuilding.Visible = false;
                        }
                        setWidthFirstValue = true;
                        WidthFirstValue = 32f;
                        if (interpolationValue < 1)
                        {
                            this.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        if (interpolationValue < 1)
                        {
                            this.XButtonInstance.Visible = false;
                        }
                        break;
                    case  VariableState.BuildMenuSelected:
                        if (interpolationValue < 1)
                        {
                            this.ActionStackContainerInstance.Visible = true;
                        }
                        if (interpolationValue < 1)
                        {
                            this.Background.Visible = true;
                        }
                        if (interpolationValue < 1)
                        {
                            this.BuildMenuButtonInstance.Visible = false;
                        }
                        setHeightFirstValue = true;
                        HeightFirstValue = 8f;
                        if (interpolationValue < 1)
                        {
                            this.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToChildren;
                        }
                        setMenuTitleDisplayInstanceHeightFirstValue = true;
                        MenuTitleDisplayInstanceHeightFirstValue = 16f;
                        if (interpolationValue < 1)
                        {
                            this.MenuTitleDisplayInstance.Visible = true;
                        }
                        setMenuTitleDisplayInstanceWidthFirstValue = true;
                        MenuTitleDisplayInstanceWidthFirstValue = 130f;
                        setMenuTitleDisplayInstanceXFirstValue = true;
                        MenuTitleDisplayInstanceXFirstValue = 1f;
                        setMenuTitleDisplayInstanceYFirstValue = true;
                        MenuTitleDisplayInstanceYFirstValue = 8f;
                        if (interpolationValue < 1)
                        {
                            this.ResourceCostContainer.Visible = true;
                        }
                        setResourceCostContainerXFirstValue = true;
                        ResourceCostContainerXFirstValue = 1f;
                        setResourceCostContainerYFirstValue = true;
                        ResourceCostContainerYFirstValue = 28f;
                        if (interpolationValue < 1)
                        {
                            this.SelectedBuilding.Visible = false;
                        }
                        setWidthFirstValue = true;
                        WidthFirstValue = 8f;
                        if (interpolationValue < 1)
                        {
                            this.WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToChildren;
                        }
                        if (interpolationValue < 1)
                        {
                            this.XButtonInstance.Visible = true;
                        }
                        setXButtonInstanceXFirstValue = true;
                        XButtonInstanceXFirstValue = -2f;
                        if (interpolationValue < 1)
                        {
                            this.XButtonInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.XButtonInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        setXButtonInstanceYFirstValue = true;
                        XButtonInstanceYFirstValue = 2f;
                        if (interpolationValue < 1)
                        {
                            this.XButtonInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.XButtonInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        break;
                    case  VariableState.SelectedEntity:
                        if (interpolationValue < 1)
                        {
                            this.ActionStackContainerInstance.Visible = true;
                        }
                        if (interpolationValue < 1)
                        {
                            this.Background.Visible = true;
                        }
                        if (interpolationValue < 1)
                        {
                            this.BuildMenuButtonInstance.Visible = false;
                        }
                        setHeightFirstValue = true;
                        HeightFirstValue = 8f;
                        if (interpolationValue < 1)
                        {
                            this.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToChildren;
                        }
                        setMenuTitleDisplayInstanceHeightFirstValue = true;
                        MenuTitleDisplayInstanceHeightFirstValue = 16f;
                        if (interpolationValue < 1)
                        {
                            this.MenuTitleDisplayInstance.Visible = true;
                        }
                        setMenuTitleDisplayInstanceWidthFirstValue = true;
                        MenuTitleDisplayInstanceWidthFirstValue = 130f;
                        setMenuTitleDisplayInstanceXFirstValue = true;
                        MenuTitleDisplayInstanceXFirstValue = 1f;
                        setMenuTitleDisplayInstanceYFirstValue = true;
                        MenuTitleDisplayInstanceYFirstValue = 8f;
                        if (interpolationValue < 1)
                        {
                            this.ResourceCostContainer.Visible = true;
                        }
                        setResourceCostContainerXFirstValue = true;
                        ResourceCostContainerXFirstValue = 1f;
                        setResourceCostContainerYFirstValue = true;
                        ResourceCostContainerYFirstValue = 28f;
                        if (interpolationValue < 1)
                        {
                            this.SelectedBuilding.Visible = false;
                        }
                        setWidthFirstValue = true;
                        WidthFirstValue = 8f;
                        if (interpolationValue < 1)
                        {
                            this.WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToChildren;
                        }
                        if (interpolationValue < 1)
                        {
                            this.XButtonInstance.Visible = true;
                        }
                        setXButtonInstanceXFirstValue = true;
                        XButtonInstanceXFirstValue = -2f;
                        if (interpolationValue < 1)
                        {
                            this.XButtonInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.XButtonInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        setXButtonInstanceYFirstValue = true;
                        XButtonInstanceYFirstValue = 2f;
                        if (interpolationValue < 1)
                        {
                            this.XButtonInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.XButtonInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        break;
                    case  VariableState.PlacingBuilding:
                        if (interpolationValue < 1)
                        {
                            this.ActionStackContainerInstance.Visible = false;
                        }
                        if (interpolationValue < 1)
                        {
                            this.Background.Visible = false;
                        }
                        if (interpolationValue < 1)
                        {
                            this.BuildMenuButtonInstance.Visible = false;
                        }
                        setHeightFirstValue = true;
                        HeightFirstValue = 32f;
                        if (interpolationValue < 1)
                        {
                            this.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        if (interpolationValue < 1)
                        {
                            this.MenuTitleDisplayInstance.Visible = false;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ResourceCostContainer.Visible = false;
                        }
                        if (interpolationValue < 1)
                        {
                            this.SelectedBuilding.Visible = true;
                        }
                        setWidthFirstValue = true;
                        WidthFirstValue = 32f;
                        if (interpolationValue < 1)
                        {
                            this.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        setXButtonInstanceXFirstValue = true;
                        XButtonInstanceXFirstValue = -2f;
                        if (interpolationValue < 1)
                        {
                            this.XButtonInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.XButtonInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        setXButtonInstanceYFirstValue = true;
                        XButtonInstanceYFirstValue = 2f;
                        if (interpolationValue < 1)
                        {
                            this.XButtonInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.XButtonInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        break;
                }
                switch(secondState)
                {
                    case  VariableState.Default:
                        setActionStackContainerInstanceXSecondValue = true;
                        ActionStackContainerInstanceXSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.ActionStackContainerInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ActionStackContainerInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setActionStackContainerInstanceYSecondValue = true;
                        ActionStackContainerInstanceYSecondValue = 47f;
                        if (interpolationValue >= 1)
                        {
                            this.ActionStackContainerInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        setBackgroundHeightSecondValue = true;
                        BackgroundHeightSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.Background.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        if (interpolationValue >= 1)
                        {
                            SetProperty("Background.SourceFile", "..\\MainTileset.png");
                        }
                        if (interpolationValue >= 1)
                        {
                            this.Background.TextureAddress = Gum.Managers.TextureAddress.Custom;
                        }
                        setBackgroundTextureHeightSecondValue = true;
                        BackgroundTextureHeightSecondValue = 32;
                        setBackgroundTextureLeftSecondValue = true;
                        BackgroundTextureLeftSecondValue = 480;
                        setBackgroundTextureTopSecondValue = true;
                        BackgroundTextureTopSecondValue = 0;
                        setBackgroundTextureWidthSecondValue = true;
                        BackgroundTextureWidthSecondValue = 32;
                        setBackgroundWidthSecondValue = true;
                        BackgroundWidthSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.Background.WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ChildrenLayout = Gum.Managers.ChildrenLayout.Regular;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ClipsChildren = false;
                        }
                        setHeightSecondValue = true;
                        HeightSecondValue = 8f;
                        if (interpolationValue >= 1)
                        {
                            this.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToChildren;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.MenuTitleDisplayInstance.DisplayText = "Barracks";
                        }
                        if (interpolationValue >= 1)
                        {
                            this.MenuTitleDisplayInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.MenuTitleDisplayInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ResourceCostContainer.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ResourceCostContainer.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setSelectedBuildingHeightSecondValue = true;
                        SelectedBuildingHeightSecondValue = 100f;
                        setSelectedBuildingWidthSecondValue = true;
                        SelectedBuildingWidthSecondValue = 100f;
                        if (interpolationValue >= 1)
                        {
                            this.Visible = true;
                        }
                        setWidthSecondValue = true;
                        WidthSecondValue = 8f;
                        if (interpolationValue >= 1)
                        {
                            this.WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToChildren;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.WrapsChildren = false;
                        }
                        setXSecondValue = true;
                        XSecondValue = -5f;
                        if (interpolationValue >= 1)
                        {
                            this.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Right;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.XUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        setYSecondValue = true;
                        YSecondValue = -5f;
                        if (interpolationValue >= 1)
                        {
                            this.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Bottom;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.YUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        break;
                    case  VariableState.SelectModeView:
                        if (interpolationValue >= 1)
                        {
                            this.ActionStackContainerInstance.Visible = false;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.Background.Visible = false;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.BuildMenuButtonInstance.Visible = true;
                        }
                        setBuildMenuButtonInstanceXSecondValue = true;
                        BuildMenuButtonInstanceXSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.BuildMenuButtonInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.BuildMenuButtonInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        setBuildMenuButtonInstanceYSecondValue = true;
                        BuildMenuButtonInstanceYSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.BuildMenuButtonInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.BuildMenuButtonInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        setHeightSecondValue = true;
                        HeightSecondValue = 32f;
                        if (interpolationValue >= 1)
                        {
                            this.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.MenuTitleDisplayInstance.Visible = false;
                        }
                        setMenuTitleDisplayInstanceXSecondValue = true;
                        MenuTitleDisplayInstanceXSecondValue = 0f;
                        setMenuTitleDisplayInstanceYSecondValue = true;
                        MenuTitleDisplayInstanceYSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.ResourceCostContainer.Visible = false;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.SelectedBuilding.Visible = false;
                        }
                        setWidthSecondValue = true;
                        WidthSecondValue = 32f;
                        if (interpolationValue >= 1)
                        {
                            this.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.XButtonInstance.Visible = false;
                        }
                        break;
                    case  VariableState.BuildMenuSelected:
                        if (interpolationValue >= 1)
                        {
                            this.ActionStackContainerInstance.Visible = true;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.Background.Visible = true;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.BuildMenuButtonInstance.Visible = false;
                        }
                        setHeightSecondValue = true;
                        HeightSecondValue = 8f;
                        if (interpolationValue >= 1)
                        {
                            this.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToChildren;
                        }
                        setMenuTitleDisplayInstanceHeightSecondValue = true;
                        MenuTitleDisplayInstanceHeightSecondValue = 16f;
                        if (interpolationValue >= 1)
                        {
                            this.MenuTitleDisplayInstance.Visible = true;
                        }
                        setMenuTitleDisplayInstanceWidthSecondValue = true;
                        MenuTitleDisplayInstanceWidthSecondValue = 130f;
                        setMenuTitleDisplayInstanceXSecondValue = true;
                        MenuTitleDisplayInstanceXSecondValue = 1f;
                        setMenuTitleDisplayInstanceYSecondValue = true;
                        MenuTitleDisplayInstanceYSecondValue = 8f;
                        if (interpolationValue >= 1)
                        {
                            this.ResourceCostContainer.Visible = true;
                        }
                        setResourceCostContainerXSecondValue = true;
                        ResourceCostContainerXSecondValue = 1f;
                        setResourceCostContainerYSecondValue = true;
                        ResourceCostContainerYSecondValue = 28f;
                        if (interpolationValue >= 1)
                        {
                            this.SelectedBuilding.Visible = false;
                        }
                        setWidthSecondValue = true;
                        WidthSecondValue = 8f;
                        if (interpolationValue >= 1)
                        {
                            this.WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToChildren;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.XButtonInstance.Visible = true;
                        }
                        setXButtonInstanceXSecondValue = true;
                        XButtonInstanceXSecondValue = -2f;
                        if (interpolationValue >= 1)
                        {
                            this.XButtonInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.XButtonInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        setXButtonInstanceYSecondValue = true;
                        XButtonInstanceYSecondValue = 2f;
                        if (interpolationValue >= 1)
                        {
                            this.XButtonInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.XButtonInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        break;
                    case  VariableState.SelectedEntity:
                        if (interpolationValue >= 1)
                        {
                            this.ActionStackContainerInstance.Visible = true;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.Background.Visible = true;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.BuildMenuButtonInstance.Visible = false;
                        }
                        setHeightSecondValue = true;
                        HeightSecondValue = 8f;
                        if (interpolationValue >= 1)
                        {
                            this.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToChildren;
                        }
                        setMenuTitleDisplayInstanceHeightSecondValue = true;
                        MenuTitleDisplayInstanceHeightSecondValue = 16f;
                        if (interpolationValue >= 1)
                        {
                            this.MenuTitleDisplayInstance.Visible = true;
                        }
                        setMenuTitleDisplayInstanceWidthSecondValue = true;
                        MenuTitleDisplayInstanceWidthSecondValue = 130f;
                        setMenuTitleDisplayInstanceXSecondValue = true;
                        MenuTitleDisplayInstanceXSecondValue = 1f;
                        setMenuTitleDisplayInstanceYSecondValue = true;
                        MenuTitleDisplayInstanceYSecondValue = 8f;
                        if (interpolationValue >= 1)
                        {
                            this.ResourceCostContainer.Visible = true;
                        }
                        setResourceCostContainerXSecondValue = true;
                        ResourceCostContainerXSecondValue = 1f;
                        setResourceCostContainerYSecondValue = true;
                        ResourceCostContainerYSecondValue = 28f;
                        if (interpolationValue >= 1)
                        {
                            this.SelectedBuilding.Visible = false;
                        }
                        setWidthSecondValue = true;
                        WidthSecondValue = 8f;
                        if (interpolationValue >= 1)
                        {
                            this.WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToChildren;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.XButtonInstance.Visible = true;
                        }
                        setXButtonInstanceXSecondValue = true;
                        XButtonInstanceXSecondValue = -2f;
                        if (interpolationValue >= 1)
                        {
                            this.XButtonInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.XButtonInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        setXButtonInstanceYSecondValue = true;
                        XButtonInstanceYSecondValue = 2f;
                        if (interpolationValue >= 1)
                        {
                            this.XButtonInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.XButtonInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        break;
                    case  VariableState.PlacingBuilding:
                        if (interpolationValue >= 1)
                        {
                            this.ActionStackContainerInstance.Visible = false;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.Background.Visible = false;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.BuildMenuButtonInstance.Visible = false;
                        }
                        setHeightSecondValue = true;
                        HeightSecondValue = 32f;
                        if (interpolationValue >= 1)
                        {
                            this.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.MenuTitleDisplayInstance.Visible = false;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ResourceCostContainer.Visible = false;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.SelectedBuilding.Visible = true;
                        }
                        setWidthSecondValue = true;
                        WidthSecondValue = 32f;
                        if (interpolationValue >= 1)
                        {
                            this.WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        setXButtonInstanceXSecondValue = true;
                        XButtonInstanceXSecondValue = -2f;
                        if (interpolationValue >= 1)
                        {
                            this.XButtonInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.XButtonInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        setXButtonInstanceYSecondValue = true;
                        XButtonInstanceYSecondValue = 2f;
                        if (interpolationValue >= 1)
                        {
                            this.XButtonInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.XButtonInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        break;
                }
                if (setActionStackContainerInstanceXFirstValue && setActionStackContainerInstanceXSecondValue)
                {
                    ActionStackContainerInstance.X = ActionStackContainerInstanceXFirstValue * (1 - interpolationValue) + ActionStackContainerInstanceXSecondValue * interpolationValue;
                }
                if (setActionStackContainerInstanceYFirstValue && setActionStackContainerInstanceYSecondValue)
                {
                    ActionStackContainerInstance.Y = ActionStackContainerInstanceYFirstValue * (1 - interpolationValue) + ActionStackContainerInstanceYSecondValue * interpolationValue;
                }
                if (setBackgroundHeightFirstValue && setBackgroundHeightSecondValue)
                {
                    Background.Height = BackgroundHeightFirstValue * (1 - interpolationValue) + BackgroundHeightSecondValue * interpolationValue;
                }
                if (setBackgroundTextureHeightFirstValue && setBackgroundTextureHeightSecondValue)
                {
                    Background.TextureHeight = FlatRedBall.Math.MathFunctions.RoundToInt(BackgroundTextureHeightFirstValue* (1 - interpolationValue) + BackgroundTextureHeightSecondValue * interpolationValue);
                }
                if (setBackgroundTextureLeftFirstValue && setBackgroundTextureLeftSecondValue)
                {
                    Background.TextureLeft = FlatRedBall.Math.MathFunctions.RoundToInt(BackgroundTextureLeftFirstValue* (1 - interpolationValue) + BackgroundTextureLeftSecondValue * interpolationValue);
                }
                if (setBackgroundTextureTopFirstValue && setBackgroundTextureTopSecondValue)
                {
                    Background.TextureTop = FlatRedBall.Math.MathFunctions.RoundToInt(BackgroundTextureTopFirstValue* (1 - interpolationValue) + BackgroundTextureTopSecondValue * interpolationValue);
                }
                if (setBackgroundTextureWidthFirstValue && setBackgroundTextureWidthSecondValue)
                {
                    Background.TextureWidth = FlatRedBall.Math.MathFunctions.RoundToInt(BackgroundTextureWidthFirstValue* (1 - interpolationValue) + BackgroundTextureWidthSecondValue * interpolationValue);
                }
                if (setBackgroundWidthFirstValue && setBackgroundWidthSecondValue)
                {
                    Background.Width = BackgroundWidthFirstValue * (1 - interpolationValue) + BackgroundWidthSecondValue * interpolationValue;
                }
                if (setHeightFirstValue && setHeightSecondValue)
                {
                    Height = HeightFirstValue * (1 - interpolationValue) + HeightSecondValue * interpolationValue;
                }
                if (setSelectedBuildingHeightFirstValue && setSelectedBuildingHeightSecondValue)
                {
                    SelectedBuilding.Height = SelectedBuildingHeightFirstValue * (1 - interpolationValue) + SelectedBuildingHeightSecondValue * interpolationValue;
                }
                if (setSelectedBuildingWidthFirstValue && setSelectedBuildingWidthSecondValue)
                {
                    SelectedBuilding.Width = SelectedBuildingWidthFirstValue * (1 - interpolationValue) + SelectedBuildingWidthSecondValue * interpolationValue;
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
                if (setBuildMenuButtonInstanceXFirstValue && setBuildMenuButtonInstanceXSecondValue)
                {
                    BuildMenuButtonInstance.X = BuildMenuButtonInstanceXFirstValue * (1 - interpolationValue) + BuildMenuButtonInstanceXSecondValue * interpolationValue;
                }
                if (setBuildMenuButtonInstanceYFirstValue && setBuildMenuButtonInstanceYSecondValue)
                {
                    BuildMenuButtonInstance.Y = BuildMenuButtonInstanceYFirstValue * (1 - interpolationValue) + BuildMenuButtonInstanceYSecondValue * interpolationValue;
                }
                if (setMenuTitleDisplayInstanceXFirstValue && setMenuTitleDisplayInstanceXSecondValue)
                {
                    MenuTitleDisplayInstance.X = MenuTitleDisplayInstanceXFirstValue * (1 - interpolationValue) + MenuTitleDisplayInstanceXSecondValue * interpolationValue;
                }
                if (setMenuTitleDisplayInstanceYFirstValue && setMenuTitleDisplayInstanceYSecondValue)
                {
                    MenuTitleDisplayInstance.Y = MenuTitleDisplayInstanceYFirstValue * (1 - interpolationValue) + MenuTitleDisplayInstanceYSecondValue * interpolationValue;
                }
                if (setMenuTitleDisplayInstanceHeightFirstValue && setMenuTitleDisplayInstanceHeightSecondValue)
                {
                    MenuTitleDisplayInstance.Height = MenuTitleDisplayInstanceHeightFirstValue * (1 - interpolationValue) + MenuTitleDisplayInstanceHeightSecondValue * interpolationValue;
                }
                if (setMenuTitleDisplayInstanceWidthFirstValue && setMenuTitleDisplayInstanceWidthSecondValue)
                {
                    MenuTitleDisplayInstance.Width = MenuTitleDisplayInstanceWidthFirstValue * (1 - interpolationValue) + MenuTitleDisplayInstanceWidthSecondValue * interpolationValue;
                }
                if (setResourceCostContainerXFirstValue && setResourceCostContainerXSecondValue)
                {
                    ResourceCostContainer.X = ResourceCostContainerXFirstValue * (1 - interpolationValue) + ResourceCostContainerXSecondValue * interpolationValue;
                }
                if (setResourceCostContainerYFirstValue && setResourceCostContainerYSecondValue)
                {
                    ResourceCostContainer.Y = ResourceCostContainerYFirstValue * (1 - interpolationValue) + ResourceCostContainerYSecondValue * interpolationValue;
                }
                if (setXButtonInstanceXFirstValue && setXButtonInstanceXSecondValue)
                {
                    XButtonInstance.X = XButtonInstanceXFirstValue * (1 - interpolationValue) + XButtonInstanceXSecondValue * interpolationValue;
                }
                if (setXButtonInstanceYFirstValue && setXButtonInstanceYSecondValue)
                {
                    XButtonInstance.Y = XButtonInstanceYFirstValue * (1 - interpolationValue) + XButtonInstanceYSecondValue * interpolationValue;
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
            public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateTo (TownRaiserImGui.GumRuntimes.ActionToolbarRuntime.VariableState fromState,TownRaiserImGui.GumRuntimes.ActionToolbarRuntime.VariableState toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null) 
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
                BuildMenuButtonInstance.StopAnimations();
                MenuTitleDisplayInstance.StopAnimations();
                ResourceCostContainer.StopAnimations();
                ActionStackContainerInstance.StopAnimations();
                SelectedBuilding.StopAnimations();
                XButtonInstance.StopAnimations();
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
                            Name = "Background.Height",
                            Type = "float",
                            Value = Background.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Height Units",
                            Type = "DimensionUnitType",
                            Value = Background.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.SourceFile",
                            Type = "string",
                            Value = Background.SourceFile
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Texture Address",
                            Type = "TextureAddress",
                            Value = Background.TextureAddress
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Texture Height",
                            Type = "int",
                            Value = Background.TextureHeight
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Texture Left",
                            Type = "int",
                            Value = Background.TextureLeft
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Texture Top",
                            Type = "int",
                            Value = Background.TextureTop
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Texture Width",
                            Type = "int",
                            Value = Background.TextureWidth
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Width",
                            Type = "float",
                            Value = Background.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Width Units",
                            Type = "DimensionUnitType",
                            Value = Background.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MenuTitleDisplayInstance.DisplayText",
                            Type = "string",
                            Value = MenuTitleDisplayInstance.DisplayText
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MenuTitleDisplayInstance.X Origin",
                            Type = "HorizontalAlignment",
                            Value = MenuTitleDisplayInstance.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MenuTitleDisplayInstance.X Units",
                            Type = "PositionUnitType",
                            Value = MenuTitleDisplayInstance.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ResourceCostContainer.X Origin",
                            Type = "HorizontalAlignment",
                            Value = ResourceCostContainer.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ResourceCostContainer.X Units",
                            Type = "PositionUnitType",
                            Value = ResourceCostContainer.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ActionStackContainerInstance.X",
                            Type = "float",
                            Value = ActionStackContainerInstance.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ActionStackContainerInstance.X Origin",
                            Type = "HorizontalAlignment",
                            Value = ActionStackContainerInstance.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ActionStackContainerInstance.X Units",
                            Type = "PositionUnitType",
                            Value = ActionStackContainerInstance.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ActionStackContainerInstance.Y",
                            Type = "float",
                            Value = ActionStackContainerInstance.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ActionStackContainerInstance.Y Units",
                            Type = "PositionUnitType",
                            Value = ActionStackContainerInstance.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SelectedBuilding.Height",
                            Type = "float",
                            Value = SelectedBuilding.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SelectedBuilding.Width",
                            Type = "float",
                            Value = SelectedBuilding.Width
                        }
                        );
                        break;
                    case  VariableState.SelectModeView:
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
                            Name = "Background.Visible",
                            Type = "bool",
                            Value = Background.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BuildMenuButtonInstance.Visible",
                            Type = "bool",
                            Value = BuildMenuButtonInstance.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BuildMenuButtonInstance.X",
                            Type = "float",
                            Value = BuildMenuButtonInstance.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BuildMenuButtonInstance.X Origin",
                            Type = "HorizontalAlignment",
                            Value = BuildMenuButtonInstance.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BuildMenuButtonInstance.X Units",
                            Type = "PositionUnitType",
                            Value = BuildMenuButtonInstance.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BuildMenuButtonInstance.Y",
                            Type = "float",
                            Value = BuildMenuButtonInstance.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BuildMenuButtonInstance.Y Origin",
                            Type = "VerticalAlignment",
                            Value = BuildMenuButtonInstance.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BuildMenuButtonInstance.Y Units",
                            Type = "PositionUnitType",
                            Value = BuildMenuButtonInstance.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MenuTitleDisplayInstance.Visible",
                            Type = "bool",
                            Value = MenuTitleDisplayInstance.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MenuTitleDisplayInstance.X",
                            Type = "float",
                            Value = MenuTitleDisplayInstance.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MenuTitleDisplayInstance.Y",
                            Type = "float",
                            Value = MenuTitleDisplayInstance.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ResourceCostContainer.Visible",
                            Type = "bool",
                            Value = ResourceCostContainer.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ActionStackContainerInstance.Visible",
                            Type = "bool",
                            Value = ActionStackContainerInstance.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SelectedBuilding.Visible",
                            Type = "bool",
                            Value = SelectedBuilding.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "XButtonInstance.Visible",
                            Type = "bool",
                            Value = XButtonInstance.Visible
                        }
                        );
                        break;
                    case  VariableState.BuildMenuSelected:
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
                            Name = "Background.Visible",
                            Type = "bool",
                            Value = Background.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BuildMenuButtonInstance.Visible",
                            Type = "bool",
                            Value = BuildMenuButtonInstance.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MenuTitleDisplayInstance.Height",
                            Type = "float",
                            Value = MenuTitleDisplayInstance.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MenuTitleDisplayInstance.Visible",
                            Type = "bool",
                            Value = MenuTitleDisplayInstance.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MenuTitleDisplayInstance.Width",
                            Type = "float",
                            Value = MenuTitleDisplayInstance.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MenuTitleDisplayInstance.X",
                            Type = "float",
                            Value = MenuTitleDisplayInstance.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MenuTitleDisplayInstance.Y",
                            Type = "float",
                            Value = MenuTitleDisplayInstance.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ResourceCostContainer.Visible",
                            Type = "bool",
                            Value = ResourceCostContainer.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ResourceCostContainer.X",
                            Type = "float",
                            Value = ResourceCostContainer.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ResourceCostContainer.Y",
                            Type = "float",
                            Value = ResourceCostContainer.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ActionStackContainerInstance.Visible",
                            Type = "bool",
                            Value = ActionStackContainerInstance.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SelectedBuilding.Visible",
                            Type = "bool",
                            Value = SelectedBuilding.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "XButtonInstance.Visible",
                            Type = "bool",
                            Value = XButtonInstance.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "XButtonInstance.X",
                            Type = "float",
                            Value = XButtonInstance.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "XButtonInstance.X Origin",
                            Type = "HorizontalAlignment",
                            Value = XButtonInstance.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "XButtonInstance.X Units",
                            Type = "PositionUnitType",
                            Value = XButtonInstance.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "XButtonInstance.Y",
                            Type = "float",
                            Value = XButtonInstance.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "XButtonInstance.Y Origin",
                            Type = "VerticalAlignment",
                            Value = XButtonInstance.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "XButtonInstance.Y Units",
                            Type = "PositionUnitType",
                            Value = XButtonInstance.YUnits
                        }
                        );
                        break;
                    case  VariableState.SelectedEntity:
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
                            Name = "Background.Visible",
                            Type = "bool",
                            Value = Background.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BuildMenuButtonInstance.Visible",
                            Type = "bool",
                            Value = BuildMenuButtonInstance.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MenuTitleDisplayInstance.Height",
                            Type = "float",
                            Value = MenuTitleDisplayInstance.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MenuTitleDisplayInstance.Visible",
                            Type = "bool",
                            Value = MenuTitleDisplayInstance.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MenuTitleDisplayInstance.Width",
                            Type = "float",
                            Value = MenuTitleDisplayInstance.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MenuTitleDisplayInstance.X",
                            Type = "float",
                            Value = MenuTitleDisplayInstance.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MenuTitleDisplayInstance.Y",
                            Type = "float",
                            Value = MenuTitleDisplayInstance.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ResourceCostContainer.Visible",
                            Type = "bool",
                            Value = ResourceCostContainer.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ResourceCostContainer.X",
                            Type = "float",
                            Value = ResourceCostContainer.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ResourceCostContainer.Y",
                            Type = "float",
                            Value = ResourceCostContainer.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ActionStackContainerInstance.Visible",
                            Type = "bool",
                            Value = ActionStackContainerInstance.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SelectedBuilding.Visible",
                            Type = "bool",
                            Value = SelectedBuilding.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "XButtonInstance.Visible",
                            Type = "bool",
                            Value = XButtonInstance.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "XButtonInstance.X",
                            Type = "float",
                            Value = XButtonInstance.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "XButtonInstance.X Origin",
                            Type = "HorizontalAlignment",
                            Value = XButtonInstance.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "XButtonInstance.X Units",
                            Type = "PositionUnitType",
                            Value = XButtonInstance.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "XButtonInstance.Y",
                            Type = "float",
                            Value = XButtonInstance.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "XButtonInstance.Y Origin",
                            Type = "VerticalAlignment",
                            Value = XButtonInstance.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "XButtonInstance.Y Units",
                            Type = "PositionUnitType",
                            Value = XButtonInstance.YUnits
                        }
                        );
                        break;
                    case  VariableState.PlacingBuilding:
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
                            Name = "Background.Visible",
                            Type = "bool",
                            Value = Background.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BuildMenuButtonInstance.Visible",
                            Type = "bool",
                            Value = BuildMenuButtonInstance.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MenuTitleDisplayInstance.Visible",
                            Type = "bool",
                            Value = MenuTitleDisplayInstance.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ResourceCostContainer.Visible",
                            Type = "bool",
                            Value = ResourceCostContainer.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ActionStackContainerInstance.Visible",
                            Type = "bool",
                            Value = ActionStackContainerInstance.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SelectedBuilding.Visible",
                            Type = "bool",
                            Value = SelectedBuilding.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "XButtonInstance.X",
                            Type = "float",
                            Value = XButtonInstance.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "XButtonInstance.X Origin",
                            Type = "HorizontalAlignment",
                            Value = XButtonInstance.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "XButtonInstance.X Units",
                            Type = "PositionUnitType",
                            Value = XButtonInstance.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "XButtonInstance.Y",
                            Type = "float",
                            Value = XButtonInstance.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "XButtonInstance.Y Origin",
                            Type = "VerticalAlignment",
                            Value = XButtonInstance.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "XButtonInstance.Y Units",
                            Type = "PositionUnitType",
                            Value = XButtonInstance.YUnits
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
                            Value = Height + 8f
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
                            Value = Width + 8f
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
                            Value = X + -5f
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
                            Value = Y + -5f
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
                            Name = "Background.Height",
                            Type = "float",
                            Value = Background.Height + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Height Units",
                            Type = "DimensionUnitType",
                            Value = Background.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.SourceFile",
                            Type = "string",
                            Value = Background.SourceFile
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Texture Address",
                            Type = "TextureAddress",
                            Value = Background.TextureAddress
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Texture Height",
                            Type = "int",
                            Value = Background.TextureHeight + 32
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Texture Left",
                            Type = "int",
                            Value = Background.TextureLeft + 480
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Texture Top",
                            Type = "int",
                            Value = Background.TextureTop + 0
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Texture Width",
                            Type = "int",
                            Value = Background.TextureWidth + 32
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Width",
                            Type = "float",
                            Value = Background.Width + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Background.Width Units",
                            Type = "DimensionUnitType",
                            Value = Background.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MenuTitleDisplayInstance.DisplayText",
                            Type = "string",
                            Value = MenuTitleDisplayInstance.DisplayText
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MenuTitleDisplayInstance.X Origin",
                            Type = "HorizontalAlignment",
                            Value = MenuTitleDisplayInstance.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MenuTitleDisplayInstance.X Units",
                            Type = "PositionUnitType",
                            Value = MenuTitleDisplayInstance.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ResourceCostContainer.X Origin",
                            Type = "HorizontalAlignment",
                            Value = ResourceCostContainer.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ResourceCostContainer.X Units",
                            Type = "PositionUnitType",
                            Value = ResourceCostContainer.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ActionStackContainerInstance.X",
                            Type = "float",
                            Value = ActionStackContainerInstance.X + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ActionStackContainerInstance.X Origin",
                            Type = "HorizontalAlignment",
                            Value = ActionStackContainerInstance.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ActionStackContainerInstance.X Units",
                            Type = "PositionUnitType",
                            Value = ActionStackContainerInstance.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ActionStackContainerInstance.Y",
                            Type = "float",
                            Value = ActionStackContainerInstance.Y + 47f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ActionStackContainerInstance.Y Units",
                            Type = "PositionUnitType",
                            Value = ActionStackContainerInstance.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SelectedBuilding.Height",
                            Type = "float",
                            Value = SelectedBuilding.Height + 100f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SelectedBuilding.Width",
                            Type = "float",
                            Value = SelectedBuilding.Width + 100f
                        }
                        );
                        break;
                    case  VariableState.SelectModeView:
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Height",
                            Type = "float",
                            Value = Height + 32f
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
                            Name = "Width",
                            Type = "float",
                            Value = Width + 32f
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
                            Name = "Background.Visible",
                            Type = "bool",
                            Value = Background.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BuildMenuButtonInstance.Visible",
                            Type = "bool",
                            Value = BuildMenuButtonInstance.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BuildMenuButtonInstance.X",
                            Type = "float",
                            Value = BuildMenuButtonInstance.X + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BuildMenuButtonInstance.X Origin",
                            Type = "HorizontalAlignment",
                            Value = BuildMenuButtonInstance.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BuildMenuButtonInstance.X Units",
                            Type = "PositionUnitType",
                            Value = BuildMenuButtonInstance.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BuildMenuButtonInstance.Y",
                            Type = "float",
                            Value = BuildMenuButtonInstance.Y + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BuildMenuButtonInstance.Y Origin",
                            Type = "VerticalAlignment",
                            Value = BuildMenuButtonInstance.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BuildMenuButtonInstance.Y Units",
                            Type = "PositionUnitType",
                            Value = BuildMenuButtonInstance.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MenuTitleDisplayInstance.Visible",
                            Type = "bool",
                            Value = MenuTitleDisplayInstance.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MenuTitleDisplayInstance.X",
                            Type = "float",
                            Value = MenuTitleDisplayInstance.X + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MenuTitleDisplayInstance.Y",
                            Type = "float",
                            Value = MenuTitleDisplayInstance.Y + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ResourceCostContainer.Visible",
                            Type = "bool",
                            Value = ResourceCostContainer.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ActionStackContainerInstance.Visible",
                            Type = "bool",
                            Value = ActionStackContainerInstance.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SelectedBuilding.Visible",
                            Type = "bool",
                            Value = SelectedBuilding.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "XButtonInstance.Visible",
                            Type = "bool",
                            Value = XButtonInstance.Visible
                        }
                        );
                        break;
                    case  VariableState.BuildMenuSelected:
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Height",
                            Type = "float",
                            Value = Height + 8f
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
                            Name = "Width",
                            Type = "float",
                            Value = Width + 8f
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
                            Name = "Background.Visible",
                            Type = "bool",
                            Value = Background.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BuildMenuButtonInstance.Visible",
                            Type = "bool",
                            Value = BuildMenuButtonInstance.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MenuTitleDisplayInstance.Height",
                            Type = "float",
                            Value = MenuTitleDisplayInstance.Height + 16f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MenuTitleDisplayInstance.Visible",
                            Type = "bool",
                            Value = MenuTitleDisplayInstance.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MenuTitleDisplayInstance.Width",
                            Type = "float",
                            Value = MenuTitleDisplayInstance.Width + 130f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MenuTitleDisplayInstance.X",
                            Type = "float",
                            Value = MenuTitleDisplayInstance.X + 1f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MenuTitleDisplayInstance.Y",
                            Type = "float",
                            Value = MenuTitleDisplayInstance.Y + 8f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ResourceCostContainer.Visible",
                            Type = "bool",
                            Value = ResourceCostContainer.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ResourceCostContainer.X",
                            Type = "float",
                            Value = ResourceCostContainer.X + 1f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ResourceCostContainer.Y",
                            Type = "float",
                            Value = ResourceCostContainer.Y + 28f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ActionStackContainerInstance.Visible",
                            Type = "bool",
                            Value = ActionStackContainerInstance.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SelectedBuilding.Visible",
                            Type = "bool",
                            Value = SelectedBuilding.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "XButtonInstance.Visible",
                            Type = "bool",
                            Value = XButtonInstance.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "XButtonInstance.X",
                            Type = "float",
                            Value = XButtonInstance.X + -2f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "XButtonInstance.X Origin",
                            Type = "HorizontalAlignment",
                            Value = XButtonInstance.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "XButtonInstance.X Units",
                            Type = "PositionUnitType",
                            Value = XButtonInstance.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "XButtonInstance.Y",
                            Type = "float",
                            Value = XButtonInstance.Y + 2f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "XButtonInstance.Y Origin",
                            Type = "VerticalAlignment",
                            Value = XButtonInstance.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "XButtonInstance.Y Units",
                            Type = "PositionUnitType",
                            Value = XButtonInstance.YUnits
                        }
                        );
                        break;
                    case  VariableState.SelectedEntity:
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Height",
                            Type = "float",
                            Value = Height + 8f
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
                            Name = "Width",
                            Type = "float",
                            Value = Width + 8f
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
                            Name = "Background.Visible",
                            Type = "bool",
                            Value = Background.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BuildMenuButtonInstance.Visible",
                            Type = "bool",
                            Value = BuildMenuButtonInstance.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MenuTitleDisplayInstance.Height",
                            Type = "float",
                            Value = MenuTitleDisplayInstance.Height + 16f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MenuTitleDisplayInstance.Visible",
                            Type = "bool",
                            Value = MenuTitleDisplayInstance.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MenuTitleDisplayInstance.Width",
                            Type = "float",
                            Value = MenuTitleDisplayInstance.Width + 130f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MenuTitleDisplayInstance.X",
                            Type = "float",
                            Value = MenuTitleDisplayInstance.X + 1f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MenuTitleDisplayInstance.Y",
                            Type = "float",
                            Value = MenuTitleDisplayInstance.Y + 8f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ResourceCostContainer.Visible",
                            Type = "bool",
                            Value = ResourceCostContainer.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ResourceCostContainer.X",
                            Type = "float",
                            Value = ResourceCostContainer.X + 1f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ResourceCostContainer.Y",
                            Type = "float",
                            Value = ResourceCostContainer.Y + 28f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ActionStackContainerInstance.Visible",
                            Type = "bool",
                            Value = ActionStackContainerInstance.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SelectedBuilding.Visible",
                            Type = "bool",
                            Value = SelectedBuilding.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "XButtonInstance.Visible",
                            Type = "bool",
                            Value = XButtonInstance.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "XButtonInstance.X",
                            Type = "float",
                            Value = XButtonInstance.X + -2f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "XButtonInstance.X Origin",
                            Type = "HorizontalAlignment",
                            Value = XButtonInstance.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "XButtonInstance.X Units",
                            Type = "PositionUnitType",
                            Value = XButtonInstance.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "XButtonInstance.Y",
                            Type = "float",
                            Value = XButtonInstance.Y + 2f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "XButtonInstance.Y Origin",
                            Type = "VerticalAlignment",
                            Value = XButtonInstance.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "XButtonInstance.Y Units",
                            Type = "PositionUnitType",
                            Value = XButtonInstance.YUnits
                        }
                        );
                        break;
                    case  VariableState.PlacingBuilding:
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Height",
                            Type = "float",
                            Value = Height + 32f
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
                            Name = "Width",
                            Type = "float",
                            Value = Width + 32f
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
                            Name = "Background.Visible",
                            Type = "bool",
                            Value = Background.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "BuildMenuButtonInstance.Visible",
                            Type = "bool",
                            Value = BuildMenuButtonInstance.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "MenuTitleDisplayInstance.Visible",
                            Type = "bool",
                            Value = MenuTitleDisplayInstance.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ResourceCostContainer.Visible",
                            Type = "bool",
                            Value = ResourceCostContainer.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ActionStackContainerInstance.Visible",
                            Type = "bool",
                            Value = ActionStackContainerInstance.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SelectedBuilding.Visible",
                            Type = "bool",
                            Value = SelectedBuilding.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "XButtonInstance.X",
                            Type = "float",
                            Value = XButtonInstance.X + -2f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "XButtonInstance.X Origin",
                            Type = "HorizontalAlignment",
                            Value = XButtonInstance.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "XButtonInstance.X Units",
                            Type = "PositionUnitType",
                            Value = XButtonInstance.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "XButtonInstance.Y",
                            Type = "float",
                            Value = XButtonInstance.Y + 2f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "XButtonInstance.Y Origin",
                            Type = "VerticalAlignment",
                            Value = XButtonInstance.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "XButtonInstance.Y Units",
                            Type = "PositionUnitType",
                            Value = XButtonInstance.YUnits
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
                        if (state.Name == "SelectModeView") this.mCurrentVariableState = VariableState.SelectModeView;
                        if (state.Name == "BuildMenuSelected") this.mCurrentVariableState = VariableState.BuildMenuSelected;
                        if (state.Name == "SelectedEntity") this.mCurrentVariableState = VariableState.SelectedEntity;
                        if (state.Name == "PlacingBuilding") this.mCurrentVariableState = VariableState.PlacingBuilding;
                    }
                }
                base.ApplyState(state);
            }
            private TownRaiserImGui.GumRuntimes.NineSliceRuntime Background { get; set; }
            private TownRaiserImGui.GumRuntimes.FramedButtonRuntime BuildMenuButtonInstance { get; set; }
            private TownRaiserImGui.GumRuntimes.MenuTitleDisplayRuntime MenuTitleDisplayInstance { get; set; }
            private TownRaiserImGui.GumRuntimes.ResourceCostContainerRuntime ResourceCostContainer { get; set; }
            private TownRaiserImGui.GumRuntimes.ActionStackContainerRuntime ActionStackContainerInstance { get; set; }
            private TownRaiserImGui.GumRuntimes.SelectedButtonDisplayRuntime SelectedBuilding { get; set; }
            private TownRaiserImGui.GumRuntimes.XButtonRuntime XButtonInstance { get; set; }
            public string MenuTitleDisplayText
            {
                get
                {
                    return MenuTitleDisplayInstance.DisplayText;
                }
                set
                {
                    if (MenuTitleDisplayInstance.DisplayText != value)
                    {
                        MenuTitleDisplayInstance.DisplayText = value;
                        MenuTitleDisplayTextChanged?.Invoke(this, null);
                    }
                }
            }
            public event FlatRedBall.Gui.WindowEvent BuildMenuButtonInstanceClick;
            public event FlatRedBall.Gui.WindowEvent MenuTitleDisplayInstanceClick;
            public event FlatRedBall.Gui.WindowEvent ResourceCostContainerClick;
            public event FlatRedBall.Gui.WindowEvent ActionStackContainerInstanceClick;
            public event FlatRedBall.Gui.WindowEvent SelectedBuildingClick;
            public event FlatRedBall.Gui.WindowEvent XButtonInstanceClick;
            public event System.EventHandler MenuTitleDisplayTextChanged;
            public ActionToolbarRuntime (bool fullInstantiation = true, bool tryCreateFormsObject = true) 
            	: base(false, tryCreateFormsObject)
            {
                this.HasEvents = false;
                this.ExposeChildrenEvents = true;
                if (fullInstantiation)
                {
                    Gum.DataTypes.ElementSave elementSave = Gum.Managers.ObjectFinder.Self.GumProjectSave.Components.First(item => item.Name == "ActionToolbar");
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
                Background = this.GetGraphicalUiElementByName("Background") as TownRaiserImGui.GumRuntimes.NineSliceRuntime;
                BuildMenuButtonInstance = this.GetGraphicalUiElementByName("BuildMenuButtonInstance") as TownRaiserImGui.GumRuntimes.FramedButtonRuntime;
                MenuTitleDisplayInstance = this.GetGraphicalUiElementByName("MenuTitleDisplayInstance") as TownRaiserImGui.GumRuntimes.MenuTitleDisplayRuntime;
                ResourceCostContainer = this.GetGraphicalUiElementByName("ResourceCostContainer") as TownRaiserImGui.GumRuntimes.ResourceCostContainerRuntime;
                ActionStackContainerInstance = this.GetGraphicalUiElementByName("ActionStackContainerInstance") as TownRaiserImGui.GumRuntimes.ActionStackContainerRuntime;
                SelectedBuilding = this.GetGraphicalUiElementByName("SelectedBuilding") as TownRaiserImGui.GumRuntimes.SelectedButtonDisplayRuntime;
                XButtonInstance = this.GetGraphicalUiElementByName("XButtonInstance") as TownRaiserImGui.GumRuntimes.XButtonRuntime;
                BuildMenuButtonInstance.Click += (unused) => BuildMenuButtonInstanceClick?.Invoke(this);
                MenuTitleDisplayInstance.Click += (unused) => MenuTitleDisplayInstanceClick?.Invoke(this);
                ResourceCostContainer.Click += (unused) => ResourceCostContainerClick?.Invoke(this);
                ActionStackContainerInstance.Click += (unused) => ActionStackContainerInstanceClick?.Invoke(this);
                SelectedBuilding.Click += (unused) => SelectedBuildingClick?.Invoke(this);
                XButtonInstance.Click += (unused) => XButtonInstanceClick?.Invoke(this);
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
