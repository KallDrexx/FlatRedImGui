    using System.Linq;
    namespace TownRaiserImGui.GumRuntimes
    {
        public partial class IconButtonRuntime : TownRaiserImGui.GumRuntimes.ContainerRuntime
        {
            #region State Enums
            public enum VariableState
            {
                Default
            }
            public enum ButtonCategory
            {
                Enabled,
                Disabled,
                Highlighted,
                Pushed
            }
            #endregion
            #region State Fields
            VariableState mCurrentVariableState;
            ButtonCategory? mCurrentButtonCategoryState;
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
                            Height = 42f;
                            HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                            Visible = true;
                            Width = 42f;
                            WidthUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                            WrapsChildren = false;
                            XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Left;
                            XUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                            YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Top;
                            YUnits = Gum.Converters.GeneralUnitType.PixelsFromSmall;
                            ButtonBackground.Height = 0f;
                            ButtonBackground.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                            SetProperty("ButtonBackground.SourceFile", "..\\MainTileset.png");
                            ButtonBackground.TextureAddress = Gum.Managers.TextureAddress.Custom;
                            ButtonBackground.TextureHeight = 32;
                            ButtonBackground.TextureLeft = 480;
                            ButtonBackground.TextureTop = 64;
                            ButtonBackground.TextureWidth = 32;
                            ButtonBackground.Width = 0f;
                            ButtonBackground.WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                            ButtonBackground.X = 0f;
                            ButtonBackground.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                            ButtonBackground.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            ButtonBackground.Y = 0f;
                            ButtonBackground.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                            ButtonBackground.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            ProgressSprite.Height = 100f;
                            ProgressSprite.HeightUnits = Gum.DataTypes.DimensionUnitType.PercentageOfSourceFile;
                            SetProperty("ProgressSprite.SourceFile", "..\\MainTileset.png");
                            ProgressSprite.TextureAddress = Gum.Managers.TextureAddress.Custom;
                            ProgressSprite.TextureHeight = 42;
                            ProgressSprite.TextureLeft = 470;
                            ProgressSprite.TextureTop = 256;
                            ProgressSprite.TextureWidth = 42;
                            ProgressSprite.Visible = false;
                            ProgressSprite.Width = 100f;
                            ProgressSprite.WidthUnits = Gum.DataTypes.DimensionUnitType.PercentageOfSourceFile;
                            ProgressSprite.X = 0f;
                            ProgressSprite.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                            ProgressSprite.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            ProgressSprite.Y = 0f;
                            ProgressSprite.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Bottom;
                            ProgressSprite.YUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                            SpriteInstance.Height = 100f;
                            SpriteInstance.HeightUnits = Gum.DataTypes.DimensionUnitType.PercentageOfSourceFile;
                            SetProperty("SpriteInstance.SourceFile", "..\\MainTileset.png");
                            SpriteInstance.TextureAddress = Gum.Managers.TextureAddress.Custom;
                            SpriteInstance.TextureHeight = 14;
                            SpriteInstance.TextureLeft = 1;
                            SpriteInstance.TextureTop = 178;
                            SpriteInstance.TextureWidth = 14;
                            SpriteInstance.Width = 100f;
                            SpriteInstance.WidthUnits = Gum.DataTypes.DimensionUnitType.PercentageOfSourceFile;
                            SpriteInstance.X = 0f;
                            SpriteInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                            SpriteInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            SpriteInstance.Y = 0f;
                            SpriteInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                            SpriteInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                            SetProperty("TextInstance.CustomFontFile", "FontCache\\font-1.fnt");
                            TextInstance.Height = 12f;
                            TextInstance.HorizontalAlignment = RenderingLibrary.Graphics.HorizontalAlignment.Right;
                            TextInstance.Text = "0";
                            TextInstance.UseCustomFont = true;
                            TextInstance.VerticalAlignment = RenderingLibrary.Graphics.VerticalAlignment.Bottom;
                            TextInstance.Visible = false;
                            TextInstance.Width = 12f;
                            TextInstance.X = 0f;
                            TextInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Right;
                            TextInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                            TextInstance.Y = 0f;
                            TextInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Bottom;
                            TextInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                            break;
                    }
                }
            }
            public ButtonCategory? CurrentButtonCategoryState
            {
                get
                {
                    return mCurrentButtonCategoryState;
                }
                set
                {
                    if (value != null)
                    {
                        mCurrentButtonCategoryState = value;
                        switch(mCurrentButtonCategoryState)
                        {
                            case  ButtonCategory.Enabled:
                                ButtonBackground.TextureTop = 64;
                                break;
                            case  ButtonCategory.Disabled:
                                ButtonBackground.TextureTop = 128;
                                break;
                            case  ButtonCategory.Highlighted:
                                ButtonBackground.TextureTop = 96;
                                break;
                            case  ButtonCategory.Pushed:
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
                bool setButtonBackgroundHeightFirstValue = false;
                bool setButtonBackgroundHeightSecondValue = false;
                float ButtonBackgroundHeightFirstValue= 0;
                float ButtonBackgroundHeightSecondValue= 0;
                bool setButtonBackgroundTextureHeightFirstValue = false;
                bool setButtonBackgroundTextureHeightSecondValue = false;
                int ButtonBackgroundTextureHeightFirstValue= 0;
                int ButtonBackgroundTextureHeightSecondValue= 0;
                bool setButtonBackgroundTextureLeftFirstValue = false;
                bool setButtonBackgroundTextureLeftSecondValue = false;
                int ButtonBackgroundTextureLeftFirstValue= 0;
                int ButtonBackgroundTextureLeftSecondValue= 0;
                bool setButtonBackgroundTextureTopFirstValue = false;
                bool setButtonBackgroundTextureTopSecondValue = false;
                int ButtonBackgroundTextureTopFirstValue= 0;
                int ButtonBackgroundTextureTopSecondValue= 0;
                bool setButtonBackgroundTextureWidthFirstValue = false;
                bool setButtonBackgroundTextureWidthSecondValue = false;
                int ButtonBackgroundTextureWidthFirstValue= 0;
                int ButtonBackgroundTextureWidthSecondValue= 0;
                bool setButtonBackgroundWidthFirstValue = false;
                bool setButtonBackgroundWidthSecondValue = false;
                float ButtonBackgroundWidthFirstValue= 0;
                float ButtonBackgroundWidthSecondValue= 0;
                bool setButtonBackgroundXFirstValue = false;
                bool setButtonBackgroundXSecondValue = false;
                float ButtonBackgroundXFirstValue= 0;
                float ButtonBackgroundXSecondValue= 0;
                bool setButtonBackgroundYFirstValue = false;
                bool setButtonBackgroundYSecondValue = false;
                float ButtonBackgroundYFirstValue= 0;
                float ButtonBackgroundYSecondValue= 0;
                bool setHeightFirstValue = false;
                bool setHeightSecondValue = false;
                float HeightFirstValue= 0;
                float HeightSecondValue= 0;
                bool setProgressSpriteHeightFirstValue = false;
                bool setProgressSpriteHeightSecondValue = false;
                float ProgressSpriteHeightFirstValue= 0;
                float ProgressSpriteHeightSecondValue= 0;
                bool setProgressSpriteTextureHeightFirstValue = false;
                bool setProgressSpriteTextureHeightSecondValue = false;
                int ProgressSpriteTextureHeightFirstValue= 0;
                int ProgressSpriteTextureHeightSecondValue= 0;
                bool setProgressSpriteTextureLeftFirstValue = false;
                bool setProgressSpriteTextureLeftSecondValue = false;
                int ProgressSpriteTextureLeftFirstValue= 0;
                int ProgressSpriteTextureLeftSecondValue= 0;
                bool setProgressSpriteTextureTopFirstValue = false;
                bool setProgressSpriteTextureTopSecondValue = false;
                int ProgressSpriteTextureTopFirstValue= 0;
                int ProgressSpriteTextureTopSecondValue= 0;
                bool setProgressSpriteTextureWidthFirstValue = false;
                bool setProgressSpriteTextureWidthSecondValue = false;
                int ProgressSpriteTextureWidthFirstValue= 0;
                int ProgressSpriteTextureWidthSecondValue= 0;
                bool setProgressSpriteWidthFirstValue = false;
                bool setProgressSpriteWidthSecondValue = false;
                float ProgressSpriteWidthFirstValue= 0;
                float ProgressSpriteWidthSecondValue= 0;
                bool setProgressSpriteXFirstValue = false;
                bool setProgressSpriteXSecondValue = false;
                float ProgressSpriteXFirstValue= 0;
                float ProgressSpriteXSecondValue= 0;
                bool setProgressSpriteYFirstValue = false;
                bool setProgressSpriteYSecondValue = false;
                float ProgressSpriteYFirstValue= 0;
                float ProgressSpriteYSecondValue= 0;
                bool setSpriteInstanceHeightFirstValue = false;
                bool setSpriteInstanceHeightSecondValue = false;
                float SpriteInstanceHeightFirstValue= 0;
                float SpriteInstanceHeightSecondValue= 0;
                bool setSpriteInstanceTextureHeightFirstValue = false;
                bool setSpriteInstanceTextureHeightSecondValue = false;
                int SpriteInstanceTextureHeightFirstValue= 0;
                int SpriteInstanceTextureHeightSecondValue= 0;
                bool setSpriteInstanceTextureLeftFirstValue = false;
                bool setSpriteInstanceTextureLeftSecondValue = false;
                int SpriteInstanceTextureLeftFirstValue= 0;
                int SpriteInstanceTextureLeftSecondValue= 0;
                bool setSpriteInstanceTextureTopFirstValue = false;
                bool setSpriteInstanceTextureTopSecondValue = false;
                int SpriteInstanceTextureTopFirstValue= 0;
                int SpriteInstanceTextureTopSecondValue= 0;
                bool setSpriteInstanceTextureWidthFirstValue = false;
                bool setSpriteInstanceTextureWidthSecondValue = false;
                int SpriteInstanceTextureWidthFirstValue= 0;
                int SpriteInstanceTextureWidthSecondValue= 0;
                bool setSpriteInstanceWidthFirstValue = false;
                bool setSpriteInstanceWidthSecondValue = false;
                float SpriteInstanceWidthFirstValue= 0;
                float SpriteInstanceWidthSecondValue= 0;
                bool setSpriteInstanceXFirstValue = false;
                bool setSpriteInstanceXSecondValue = false;
                float SpriteInstanceXFirstValue= 0;
                float SpriteInstanceXSecondValue= 0;
                bool setSpriteInstanceYFirstValue = false;
                bool setSpriteInstanceYSecondValue = false;
                float SpriteInstanceYFirstValue= 0;
                float SpriteInstanceYSecondValue= 0;
                bool setTextInstanceHeightFirstValue = false;
                bool setTextInstanceHeightSecondValue = false;
                float TextInstanceHeightFirstValue= 0;
                float TextInstanceHeightSecondValue= 0;
                bool setTextInstanceWidthFirstValue = false;
                bool setTextInstanceWidthSecondValue = false;
                float TextInstanceWidthFirstValue= 0;
                float TextInstanceWidthSecondValue= 0;
                bool setTextInstanceXFirstValue = false;
                bool setTextInstanceXSecondValue = false;
                float TextInstanceXFirstValue= 0;
                float TextInstanceXSecondValue= 0;
                bool setTextInstanceYFirstValue = false;
                bool setTextInstanceYSecondValue = false;
                float TextInstanceYFirstValue= 0;
                float TextInstanceYSecondValue= 0;
                bool setWidthFirstValue = false;
                bool setWidthSecondValue = false;
                float WidthFirstValue= 0;
                float WidthSecondValue= 0;
                switch(firstState)
                {
                    case  VariableState.Default:
                        setButtonBackgroundHeightFirstValue = true;
                        ButtonBackgroundHeightFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.ButtonBackground.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        if (interpolationValue < 1)
                        {
                            SetProperty("ButtonBackground.SourceFile", "..\\MainTileset.png");
                        }
                        if (interpolationValue < 1)
                        {
                            this.ButtonBackground.TextureAddress = Gum.Managers.TextureAddress.Custom;
                        }
                        setButtonBackgroundTextureHeightFirstValue = true;
                        ButtonBackgroundTextureHeightFirstValue = 32;
                        setButtonBackgroundTextureLeftFirstValue = true;
                        ButtonBackgroundTextureLeftFirstValue = 480;
                        setButtonBackgroundTextureTopFirstValue = true;
                        ButtonBackgroundTextureTopFirstValue = 64;
                        setButtonBackgroundTextureWidthFirstValue = true;
                        ButtonBackgroundTextureWidthFirstValue = 32;
                        setButtonBackgroundWidthFirstValue = true;
                        ButtonBackgroundWidthFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.ButtonBackground.WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        setButtonBackgroundXFirstValue = true;
                        ButtonBackgroundXFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.ButtonBackground.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ButtonBackground.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setButtonBackgroundYFirstValue = true;
                        ButtonBackgroundYFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.ButtonBackground.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ButtonBackground.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
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
                        HeightFirstValue = 42f;
                        if (interpolationValue < 1)
                        {
                            this.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        setProgressSpriteHeightFirstValue = true;
                        ProgressSpriteHeightFirstValue = 100f;
                        if (interpolationValue < 1)
                        {
                            this.ProgressSprite.HeightUnits = Gum.DataTypes.DimensionUnitType.PercentageOfSourceFile;
                        }
                        if (interpolationValue < 1)
                        {
                            SetProperty("ProgressSprite.SourceFile", "..\\MainTileset.png");
                        }
                        if (interpolationValue < 1)
                        {
                            this.ProgressSprite.TextureAddress = Gum.Managers.TextureAddress.Custom;
                        }
                        setProgressSpriteTextureHeightFirstValue = true;
                        ProgressSpriteTextureHeightFirstValue = 42;
                        setProgressSpriteTextureLeftFirstValue = true;
                        ProgressSpriteTextureLeftFirstValue = 470;
                        setProgressSpriteTextureTopFirstValue = true;
                        ProgressSpriteTextureTopFirstValue = 256;
                        setProgressSpriteTextureWidthFirstValue = true;
                        ProgressSpriteTextureWidthFirstValue = 42;
                        if (interpolationValue < 1)
                        {
                            this.ProgressSprite.Visible = false;
                        }
                        setProgressSpriteWidthFirstValue = true;
                        ProgressSpriteWidthFirstValue = 100f;
                        if (interpolationValue < 1)
                        {
                            this.ProgressSprite.WidthUnits = Gum.DataTypes.DimensionUnitType.PercentageOfSourceFile;
                        }
                        setProgressSpriteXFirstValue = true;
                        ProgressSpriteXFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.ProgressSprite.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ProgressSprite.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setProgressSpriteYFirstValue = true;
                        ProgressSpriteYFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.ProgressSprite.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Bottom;
                        }
                        if (interpolationValue < 1)
                        {
                            this.ProgressSprite.YUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        setSpriteInstanceHeightFirstValue = true;
                        SpriteInstanceHeightFirstValue = 100f;
                        if (interpolationValue < 1)
                        {
                            this.SpriteInstance.HeightUnits = Gum.DataTypes.DimensionUnitType.PercentageOfSourceFile;
                        }
                        if (interpolationValue < 1)
                        {
                            SetProperty("SpriteInstance.SourceFile", "..\\MainTileset.png");
                        }
                        if (interpolationValue < 1)
                        {
                            this.SpriteInstance.TextureAddress = Gum.Managers.TextureAddress.Custom;
                        }
                        setSpriteInstanceTextureHeightFirstValue = true;
                        SpriteInstanceTextureHeightFirstValue = 14;
                        setSpriteInstanceTextureLeftFirstValue = true;
                        SpriteInstanceTextureLeftFirstValue = 1;
                        setSpriteInstanceTextureTopFirstValue = true;
                        SpriteInstanceTextureTopFirstValue = 178;
                        setSpriteInstanceTextureWidthFirstValue = true;
                        SpriteInstanceTextureWidthFirstValue = 14;
                        setSpriteInstanceWidthFirstValue = true;
                        SpriteInstanceWidthFirstValue = 100f;
                        if (interpolationValue < 1)
                        {
                            this.SpriteInstance.WidthUnits = Gum.DataTypes.DimensionUnitType.PercentageOfSourceFile;
                        }
                        setSpriteInstanceXFirstValue = true;
                        SpriteInstanceXFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.SpriteInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.SpriteInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setSpriteInstanceYFirstValue = true;
                        SpriteInstanceYFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.SpriteInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue < 1)
                        {
                            this.SpriteInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        if (interpolationValue < 1)
                        {
                            SetProperty("TextInstance.CustomFontFile", "FontCache\\font-1.fnt");
                        }
                        setTextInstanceHeightFirstValue = true;
                        TextInstanceHeightFirstValue = 12f;
                        if (interpolationValue < 1)
                        {
                            this.TextInstance.HorizontalAlignment = RenderingLibrary.Graphics.HorizontalAlignment.Right;
                        }
                        if (interpolationValue < 1)
                        {
                            this.TextInstance.Text = "0";
                        }
                        if (interpolationValue < 1)
                        {
                            this.TextInstance.UseCustomFont = true;
                        }
                        if (interpolationValue < 1)
                        {
                            this.TextInstance.VerticalAlignment = RenderingLibrary.Graphics.VerticalAlignment.Bottom;
                        }
                        if (interpolationValue < 1)
                        {
                            this.TextInstance.Visible = false;
                        }
                        setTextInstanceWidthFirstValue = true;
                        TextInstanceWidthFirstValue = 12f;
                        setTextInstanceXFirstValue = true;
                        TextInstanceXFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.TextInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Right;
                        }
                        if (interpolationValue < 1)
                        {
                            this.TextInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        setTextInstanceYFirstValue = true;
                        TextInstanceYFirstValue = 0f;
                        if (interpolationValue < 1)
                        {
                            this.TextInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Bottom;
                        }
                        if (interpolationValue < 1)
                        {
                            this.TextInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        if (interpolationValue < 1)
                        {
                            this.Visible = true;
                        }
                        setWidthFirstValue = true;
                        WidthFirstValue = 42f;
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
                        setButtonBackgroundHeightSecondValue = true;
                        ButtonBackgroundHeightSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.ButtonBackground.HeightUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        if (interpolationValue >= 1)
                        {
                            SetProperty("ButtonBackground.SourceFile", "..\\MainTileset.png");
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ButtonBackground.TextureAddress = Gum.Managers.TextureAddress.Custom;
                        }
                        setButtonBackgroundTextureHeightSecondValue = true;
                        ButtonBackgroundTextureHeightSecondValue = 32;
                        setButtonBackgroundTextureLeftSecondValue = true;
                        ButtonBackgroundTextureLeftSecondValue = 480;
                        setButtonBackgroundTextureTopSecondValue = true;
                        ButtonBackgroundTextureTopSecondValue = 64;
                        setButtonBackgroundTextureWidthSecondValue = true;
                        ButtonBackgroundTextureWidthSecondValue = 32;
                        setButtonBackgroundWidthSecondValue = true;
                        ButtonBackgroundWidthSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.ButtonBackground.WidthUnits = Gum.DataTypes.DimensionUnitType.RelativeToContainer;
                        }
                        setButtonBackgroundXSecondValue = true;
                        ButtonBackgroundXSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.ButtonBackground.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ButtonBackground.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setButtonBackgroundYSecondValue = true;
                        ButtonBackgroundYSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.ButtonBackground.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ButtonBackground.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
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
                        HeightSecondValue = 42f;
                        if (interpolationValue >= 1)
                        {
                            this.HeightUnits = Gum.DataTypes.DimensionUnitType.Absolute;
                        }
                        setProgressSpriteHeightSecondValue = true;
                        ProgressSpriteHeightSecondValue = 100f;
                        if (interpolationValue >= 1)
                        {
                            this.ProgressSprite.HeightUnits = Gum.DataTypes.DimensionUnitType.PercentageOfSourceFile;
                        }
                        if (interpolationValue >= 1)
                        {
                            SetProperty("ProgressSprite.SourceFile", "..\\MainTileset.png");
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ProgressSprite.TextureAddress = Gum.Managers.TextureAddress.Custom;
                        }
                        setProgressSpriteTextureHeightSecondValue = true;
                        ProgressSpriteTextureHeightSecondValue = 42;
                        setProgressSpriteTextureLeftSecondValue = true;
                        ProgressSpriteTextureLeftSecondValue = 470;
                        setProgressSpriteTextureTopSecondValue = true;
                        ProgressSpriteTextureTopSecondValue = 256;
                        setProgressSpriteTextureWidthSecondValue = true;
                        ProgressSpriteTextureWidthSecondValue = 42;
                        if (interpolationValue >= 1)
                        {
                            this.ProgressSprite.Visible = false;
                        }
                        setProgressSpriteWidthSecondValue = true;
                        ProgressSpriteWidthSecondValue = 100f;
                        if (interpolationValue >= 1)
                        {
                            this.ProgressSprite.WidthUnits = Gum.DataTypes.DimensionUnitType.PercentageOfSourceFile;
                        }
                        setProgressSpriteXSecondValue = true;
                        ProgressSpriteXSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.ProgressSprite.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ProgressSprite.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setProgressSpriteYSecondValue = true;
                        ProgressSpriteYSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.ProgressSprite.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Bottom;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.ProgressSprite.YUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        setSpriteInstanceHeightSecondValue = true;
                        SpriteInstanceHeightSecondValue = 100f;
                        if (interpolationValue >= 1)
                        {
                            this.SpriteInstance.HeightUnits = Gum.DataTypes.DimensionUnitType.PercentageOfSourceFile;
                        }
                        if (interpolationValue >= 1)
                        {
                            SetProperty("SpriteInstance.SourceFile", "..\\MainTileset.png");
                        }
                        if (interpolationValue >= 1)
                        {
                            this.SpriteInstance.TextureAddress = Gum.Managers.TextureAddress.Custom;
                        }
                        setSpriteInstanceTextureHeightSecondValue = true;
                        SpriteInstanceTextureHeightSecondValue = 14;
                        setSpriteInstanceTextureLeftSecondValue = true;
                        SpriteInstanceTextureLeftSecondValue = 1;
                        setSpriteInstanceTextureTopSecondValue = true;
                        SpriteInstanceTextureTopSecondValue = 178;
                        setSpriteInstanceTextureWidthSecondValue = true;
                        SpriteInstanceTextureWidthSecondValue = 14;
                        setSpriteInstanceWidthSecondValue = true;
                        SpriteInstanceWidthSecondValue = 100f;
                        if (interpolationValue >= 1)
                        {
                            this.SpriteInstance.WidthUnits = Gum.DataTypes.DimensionUnitType.PercentageOfSourceFile;
                        }
                        setSpriteInstanceXSecondValue = true;
                        SpriteInstanceXSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.SpriteInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.SpriteInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        setSpriteInstanceYSecondValue = true;
                        SpriteInstanceYSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.SpriteInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Center;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.SpriteInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromMiddle;
                        }
                        if (interpolationValue >= 1)
                        {
                            SetProperty("TextInstance.CustomFontFile", "FontCache\\font-1.fnt");
                        }
                        setTextInstanceHeightSecondValue = true;
                        TextInstanceHeightSecondValue = 12f;
                        if (interpolationValue >= 1)
                        {
                            this.TextInstance.HorizontalAlignment = RenderingLibrary.Graphics.HorizontalAlignment.Right;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.TextInstance.Text = "0";
                        }
                        if (interpolationValue >= 1)
                        {
                            this.TextInstance.UseCustomFont = true;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.TextInstance.VerticalAlignment = RenderingLibrary.Graphics.VerticalAlignment.Bottom;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.TextInstance.Visible = false;
                        }
                        setTextInstanceWidthSecondValue = true;
                        TextInstanceWidthSecondValue = 12f;
                        setTextInstanceXSecondValue = true;
                        TextInstanceXSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.TextInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Right;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.TextInstance.XUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        setTextInstanceYSecondValue = true;
                        TextInstanceYSecondValue = 0f;
                        if (interpolationValue >= 1)
                        {
                            this.TextInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Bottom;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.TextInstance.YUnits = Gum.Converters.GeneralUnitType.PixelsFromLarge;
                        }
                        if (interpolationValue >= 1)
                        {
                            this.Visible = true;
                        }
                        setWidthSecondValue = true;
                        WidthSecondValue = 42f;
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
                if (setButtonBackgroundHeightFirstValue && setButtonBackgroundHeightSecondValue)
                {
                    ButtonBackground.Height = ButtonBackgroundHeightFirstValue * (1 - interpolationValue) + ButtonBackgroundHeightSecondValue * interpolationValue;
                }
                if (setButtonBackgroundTextureHeightFirstValue && setButtonBackgroundTextureHeightSecondValue)
                {
                    ButtonBackground.TextureHeight = FlatRedBall.Math.MathFunctions.RoundToInt(ButtonBackgroundTextureHeightFirstValue* (1 - interpolationValue) + ButtonBackgroundTextureHeightSecondValue * interpolationValue);
                }
                if (setButtonBackgroundTextureLeftFirstValue && setButtonBackgroundTextureLeftSecondValue)
                {
                    ButtonBackground.TextureLeft = FlatRedBall.Math.MathFunctions.RoundToInt(ButtonBackgroundTextureLeftFirstValue* (1 - interpolationValue) + ButtonBackgroundTextureLeftSecondValue * interpolationValue);
                }
                if (setButtonBackgroundTextureTopFirstValue && setButtonBackgroundTextureTopSecondValue)
                {
                    ButtonBackground.TextureTop = FlatRedBall.Math.MathFunctions.RoundToInt(ButtonBackgroundTextureTopFirstValue* (1 - interpolationValue) + ButtonBackgroundTextureTopSecondValue * interpolationValue);
                }
                if (setButtonBackgroundTextureWidthFirstValue && setButtonBackgroundTextureWidthSecondValue)
                {
                    ButtonBackground.TextureWidth = FlatRedBall.Math.MathFunctions.RoundToInt(ButtonBackgroundTextureWidthFirstValue* (1 - interpolationValue) + ButtonBackgroundTextureWidthSecondValue * interpolationValue);
                }
                if (setButtonBackgroundWidthFirstValue && setButtonBackgroundWidthSecondValue)
                {
                    ButtonBackground.Width = ButtonBackgroundWidthFirstValue * (1 - interpolationValue) + ButtonBackgroundWidthSecondValue * interpolationValue;
                }
                if (setButtonBackgroundXFirstValue && setButtonBackgroundXSecondValue)
                {
                    ButtonBackground.X = ButtonBackgroundXFirstValue * (1 - interpolationValue) + ButtonBackgroundXSecondValue * interpolationValue;
                }
                if (setButtonBackgroundYFirstValue && setButtonBackgroundYSecondValue)
                {
                    ButtonBackground.Y = ButtonBackgroundYFirstValue * (1 - interpolationValue) + ButtonBackgroundYSecondValue * interpolationValue;
                }
                if (setHeightFirstValue && setHeightSecondValue)
                {
                    Height = HeightFirstValue * (1 - interpolationValue) + HeightSecondValue * interpolationValue;
                }
                if (setProgressSpriteHeightFirstValue && setProgressSpriteHeightSecondValue)
                {
                    ProgressSprite.Height = ProgressSpriteHeightFirstValue * (1 - interpolationValue) + ProgressSpriteHeightSecondValue * interpolationValue;
                }
                if (setProgressSpriteTextureHeightFirstValue && setProgressSpriteTextureHeightSecondValue)
                {
                    ProgressSprite.TextureHeight = FlatRedBall.Math.MathFunctions.RoundToInt(ProgressSpriteTextureHeightFirstValue* (1 - interpolationValue) + ProgressSpriteTextureHeightSecondValue * interpolationValue);
                }
                if (setProgressSpriteTextureLeftFirstValue && setProgressSpriteTextureLeftSecondValue)
                {
                    ProgressSprite.TextureLeft = FlatRedBall.Math.MathFunctions.RoundToInt(ProgressSpriteTextureLeftFirstValue* (1 - interpolationValue) + ProgressSpriteTextureLeftSecondValue * interpolationValue);
                }
                if (setProgressSpriteTextureTopFirstValue && setProgressSpriteTextureTopSecondValue)
                {
                    ProgressSprite.TextureTop = FlatRedBall.Math.MathFunctions.RoundToInt(ProgressSpriteTextureTopFirstValue* (1 - interpolationValue) + ProgressSpriteTextureTopSecondValue * interpolationValue);
                }
                if (setProgressSpriteTextureWidthFirstValue && setProgressSpriteTextureWidthSecondValue)
                {
                    ProgressSprite.TextureWidth = FlatRedBall.Math.MathFunctions.RoundToInt(ProgressSpriteTextureWidthFirstValue* (1 - interpolationValue) + ProgressSpriteTextureWidthSecondValue * interpolationValue);
                }
                if (setProgressSpriteWidthFirstValue && setProgressSpriteWidthSecondValue)
                {
                    ProgressSprite.Width = ProgressSpriteWidthFirstValue * (1 - interpolationValue) + ProgressSpriteWidthSecondValue * interpolationValue;
                }
                if (setProgressSpriteXFirstValue && setProgressSpriteXSecondValue)
                {
                    ProgressSprite.X = ProgressSpriteXFirstValue * (1 - interpolationValue) + ProgressSpriteXSecondValue * interpolationValue;
                }
                if (setProgressSpriteYFirstValue && setProgressSpriteYSecondValue)
                {
                    ProgressSprite.Y = ProgressSpriteYFirstValue * (1 - interpolationValue) + ProgressSpriteYSecondValue * interpolationValue;
                }
                if (setSpriteInstanceHeightFirstValue && setSpriteInstanceHeightSecondValue)
                {
                    SpriteInstance.Height = SpriteInstanceHeightFirstValue * (1 - interpolationValue) + SpriteInstanceHeightSecondValue * interpolationValue;
                }
                if (setSpriteInstanceTextureHeightFirstValue && setSpriteInstanceTextureHeightSecondValue)
                {
                    SpriteInstance.TextureHeight = FlatRedBall.Math.MathFunctions.RoundToInt(SpriteInstanceTextureHeightFirstValue* (1 - interpolationValue) + SpriteInstanceTextureHeightSecondValue * interpolationValue);
                }
                if (setSpriteInstanceTextureLeftFirstValue && setSpriteInstanceTextureLeftSecondValue)
                {
                    SpriteInstance.TextureLeft = FlatRedBall.Math.MathFunctions.RoundToInt(SpriteInstanceTextureLeftFirstValue* (1 - interpolationValue) + SpriteInstanceTextureLeftSecondValue * interpolationValue);
                }
                if (setSpriteInstanceTextureTopFirstValue && setSpriteInstanceTextureTopSecondValue)
                {
                    SpriteInstance.TextureTop = FlatRedBall.Math.MathFunctions.RoundToInt(SpriteInstanceTextureTopFirstValue* (1 - interpolationValue) + SpriteInstanceTextureTopSecondValue * interpolationValue);
                }
                if (setSpriteInstanceTextureWidthFirstValue && setSpriteInstanceTextureWidthSecondValue)
                {
                    SpriteInstance.TextureWidth = FlatRedBall.Math.MathFunctions.RoundToInt(SpriteInstanceTextureWidthFirstValue* (1 - interpolationValue) + SpriteInstanceTextureWidthSecondValue * interpolationValue);
                }
                if (setSpriteInstanceWidthFirstValue && setSpriteInstanceWidthSecondValue)
                {
                    SpriteInstance.Width = SpriteInstanceWidthFirstValue * (1 - interpolationValue) + SpriteInstanceWidthSecondValue * interpolationValue;
                }
                if (setSpriteInstanceXFirstValue && setSpriteInstanceXSecondValue)
                {
                    SpriteInstance.X = SpriteInstanceXFirstValue * (1 - interpolationValue) + SpriteInstanceXSecondValue * interpolationValue;
                }
                if (setSpriteInstanceYFirstValue && setSpriteInstanceYSecondValue)
                {
                    SpriteInstance.Y = SpriteInstanceYFirstValue * (1 - interpolationValue) + SpriteInstanceYSecondValue * interpolationValue;
                }
                if (setTextInstanceHeightFirstValue && setTextInstanceHeightSecondValue)
                {
                    TextInstance.Height = TextInstanceHeightFirstValue * (1 - interpolationValue) + TextInstanceHeightSecondValue * interpolationValue;
                }
                if (setTextInstanceWidthFirstValue && setTextInstanceWidthSecondValue)
                {
                    TextInstance.Width = TextInstanceWidthFirstValue * (1 - interpolationValue) + TextInstanceWidthSecondValue * interpolationValue;
                }
                if (setTextInstanceXFirstValue && setTextInstanceXSecondValue)
                {
                    TextInstance.X = TextInstanceXFirstValue * (1 - interpolationValue) + TextInstanceXSecondValue * interpolationValue;
                }
                if (setTextInstanceYFirstValue && setTextInstanceYSecondValue)
                {
                    TextInstance.Y = TextInstanceYFirstValue * (1 - interpolationValue) + TextInstanceYSecondValue * interpolationValue;
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
            public void InterpolateBetween (ButtonCategory firstState, ButtonCategory secondState, float interpolationValue) 
            {
                #if DEBUG
                if (float.IsNaN(interpolationValue))
                {
                    throw new System.Exception("interpolationValue cannot be NaN");
                }
                #endif
                bool setButtonBackgroundTextureTopFirstValue = false;
                bool setButtonBackgroundTextureTopSecondValue = false;
                int ButtonBackgroundTextureTopFirstValue= 0;
                int ButtonBackgroundTextureTopSecondValue= 0;
                switch(firstState)
                {
                    case  ButtonCategory.Enabled:
                        setButtonBackgroundTextureTopFirstValue = true;
                        ButtonBackgroundTextureTopFirstValue = 64;
                        break;
                    case  ButtonCategory.Disabled:
                        setButtonBackgroundTextureTopFirstValue = true;
                        ButtonBackgroundTextureTopFirstValue = 128;
                        break;
                    case  ButtonCategory.Highlighted:
                        setButtonBackgroundTextureTopFirstValue = true;
                        ButtonBackgroundTextureTopFirstValue = 96;
                        break;
                    case  ButtonCategory.Pushed:
                        break;
                }
                switch(secondState)
                {
                    case  ButtonCategory.Enabled:
                        setButtonBackgroundTextureTopSecondValue = true;
                        ButtonBackgroundTextureTopSecondValue = 64;
                        break;
                    case  ButtonCategory.Disabled:
                        setButtonBackgroundTextureTopSecondValue = true;
                        ButtonBackgroundTextureTopSecondValue = 128;
                        break;
                    case  ButtonCategory.Highlighted:
                        setButtonBackgroundTextureTopSecondValue = true;
                        ButtonBackgroundTextureTopSecondValue = 96;
                        break;
                    case  ButtonCategory.Pushed:
                        break;
                }
                if (setButtonBackgroundTextureTopFirstValue && setButtonBackgroundTextureTopSecondValue)
                {
                    ButtonBackground.TextureTop = FlatRedBall.Math.MathFunctions.RoundToInt(ButtonBackgroundTextureTopFirstValue* (1 - interpolationValue) + ButtonBackgroundTextureTopSecondValue * interpolationValue);
                }
                if (interpolationValue < 1)
                {
                    mCurrentButtonCategoryState = firstState;
                }
                else
                {
                    mCurrentButtonCategoryState = secondState;
                }
            }
            #endregion
            #region State Interpolate To
            public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateTo (TownRaiserImGui.GumRuntimes.IconButtonRuntime.VariableState fromState,TownRaiserImGui.GumRuntimes.IconButtonRuntime.VariableState toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null) 
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
            public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateTo (TownRaiserImGui.GumRuntimes.IconButtonRuntime.ButtonCategory fromState,TownRaiserImGui.GumRuntimes.IconButtonRuntime.ButtonCategory toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null) 
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
            public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateTo (ButtonCategory toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null ) 
            {
                Gum.DataTypes.Variables.StateSave current = GetCurrentValuesOnState(toState);
                Gum.DataTypes.Variables.StateSave toAsStateSave = this.ElementSave.Categories.First(item => item.Name == "ButtonCategory").States.First(item => item.Name == toState.ToString());
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
                tweener.Ended += ()=> this.CurrentButtonCategoryState = toState;
                tweener.Start();
                StateInterpolationPlugin.TweenerManager.Self.Add(tweener);
                return tweener;
            }
            public FlatRedBall.Glue.StateInterpolation.Tweener InterpolateToRelative (ButtonCategory toState, double secondsToTake, FlatRedBall.Glue.StateInterpolation.InterpolationType interpolationType, FlatRedBall.Glue.StateInterpolation.Easing easing, object owner = null ) 
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
                tweener.Ended += ()=> this.CurrentButtonCategoryState = toState;
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
                            Name = "ButtonBackground.Height",
                            Type = "float",
                            Value = ButtonBackground.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBackground.Height Units",
                            Type = "DimensionUnitType",
                            Value = ButtonBackground.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBackground.SourceFile",
                            Type = "string",
                            Value = ButtonBackground.SourceFile
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBackground.Texture Address",
                            Type = "TextureAddress",
                            Value = ButtonBackground.TextureAddress
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBackground.Texture Height",
                            Type = "int",
                            Value = ButtonBackground.TextureHeight
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBackground.Texture Left",
                            Type = "int",
                            Value = ButtonBackground.TextureLeft
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBackground.Texture Top",
                            Type = "int",
                            Value = ButtonBackground.TextureTop
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBackground.Texture Width",
                            Type = "int",
                            Value = ButtonBackground.TextureWidth
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBackground.Width",
                            Type = "float",
                            Value = ButtonBackground.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBackground.Width Units",
                            Type = "DimensionUnitType",
                            Value = ButtonBackground.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBackground.X",
                            Type = "float",
                            Value = ButtonBackground.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBackground.X Origin",
                            Type = "HorizontalAlignment",
                            Value = ButtonBackground.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBackground.X Units",
                            Type = "PositionUnitType",
                            Value = ButtonBackground.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBackground.Y",
                            Type = "float",
                            Value = ButtonBackground.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBackground.Y Origin",
                            Type = "VerticalAlignment",
                            Value = ButtonBackground.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBackground.Y Units",
                            Type = "PositionUnitType",
                            Value = ButtonBackground.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ProgressSprite.Height",
                            Type = "float",
                            Value = ProgressSprite.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ProgressSprite.Height Units",
                            Type = "DimensionUnitType",
                            Value = ProgressSprite.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ProgressSprite.SourceFile",
                            Type = "string",
                            Value = ProgressSprite.SourceFile
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ProgressSprite.Texture Address",
                            Type = "TextureAddress",
                            Value = ProgressSprite.TextureAddress
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ProgressSprite.Texture Height",
                            Type = "int",
                            Value = ProgressSprite.TextureHeight
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ProgressSprite.Texture Left",
                            Type = "int",
                            Value = ProgressSprite.TextureLeft
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ProgressSprite.Texture Top",
                            Type = "int",
                            Value = ProgressSprite.TextureTop
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ProgressSprite.Texture Width",
                            Type = "int",
                            Value = ProgressSprite.TextureWidth
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ProgressSprite.Visible",
                            Type = "bool",
                            Value = ProgressSprite.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ProgressSprite.Width",
                            Type = "float",
                            Value = ProgressSprite.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ProgressSprite.Width Units",
                            Type = "DimensionUnitType",
                            Value = ProgressSprite.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ProgressSprite.X",
                            Type = "float",
                            Value = ProgressSprite.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ProgressSprite.X Origin",
                            Type = "HorizontalAlignment",
                            Value = ProgressSprite.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ProgressSprite.X Units",
                            Type = "PositionUnitType",
                            Value = ProgressSprite.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ProgressSprite.Y",
                            Type = "float",
                            Value = ProgressSprite.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ProgressSprite.Y Origin",
                            Type = "VerticalAlignment",
                            Value = ProgressSprite.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ProgressSprite.Y Units",
                            Type = "PositionUnitType",
                            Value = ProgressSprite.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SpriteInstance.Height",
                            Type = "float",
                            Value = SpriteInstance.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SpriteInstance.Height Units",
                            Type = "DimensionUnitType",
                            Value = SpriteInstance.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SpriteInstance.SourceFile",
                            Type = "string",
                            Value = SpriteInstance.SourceFile
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SpriteInstance.Texture Address",
                            Type = "TextureAddress",
                            Value = SpriteInstance.TextureAddress
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SpriteInstance.Texture Height",
                            Type = "int",
                            Value = SpriteInstance.TextureHeight
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SpriteInstance.Texture Left",
                            Type = "int",
                            Value = SpriteInstance.TextureLeft
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SpriteInstance.Texture Top",
                            Type = "int",
                            Value = SpriteInstance.TextureTop
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SpriteInstance.Texture Width",
                            Type = "int",
                            Value = SpriteInstance.TextureWidth
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SpriteInstance.Width",
                            Type = "float",
                            Value = SpriteInstance.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SpriteInstance.Width Units",
                            Type = "DimensionUnitType",
                            Value = SpriteInstance.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SpriteInstance.X",
                            Type = "float",
                            Value = SpriteInstance.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SpriteInstance.X Origin",
                            Type = "HorizontalAlignment",
                            Value = SpriteInstance.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SpriteInstance.X Units",
                            Type = "PositionUnitType",
                            Value = SpriteInstance.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SpriteInstance.Y",
                            Type = "float",
                            Value = SpriteInstance.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SpriteInstance.Y Origin",
                            Type = "VerticalAlignment",
                            Value = SpriteInstance.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SpriteInstance.Y Units",
                            Type = "PositionUnitType",
                            Value = SpriteInstance.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextInstance.CustomFontFile",
                            Type = "string",
                            Value = TextInstance.CustomFontFile
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextInstance.Height",
                            Type = "float",
                            Value = TextInstance.Height
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextInstance.HorizontalAlignment",
                            Type = "HorizontalAlignment",
                            Value = TextInstance.HorizontalAlignment
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextInstance.Text",
                            Type = "string",
                            Value = TextInstance.Text
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextInstance.UseCustomFont",
                            Type = "bool",
                            Value = TextInstance.UseCustomFont
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextInstance.VerticalAlignment",
                            Type = "VerticalAlignment",
                            Value = TextInstance.VerticalAlignment
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextInstance.Visible",
                            Type = "bool",
                            Value = TextInstance.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextInstance.Width",
                            Type = "float",
                            Value = TextInstance.Width
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextInstance.X",
                            Type = "float",
                            Value = TextInstance.X
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextInstance.X Origin",
                            Type = "HorizontalAlignment",
                            Value = TextInstance.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextInstance.X Units",
                            Type = "PositionUnitType",
                            Value = TextInstance.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextInstance.Y",
                            Type = "float",
                            Value = TextInstance.Y
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextInstance.Y Origin",
                            Type = "VerticalAlignment",
                            Value = TextInstance.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextInstance.Y Units",
                            Type = "PositionUnitType",
                            Value = TextInstance.YUnits
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
                            Value = Height + 42f
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
                            Value = Width + 42f
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
                            Name = "ButtonBackground.Height",
                            Type = "float",
                            Value = ButtonBackground.Height + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBackground.Height Units",
                            Type = "DimensionUnitType",
                            Value = ButtonBackground.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBackground.SourceFile",
                            Type = "string",
                            Value = ButtonBackground.SourceFile
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBackground.Texture Address",
                            Type = "TextureAddress",
                            Value = ButtonBackground.TextureAddress
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBackground.Texture Height",
                            Type = "int",
                            Value = ButtonBackground.TextureHeight + 32
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBackground.Texture Left",
                            Type = "int",
                            Value = ButtonBackground.TextureLeft + 480
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBackground.Texture Top",
                            Type = "int",
                            Value = ButtonBackground.TextureTop + 64
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBackground.Texture Width",
                            Type = "int",
                            Value = ButtonBackground.TextureWidth + 32
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBackground.Width",
                            Type = "float",
                            Value = ButtonBackground.Width + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBackground.Width Units",
                            Type = "DimensionUnitType",
                            Value = ButtonBackground.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBackground.X",
                            Type = "float",
                            Value = ButtonBackground.X + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBackground.X Origin",
                            Type = "HorizontalAlignment",
                            Value = ButtonBackground.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBackground.X Units",
                            Type = "PositionUnitType",
                            Value = ButtonBackground.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBackground.Y",
                            Type = "float",
                            Value = ButtonBackground.Y + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBackground.Y Origin",
                            Type = "VerticalAlignment",
                            Value = ButtonBackground.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBackground.Y Units",
                            Type = "PositionUnitType",
                            Value = ButtonBackground.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ProgressSprite.Height",
                            Type = "float",
                            Value = ProgressSprite.Height + 100f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ProgressSprite.Height Units",
                            Type = "DimensionUnitType",
                            Value = ProgressSprite.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ProgressSprite.SourceFile",
                            Type = "string",
                            Value = ProgressSprite.SourceFile
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ProgressSprite.Texture Address",
                            Type = "TextureAddress",
                            Value = ProgressSprite.TextureAddress
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ProgressSprite.Texture Height",
                            Type = "int",
                            Value = ProgressSprite.TextureHeight + 42
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ProgressSprite.Texture Left",
                            Type = "int",
                            Value = ProgressSprite.TextureLeft + 470
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ProgressSprite.Texture Top",
                            Type = "int",
                            Value = ProgressSprite.TextureTop + 256
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ProgressSprite.Texture Width",
                            Type = "int",
                            Value = ProgressSprite.TextureWidth + 42
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ProgressSprite.Visible",
                            Type = "bool",
                            Value = ProgressSprite.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ProgressSprite.Width",
                            Type = "float",
                            Value = ProgressSprite.Width + 100f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ProgressSprite.Width Units",
                            Type = "DimensionUnitType",
                            Value = ProgressSprite.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ProgressSprite.X",
                            Type = "float",
                            Value = ProgressSprite.X + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ProgressSprite.X Origin",
                            Type = "HorizontalAlignment",
                            Value = ProgressSprite.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ProgressSprite.X Units",
                            Type = "PositionUnitType",
                            Value = ProgressSprite.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ProgressSprite.Y",
                            Type = "float",
                            Value = ProgressSprite.Y + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ProgressSprite.Y Origin",
                            Type = "VerticalAlignment",
                            Value = ProgressSprite.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ProgressSprite.Y Units",
                            Type = "PositionUnitType",
                            Value = ProgressSprite.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SpriteInstance.Height",
                            Type = "float",
                            Value = SpriteInstance.Height + 100f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SpriteInstance.Height Units",
                            Type = "DimensionUnitType",
                            Value = SpriteInstance.HeightUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SpriteInstance.SourceFile",
                            Type = "string",
                            Value = SpriteInstance.SourceFile
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SpriteInstance.Texture Address",
                            Type = "TextureAddress",
                            Value = SpriteInstance.TextureAddress
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SpriteInstance.Texture Height",
                            Type = "int",
                            Value = SpriteInstance.TextureHeight + 14
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SpriteInstance.Texture Left",
                            Type = "int",
                            Value = SpriteInstance.TextureLeft + 1
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SpriteInstance.Texture Top",
                            Type = "int",
                            Value = SpriteInstance.TextureTop + 178
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SpriteInstance.Texture Width",
                            Type = "int",
                            Value = SpriteInstance.TextureWidth + 14
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SpriteInstance.Width",
                            Type = "float",
                            Value = SpriteInstance.Width + 100f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SpriteInstance.Width Units",
                            Type = "DimensionUnitType",
                            Value = SpriteInstance.WidthUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SpriteInstance.X",
                            Type = "float",
                            Value = SpriteInstance.X + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SpriteInstance.X Origin",
                            Type = "HorizontalAlignment",
                            Value = SpriteInstance.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SpriteInstance.X Units",
                            Type = "PositionUnitType",
                            Value = SpriteInstance.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SpriteInstance.Y",
                            Type = "float",
                            Value = SpriteInstance.Y + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SpriteInstance.Y Origin",
                            Type = "VerticalAlignment",
                            Value = SpriteInstance.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "SpriteInstance.Y Units",
                            Type = "PositionUnitType",
                            Value = SpriteInstance.YUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextInstance.CustomFontFile",
                            Type = "string",
                            Value = TextInstance.CustomFontFile
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextInstance.Height",
                            Type = "float",
                            Value = TextInstance.Height + 12f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextInstance.HorizontalAlignment",
                            Type = "HorizontalAlignment",
                            Value = TextInstance.HorizontalAlignment
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextInstance.Text",
                            Type = "string",
                            Value = TextInstance.Text
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextInstance.UseCustomFont",
                            Type = "bool",
                            Value = TextInstance.UseCustomFont
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextInstance.VerticalAlignment",
                            Type = "VerticalAlignment",
                            Value = TextInstance.VerticalAlignment
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextInstance.Visible",
                            Type = "bool",
                            Value = TextInstance.Visible
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextInstance.Width",
                            Type = "float",
                            Value = TextInstance.Width + 12f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextInstance.X",
                            Type = "float",
                            Value = TextInstance.X + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextInstance.X Origin",
                            Type = "HorizontalAlignment",
                            Value = TextInstance.XOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextInstance.X Units",
                            Type = "PositionUnitType",
                            Value = TextInstance.XUnits
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextInstance.Y",
                            Type = "float",
                            Value = TextInstance.Y + 0f
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextInstance.Y Origin",
                            Type = "VerticalAlignment",
                            Value = TextInstance.YOrigin
                        }
                        );
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "TextInstance.Y Units",
                            Type = "PositionUnitType",
                            Value = TextInstance.YUnits
                        }
                        );
                        break;
                }
                return newState;
            }
            private Gum.DataTypes.Variables.StateSave GetCurrentValuesOnState (ButtonCategory state) 
            {
                Gum.DataTypes.Variables.StateSave newState = new Gum.DataTypes.Variables.StateSave();
                switch(state)
                {
                    case  ButtonCategory.Enabled:
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBackground.Texture Top",
                            Type = "int",
                            Value = ButtonBackground.TextureTop
                        }
                        );
                        break;
                    case  ButtonCategory.Disabled:
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBackground.Texture Top",
                            Type = "int",
                            Value = ButtonBackground.TextureTop
                        }
                        );
                        break;
                    case  ButtonCategory.Highlighted:
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBackground.Texture Top",
                            Type = "int",
                            Value = ButtonBackground.TextureTop
                        }
                        );
                        break;
                    case  ButtonCategory.Pushed:
                        break;
                }
                return newState;
            }
            private Gum.DataTypes.Variables.StateSave AddToCurrentValuesWithState (ButtonCategory state) 
            {
                Gum.DataTypes.Variables.StateSave newState = new Gum.DataTypes.Variables.StateSave();
                switch(state)
                {
                    case  ButtonCategory.Enabled:
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBackground.Texture Top",
                            Type = "int",
                            Value = ButtonBackground.TextureTop + 64
                        }
                        );
                        break;
                    case  ButtonCategory.Disabled:
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBackground.Texture Top",
                            Type = "int",
                            Value = ButtonBackground.TextureTop + 128
                        }
                        );
                        break;
                    case  ButtonCategory.Highlighted:
                        newState.Variables.Add(new Gum.DataTypes.Variables.VariableSave()
                        {
                            SetsValue = true,
                            Name = "ButtonBackground.Texture Top",
                            Type = "int",
                            Value = ButtonBackground.TextureTop + 96
                        }
                        );
                        break;
                    case  ButtonCategory.Pushed:
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
                    else if (category.Name == "ButtonCategory")
                    {
                        if(state.Name == "Enabled") this.mCurrentButtonCategoryState = ButtonCategory.Enabled;
                        if(state.Name == "Disabled") this.mCurrentButtonCategoryState = ButtonCategory.Disabled;
                        if(state.Name == "Highlighted") this.mCurrentButtonCategoryState = ButtonCategory.Highlighted;
                        if(state.Name == "Pushed") this.mCurrentButtonCategoryState = ButtonCategory.Pushed;
                    }
                }
                base.ApplyState(state);
            }
            private TownRaiserImGui.GumRuntimes.NineSliceRuntime ButtonBackground { get; set; }
            private TownRaiserImGui.GumRuntimes.SpriteRuntime ProgressSprite { get; set; }
            private TownRaiserImGui.GumRuntimes.SpriteRuntime SpriteInstance { get; set; }
            private TownRaiserImGui.GumRuntimes.TextRuntime TextInstance { get; set; }
            public IconButtonRuntime (bool fullInstantiation = true, bool tryCreateFormsObject = true) 
            	: base(false, tryCreateFormsObject)
            {
                this.HasEvents = true;
                this.ExposeChildrenEvents = true;
                if (fullInstantiation)
                {
                    Gum.DataTypes.ElementSave elementSave = Gum.Managers.ObjectFinder.Self.GumProjectSave.Components.First(item => item.Name == "IconButton");
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
                ButtonBackground = this.GetGraphicalUiElementByName("ButtonBackground") as TownRaiserImGui.GumRuntimes.NineSliceRuntime;
                ProgressSprite = this.GetGraphicalUiElementByName("ProgressSprite") as TownRaiserImGui.GumRuntimes.SpriteRuntime;
                SpriteInstance = this.GetGraphicalUiElementByName("SpriteInstance") as TownRaiserImGui.GumRuntimes.SpriteRuntime;
                TextInstance = this.GetGraphicalUiElementByName("TextInstance") as TownRaiserImGui.GumRuntimes.TextRuntime;
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
