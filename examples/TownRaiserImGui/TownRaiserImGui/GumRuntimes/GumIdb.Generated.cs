    namespace FlatRedBall.Gum
    {
        public  class GumIdbExtensions
        {
            public static void RegisterTypes () 
            {
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("Circle", typeof(TownRaiserImGui.GumRuntimes.CircleRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("ColoredRectangle", typeof(TownRaiserImGui.GumRuntimes.ColoredRectangleRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("Container", typeof(TownRaiserImGui.GumRuntimes.ContainerRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("Container<T>", typeof(TownRaiserImGui.GumRuntimes.ContainerRuntime<>));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("NineSlice", typeof(TownRaiserImGui.GumRuntimes.NineSliceRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("Rectangle", typeof(TownRaiserImGui.GumRuntimes.RectangleRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("Sprite", typeof(TownRaiserImGui.GumRuntimes.SpriteRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("Text", typeof(TownRaiserImGui.GumRuntimes.TextRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("Polygon", typeof(TownRaiserImGui.GumRuntimes.PolygonRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("ActionStackContainer", typeof(TownRaiserImGui.GumRuntimes.ActionStackContainerRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("ActionToolbar", typeof(TownRaiserImGui.GumRuntimes.ActionToolbarRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("FontTest", typeof(TownRaiserImGui.GumRuntimes.FontTestRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("FramedButton", typeof(TownRaiserImGui.GumRuntimes.FramedButtonRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("GroupSelector", typeof(TownRaiserImGui.GumRuntimes.GroupSelectorRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("HealthBar", typeof(TownRaiserImGui.GumRuntimes.HealthBarRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("IconButton", typeof(TownRaiserImGui.GumRuntimes.IconButtonRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("MenuTitleDisplay", typeof(TownRaiserImGui.GumRuntimes.MenuTitleDisplayRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("MinimapContents", typeof(TownRaiserImGui.GumRuntimes.MinimapContentsRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("Resource", typeof(TownRaiserImGui.GumRuntimes.ResourceRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("ResourceCostContainer", typeof(TownRaiserImGui.GumRuntimes.ResourceCostContainerRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("ResourceCostDisplay", typeof(TownRaiserImGui.GumRuntimes.ResourceCostDisplayRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("ResourceDisplay", typeof(TownRaiserImGui.GumRuntimes.ResourceDisplayRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("SelectedButtonDisplay", typeof(TownRaiserImGui.GumRuntimes.SelectedButtonDisplayRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("TrainingUnitSprite", typeof(TownRaiserImGui.GumRuntimes.TrainingUnitSpriteRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("XButton", typeof(TownRaiserImGui.GumRuntimes.XButtonRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("GameScreenGum", typeof(TownRaiserImGui.GumRuntimes.GameScreenGumRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("MainMenuGum", typeof(TownRaiserImGui.GumRuntimes.MainMenuGumRuntime));
                GumRuntime.ElementSaveExtensions.RegisterGueInstantiationType("TestScreenGum", typeof(TownRaiserImGui.GumRuntimes.TestScreenGumRuntime));
            }
        }
    }
