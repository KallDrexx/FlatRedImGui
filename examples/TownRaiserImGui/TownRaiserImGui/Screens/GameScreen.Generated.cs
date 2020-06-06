#if ANDROID || IOS || DESKTOP_GL
#define REQUIRES_PRIMARY_THREAD_LOADING
#endif
using Color = Microsoft.Xna.Framework.Color;
using System.Linq;
using FlatRedBall;
using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall.Graphics;
using FlatRedBall.Math;
namespace TownRaiserImGui.Screens
{
    public partial class GameScreen : FlatRedBall.Screens.Screen
    {
        #if DEBUG
        static bool HasBeenLoadedWithGlobalContentManager = false;
        #endif
        protected static FlatRedBall.Gum.GumIdb GameScreenGum;
        protected static FlatRedBall.TileGraphics.LayeredTileMap WorldMap;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect ui_collect_gold_1;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect ui_collect_lumber_1;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect ui_collect_stone_1;
        static Microsoft.Xna.Framework.Media.Song mFR_VictorySong;
        static string mLastContentManagerForFR_VictorySong;
        public static Microsoft.Xna.Framework.Media.Song FR_VictorySong
        {
            get
            {
                if (mFR_VictorySong == null || mLastContentManagerForFR_VictorySong != "GameScreen")
                {
                    mLastContentManagerForFR_VictorySong = "GameScreen";
                    mFR_VictorySong = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Media.Song>(@"content/screens/gamescreen/fr_victorysong", "GameScreen");
                }
                return mFR_VictorySong;
            }
        }
        static Microsoft.Xna.Framework.Media.Song mFR_BattleSong_Loop;
        static string mLastContentManagerForFR_BattleSong_Loop;
        public static Microsoft.Xna.Framework.Media.Song FR_BattleSong_Loop
        {
            get
            {
                if (mFR_BattleSong_Loop == null || mLastContentManagerForFR_BattleSong_Loop != "GameScreen")
                {
                    mLastContentManagerForFR_BattleSong_Loop = "GameScreen";
                    mFR_BattleSong_Loop = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Media.Song>(@"content/screens/gamescreen/fr_battlesong_loop", "GameScreen");
                }
                return mFR_BattleSong_Loop;
            }
        }
        static Microsoft.Xna.Framework.Media.Song mFR_TownSong_Loop;
        static string mLastContentManagerForFR_TownSong_Loop;
        public static Microsoft.Xna.Framework.Media.Song FR_TownSong_Loop
        {
            get
            {
                if (mFR_TownSong_Loop == null || mLastContentManagerForFR_TownSong_Loop != "GameScreen")
                {
                    mLastContentManagerForFR_TownSong_Loop = "GameScreen";
                    mFR_TownSong_Loop = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Media.Song>(@"content/screens/gamescreen/fr_townsong_loop", "GameScreen");
                }
                return mFR_TownSong_Loop;
            }
        }
        
        private FlatRedBall.Graphics.Layer UiLayer;
        private FlatRedBall.Math.PositionedObjectList<TownRaiserImGui.Entities.Building> BuildingList;
        private FlatRedBall.Math.PositionedObjectList<TownRaiserImGui.Entities.Unit> UnitList;
        private FlatRedBall.Math.PositionedObjectList<TownRaiserImGui.Entities.EncounterSpawnPoint> EncounterSpawnPointList;
        private TownRaiserImGui.GumRuntimes.ResourceDisplayRuntime ResourceDisplayInstance;
        private TownRaiserImGui.GumRuntimes.ActionToolbarRuntime ActionToolbarInstance;
        private FlatRedBall.Math.PositionedObjectList<TownRaiserImGui.Entities.SelectionMarker> SelectionMarkerList;
        private TownRaiserImGui.Entities.GroupSelector GroupSelectorInstance;
        private TownRaiserImGui.GumRuntimes.GroupSelectorRuntime GroupSelectorGumInstance;
        private TownRaiserImGui.Entities.BuildingMarker BuildingMarkerInstance;
        private FlatRedBall.Math.PositionedObjectList<TownRaiserImGui.Entities.RallyPointMarker> RallyPointMarkerList;
        private TownRaiserImGui.Entities.RoadManager RoadManagerInstance;
        private TownRaiserImGui.GumRuntimes.MinimapContentsRuntime MinimapInstance;
        private TownRaiserImGui.GumRuntimes.FramedButtonRuntime MinimapButtonInstance;
        public int Lumber = 200;
        public int Stone = 100;
        public int Gold = 300;
        public event FlatRedBall.Gui.WindowEvent MinimapButtonInstanceClick;
        protected global::RenderingLibrary.Graphics.Layer UiLayerGum;
        public GameScreen () 
        	: base ("GameScreen")
        {
        }
        public override void Initialize (bool addToManagers) 
        {
            LoadStaticContent(ContentManagerName);
            UiLayer = new FlatRedBall.Graphics.Layer();
            UiLayer.Name = "UiLayer";
            BuildingList = new FlatRedBall.Math.PositionedObjectList<TownRaiserImGui.Entities.Building>();
            BuildingList.Name = "BuildingList";
            UnitList = new FlatRedBall.Math.PositionedObjectList<TownRaiserImGui.Entities.Unit>();
            UnitList.Name = "UnitList";
            EncounterSpawnPointList = new FlatRedBall.Math.PositionedObjectList<TownRaiserImGui.Entities.EncounterSpawnPoint>();
            EncounterSpawnPointList.Name = "EncounterSpawnPointList";
            ResourceDisplayInstance = GameScreenGum.GetGraphicalUiElementByName("ResourceDisplayInstance") as TownRaiserImGui.GumRuntimes.ResourceDisplayRuntime;
            ActionToolbarInstance = GameScreenGum.GetGraphicalUiElementByName("ActionToolbarInstance") as TownRaiserImGui.GumRuntimes.ActionToolbarRuntime;
            SelectionMarkerList = new FlatRedBall.Math.PositionedObjectList<TownRaiserImGui.Entities.SelectionMarker>();
            SelectionMarkerList.Name = "SelectionMarkerList";
            GroupSelectorInstance = new TownRaiserImGui.Entities.GroupSelector(ContentManagerName, false);
            GroupSelectorInstance.Name = "GroupSelectorInstance";
            GroupSelectorGumInstance = GameScreenGum.GetGraphicalUiElementByName("GroupSelectorInstance") as TownRaiserImGui.GumRuntimes.GroupSelectorRuntime;
            BuildingMarkerInstance = new TownRaiserImGui.Entities.BuildingMarker(ContentManagerName, false);
            BuildingMarkerInstance.Name = "BuildingMarkerInstance";
            RallyPointMarkerList = new FlatRedBall.Math.PositionedObjectList<TownRaiserImGui.Entities.RallyPointMarker>();
            RallyPointMarkerList.Name = "RallyPointMarkerList";
            RoadManagerInstance = new TownRaiserImGui.Entities.RoadManager(ContentManagerName, false);
            RoadManagerInstance.Name = "RoadManagerInstance";
            MinimapInstance = GameScreenGum.GetGraphicalUiElementByName("MinimapContentsInstance") as TownRaiserImGui.GumRuntimes.MinimapContentsRuntime;
            MinimapButtonInstance = GameScreenGum.GetGraphicalUiElementByName("MinimapButtonInstance") as TownRaiserImGui.GumRuntimes.FramedButtonRuntime;
            
            
            PostInitialize();
            base.Initialize(addToManagers);
            if (addToManagers)
            {
                AddToManagers();
            }
        }
        public override void AddToManagers () 
        {
            GameScreenGum.InstanceInitialize(); FlatRedBall.FlatRedBallServices.GraphicsOptions.SizeOrOrientationChanged += GameScreenGum.HandleResolutionChanged;
            WorldMap.AddToManagers(mLayer);
            FlatRedBall.SpriteManager.AddLayer(UiLayer);
            UiLayer.UsePixelCoordinates();
            if (FlatRedBall.SpriteManager.Camera.Orthogonal)
            {
                UiLayer.LayerCameraSettings.OrthogonalWidth = FlatRedBall.SpriteManager.Camera.OrthogonalWidth;
                UiLayer.LayerCameraSettings.OrthogonalHeight = FlatRedBall.SpriteManager.Camera.OrthogonalHeight;
            }
            UiLayerGum = RenderingLibrary.SystemManagers.Default.Renderer.AddLayer();
            UiLayerGum.Name = "UiLayerGum";
            GameScreenGum.AddGumLayerToFrbLayer(UiLayerGum, UiLayer);
            Factories.BuildingFactory.Initialize(ContentManagerName);
            Factories.UnitFactory.Initialize(ContentManagerName);
            Factories.EncounterSpawnPointFactory.Initialize(ContentManagerName);
            Factories.RallyPointMarkerFactory.Initialize(ContentManagerName);
            Factories.BuildingFactory.AddList(BuildingList);
            Factories.UnitFactory.AddList(UnitList);
            Factories.EncounterSpawnPointFactory.AddList(EncounterSpawnPointList);
            Factories.RallyPointMarkerFactory.AddList(RallyPointMarkerList);
            GroupSelectorInstance.AddToManagers(mLayer);
            BuildingMarkerInstance.AddToManagers(mLayer);
            RoadManagerInstance.AddToManagers(mLayer);
            base.AddToManagers();
            AddToManagersBottomUp();
            CustomInitialize();
        }
        public override void Activity (bool firstTimeCalled) 
        {
            if (!IsPaused)
            {
                
                for (int i = BuildingList.Count - 1; i > -1; i--)
                {
                    if (i < BuildingList.Count)
                    {
                        // We do the extra if-check because activity could destroy any number of entities
                        BuildingList[i].Activity();
                    }
                }
                for (int i = UnitList.Count - 1; i > -1; i--)
                {
                    if (i < UnitList.Count)
                    {
                        // We do the extra if-check because activity could destroy any number of entities
                        UnitList[i].Activity();
                    }
                }
                for (int i = EncounterSpawnPointList.Count - 1; i > -1; i--)
                {
                    if (i < EncounterSpawnPointList.Count)
                    {
                        // We do the extra if-check because activity could destroy any number of entities
                        EncounterSpawnPointList[i].Activity();
                    }
                }
                for (int i = SelectionMarkerList.Count - 1; i > -1; i--)
                {
                    if (i < SelectionMarkerList.Count)
                    {
                        // We do the extra if-check because activity could destroy any number of entities
                        SelectionMarkerList[i].Activity();
                    }
                }
                GroupSelectorInstance.Activity();
                BuildingMarkerInstance.Activity();
                for (int i = RallyPointMarkerList.Count - 1; i > -1; i--)
                {
                    if (i < RallyPointMarkerList.Count)
                    {
                        // We do the extra if-check because activity could destroy any number of entities
                        RallyPointMarkerList[i].Activity();
                    }
                }
                RoadManagerInstance.Activity();
            }
            else
            {
            }
            base.Activity(firstTimeCalled);
            if (!IsActivityFinished)
            {
                CustomActivity(firstTimeCalled);
            }
        }
        public override void Destroy () 
        {
            base.Destroy();
            Factories.BuildingFactory.Destroy();
            Factories.UnitFactory.Destroy();
            Factories.EncounterSpawnPointFactory.Destroy();
            Factories.RallyPointMarkerFactory.Destroy();
            FlatRedBall.SpriteManager.RemoveDrawableBatch(GameScreenGum); FlatRedBall.FlatRedBallServices.GraphicsOptions.SizeOrOrientationChanged -= GameScreenGum.HandleResolutionChanged;
            GameScreenGum = null;
            WorldMap.Destroy();
            WorldMap = null;
            ui_collect_gold_1 = null;
            ui_collect_lumber_1 = null;
            ui_collect_stone_1 = null;
            if (mFR_VictorySong != null)
            {
                FlatRedBall.Audio.AudioManager.StopSong();
                if (this.UnloadsContentManagerWhenDestroyed && ContentManagerName != "Global")
                {
                    mFR_VictorySong.Dispose();
                }
                mFR_VictorySong = null;
            }
            if (mFR_BattleSong_Loop != null)
            {
                FlatRedBall.Audio.AudioManager.StopSong();
                if (this.UnloadsContentManagerWhenDestroyed && ContentManagerName != "Global")
                {
                    mFR_BattleSong_Loop.Dispose();
                }
                mFR_BattleSong_Loop = null;
            }
            if (mFR_TownSong_Loop != null)
            {
                FlatRedBall.Audio.AudioManager.StopSong();
                if (this.UnloadsContentManagerWhenDestroyed && ContentManagerName != "Global")
                {
                    mFR_TownSong_Loop.Dispose();
                }
                mFR_TownSong_Loop = null;
            }
            
            BuildingList.MakeOneWay();
            UnitList.MakeOneWay();
            EncounterSpawnPointList.MakeOneWay();
            SelectionMarkerList.MakeOneWay();
            RallyPointMarkerList.MakeOneWay();
            if (UiLayer != null)
            {
                FlatRedBall.SpriteManager.RemoveLayer(UiLayer);
            }
            for (int i = BuildingList.Count - 1; i > -1; i--)
            {
                BuildingList[i].Destroy();
            }
            for (int i = UnitList.Count - 1; i > -1; i--)
            {
                UnitList[i].Destroy();
            }
            for (int i = EncounterSpawnPointList.Count - 1; i > -1; i--)
            {
                EncounterSpawnPointList[i].Destroy();
            }
            if (ResourceDisplayInstance != null)
            {
                ResourceDisplayInstance.RemoveFromManagers();
            }
            if (ActionToolbarInstance != null)
            {
                ActionToolbarInstance.RemoveFromManagers();
            }
            for (int i = SelectionMarkerList.Count - 1; i > -1; i--)
            {
                SelectionMarkerList[i].Destroy();
            }
            if (GroupSelectorInstance != null)
            {
                GroupSelectorInstance.Destroy();
                GroupSelectorInstance.Detach();
            }
            if (GroupSelectorGumInstance != null)
            {
                GroupSelectorGumInstance.RemoveFromManagers();
            }
            if (BuildingMarkerInstance != null)
            {
                BuildingMarkerInstance.Destroy();
                BuildingMarkerInstance.Detach();
            }
            for (int i = RallyPointMarkerList.Count - 1; i > -1; i--)
            {
                RallyPointMarkerList[i].Destroy();
            }
            if (RoadManagerInstance != null)
            {
                RoadManagerInstance.Destroy();
                RoadManagerInstance.Detach();
            }
            if (MinimapInstance != null)
            {
                MinimapInstance.RemoveFromManagers();
            }
            if (MinimapButtonInstance != null)
            {
                MinimapButtonInstance.RemoveFromManagers();
            }
            BuildingList.MakeTwoWay();
            UnitList.MakeTwoWay();
            EncounterSpawnPointList.MakeTwoWay();
            SelectionMarkerList.MakeTwoWay();
            RallyPointMarkerList.MakeTwoWay();
            FlatRedBall.Math.Collision.CollisionManager.Self.Relationships.Clear();
            CustomDestroy();
        }
        public virtual void PostInitialize () 
        {
            bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
            MinimapButtonInstance.Click += OnMinimapButtonInstanceClick;
            MinimapButtonInstance.Click += OnMinimapButtonInstanceClickTunnel;
            if (RoadManagerInstance.Parent == null)
            {
                RoadManagerInstance.Z = 0.1f;
            }
            else
            {
                RoadManagerInstance.RelativeZ = 0.1f;
            }
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = oldShapeManagerSuppressAdd;
        }
        public virtual void AddToManagersBottomUp () 
        {
            CameraSetup.ResetCamera(SpriteManager.Camera);
            AssignCustomVariables(false);
        }
        public virtual void RemoveFromManagers () 
        {
            FlatRedBall.SpriteManager.RemoveDrawableBatch(GameScreenGum); FlatRedBall.FlatRedBallServices.GraphicsOptions.SizeOrOrientationChanged -= GameScreenGum.HandleResolutionChanged;
            WorldMap.Destroy();
            if (UiLayer != null)
            {
                FlatRedBall.SpriteManager.RemoveLayer(UiLayer);
            }
            for (int i = BuildingList.Count - 1; i > -1; i--)
            {
                BuildingList[i].Destroy();
            }
            for (int i = UnitList.Count - 1; i > -1; i--)
            {
                UnitList[i].Destroy();
            }
            for (int i = EncounterSpawnPointList.Count - 1; i > -1; i--)
            {
                EncounterSpawnPointList[i].Destroy();
            }
            if (ResourceDisplayInstance != null)
            {
                ResourceDisplayInstance.RemoveFromManagers();
            }
            if (ActionToolbarInstance != null)
            {
                ActionToolbarInstance.RemoveFromManagers();
            }
            for (int i = SelectionMarkerList.Count - 1; i > -1; i--)
            {
                SelectionMarkerList[i].Destroy();
            }
            GroupSelectorInstance.RemoveFromManagers();
            if (GroupSelectorGumInstance != null)
            {
                GroupSelectorGumInstance.RemoveFromManagers();
            }
            BuildingMarkerInstance.RemoveFromManagers();
            for (int i = RallyPointMarkerList.Count - 1; i > -1; i--)
            {
                RallyPointMarkerList[i].Destroy();
            }
            RoadManagerInstance.RemoveFromManagers();
            if (MinimapInstance != null)
            {
                MinimapInstance.RemoveFromManagers();
            }
            if (MinimapButtonInstance != null)
            {
                MinimapButtonInstance.RemoveFromManagers();
            }
        }
        public virtual void AssignCustomVariables (bool callOnContainedElements) 
        {
            if (callOnContainedElements)
            {
                GroupSelectorInstance.AssignCustomVariables(true);
                BuildingMarkerInstance.AssignCustomVariables(true);
                RoadManagerInstance.AssignCustomVariables(true);
            }
            if (RoadManagerInstance.Parent == null)
            {
                RoadManagerInstance.Z = 0.1f;
            }
            else
            {
                RoadManagerInstance.RelativeZ = 0.1f;
            }
            Lumber = 200;
            Stone = 100;
            Gold = 300;
        }
        public virtual void ConvertToManuallyUpdated () 
        {
            for (int i = 0; i < BuildingList.Count; i++)
            {
                BuildingList[i].ConvertToManuallyUpdated();
            }
            for (int i = 0; i < UnitList.Count; i++)
            {
                UnitList[i].ConvertToManuallyUpdated();
            }
            for (int i = 0; i < EncounterSpawnPointList.Count; i++)
            {
                EncounterSpawnPointList[i].ConvertToManuallyUpdated();
            }
            for (int i = 0; i < SelectionMarkerList.Count; i++)
            {
                SelectionMarkerList[i].ConvertToManuallyUpdated();
            }
            GroupSelectorInstance.ConvertToManuallyUpdated();
            BuildingMarkerInstance.ConvertToManuallyUpdated();
            for (int i = 0; i < RallyPointMarkerList.Count; i++)
            {
                RallyPointMarkerList[i].ConvertToManuallyUpdated();
            }
            RoadManagerInstance.ConvertToManuallyUpdated();
        }
        public static void LoadStaticContent (string contentManagerName) 
        {
            if (string.IsNullOrEmpty(contentManagerName))
            {
                throw new System.ArgumentException("contentManagerName cannot be empty or null");
            }
            // Set the content manager for Gum
            var contentManagerWrapper = new FlatRedBall.Gum.ContentManagerWrapper();
            contentManagerWrapper.ContentManagerName = contentManagerName;
            RenderingLibrary.Content.LoaderManager.Self.ContentLoader = contentManagerWrapper;
            // Access the GumProject just in case it's async loaded
            var throwaway = GlobalContent.GumProject;
            #if DEBUG
            if (contentManagerName == FlatRedBall.FlatRedBallServices.GlobalContentManager)
            {
                HasBeenLoadedWithGlobalContentManager = true;
            }
            else if (HasBeenLoadedWithGlobalContentManager)
            {
                throw new System.Exception("This type has been loaded with a Global content manager, then loaded with a non-global.  This can lead to a lot of bugs");
            }
            #endif
            if(GameScreenGum == null)
{
Gum.Wireframe.GraphicalUiElement.IsAllLayoutSuspended = true;
GameScreenGum = new FlatRedBall.Gum.GumIdb(); 
GameScreenGum.LoadFromFile("content/gumproject/screens/gamescreengum.gusx");  GameScreenGum.AssignReferences();Gum.Wireframe.GraphicalUiElement.IsAllLayoutSuspended = false;
GameScreenGum.Element.UpdateLayout();
GameScreenGum.Element.UpdateLayout();
};
            WorldMap = FlatRedBall.TileGraphics.LayeredTileMap.FromTiledMapSave("content/screens/gamescreen/worldmap.tmx", contentManagerName);
            ui_collect_gold_1 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/screens/gamescreen/sfx/ui_collect_gold_1", contentManagerName);
            ui_collect_lumber_1 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/screens/gamescreen/sfx/ui_collect_lumber_1", contentManagerName);
            ui_collect_stone_1 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/screens/gamescreen/sfx/ui_collect_stone_1", contentManagerName);
            TownRaiserImGui.Entities.GroupSelector.LoadStaticContent(contentManagerName);
            TownRaiserImGui.Entities.BuildingMarker.LoadStaticContent(contentManagerName);
            TownRaiserImGui.Entities.RoadManager.LoadStaticContent(contentManagerName);
            CustomLoadStaticContent(contentManagerName);
        }
        public override void PauseThisScreen () 
        {
            StateInterpolationPlugin.TweenerManager.Self.Pause();
            base.PauseThisScreen();
        }
        public override void UnpauseThisScreen () 
        {
            StateInterpolationPlugin.TweenerManager.Self.Unpause();
            base.UnpauseThisScreen();
        }
        [System.Obsolete("Use GetFile instead")]
        public static object GetStaticMember (string memberName) 
        {
            switch(memberName)
            {
                case  "GameScreenGum":
                    return GameScreenGum;
                case  "WorldMap":
                    return WorldMap;
                case  "ui_collect_gold_1":
                    return ui_collect_gold_1;
                case  "ui_collect_lumber_1":
                    return ui_collect_lumber_1;
                case  "ui_collect_stone_1":
                    return ui_collect_stone_1;
                case  "FR_VictorySong":
                    return FR_VictorySong;
                case  "FR_BattleSong_Loop":
                    return FR_BattleSong_Loop;
                case  "FR_TownSong_Loop":
                    return FR_TownSong_Loop;
            }
            return null;
        }
        public static object GetFile (string memberName) 
        {
            switch(memberName)
            {
                case  "GameScreenGum":
                    return GameScreenGum;
                case  "WorldMap":
                    return WorldMap;
                case  "ui_collect_gold_1":
                    return ui_collect_gold_1;
                case  "ui_collect_lumber_1":
                    return ui_collect_lumber_1;
                case  "ui_collect_stone_1":
                    return ui_collect_stone_1;
                case  "FR_VictorySong":
                    return FR_VictorySong;
                case  "FR_BattleSong_Loop":
                    return FR_BattleSong_Loop;
                case  "FR_TownSong_Loop":
                    return FR_TownSong_Loop;
            }
            return null;
        }
        object GetMember (string memberName) 
        {
            switch(memberName)
            {
                case  "GameScreenGum":
                    return GameScreenGum;
                case  "WorldMap":
                    return WorldMap;
                case  "ui_collect_gold_1":
                    return ui_collect_gold_1;
                case  "ui_collect_lumber_1":
                    return ui_collect_lumber_1;
                case  "ui_collect_stone_1":
                    return ui_collect_stone_1;
                case  "FR_VictorySong":
                    return FR_VictorySong;
                case  "FR_BattleSong_Loop":
                    return FR_BattleSong_Loop;
                case  "FR_TownSong_Loop":
                    return FR_TownSong_Loop;
            }
            return null;
        }
        private void RefreshLayoutInternal (object sender, EventArgs e) 
        {
            GameScreenGum.Element.UpdateLayout();
        }
    }
}
