#if ANDROID || IOS || DESKTOP_GL
#define REQUIRES_PRIMARY_THREAD_LOADING
#endif
using Color = Microsoft.Xna.Framework.Color;
using System.Linq;
using FlatRedBall.Graphics;
using FlatRedBall.Math;
using FlatRedBall.Gui;
using FlatRedBall;
using System;
using System.Collections.Generic;
using System.Text;
using FlatRedBall.Math.Geometry;
namespace TownRaiserImGui.Entities
{
    public partial class Building : FlatRedBall.PositionedObject, FlatRedBall.Graphics.IDestroyable, FlatRedBall.Performance.IPoolable, FlatRedBall.Gui.IClickable, FlatRedBall.Math.Geometry.ICollidable
    {
        // This is made static so that static lazy-loaded content can access it.
        public static string ContentManagerName { get; set; }
        #if DEBUG
        static bool HasBeenLoadedWithGlobalContentManager = false;
        #endif
        static object mLockObject = new object();
        static System.Collections.Generic.List<string> mRegisteredUnloads = new System.Collections.Generic.List<string>();
        static System.Collections.Generic.List<string> LoadedContentManagers = new System.Collections.Generic.List<string>();
        protected static Microsoft.Xna.Framework.Graphics.Texture2D MainTileset;
        protected static FlatRedBall.Graphics.Animation.AnimationChainList AnimationChainListFile;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect building_constuction_complete_barracks_1;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect building_constuction_complete_house_1;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect building_constuction_complete_tent_1;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect building_constuction_complete_townhall_1;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect building_constuction_start_generic_1;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect building_constuction_complete_generic_1;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_building_damage_1;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_building_damage_2;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_building_damage_3;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_building_damage_4;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_building_damage_5;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_building_damage_6;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_building_damage_7;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_building_damage_8;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_building_damage_9;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_building_damage_10;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_building_damage_11;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_building_damage_12;
        
        private FlatRedBall.Sprite SpriteInstance;
        private FlatRedBall.Math.Geometry.AxisAlignedRectangle mAxisAlignedRectangleInstance;
        public FlatRedBall.Math.Geometry.AxisAlignedRectangle AxisAlignedRectangleInstance
        {
            get
            {
                return mAxisAlignedRectangleInstance;
            }
            private set
            {
                mAxisAlignedRectangleInstance = value;
            }
        }
        private TownRaiserImGui.GumRuntimes.HealthBarRuntime HealthBarRuntimeInstance;
        public event Action<TownRaiserImGui.DataTypes.BuildingData> BeforeBuildingDataSet;
        public event System.EventHandler AfterBuildingDataSet;
        private TownRaiserImGui.DataTypes.BuildingData mBuildingData;
        public TownRaiserImGui.DataTypes.BuildingData BuildingData
        {
            set
            {
                if (BeforeBuildingDataSet != null)
                {
                    BeforeBuildingDataSet(value);
                }
                mBuildingData = value;
                if (AfterBuildingDataSet != null)
                {
                    AfterBuildingDataSet(this, null);
                }
            }
            get
            {
                return mBuildingData;
            }
        }
        public float SpriteInstanceAlpha
        {
            get
            {
                return SpriteInstance.Alpha;
            }
            set
            {
                SpriteInstance.Alpha = value;
            }
        }
        public int Index { get; set; }
        public bool Used { get; set; }
        System.Collections.Generic.List<GumCoreShared.FlatRedBall.Embedded.PositionedObjectGueWrapper> gumAttachmentWrappers = new System.Collections.Generic.List<GumCoreShared.FlatRedBall.Embedded.PositionedObjectGueWrapper>();
        private FlatRedBall.Math.Geometry.ShapeCollection mGeneratedCollision;
        public FlatRedBall.Math.Geometry.ShapeCollection Collision
        {
            get
            {
                return mGeneratedCollision;
            }
        }
        protected FlatRedBall.Graphics.Layer LayerProvidedByContainer = null;
        public Building () 
        	: this(FlatRedBall.Screens.ScreenManager.CurrentScreen.ContentManagerName, true)
        {
        }
        public Building (string contentManagerName) 
        	: this(contentManagerName, true)
        {
        }
        public Building (string contentManagerName, bool addToManagers) 
        	: base()
        {
            ContentManagerName = contentManagerName;
            InitializeEntity(addToManagers);
        }
        protected virtual void InitializeEntity (bool addToManagers) 
        {
            LoadStaticContent(ContentManagerName);
            SpriteInstance = new FlatRedBall.Sprite();
            SpriteInstance.Name = "SpriteInstance";
            mAxisAlignedRectangleInstance = new FlatRedBall.Math.Geometry.AxisAlignedRectangle();
            mAxisAlignedRectangleInstance.Name = "mAxisAlignedRectangleInstance";
            {var oldLayoutSuspended = global::Gum.Wireframe.GraphicalUiElement.IsAllLayoutSuspended; global::Gum.Wireframe.GraphicalUiElement.IsAllLayoutSuspended = true; HealthBarRuntimeInstance = new TownRaiserImGui.GumRuntimes.HealthBarRuntime();global::Gum.Wireframe.GraphicalUiElement.IsAllLayoutSuspended = oldLayoutSuspended; HealthBarRuntimeInstance.UpdateLayout();}
            
            PostInitialize();
            if (addToManagers)
            {
                AddToManagers(null);
            }
        }
        public virtual void ReAddToManagers (FlatRedBall.Graphics.Layer layerToAddTo) 
        {
            LayerProvidedByContainer = layerToAddTo;
            FlatRedBall.SpriteManager.AddPositionedObject(this);
            FlatRedBall.SpriteManager.AddToLayer(SpriteInstance, LayerProvidedByContainer);
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(mAxisAlignedRectangleInstance, LayerProvidedByContainer);
            {
HealthBarRuntimeInstance.AddToManagers(RenderingLibrary.SystemManagers.Default, System.Linq.Enumerable.FirstOrDefault(FlatRedBall.Gum.GumIdb.AllGumLayersOnFrbLayer(LayerProvidedByContainer)));
var wrapperForAttachment = new GumCoreShared.FlatRedBall.Embedded.PositionedObjectGueWrapper(this, HealthBarRuntimeInstance);
FlatRedBall.SpriteManager.AddPositionedObject(wrapperForAttachment);
gumAttachmentWrappers.Add(wrapperForAttachment);
}

        }
        public virtual void AddToManagers (FlatRedBall.Graphics.Layer layerToAddTo) 
        {
            LayerProvidedByContainer = layerToAddTo;
            FlatRedBall.SpriteManager.AddPositionedObject(this);
            FlatRedBall.SpriteManager.AddToLayer(SpriteInstance, LayerProvidedByContainer);
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(mAxisAlignedRectangleInstance, LayerProvidedByContainer);
            {
HealthBarRuntimeInstance.AddToManagers(RenderingLibrary.SystemManagers.Default, System.Linq.Enumerable.FirstOrDefault(FlatRedBall.Gum.GumIdb.AllGumLayersOnFrbLayer(LayerProvidedByContainer)));
var wrapperForAttachment = new GumCoreShared.FlatRedBall.Embedded.PositionedObjectGueWrapper(this, HealthBarRuntimeInstance);
FlatRedBall.SpriteManager.AddPositionedObject(wrapperForAttachment);
gumAttachmentWrappers.Add(wrapperForAttachment);
}

            AddToManagersBottomUp(layerToAddTo);
            CustomInitialize();
        }
        public virtual void Activity () 
        {
            mIsPaused = false;
            
            CustomActivity();
        }
        public virtual void Destroy () 
        {
            if (Used)
            {
                Factories.BuildingFactory.MakeUnused(this, false);
            }
            FlatRedBall.SpriteManager.RemovePositionedObject(this);
            
            if (SpriteInstance != null)
            {
                FlatRedBall.SpriteManager.RemoveSpriteOneWay(SpriteInstance);
            }
            if (AxisAlignedRectangleInstance != null)
            {
                FlatRedBall.Math.Geometry.ShapeManager.RemoveOneWay(AxisAlignedRectangleInstance);
            }
            if (HealthBarRuntimeInstance != null)
            {
                HealthBarRuntimeInstance.RemoveFromManagers();
            }
            for (int i = gumAttachmentWrappers.Count-1; i > -1; i--)
            {
                FlatRedBall.SpriteManager.RemovePositionedObject(gumAttachmentWrappers[i]);
            }
            mGeneratedCollision.RemoveFromManagers(clearThis: false);
            CustomDestroy();
        }
        public virtual void PostInitialize () 
        {
            bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
            this.AfterBuildingDataSet += OnAfterBuildingDataSet;
            if (SpriteInstance.Parent == null)
            {
                SpriteInstance.CopyAbsoluteToRelative();
                SpriteInstance.AttachTo(this, false);
            }
            SpriteInstance.TextureScale = 1f;
            SpriteInstance.AnimationChains = AnimationChainListFile;
            if (mAxisAlignedRectangleInstance.Parent == null)
            {
                mAxisAlignedRectangleInstance.CopyAbsoluteToRelative();
                mAxisAlignedRectangleInstance.AttachTo(this, false);
            }
            AxisAlignedRectangleInstance.Width = 48f;
            AxisAlignedRectangleInstance.Height = 48f;
            AxisAlignedRectangleInstance.Visible = false;
            AxisAlignedRectangleInstance.Color = Microsoft.Xna.Framework.Color.WhiteSmoke;
            HealthBarRuntimeInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
            HealthBarRuntimeInstance.Y = -14f;
            HealthBarRuntimeInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Bottom;
            mGeneratedCollision = new FlatRedBall.Math.Geometry.ShapeCollection();
            Collision.AxisAlignedRectangles.AddOneWay(mAxisAlignedRectangleInstance);
            FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = oldShapeManagerSuppressAdd;
        }
        public virtual void AddToManagersBottomUp (FlatRedBall.Graphics.Layer layerToAddTo) 
        {
            AssignCustomVariables(false);
        }
        public virtual void RemoveFromManagers () 
        {
            FlatRedBall.SpriteManager.ConvertToManuallyUpdated(this);
            if (SpriteInstance != null)
            {
                FlatRedBall.SpriteManager.RemoveSpriteOneWay(SpriteInstance);
            }
            if (AxisAlignedRectangleInstance != null)
            {
                FlatRedBall.Math.Geometry.ShapeManager.RemoveOneWay(AxisAlignedRectangleInstance);
            }
            if (HealthBarRuntimeInstance != null)
            {
                HealthBarRuntimeInstance.RemoveFromManagers();
            }
            mGeneratedCollision.RemoveFromManagers(clearThis: false);
        }
        public virtual void AssignCustomVariables (bool callOnContainedElements) 
        {
            if (callOnContainedElements)
            {
            }
            SpriteInstance.TextureScale = 1f;
            SpriteInstance.AnimationChains = AnimationChainListFile;
            AxisAlignedRectangleInstance.Width = 48f;
            AxisAlignedRectangleInstance.Height = 48f;
            AxisAlignedRectangleInstance.Visible = false;
            AxisAlignedRectangleInstance.Color = Microsoft.Xna.Framework.Color.WhiteSmoke;
            HealthBarRuntimeInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
            HealthBarRuntimeInstance.Y = -14f;
            HealthBarRuntimeInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Bottom;
            BuildingData = GlobalContent.BuildingData["Tent"];
            SpriteInstanceAlpha = 1f;
        }
        public virtual void ConvertToManuallyUpdated () 
        {
            this.ForceUpdateDependenciesDeep();
            FlatRedBall.SpriteManager.ConvertToManuallyUpdated(this);
            FlatRedBall.SpriteManager.ConvertToManuallyUpdated(SpriteInstance);
        }
        public static void LoadStaticContent (string contentManagerName) 
        {
            if (string.IsNullOrEmpty(contentManagerName))
            {
                throw new System.ArgumentException("contentManagerName cannot be empty or null");
            }
            ContentManagerName = contentManagerName;
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
            bool registerUnload = false;
            if (LoadedContentManagers.Contains(contentManagerName) == false)
            {
                LoadedContentManagers.Add(contentManagerName);
                lock (mLockObject)
                {
                    if (!mRegisteredUnloads.Contains(ContentManagerName) && ContentManagerName != FlatRedBall.FlatRedBallServices.GlobalContentManager)
                    {
                        FlatRedBall.FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("BuildingStaticUnload", UnloadStaticContent);
                        mRegisteredUnloads.Add(ContentManagerName);
                    }
                }
                if (!FlatRedBall.FlatRedBallServices.IsLoaded<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/maintileset.png", ContentManagerName))
                {
                    registerUnload = true;
                }
                MainTileset = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/maintileset.png", ContentManagerName);
                if (!FlatRedBall.FlatRedBallServices.IsLoaded<FlatRedBall.Graphics.Animation.AnimationChainList>(@"content/entities/building/animationchainlistfile.achx", ContentManagerName))
                {
                    registerUnload = true;
                }
                AnimationChainListFile = FlatRedBall.FlatRedBallServices.Load<FlatRedBall.Graphics.Animation.AnimationChainList>(@"content/entities/building/animationchainlistfile.achx", ContentManagerName);
                building_constuction_complete_barracks_1 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/building/sfx/building_constuction_complete_barracks_1", ContentManagerName);
                building_constuction_complete_house_1 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/building/sfx/building_constuction_complete_house_1", ContentManagerName);
                building_constuction_complete_tent_1 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/building/sfx/building_constuction_complete_tent_1", ContentManagerName);
                building_constuction_complete_townhall_1 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/building/sfx/building_constuction_complete_townhall_1", ContentManagerName);
                building_constuction_start_generic_1 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/building/sfx/building_constuction_start_generic_1", ContentManagerName);
                building_constuction_complete_generic_1 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/building/sfx/building_constuction_complete_generic_1", ContentManagerName);
                combat_building_damage_1 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/building/sfx/combat_building_damage_1", ContentManagerName);
                combat_building_damage_2 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/building/sfx/combat_building_damage_2", ContentManagerName);
                combat_building_damage_3 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/building/sfx/combat_building_damage_3", ContentManagerName);
                combat_building_damage_4 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/building/sfx/combat_building_damage_4", ContentManagerName);
                combat_building_damage_5 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/building/sfx/combat_building_damage_5", ContentManagerName);
                combat_building_damage_6 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/building/sfx/combat_building_damage_6", ContentManagerName);
                combat_building_damage_7 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/building/sfx/combat_building_damage_7", ContentManagerName);
                combat_building_damage_8 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/building/sfx/combat_building_damage_8", ContentManagerName);
                combat_building_damage_9 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/building/sfx/combat_building_damage_9", ContentManagerName);
                combat_building_damage_10 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/building/sfx/combat_building_damage_10", ContentManagerName);
                combat_building_damage_11 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/building/sfx/combat_building_damage_11", ContentManagerName);
                combat_building_damage_12 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/building/sfx/combat_building_damage_12", ContentManagerName);
            }
            if (registerUnload && ContentManagerName != FlatRedBall.FlatRedBallServices.GlobalContentManager)
            {
                lock (mLockObject)
                {
                    if (!mRegisteredUnloads.Contains(ContentManagerName) && ContentManagerName != FlatRedBall.FlatRedBallServices.GlobalContentManager)
                    {
                        FlatRedBall.FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("BuildingStaticUnload", UnloadStaticContent);
                        mRegisteredUnloads.Add(ContentManagerName);
                    }
                }
            }
            CustomLoadStaticContent(contentManagerName);
        }
        public static void UnloadStaticContent () 
        {
            if (LoadedContentManagers.Count != 0)
            {
                LoadedContentManagers.RemoveAt(0);
                mRegisteredUnloads.RemoveAt(0);
            }
            if (LoadedContentManagers.Count == 0)
            {
                if (MainTileset != null)
                {
                    MainTileset= null;
                }
                if (AnimationChainListFile != null)
                {
                    AnimationChainListFile= null;
                }
                if (building_constuction_complete_barracks_1 != null)
                {
                    building_constuction_complete_barracks_1= null;
                }
                if (building_constuction_complete_house_1 != null)
                {
                    building_constuction_complete_house_1= null;
                }
                if (building_constuction_complete_tent_1 != null)
                {
                    building_constuction_complete_tent_1= null;
                }
                if (building_constuction_complete_townhall_1 != null)
                {
                    building_constuction_complete_townhall_1= null;
                }
                if (building_constuction_start_generic_1 != null)
                {
                    building_constuction_start_generic_1= null;
                }
                if (building_constuction_complete_generic_1 != null)
                {
                    building_constuction_complete_generic_1= null;
                }
                if (combat_building_damage_1 != null)
                {
                    combat_building_damage_1= null;
                }
                if (combat_building_damage_2 != null)
                {
                    combat_building_damage_2= null;
                }
                if (combat_building_damage_3 != null)
                {
                    combat_building_damage_3= null;
                }
                if (combat_building_damage_4 != null)
                {
                    combat_building_damage_4= null;
                }
                if (combat_building_damage_5 != null)
                {
                    combat_building_damage_5= null;
                }
                if (combat_building_damage_6 != null)
                {
                    combat_building_damage_6= null;
                }
                if (combat_building_damage_7 != null)
                {
                    combat_building_damage_7= null;
                }
                if (combat_building_damage_8 != null)
                {
                    combat_building_damage_8= null;
                }
                if (combat_building_damage_9 != null)
                {
                    combat_building_damage_9= null;
                }
                if (combat_building_damage_10 != null)
                {
                    combat_building_damage_10= null;
                }
                if (combat_building_damage_11 != null)
                {
                    combat_building_damage_11= null;
                }
                if (combat_building_damage_12 != null)
                {
                    combat_building_damage_12= null;
                }
            }
        }
        [System.Obsolete("Use GetFile instead")]
        public static object GetStaticMember (string memberName) 
        {
            switch(memberName)
            {
                case  "MainTileset":
                    return MainTileset;
                case  "AnimationChainListFile":
                    return AnimationChainListFile;
                case  "building_constuction_complete_barracks_1":
                    return building_constuction_complete_barracks_1;
                case  "building_constuction_complete_house_1":
                    return building_constuction_complete_house_1;
                case  "building_constuction_complete_tent_1":
                    return building_constuction_complete_tent_1;
                case  "building_constuction_complete_townhall_1":
                    return building_constuction_complete_townhall_1;
                case  "building_constuction_start_generic_1":
                    return building_constuction_start_generic_1;
                case  "building_constuction_complete_generic_1":
                    return building_constuction_complete_generic_1;
                case  "combat_building_damage_1":
                    return combat_building_damage_1;
                case  "combat_building_damage_2":
                    return combat_building_damage_2;
                case  "combat_building_damage_3":
                    return combat_building_damage_3;
                case  "combat_building_damage_4":
                    return combat_building_damage_4;
                case  "combat_building_damage_5":
                    return combat_building_damage_5;
                case  "combat_building_damage_6":
                    return combat_building_damage_6;
                case  "combat_building_damage_7":
                    return combat_building_damage_7;
                case  "combat_building_damage_8":
                    return combat_building_damage_8;
                case  "combat_building_damage_9":
                    return combat_building_damage_9;
                case  "combat_building_damage_10":
                    return combat_building_damage_10;
                case  "combat_building_damage_11":
                    return combat_building_damage_11;
                case  "combat_building_damage_12":
                    return combat_building_damage_12;
            }
            return null;
        }
        public static object GetFile (string memberName) 
        {
            switch(memberName)
            {
                case  "MainTileset":
                    return MainTileset;
                case  "AnimationChainListFile":
                    return AnimationChainListFile;
                case  "building_constuction_complete_barracks_1":
                    return building_constuction_complete_barracks_1;
                case  "building_constuction_complete_house_1":
                    return building_constuction_complete_house_1;
                case  "building_constuction_complete_tent_1":
                    return building_constuction_complete_tent_1;
                case  "building_constuction_complete_townhall_1":
                    return building_constuction_complete_townhall_1;
                case  "building_constuction_start_generic_1":
                    return building_constuction_start_generic_1;
                case  "building_constuction_complete_generic_1":
                    return building_constuction_complete_generic_1;
                case  "combat_building_damage_1":
                    return combat_building_damage_1;
                case  "combat_building_damage_2":
                    return combat_building_damage_2;
                case  "combat_building_damage_3":
                    return combat_building_damage_3;
                case  "combat_building_damage_4":
                    return combat_building_damage_4;
                case  "combat_building_damage_5":
                    return combat_building_damage_5;
                case  "combat_building_damage_6":
                    return combat_building_damage_6;
                case  "combat_building_damage_7":
                    return combat_building_damage_7;
                case  "combat_building_damage_8":
                    return combat_building_damage_8;
                case  "combat_building_damage_9":
                    return combat_building_damage_9;
                case  "combat_building_damage_10":
                    return combat_building_damage_10;
                case  "combat_building_damage_11":
                    return combat_building_damage_11;
                case  "combat_building_damage_12":
                    return combat_building_damage_12;
            }
            return null;
        }
        object GetMember (string memberName) 
        {
            switch(memberName)
            {
                case  "MainTileset":
                    return MainTileset;
                case  "AnimationChainListFile":
                    return AnimationChainListFile;
                case  "building_constuction_complete_barracks_1":
                    return building_constuction_complete_barracks_1;
                case  "building_constuction_complete_house_1":
                    return building_constuction_complete_house_1;
                case  "building_constuction_complete_tent_1":
                    return building_constuction_complete_tent_1;
                case  "building_constuction_complete_townhall_1":
                    return building_constuction_complete_townhall_1;
                case  "building_constuction_start_generic_1":
                    return building_constuction_start_generic_1;
                case  "building_constuction_complete_generic_1":
                    return building_constuction_complete_generic_1;
                case  "combat_building_damage_1":
                    return combat_building_damage_1;
                case  "combat_building_damage_2":
                    return combat_building_damage_2;
                case  "combat_building_damage_3":
                    return combat_building_damage_3;
                case  "combat_building_damage_4":
                    return combat_building_damage_4;
                case  "combat_building_damage_5":
                    return combat_building_damage_5;
                case  "combat_building_damage_6":
                    return combat_building_damage_6;
                case  "combat_building_damage_7":
                    return combat_building_damage_7;
                case  "combat_building_damage_8":
                    return combat_building_damage_8;
                case  "combat_building_damage_9":
                    return combat_building_damage_9;
                case  "combat_building_damage_10":
                    return combat_building_damage_10;
                case  "combat_building_damage_11":
                    return combat_building_damage_11;
                case  "combat_building_damage_12":
                    return combat_building_damage_12;
            }
            return null;
        }
        public virtual bool HasCursorOver (FlatRedBall.Gui.Cursor cursor) 
        {
            if (mIsPaused)
            {
                return false;
            }
            if (LayerProvidedByContainer != null && LayerProvidedByContainer.Visible == false)
            {
                return false;
            }
            if (!cursor.IsOn(LayerProvidedByContainer))
            {
                return false;
            }
            if (SpriteInstance.Alpha != 0 && SpriteInstance.AbsoluteVisible && cursor.IsOn3D(SpriteInstance, LayerProvidedByContainer))
            {
                return true;
            }
            if (cursor.IsOn3D(AxisAlignedRectangleInstance, LayerProvidedByContainer))
            {
                return true;
            }
            return false;
        }
        public virtual bool WasClickedThisFrame (FlatRedBall.Gui.Cursor cursor) 
        {
            return cursor.PrimaryClick && HasCursorOver(cursor);
        }
        protected bool mIsPaused;
        public override void Pause (FlatRedBall.Instructions.InstructionList instructions) 
        {
            base.Pause(instructions);
            mIsPaused = true;
        }
        public virtual void SetToIgnorePausing () 
        {
            FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(this);
            FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(SpriteInstance);
            FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(AxisAlignedRectangleInstance);
        }
        public virtual void MoveToLayer (FlatRedBall.Graphics.Layer layerToMoveTo) 
        {
            var layerToRemoveFrom = LayerProvidedByContainer;
            if (layerToRemoveFrom != null)
            {
                layerToRemoveFrom.Remove(SpriteInstance);
            }
            if (layerToMoveTo != null || !SpriteManager.AutomaticallyUpdatedSprites.Contains(SpriteInstance))
            {
                FlatRedBall.SpriteManager.AddToLayer(SpriteInstance, layerToMoveTo);
            }
            if (layerToRemoveFrom != null)
            {
                layerToRemoveFrom.Remove(AxisAlignedRectangleInstance);
            }
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(AxisAlignedRectangleInstance, layerToMoveTo);
            LayerProvidedByContainer = layerToMoveTo;
        }
    }
}
