    using System.Linq;
    namespace TownRaiserImGui.GumRuntimes
    {
        public partial class ResourceCostContainerRuntime : TownRaiserImGui.GumRuntimes.ContainerRuntime
        {
            #region State Enums
            public enum VariableState
            {
                Default
            }
            public enum MenuType
            {
                BuildMenu,
                TrainUnits
            }
            #endregion
            #region State Fields
            VariableState mCurrentVariableState;
            MenuType? mCurrentMenuTypeState;
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
                            Gold.CurrentResourceTypeState = TownRaiserImGui.GumRuntimes.ResourceCostDisplayRuntime.ResourceType.Gold;
                            Lumber.CurrentResourceTypeState = TownRaiserImGui.GumRuntimes.ResourceCostDisplayRuntime.ResourceType.Lumber;
                            Stone.CurrentResourceTypeState = TownRaiserImGui.GumRuntimes.ResourceCostDisplayRuntime.ResourceType.Stone;
                            Capacity.CurrentResourceTypeState = TownRaiserImGui.GumRuntimes.ResourceCostDisplayRuntime.ResourceType.Capacity;
                            ChildrenLayout = Gum.Managers.ChildrenLayout.Regular;
                            ClipsChildren = false;
                            Height = 0f;
                            HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToChildren;
                            Visible = true;
                            Width = 130f;
                            WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                            WrapsChildren = false;
                            X = 0f;
                            XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                            XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                            Y = 0f;
                            YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                            YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                            Gold.X = 0f;
                            Gold.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                            Gold.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                            Gold.Y = 0f;
                            Gold.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                            Gold.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            Lumber.X = 0f;
                            Lumber.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                            Lumber.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            Lumber.Y = 0f;
                            Lumber.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                            Lumber.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            Stone.X = 0f;
                            Stone.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Right;
                            Stone.XUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                            Stone.Y = 0f;
                            Stone.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                            Stone.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            break;
                    }
                }
            }
            public MenuType? CurrentMenuTypeState
            {
                get
                {
                    return mCurrentMenuTypeState;
                }
                set
                {
                    if (value != null)
                    {
                        mCurrentMenuTypeState = value;
                        switch(mCurrentMenuTypeState)
                        {
                            case  MenuType.BuildMenu:
                                Gold.Visible = false;
                                Gold.Width = 42f;
                                Gold.X = 0f;
                                Gold.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                                Gold.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                                Lumber.Visible = true;
                                Lumber.Width = 64f;
                                Lumber.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                                Lumber.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                                Stone.Visible = true;
                                Stone.Width = 64f;
                                Capacity.Visible = false;
                                break;
                            case  MenuType.TrainUnits:
                                Gold.Visible = true;
                                Gold.Width = 64f;
                                Gold.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Right;
                                Gold.XUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                                Lumber.Visible = false;
                                Stone.Visible = false;
                                Capacity.Visible = true;
                                Capacity.Width = 64f;
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
                bool setCapacityCurrentResourceTypeStateFirstValue = false;
                bool setCapacityCurrentResourceTypeStateSecondValue = false;
                TownRaiserImGui.GumRuntimes.ResourceCostDisplayRuntime.ResourceType CapacityCurrentResourceTypeStateFirstValue= TownRaiserImGui.GumRuntimes.ResourceCostDisplayRuntime.ResourceType.Gold;
                TownRaiserImGui.GumRuntimes.ResourceCostDisplayRuntime.ResourceType CapacityCurrentResourceTypeStateSecondValue= TownRaiserImGui.GumRuntimes.ResourceCostDisplayRuntime.ResourceType.Gold;
                bool setGoldCurrentResourceTypeStateFirstValue = false;
                bool setGoldCurrentResourceTypeStateSecondValue = false;
                TownRaiserImGui.GumRuntimes.ResourceCostDisplayRuntime.ResourceType GoldCurrentResourceTypeStateFirstValue= TownRaiserImGui.GumRuntimes.ResourceCostDisplayRuntime.ResourceType.Gold;
                TownRaiserImGui.GumRuntimes.ResourceCostDisplayRuntime.ResourceType GoldCurrentResourceTypeStateSecondValue= TownRaiserImGui.GumRuntimes.ResourceCostDisplayRuntime.ResourceType.Gold;
                bool setGoldXFirstValue = false;
                bool setGoldXSecondValue = false;
                float GoldXFirstValue= 0;
                float GoldXSecondValue= 0;
                bool setGoldYFirstValue = false;
                bool setGoldYSecondValue = false;
                float GoldYFirstValue= 0;
                float GoldYSecondValue= 0;
                bool setHeightFirstValue = false;
                bool setHeightSecondValue = false;
                float HeightFirstValue= 0;
                float HeightSecondValue= 0;
                bool setLumberCurrentResourceTypeStateFirstValue = false;
                bool setLumberCurrentResourceTypeStateSecondValue = false;
                TownRaiserImGui.GumRuntimes.ResourceCostDisplayRuntime.ResourceType LumberCurrentResourceTypeStateFirstValue= TownRaiserImGui.GumRuntimes.ResourceCostDisplayRuntime.ResourceType.Gold;
                TownRaiserImGui.GumRuntimes.ResourceCostDisplayRuntime.ResourceType LumberCurrentResourceTypeStateSecondValue= TownRaiserImGui.GumRuntimes.ResourceCostDisplayRuntime.ResourceType.Gold;
                bool setLumberXFirstValue = false;
                bool setLumberXSecondValue = false;
                float LumberXFirstValue= 0;
                float LumberXSecondValue= 0;
                bool setLumberYFirstValue = false;
                bool setLumberYSecondValue = false;
                float LumberYFirstValue= 0;
                float LumberYSecondValue= 0;
                bool setStoneCurrentResourceTypeStateFirstValue = false;
                bool setStoneCurrentResourceTypeStateSecondValue = false;
                TownRaiserImGui.GumRuntimes.ResourceCostDisplayRuntime.ResourceType StoneCurrentResourceTypeStateFirstValue= TownRaiserImGui.GumRuntimes.ResourceCostDisplayRuntime.ResourceType.Gold;
                TownRaiserImGui.GumRuntimes.ResourceCostDisplayRuntime.ResourceType StoneCurrentResourceTypeStateSecondValue= TownRaiserImGui.GumRuntimes.ResourceCostDisplayRuntime.ResourceType.Gold;
                bool setStoneXFirstValue = false;
                bool setStoneXSecondValue = false;
                float StoneXFirstValue= 0;
                float StoneXSecondValue= 0;
                bool setStoneYFirstValue = false;
                bool setStoneYSecondValue = false;
                float StoneYFirstValue= 0;
                float StoneYSecondValue= 0;
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
                        setCapacityCurrentResourceTypeStateFirstValue = true;
                        CapacityCurrentResourceTypeStateFirstValue = TownRaiserImGui.GumRuntimes.ResourceCostDisplayRuntime.ResourceType.Capacity;
                        if (interpolationValue < 1)
                        {
                            this.ChildrenLayout = Gum.Managers.ChildrenLayout.Regular;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ClipsChildren = false;
                        }
                        setGoldCurrentResourceTypeStateFirstValue = true;
                        GoldCurrentResourceTypeStateFirstValue = TownRaiserImGui.GumRuntimes.ResourceCostDisplayRuntime.ResourceType.Gold;
                        setGoldXFirstValue = true;
                        GoldXFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.Gold.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        if (interpolationValue < 1)
                        {
                            this.Gold.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        setGoldYFirstValue = true;
                        GoldYFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.Gold.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.Gold.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setHeightFirstValue = true;
                        HeightFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToChildren;
                        }
                        setLumberCurrentResourceTypeStateFirstValue = true;
                        LumberCurrentResourceTypeStateFirstValue = TownRaiserImGui.GumRuntimes.ResourceCostDisplayRuntime.ResourceType.Lumber;
                        setLumberXFirstValue = true;
                        LumberXFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.Lumber.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.Lumber.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setLumberYFirstValue = true;
                        LumberYFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.Lumber.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.Lumber.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setStoneCurrentResourceTypeStateFirstValue = true;
                        StoneCurrentResourceTypeStateFirstValue = TownRaiserImGui.GumRuntimes.ResourceCostDisplayRuntime.ResourceType.Stone;
                        setStoneXFirstValue = true;
                        StoneXFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.Stone.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Right;
                        }
                        if (interpolationValue < 1)
                        {
                            this.Stone.XUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        setStoneYFirstValue = true;
                        StoneYFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.Stone.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.Stone.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        if (interpolationValue < 1)
                        {
                            this.Visible = true;
                        }
                        setWidthFirstValue = true;
                        WidthFirstValue = 130f;
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
                        setCapacityCurrentResourceTypeStateSecondValue = true;
                        CapacityCurrentResourceTypeStateSecondValue = TownRaiserImGui.GumRuntimes.ResourceCostDisplayRuntime.ResourceType.Capacity;
                        if (interpolationValue >= 1)
                        {
                            this.ChildrenLayout = Gum.Managers.ChildrenLayout.Regular;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ClipsChildren = false;
                        }
                        setGoldCurrentResourceTypeStateSecondValue = true;
                        GoldCurrentResourceTypeStateSecondValue = TownRaiserImGui.GumRuntimes.ResourceCostDisplayRuntime.ResourceType.Gold;
                        setGoldXSecondValue = true;
                        GoldXSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.Gold.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.Gold.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        setGoldYSecondValue = true;
                        GoldYSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.Gold.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.Gold.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setHeightSecondValue = true;
                        HeightSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToChildren;
                        }
                        setLumberCurrentResourceTypeStateSecondValue = true;
                        LumberCurrentResourceTypeStateSecondValue = TownRaiserImGui.GumRuntimes.ResourceCostDisplayRuntime.ResourceType.Lumber;
                        setLumberXSecondValue = true;
                        LumberXSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.Lumber.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.Lumber.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setLumberYSecondValue = true;
                        LumberYSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.Lumber.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.Lumber.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setStoneCurrentResourceTypeStateSecondValue = true;
                        StoneCurrentResourceTypeStateSecondValue = TownRaiserImGui.GumRuntimes.ResourceCostDisplayRuntime.ResourceType.Stone;
                        setStoneXSecondValue = true;
                        StoneXSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.Stone.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Right;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.Stone.XUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        setStoneYSecondValue = true;
                        StoneYSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.Stone.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.Stone.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.Visible = true;
                        }
                        setWidthSecondValue = true;
                        WidthSecondValue = 130f;
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
                if (setCapacityCurrentResourceTypeStateFirstValue && setCapacityCurrentResourceTypeStateSecondValue)
                {
                    Capacity.InterpolateBetween(CapacityCurrentResourceTypeStateFirstValue, CapacityCurrentResourceTypeStateSecondValue, interpolationValue);
                }
                if (setGoldCurrentResourceTypeStateFirstValue && setGoldCurrentResourceTypeStateSecondValue)
                {
                    Gold.InterpolateBetween(GoldCurrentResourceTypeStateFirstValue, GoldCurrentResourceTypeStateSecondValue, interpolationValue);
                }
                if (setGoldXFirstValue && setGoldXSecondValue)
                {
                    Gold.X = GoldXFirstValue * (1 - interpolationValue) + GoldXSecondValue * interpolationValue;
                }
                if (setGoldYFirstValue && setGoldYSecondValue)
                {
                    Gold.Y = GoldYFirstValue * (1 - interpolationValue) + GoldYSecondValue * interpolationValue;
                }
                if (setHeightFirstValue && setHeightSecondValue)
                {
                    Height = HeightFirstValue * (1 - interpolationValue) + HeightSecondValue * interpolationValue;
                }
                if (setLumberCurrentResourceTypeStateFirstValue && setLumberCurrentResourceTypeStateSecondValue)
                {
                    Lumber.InterpolateBetween(LumberCurrentResourceTypeStateFirstValue, LumberCurrentResourceTypeStateSecondValue, interpolationValue);
                }
                if (setLumberXFirstValue && setLumberXSecondValue)
                {
                    Lumber.X = LumberXFirstValue * (1 - interpolationValue) + LumberXSecondValue * interpolationValue;
                }
                if (setLumberYFirstValue && setLumberYSecondValue)
                {
                    Lumber.Y = LumberYFirstValue * (1 - interpolationValue) + LumberYSecondValue * interpolationValue;
                }
                if (setStoneCurrentResourceTypeStateFirstValue && setStoneCurrentResourceTypeStateSecondValue)
                {
                    Stone.InterpolateBetween(StoneCurrentResourceTypeStateFirstValue, StoneCurrentResourceTypeStateSecondValue, interpolationValue);
                }
                if (setStoneXFirstValue && setStoneXSecondValue)
                {
                    Stone.X = StoneXFirstValue * (1 - interpolationValue) + StoneXSecondValue * interpolationValue;
                }
                if (setStoneYFirstValue && setStoneYSecondValue)
                {
                    Stone.Y = StoneYFirstValue * (1 - interpolationValue) + StoneYSecondValue * interpolationValue;
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
            public void InterpolateBetween (MenuType firstState, MenuType secondState, float interpolationValue) 
            {
                #if DEBUG
                if (float.IsNaN(interpolationValue))
                {
                    throw new System.Exception("interpolationValue cannot be NaN");
                }
                #endif
                bool setGoldWidthFirstValue = false;
                bool setGoldWidthSecondValue = false;
                float GoldWidthFirstValue= 0;
                float GoldWidthSecondValue= 0;
                bool setGoldXFirstValue = false;
                bool setGoldXSecondValue = false;
                float GoldXFirstValue= 0;
                float GoldXSecondValue= 0;
                bool setLumberWidthFirstValue = false;
                bool setLumberWidthSecondValue = false;
                float LumberWidthFirstValue= 0;
                float LumberWidthSecondValue= 0;
                bool setStoneWidthFirstValue = false;
                bool setStoneWidthSecondValue = false;
                float StoneWidthFirstValue= 0;
                float StoneWidthSecondValue= 0;
                bool setCapacityWidthFirstValue = false;
                bool setCapacityWidthSecondValue = false;
                float CapacityWidthFirstValue= 0;
                float CapacityWidthSecondValue= 0;
                switch(firstState)
                {
                    case  MenuType.BuildMenu:
                        if (interpolationValue < 1)
                        {
                            this.Capacity.Visible = false;
                        }
                        if (interpolationValue < 1)
                        {
                            this.Gold.Visible = false;
                        }
                        setGoldWidthFirstValue = true;
                        GoldWidthFirstValue = 42f;
                        setGoldXFirstValue = true;
                        GoldXFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.Gold.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        if (interpolationValue < 1)
                        {
                            this.Gold.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        if (interpolationValue < 1)
                        {
                            this.Lumber.Visible = true;
                        }
                        setLumberWidthFirstValue = true;
                        LumberWidthFirstValue = 64f;
                        if (interpolationValue < 1)
                        {
                            this.Lumber.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        if (interpolationValue < 1)
                        {
                            this.Lumber.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        if (interpolationValue < 1)
                        {
                            this.Stone.Visible = true;
                        }
                        setStoneWidthFirstValue = true;
                        StoneWidthFirstValue = 64f;
                        break;
                    case  MenuType.TrainUnits:
                        if (interpolationValue < 1)
                        {
                            this.Capacity.Visible = true;
                        }
                        setCapacityWidthFirstValue = true;
                        CapacityWidthFirstValue = 64f;
                        if (interpolationValue < 1)
                        {
                            this.Gold.Visible = true;
                        }
                        setGoldWidthFirstValue = true;
                        GoldWidthFirstValue = 64f;
                        if (interpolationValue < 1)
                        {
                            this.Gold.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Right;
                        }
                        if (interpolationValue < 1)
                        {
                            this.Gold.XUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        if (interpolationValue < 1)
                        {
                            this.Lumber.Visible = false;
                        }
                        if (interpolationValue < 1)
                        {
                            this.Stone.Visible = false;
                        }
                        break;
                }
                switch(secondState)
                {
                    case  MenuType.BuildMenu:
                        if (interpolationValue >= 1)
                        {
                            this.Capacity.Visible = false;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.Gold.Visible = false;
                        }
                        setGoldWidthSecondValue = true;
                        GoldWidthSecondValue = 42f;
                        setGoldXSecondValue = true;
                        GoldXSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.Gold.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.Gold.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.Lumber.Visible = true;
                        }
                        setLumberWidthSecondValue = true;
                        LumberWidthSecondValue = 64f;
                        if (interpolationValue >= 1)
                        {
                            this.Lumber.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.Lumber.XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.Stone.Visible = true;
                        }
                        setStoneWidthSecondValue = true;
                        StoneWidthSecondValue = 64f;
                        break;
                    case  MenuType.TrainUnits:
                        if (interpolationValue >= 1)
                        {
                            this.Capacity.Visible = true;
                        }
                        setCapacityWidthSecondValue = true;
                        CapacityWidthSecondValue = 64f;
                        if (interpolationValue >= 1)
                        {
                            this.Gold.Visible = true;
                        }
                        setGoldWidthSecondValue = true;
                        GoldWidthSecondValue = 64f;
                        if (interpolationValue >= 1)
                        {
                            this.Gold.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Right;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.Gold.XUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.Lumber.Visible = false;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.Stone.Visible = false;
                        }
                        break;
                }
                if (setGoldWidthFirstValue && setGoldWidthSecondValue)
                {
                    Gold.Width = GoldWidthFirstValue * (1 - interpolationValue) + GoldWidthSecondValue * interpolationValue;
                }
                if (setGoldXFirstValue && setGoldXSecondValue)
                {
                    Gold.X = GoldXFirstValue * (1 - interpolationValue) + GoldXSecondValue * interpolationValue;
                }
                if (setLumberWidthFirstValue && setLumberWidthSecondValue)
                {
                    Lumber.Width = LumberWidthFirstValue * (1 - interpolationValue) + LumberWidthSecondValue * interpolationValue;
                }
                if (setStoneWidthFirstValue && setStoneWidthSecondValue)
                {
                    Stone.Width = StoneWidthFirstValue * (1 - interpolationValue) + StoneWidthSecondValue * interpolationValue;
                }
                if (setCapacityWidthFirstValue && setCapacityWidthSecondValue)
                {
                    Capacity.Width = CapacityWidthFirstValue * (1 - interpolationValue) + CapacityWidthSecondValue * interpolationValue;
                }
                if (interpolationValue < 1)
                {
                    mCurrentMenuTypeState = firstState;
                }
                else
                {
                    mCurrentMenuTypeState = secondState;
                }
            }
            #endregion
            #region State Interpolate To
            public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateTo (TownRaiserImGui.GumRuntimes.ResourceCostContainerRuntime.VariableState fromState,TownRaiserImGui.GumRuntimes.ResourceCostContainerRuntime.VariableState toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null) 
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
            public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateTo (TownRaiserImGui.GumRuntimes.ResourceCostContainerRuntime.MenuType fromState,TownRaiserImGui.GumRuntimes.ResourceCostContainerRuntime.MenuType toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null) 
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
            public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateTo (MenuType toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null ) 
            {
                Gum.DataTypes.Variables.StateSave current = GetCurrentValuesOnState(toState);
                Gum.DataTypes.Variables.StateSave toAsStateSave = this.ElementSave.Categories.First(item => item.Name == "MenuType").States.First(item => item.Name == toState.ToString());
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
                tweener.Ended += ()=> this.CurrentMenuTypeState = toState;
                tweener.Start();
                StateInterpolationPlugin.TweenerManager.Self.Add(tweener);
                return tweener;
            }
            public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateToRelative (MenuType toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null ) 
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
                tweener.Ended += ()=> this.CurrentMenuTypeState = toState;
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
                Gold.StopAnimations();
                Lumber.StopAnimations();
                Stone.StopAnimations();
                Capacity.StopAnimations();
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
                            Name = "Gold.ResourceTypeState",
                            Type = "ResourceTypeState",
                            Value = Gold.CurrentResourceTypeState
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Gold.X",
                            Type = "float",
                            Value = Gold.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Gold.X Origin",
                            Type = "HorizontalAlignment",
                            Value = Gold.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Gold.X Units",
                            Type = "PositionUnitType",
                            Value = Gold.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Gold.Y",
                            Type = "float",
                            Value = Gold.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Gold.Y Origin",
                            Type = "VerticalAlignment",
                            Value = Gold.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Gold.Y Units",
                            Type = "PositionUnitType",
                            Value = Gold.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Lumber.ResourceTypeState",
                            Type = "ResourceTypeState",
                            Value = Lumber.CurrentResourceTypeState
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Lumber.X",
                            Type = "float",
                            Value = Lumber.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Lumber.X Origin",
                            Type = "HorizontalAlignment",
                            Value = Lumber.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Lumber.X Units",
                            Type = "PositionUnitType",
                            Value = Lumber.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Lumber.Y",
                            Type = "float",
                            Value = Lumber.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Lumber.Y Origin",
                            Type = "VerticalAlignment",
                            Value = Lumber.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Lumber.Y Units",
                            Type = "PositionUnitType",
                            Value = Lumber.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Stone.ResourceTypeState",
                            Type = "ResourceTypeState",
                            Value = Stone.CurrentResourceTypeState
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Stone.X",
                            Type = "float",
                            Value = Stone.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Stone.X Origin",
                            Type = "HorizontalAlignment",
                            Value = Stone.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Stone.X Units",
                            Type = "PositionUnitType",
                            Value = Stone.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Stone.Y",
                            Type = "float",
                            Value = Stone.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Stone.Y Origin",
                            Type = "VerticalAlignment",
                            Value = Stone.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Stone.Y Units",
                            Type = "PositionUnitType",
                            Value = Stone.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Capacity.ResourceTypeState",
                            Type = "ResourceTypeState",
                            Value = Capacity.CurrentResourceTypeState
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
                            Value = Height + 0f
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
                            Value = Width + 130f
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
                            Name = "Gold.ResourceTypeState",
                            Type = "ResourceTypeState",
                            Value = Gold.CurrentResourceTypeState
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Gold.X",
                            Type = "float",
                            Value = Gold.X + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Gold.X Origin",
                            Type = "HorizontalAlignment",
                            Value = Gold.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Gold.X Units",
                            Type = "PositionUnitType",
                            Value = Gold.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Gold.Y",
                            Type = "float",
                            Value = Gold.Y + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Gold.Y Origin",
                            Type = "VerticalAlignment",
                            Value = Gold.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Gold.Y Units",
                            Type = "PositionUnitType",
                            Value = Gold.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Lumber.ResourceTypeState",
                            Type = "ResourceTypeState",
                            Value = Lumber.CurrentResourceTypeState
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Lumber.X",
                            Type = "float",
                            Value = Lumber.X + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Lumber.X Origin",
                            Type = "HorizontalAlignment",
                            Value = Lumber.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Lumber.X Units",
                            Type = "PositionUnitType",
                            Value = Lumber.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Lumber.Y",
                            Type = "float",
                            Value = Lumber.Y + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Lumber.Y Origin",
                            Type = "VerticalAlignment",
                            Value = Lumber.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Lumber.Y Units",
                            Type = "PositionUnitType",
                            Value = Lumber.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Stone.ResourceTypeState",
                            Type = "ResourceTypeState",
                            Value = Stone.CurrentResourceTypeState
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Stone.X",
                            Type = "float",
                            Value = Stone.X + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Stone.X Origin",
                            Type = "HorizontalAlignment",
                            Value = Stone.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Stone.X Units",
                            Type = "PositionUnitType",
                            Value = Stone.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Stone.Y",
                            Type = "float",
                            Value = Stone.Y + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Stone.Y Origin",
                            Type = "VerticalAlignment",
                            Value = Stone.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Stone.Y Units",
                            Type = "PositionUnitType",
                            Value = Stone.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Capacity.ResourceTypeState",
                            Type = "ResourceTypeState",
                            Value = Capacity.CurrentResourceTypeState
                        }
                        );
                        break;
                }
                return newState;
            }
            private Gum.DataTypes.Variables.StateSave GetCurrentValuesOnState (MenuType state) 
            {
                Gum.DataTypes.Variables.StateSave newState = new Gum.DataTypes.Variables.StateSave();
                switch(state)
                {
                    case  MenuType.BuildMenu:
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Gold.Visible",
                            Type = "bool",
                            Value = Gold.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Gold.Width",
                            Type = "float",
                            Value = Gold.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Gold.X",
                            Type = "float",
                            Value = Gold.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Gold.X Origin",
                            Type = "HorizontalAlignment",
                            Value = Gold.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Gold.X Units",
                            Type = "PositionUnitType",
                            Value = Gold.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Lumber.Visible",
                            Type = "bool",
                            Value = Lumber.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Lumber.Width",
                            Type = "float",
                            Value = Lumber.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Lumber.X Origin",
                            Type = "HorizontalAlignment",
                            Value = Lumber.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Lumber.X Units",
                            Type = "PositionUnitType",
                            Value = Lumber.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Stone.Visible",
                            Type = "bool",
                            Value = Stone.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Stone.Width",
                            Type = "float",
                            Value = Stone.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Capacity.Visible",
                            Type = "bool",
                            Value = Capacity.Visible
                        }
                        );
                        break;
                    case  MenuType.TrainUnits:
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Gold.Visible",
                            Type = "bool",
                            Value = Gold.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Gold.Width",
                            Type = "float",
                            Value = Gold.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Gold.X Origin",
                            Type = "HorizontalAlignment",
                            Value = Gold.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Gold.X Units",
                            Type = "PositionUnitType",
                            Value = Gold.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Lumber.Visible",
                            Type = "bool",
                            Value = Lumber.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Stone.Visible",
                            Type = "bool",
                            Value = Stone.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Capacity.Visible",
                            Type = "bool",
                            Value = Capacity.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Capacity.Width",
                            Type = "float",
                            Value = Capacity.Width
                        }
                        );
                        break;
                }
                return newState;
            }
            private Gum.DataTypes.Variables.StateSave AddToCurrentValuesWithState (MenuType state) 
            {
                Gum.DataTypes.Variables.StateSave newState = new Gum.DataTypes.Variables.StateSave();
                switch(state)
                {
                    case  MenuType.BuildMenu:
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Gold.Visible",
                            Type = "bool",
                            Value = Gold.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Gold.Width",
                            Type = "float",
                            Value = Gold.Width + 42f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Gold.X",
                            Type = "float",
                            Value = Gold.X + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Gold.X Origin",
                            Type = "HorizontalAlignment",
                            Value = Gold.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Gold.X Units",
                            Type = "PositionUnitType",
                            Value = Gold.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Lumber.Visible",
                            Type = "bool",
                            Value = Lumber.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Lumber.Width",
                            Type = "float",
                            Value = Lumber.Width + 64f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Lumber.X Origin",
                            Type = "HorizontalAlignment",
                            Value = Lumber.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Lumber.X Units",
                            Type = "PositionUnitType",
                            Value = Lumber.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Stone.Visible",
                            Type = "bool",
                            Value = Stone.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Stone.Width",
                            Type = "float",
                            Value = Stone.Width + 64f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Capacity.Visible",
                            Type = "bool",
                            Value = Capacity.Visible
                        }
                        );
                        break;
                    case  MenuType.TrainUnits:
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Gold.Visible",
                            Type = "bool",
                            Value = Gold.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Gold.Width",
                            Type = "float",
                            Value = Gold.Width + 64f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Gold.X Origin",
                            Type = "HorizontalAlignment",
                            Value = Gold.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Gold.X Units",
                            Type = "PositionUnitType",
                            Value = Gold.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Lumber.Visible",
                            Type = "bool",
                            Value = Lumber.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Stone.Visible",
                            Type = "bool",
                            Value = Stone.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Capacity.Visible",
                            Type = "bool",
                            Value = Capacity.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "Capacity.Width",
                            Type = "float",
                            Value = Capacity.Width + 64f
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
                    else if (category.Name == "MenuType")
                    {
                        if(state.Name == "BuildMenu") this.mCurrentMenuTypeState = MenuType.BuildMenu;
                        if(state.Name == "TrainUnits") this.mCurrentMenuTypeState = MenuType.TrainUnits;
                    }
                }
                base.ApplyState(state);
            }
            private TownRaiserImGui.GumRuntimes.ResourceCostDisplayRuntime Gold { get; set; }
            private TownRaiserImGui.GumRuntimes.ResourceCostDisplayRuntime Lumber { get; set; }
            private TownRaiserImGui.GumRuntimes.ResourceCostDisplayRuntime Stone { get; set; }
            private TownRaiserImGui.GumRuntimes.ResourceCostDisplayRuntime Capacity { get; set; }
            public string CapacityCostText
            {
                get
                {
                    return Capacity.CostText;
                }
                set
                {
                    if (Capacity.CostText != value)
                    {
                        Capacity.CostText = value;
                        CapacityCostTextChanged?.Invoke(this, null);
                    }
                }
            }
            public ResourceCostDisplayRuntime.TextColor? CapacityTextColorState
            {
                get
                {
                    return Capacity.CurrentTextColorState;
                }
                set
                {
                    if (Capacity.CurrentTextColorState != value)
                    {
                        Capacity.CurrentTextColorState = value;
                        CapacityTextColorStateChanged?.Invoke(this, null);
                    }
                }
            }
            public string GoldCostText
            {
                get
                {
                    return Gold.CostText;
                }
                set
                {
                    if (Gold.CostText != value)
                    {
                        Gold.CostText = value;
                        GoldCostTextChanged?.Invoke(this, null);
                    }
                }
            }
            public ResourceCostDisplayRuntime.TextColor? GoldTextColorState
            {
                get
                {
                    return Gold.CurrentTextColorState;
                }
                set
                {
                    if (Gold.CurrentTextColorState != value)
                    {
                        Gold.CurrentTextColorState = value;
                        GoldTextColorStateChanged?.Invoke(this, null);
                    }
                }
            }
            public string LumberCostText
            {
                get
                {
                    return Lumber.CostText;
                }
                set
                {
                    if (Lumber.CostText != value)
                    {
                        Lumber.CostText = value;
                        LumberCostTextChanged?.Invoke(this, null);
                    }
                }
            }
            public ResourceCostDisplayRuntime.TextColor? LumberTextColorState
            {
                get
                {
                    return Lumber.CurrentTextColorState;
                }
                set
                {
                    if (Lumber.CurrentTextColorState != value)
                    {
                        Lumber.CurrentTextColorState = value;
                        LumberTextColorStateChanged?.Invoke(this, null);
                    }
                }
            }
            public string StoneCostText
            {
                get
                {
                    return Stone.CostText;
                }
                set
                {
                    if (Stone.CostText != value)
                    {
                        Stone.CostText = value;
                        StoneCostTextChanged?.Invoke(this, null);
                    }
                }
            }
            public ResourceCostDisplayRuntime.TextColor? StoneTextColorState
            {
                get
                {
                    return Stone.CurrentTextColorState;
                }
                set
                {
                    if (Stone.CurrentTextColorState != value)
                    {
                        Stone.CurrentTextColorState = value;
                        StoneTextColorStateChanged?.Invoke(this, null);
                    }
                }
            }
            public event FlatRedBall.Gui.WindowEvent GoldClick;
            public event FlatRedBall.Gui.WindowEvent LumberClick;
            public event FlatRedBall.Gui.WindowEvent StoneClick;
            public event System.EventHandler CapacityCostTextChanged;
            public event System.EventHandler CapacityTextColorStateChanged;
            public event System.EventHandler GoldCostTextChanged;
            public event System.EventHandler GoldTextColorStateChanged;
            public event System.EventHandler LumberCostTextChanged;
            public event System.EventHandler LumberTextColorStateChanged;
            public event System.EventHandler StoneCostTextChanged;
            public event System.EventHandler StoneTextColorStateChanged;
            public ResourceCostContainerRuntime (bool fullInstantiation = true, bool tryCreateFormsObject = true) 
            	: base(false, tryCreateFormsObject)
            {
                this.HasEvents = true;
                this.ExposeChildrenEvents = true;
                if (fullInstantiation)
                {
                    Gum.DataTypes.ElementSave elementSave = Gum.Managers.ObjectFinder.Self.GumProjectSave.Components.First(item => item.Name == "ResourceCostContainer");
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
                Gold = this.GetGraphicalUiElementByName("Gold") as TownRaiserImGui.GumRuntimes.ResourceCostDisplayRuntime;
                Lumber = this.GetGraphicalUiElementByName("Lumber") as TownRaiserImGui.GumRuntimes.ResourceCostDisplayRuntime;
                Stone = this.GetGraphicalUiElementByName("Stone") as TownRaiserImGui.GumRuntimes.ResourceCostDisplayRuntime;
                Capacity = this.GetGraphicalUiElementByName("Capacity") as TownRaiserImGui.GumRuntimes.ResourceCostDisplayRuntime;
                Gold.Click += (unused) => GoldClick?.Invoke(this);
                Lumber.Click += (unused) => LumberClick?.Invoke(this);
                Stone.Click += (unused) => StoneClick?.Invoke(this);
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
