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
    public partial class Unit : FlatRedBall.PositionedObject, FlatRedBall.Graphics.IDestroyable, FlatRedBall.Performance.IPoolable, FlatRedBall.Gui.IClickable, FlatRedBall.Math.Geometry.ICollidable
    {
        // This is made static so that static lazy-loaded content can access it.
        public static string ContentManagerName { get; set; }
        #if DEBUG
        static bool HasBeenLoadedWithGlobalContentManager = false;
        #endif
        static object mLockObject = new object();
        static System.Collections.Generic.List<string> mRegisteredUnloads = new System.Collections.Generic.List<string>();
        static System.Collections.Generic.List<string> LoadedContentManagers = new System.Collections.Generic.List<string>();
        protected static FlatRedBall.Graphics.Animation.AnimationChainList AnimationChainListFile;
        protected static Microsoft.Xna.Framework.Graphics.Texture2D CharactersSheet;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_chop_wood_1;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_chop_wood_2;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_mine_gold_1;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_mine_gold_2;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_attack_worker_1;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_attack_worker_2;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_attack_worker_3;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_death_worker_1;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_death_worker_2;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_death_worker_3;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_obey_worker_1;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_obey_worker_2;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_obey_worker_3;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_select_worker_1;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_select_worker_2;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_select_worker_3;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_spawn_worker_1;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_spawn_worker_2;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_spawn_worker_3;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_attack_fighter_1;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_attack_fighter_2;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_attack_fighter_3;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_death_fighter_1;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_death_fighter_2;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_death_fighter_3;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_obey_fighter_1;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_obey_fighter_2;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_obey_fighter_3;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_select_fighter_1;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_select_fighter_2;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_select_fighter_3;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_spawn_fighter_1;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_spawn_fighter_2;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_spawn_fighter_3;
        protected static Microsoft.Xna.Framework.Graphics.Texture2D MainTileset;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_obey_fighter_4;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_obey_fighter_5;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_obey_fighter_6;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_obey_fighter_7;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_obey_fighter_8;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_obey_fighter_9;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_select_fighter_4;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_select_fighter_5;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_select_fighter_6;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_select_fighter_7;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_select_fighter_8;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_select_fighter_9;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_spawn_figher_4;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_spawn_fighter_5;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_spawn_fighter_6;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_obey_worker_4;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_obey_worker_5;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_obey_worker_6;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_obey_worker_7;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_obey_worker_8;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_obey_worker_9;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_select_worker_4;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_select_worker_5;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_select_worker_6;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_select_worker_7;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_select_worker_8;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_select_worker_9;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_spawn_worker_4;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_spawn_worker_5;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_spawn_worker_6;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_attack_club_1;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_attack_club_2;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_attack_club_3;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_attack_club_4;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_attack_club_5;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_attack_club_6;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_attack_club_7;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_attack_club_8;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_attack_club_9;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_attack_club_10;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_attack_club_11;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_attack_club_12;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_attack_magic_1;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_attack_magic_2;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_attack_magic_3;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_attack_magic_4;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_attack_magic_5;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_attack_magic_6;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_attack_magic_7;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_attack_magic_8;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_attack_magic_9;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_attack_magic_10;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_attack_magic_11;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_attack_magic_12;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_attack_sword_1;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_attack_sword_2;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_attack_sword_3;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_attack_sword_4;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_attack_sword_5;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_attack_sword_6;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_attack_sword_7;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_attack_sword_8;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_attack_sword_9;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_attack_sword_10;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_attack_sword_11;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect combat_attack_sword_12;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_mine_stone_1;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_mine_stone_2;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_attack_bat_1;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_attack_bat_2;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_attack_bat_3;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_death_bat_1;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_death_bat_2;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_death_bat_3;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_attack_cyclops_1;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_attack_cyclops_2;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_attack_cyclops_3;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_death_cyclops_1;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_death_cyclops_2;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_death_cyclops_3;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_attack_dragon_1;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_attack_dragon_2;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_attack_dragon_3;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_death_dragon_1;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_death_dragon_2;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_death_dragon_3;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_attack_goblin_1;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_attack_goblin_2;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_attack_goblin_3;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_death_goblin_1;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_death_goblin_2;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_death_goblin_3;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_attack_slime_1;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_attack_slime_2;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_attack_slime_3;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_death_slime_1;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_death_slime_2;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_death_slime_3;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_attack_snake_1;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_attack_snake_2;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_attack_snake_3;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_death_snake_1;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_death_snake_2;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_death_snake_3;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_attack_fighter_4;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_attack_fighter_5;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_attack_fighter_6;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_attack_fighter_7;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_attack_fighter_8;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_attack_fighter_9;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_attack_fighter_10;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_attack_fighter_11;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_attack_fighter_12;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_attack_skeleton_1;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_attack_skeleton_2;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_attack_skeleton_3;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_death_skeleton_1;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_death_skeleton_2;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_death_skeleton_3;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_spawn_fighter_7;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_spawn_fighter_8;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_spawn_fighter_9;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_spawn_fighter_10;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_spawn_fighter_11;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_spawn_fighter_12;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_spawn_fighter_13;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_select_fighter_10;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_select_fighter_11;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_select_fighter_12;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_select_fighter_13;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_select_fighter_14;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_select_fighter_15;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_select_fighter_16;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_obey_fighter_10;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_obey_fighter_11;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_obey_fighter_12;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_obey_fighter_13;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_obey_fighter_14;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_obey_fighter_15;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_obey_fighter_16;
        protected static Microsoft.Xna.Framework.Audio.SoundEffect unit_obey_fighter_17;
        
        private FlatRedBall.Sprite SpriteInstance;
        private FlatRedBall.Sprite ResourceIndicatorSpriteInstance;
        private FlatRedBall.Math.Geometry.Circle mCircleInstance;
        public FlatRedBall.Math.Geometry.Circle CircleInstance
        {
            get
            {
                return mCircleInstance;
            }
            private set
            {
                mCircleInstance = value;
            }
        }
        private FlatRedBall.Math.Geometry.Circle mResourceCollectCircleInstance;
        public FlatRedBall.Math.Geometry.Circle ResourceCollectCircleInstance
        {
            get
            {
                return mResourceCollectCircleInstance;
            }
            private set
            {
                mResourceCollectCircleInstance = value;
            }
        }
        private TownRaiserImGui.GumRuntimes.HealthBarRuntime HealthBarRuntimeInstance;
        private FlatRedBall.Sprite ShadowSprite;
        public int TeamIndex;
        public event Action<TownRaiserImGui.DataTypes.UnitData> BeforeUnitDataSet;
        public event System.EventHandler AfterUnitDataSet;
        private TownRaiserImGui.DataTypes.UnitData mUnitData;
        public TownRaiserImGui.DataTypes.UnitData UnitData
        {
            set
            {
                if (BeforeUnitDataSet != null)
                {
                    BeforeUnitDataSet(value);
                }
                mUnitData = value;
                if (AfterUnitDataSet != null)
                {
                    AfterUnitDataSet(this, null);
                }
            }
            get
            {
                return mUnitData;
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
        public float DeathSpriteDuration = 5f;
        public float HopsPerSecond = 2f;
        public float AttackWobblesPerSecond = 2f;
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
        public Unit () 
        	: this(FlatRedBall.Screens.ScreenManager.CurrentScreen.ContentManagerName, true)
        {
        }
        public Unit (string contentManagerName) 
        	: this(contentManagerName, true)
        {
        }
        public Unit (string contentManagerName, bool addToManagers) 
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
            ResourceIndicatorSpriteInstance = new FlatRedBall.Sprite();
            ResourceIndicatorSpriteInstance.Name = "ResourceIndicatorSpriteInstance";
            mCircleInstance = new FlatRedBall.Math.Geometry.Circle();
            mCircleInstance.Name = "mCircleInstance";
            mResourceCollectCircleInstance = new FlatRedBall.Math.Geometry.Circle();
            mResourceCollectCircleInstance.Name = "mResourceCollectCircleInstance";
            {var oldLayoutSuspended = global::Gum.Wireframe.GraphicalUiElement.IsAllLayoutSuspended; global::Gum.Wireframe.GraphicalUiElement.IsAllLayoutSuspended = true; HealthBarRuntimeInstance = new TownRaiserImGui.GumRuntimes.HealthBarRuntime();global::Gum.Wireframe.GraphicalUiElement.IsAllLayoutSuspended = oldLayoutSuspended; HealthBarRuntimeInstance.UpdateLayout();}
            ShadowSprite = new FlatRedBall.Sprite();
            ShadowSprite.Name = "ShadowSprite";
            
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
            FlatRedBall.SpriteManager.AddToLayer(ResourceIndicatorSpriteInstance, LayerProvidedByContainer);
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(mCircleInstance, LayerProvidedByContainer);
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(mResourceCollectCircleInstance, LayerProvidedByContainer);
            {
HealthBarRuntimeInstance.AddToManagers(RenderingLibrary.SystemManagers.Default, System.Linq.Enumerable.FirstOrDefault(FlatRedBall.Gum.GumIdb.AllGumLayersOnFrbLayer(LayerProvidedByContainer)));
var wrapperForAttachment = new GumCoreShared.FlatRedBall.Embedded.PositionedObjectGueWrapper(this, HealthBarRuntimeInstance);
FlatRedBall.SpriteManager.AddPositionedObject(wrapperForAttachment);
gumAttachmentWrappers.Add(wrapperForAttachment);
}

            FlatRedBall.SpriteManager.AddToLayer(ShadowSprite, LayerProvidedByContainer);
        }
        public virtual void AddToManagers (FlatRedBall.Graphics.Layer layerToAddTo) 
        {
            LayerProvidedByContainer = layerToAddTo;
            FlatRedBall.SpriteManager.AddPositionedObject(this);
            FlatRedBall.SpriteManager.AddToLayer(SpriteInstance, LayerProvidedByContainer);
            FlatRedBall.SpriteManager.AddToLayer(ResourceIndicatorSpriteInstance, LayerProvidedByContainer);
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(mCircleInstance, LayerProvidedByContainer);
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(mResourceCollectCircleInstance, LayerProvidedByContainer);
            {
HealthBarRuntimeInstance.AddToManagers(RenderingLibrary.SystemManagers.Default, System.Linq.Enumerable.FirstOrDefault(FlatRedBall.Gum.GumIdb.AllGumLayersOnFrbLayer(LayerProvidedByContainer)));
var wrapperForAttachment = new GumCoreShared.FlatRedBall.Embedded.PositionedObjectGueWrapper(this, HealthBarRuntimeInstance);
FlatRedBall.SpriteManager.AddPositionedObject(wrapperForAttachment);
gumAttachmentWrappers.Add(wrapperForAttachment);
}

            FlatRedBall.SpriteManager.AddToLayer(ShadowSprite, LayerProvidedByContainer);
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
                Factories.UnitFactory.MakeUnused(this, false);
            }
            FlatRedBall.SpriteManager.RemovePositionedObject(this);
            
            if (SpriteInstance != null)
            {
                FlatRedBall.SpriteManager.RemoveSpriteOneWay(SpriteInstance);
            }
            if (ResourceIndicatorSpriteInstance != null)
            {
                FlatRedBall.SpriteManager.RemoveSpriteOneWay(ResourceIndicatorSpriteInstance);
            }
            if (CircleInstance != null)
            {
                FlatRedBall.Math.Geometry.ShapeManager.RemoveOneWay(CircleInstance);
            }
            if (ResourceCollectCircleInstance != null)
            {
                FlatRedBall.Math.Geometry.ShapeManager.RemoveOneWay(ResourceCollectCircleInstance);
            }
            if (HealthBarRuntimeInstance != null)
            {
                HealthBarRuntimeInstance.RemoveFromManagers();
            }
            if (ShadowSprite != null)
            {
                FlatRedBall.SpriteManager.RemoveSpriteOneWay(ShadowSprite);
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
            this.AfterUnitDataSet += OnAfterUnitDataSet;
            if (SpriteInstance.Parent == null)
            {
                SpriteInstance.CopyAbsoluteToRelative();
                SpriteInstance.AttachTo(this, false);
            }
            if (SpriteInstance.Parent == null)
            {
                SpriteInstance.Y = 7f;
            }
            else
            {
                SpriteInstance.RelativeY = 7f;
            }
            SpriteInstance.Texture = CharactersSheet;
            SpriteInstance.LeftTexturePixel = 97f;
            SpriteInstance.RightTexturePixel = 109f;
            SpriteInstance.TopTexturePixel = 5f;
            SpriteInstance.BottomTexturePixel = 17f;
            SpriteInstance.TextureScale = 1f;
            SpriteInstance.UseAnimationRelativePosition = false;
            SpriteInstance.AnimationChains = AnimationChainListFile;
            if (ResourceIndicatorSpriteInstance.Parent == null)
            {
                ResourceIndicatorSpriteInstance.CopyAbsoluteToRelative();
                ResourceIndicatorSpriteInstance.AttachTo(this, false);
            }
            if (ResourceIndicatorSpriteInstance.Parent == null)
            {
                ResourceIndicatorSpriteInstance.X = 5f;
            }
            else
            {
                ResourceIndicatorSpriteInstance.RelativeX = 5f;
            }
            if (ResourceIndicatorSpriteInstance.Parent == null)
            {
                ResourceIndicatorSpriteInstance.Y = 5f;
            }
            else
            {
                ResourceIndicatorSpriteInstance.RelativeY = 5f;
            }
            if (ResourceIndicatorSpriteInstance.Parent == null)
            {
                ResourceIndicatorSpriteInstance.Z = 1f;
            }
            else
            {
                ResourceIndicatorSpriteInstance.RelativeZ = 1f;
            }
            ResourceIndicatorSpriteInstance.Texture = MainTileset;
            ResourceIndicatorSpriteInstance.LeftTexturePixel = 437f;
            ResourceIndicatorSpriteInstance.RightTexturePixel = 443f;
            ResourceIndicatorSpriteInstance.TopTexturePixel = 36f;
            ResourceIndicatorSpriteInstance.BottomTexturePixel = 46f;
            ResourceIndicatorSpriteInstance.TextureScale = 1f;
            ResourceIndicatorSpriteInstance.UseAnimationRelativePosition = false;
            ResourceIndicatorSpriteInstance.AnimationChains = AnimationChainListFile;
            ResourceIndicatorSpriteInstance.CurrentChainName = "ResourceGold";
            ResourceIndicatorSpriteInstance.Visible = false;
            ResourceIndicatorSpriteInstance.ColorOperation = FlatRedBall.Graphics.ColorOperation.Texture;
            ResourceIndicatorSpriteInstance.Red = 0f;
            if (mCircleInstance.Parent == null)
            {
                mCircleInstance.CopyAbsoluteToRelative();
                mCircleInstance.AttachTo(this, false);
            }
            CircleInstance.Radius = 6f;
            CircleInstance.Visible = false;
            if (mResourceCollectCircleInstance.Parent == null)
            {
                mResourceCollectCircleInstance.CopyAbsoluteToRelative();
                mResourceCollectCircleInstance.AttachTo(this, false);
            }
            ResourceCollectCircleInstance.Radius = 8f;
            ResourceCollectCircleInstance.Visible = false;
            ResourceCollectCircleInstance.Color = Microsoft.Xna.Framework.Color.Green;
            HealthBarRuntimeInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
            HealthBarRuntimeInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Bottom;
            if (ShadowSprite.Parent == null)
            {
                ShadowSprite.CopyAbsoluteToRelative();
                ShadowSprite.AttachTo(this, false);
            }
            if (ShadowSprite.Parent == null)
            {
                ShadowSprite.Y = 0f;
            }
            else
            {
                ShadowSprite.RelativeY = 0f;
            }
            if (ShadowSprite.Parent == null)
            {
                ShadowSprite.Z = -0.1f;
            }
            else
            {
                ShadowSprite.RelativeZ = -0.1f;
            }
            ShadowSprite.TextureScale = 1f;
            ShadowSprite.UseAnimationRelativePosition = false;
            ShadowSprite.AnimationChains = AnimationChainListFile;
            ShadowSprite.CurrentChainName = "ShadowSmall";
            mGeneratedCollision = new FlatRedBall.Math.Geometry.ShapeCollection();
            Collision.Circles.AddOneWay(mCircleInstance);
            Collision.Circles.AddOneWay(mResourceCollectCircleInstance);
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
            if (ResourceIndicatorSpriteInstance != null)
            {
                FlatRedBall.SpriteManager.RemoveSpriteOneWay(ResourceIndicatorSpriteInstance);
            }
            if (CircleInstance != null)
            {
                FlatRedBall.Math.Geometry.ShapeManager.RemoveOneWay(CircleInstance);
            }
            if (ResourceCollectCircleInstance != null)
            {
                FlatRedBall.Math.Geometry.ShapeManager.RemoveOneWay(ResourceCollectCircleInstance);
            }
            if (HealthBarRuntimeInstance != null)
            {
                HealthBarRuntimeInstance.RemoveFromManagers();
            }
            if (ShadowSprite != null)
            {
                FlatRedBall.SpriteManager.RemoveSpriteOneWay(ShadowSprite);
            }
            mGeneratedCollision.RemoveFromManagers(clearThis: false);
        }
        public virtual void AssignCustomVariables (bool callOnContainedElements) 
        {
            if (callOnContainedElements)
            {
            }
            if (SpriteInstance.Parent == null)
            {
                SpriteInstance.Y = 7f;
            }
            else
            {
                SpriteInstance.RelativeY = 7f;
            }
            SpriteInstance.Texture = CharactersSheet;
            SpriteInstance.LeftTexturePixel = 97f;
            SpriteInstance.RightTexturePixel = 109f;
            SpriteInstance.TopTexturePixel = 5f;
            SpriteInstance.BottomTexturePixel = 17f;
            SpriteInstance.TextureScale = 1f;
            SpriteInstance.UseAnimationRelativePosition = false;
            SpriteInstance.AnimationChains = AnimationChainListFile;
            if (ResourceIndicatorSpriteInstance.Parent == null)
            {
                ResourceIndicatorSpriteInstance.X = 5f;
            }
            else
            {
                ResourceIndicatorSpriteInstance.RelativeX = 5f;
            }
            if (ResourceIndicatorSpriteInstance.Parent == null)
            {
                ResourceIndicatorSpriteInstance.Y = 5f;
            }
            else
            {
                ResourceIndicatorSpriteInstance.RelativeY = 5f;
            }
            if (ResourceIndicatorSpriteInstance.Parent == null)
            {
                ResourceIndicatorSpriteInstance.Z = 1f;
            }
            else
            {
                ResourceIndicatorSpriteInstance.RelativeZ = 1f;
            }
            ResourceIndicatorSpriteInstance.Texture = MainTileset;
            ResourceIndicatorSpriteInstance.LeftTexturePixel = 437f;
            ResourceIndicatorSpriteInstance.RightTexturePixel = 443f;
            ResourceIndicatorSpriteInstance.TopTexturePixel = 36f;
            ResourceIndicatorSpriteInstance.BottomTexturePixel = 46f;
            ResourceIndicatorSpriteInstance.TextureScale = 1f;
            ResourceIndicatorSpriteInstance.UseAnimationRelativePosition = false;
            ResourceIndicatorSpriteInstance.AnimationChains = AnimationChainListFile;
            ResourceIndicatorSpriteInstance.CurrentChainName = "ResourceGold";
            ResourceIndicatorSpriteInstance.Visible = false;
            ResourceIndicatorSpriteInstance.ColorOperation = FlatRedBall.Graphics.ColorOperation.Texture;
            ResourceIndicatorSpriteInstance.Red = 0f;
            CircleInstance.Radius = 6f;
            CircleInstance.Visible = false;
            ResourceCollectCircleInstance.Radius = 8f;
            ResourceCollectCircleInstance.Visible = false;
            ResourceCollectCircleInstance.Color = Microsoft.Xna.Framework.Color.Green;
            HealthBarRuntimeInstance.XOrigin = RenderingLibrary.Graphics.HorizontalAlignment.Center;
            HealthBarRuntimeInstance.YOrigin = RenderingLibrary.Graphics.VerticalAlignment.Bottom;
            if (ShadowSprite.Parent == null)
            {
                ShadowSprite.Y = 0f;
            }
            else
            {
                ShadowSprite.RelativeY = 0f;
            }
            if (ShadowSprite.Parent == null)
            {
                ShadowSprite.Z = -0.1f;
            }
            else
            {
                ShadowSprite.RelativeZ = -0.1f;
            }
            ShadowSprite.TextureScale = 1f;
            ShadowSprite.UseAnimationRelativePosition = false;
            ShadowSprite.AnimationChains = AnimationChainListFile;
            ShadowSprite.CurrentChainName = "ShadowSmall";
            SpriteInstanceAlpha = 1f;
            DeathSpriteDuration = 5f;
            HopsPerSecond = 2f;
            AttackWobblesPerSecond = 2f;
        }
        public virtual void ConvertToManuallyUpdated () 
        {
            this.ForceUpdateDependenciesDeep();
            FlatRedBall.SpriteManager.ConvertToManuallyUpdated(this);
            FlatRedBall.SpriteManager.ConvertToManuallyUpdated(SpriteInstance);
            FlatRedBall.SpriteManager.ConvertToManuallyUpdated(ResourceIndicatorSpriteInstance);
            FlatRedBall.SpriteManager.ConvertToManuallyUpdated(ShadowSprite);
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
                        FlatRedBall.FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("UnitStaticUnload", UnloadStaticContent);
                        mRegisteredUnloads.Add(ContentManagerName);
                    }
                }
                if (!FlatRedBall.FlatRedBallServices.IsLoaded<FlatRedBall.Graphics.Animation.AnimationChainList>(@"content/entities/unit/animationchainlistfile.achx", ContentManagerName))
                {
                    registerUnload = true;
                }
                AnimationChainListFile = FlatRedBall.FlatRedBallServices.Load<FlatRedBall.Graphics.Animation.AnimationChainList>(@"content/entities/unit/animationchainlistfile.achx", ContentManagerName);
                if (!FlatRedBall.FlatRedBallServices.IsLoaded<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/characterssheet.png", ContentManagerName))
                {
                    registerUnload = true;
                }
                CharactersSheet = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/characterssheet.png", ContentManagerName);
                unit_chop_wood_1 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/characteraction/unit_chop_wood_1", ContentManagerName);
                unit_chop_wood_2 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/characteraction/unit_chop_wood_2", ContentManagerName);
                unit_mine_gold_1 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/characteraction/unit_mine_gold_1", ContentManagerName);
                unit_mine_gold_2 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/characteraction/unit_mine_gold_2", ContentManagerName);
                unit_attack_worker_1 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/worker/unit_attack_worker_1", ContentManagerName);
                unit_attack_worker_2 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/worker/unit_attack_worker_2", ContentManagerName);
                unit_attack_worker_3 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/worker/unit_attack_worker_3", ContentManagerName);
                unit_death_worker_1 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/worker/unit_death_worker_1", ContentManagerName);
                unit_death_worker_2 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/worker/unit_death_worker_2", ContentManagerName);
                unit_death_worker_3 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/worker/unit_death_worker_3", ContentManagerName);
                unit_obey_worker_1 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/worker/unit_obey_worker_1", ContentManagerName);
                unit_obey_worker_2 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/worker/unit_obey_worker_2", ContentManagerName);
                unit_obey_worker_3 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/worker/unit_obey_worker_3", ContentManagerName);
                unit_select_worker_1 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/worker/unit_select_worker_1", ContentManagerName);
                unit_select_worker_2 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/worker/unit_select_worker_2", ContentManagerName);
                unit_select_worker_3 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/worker/unit_select_worker_3", ContentManagerName);
                unit_spawn_worker_1 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/worker/unit_spawn_worker_1", ContentManagerName);
                unit_spawn_worker_2 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/worker/unit_spawn_worker_2", ContentManagerName);
                unit_spawn_worker_3 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/worker/unit_spawn_worker_3", ContentManagerName);
                unit_attack_fighter_1 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_attack_fighter_1", ContentManagerName);
                unit_attack_fighter_2 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_attack_fighter_2", ContentManagerName);
                unit_attack_fighter_3 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_attack_fighter_3", ContentManagerName);
                unit_death_fighter_1 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_death_fighter_1", ContentManagerName);
                unit_death_fighter_2 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_death_fighter_2", ContentManagerName);
                unit_death_fighter_3 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_death_fighter_3", ContentManagerName);
                unit_obey_fighter_1 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_obey_fighter_1", ContentManagerName);
                unit_obey_fighter_2 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_obey_fighter_2", ContentManagerName);
                unit_obey_fighter_3 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_obey_fighter_3", ContentManagerName);
                unit_select_fighter_1 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_select_fighter_1", ContentManagerName);
                unit_select_fighter_2 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_select_fighter_2", ContentManagerName);
                unit_select_fighter_3 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_select_fighter_3", ContentManagerName);
                unit_spawn_fighter_1 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_spawn_fighter_1", ContentManagerName);
                unit_spawn_fighter_2 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_spawn_fighter_2", ContentManagerName);
                unit_spawn_fighter_3 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_spawn_fighter_3", ContentManagerName);
                if (!FlatRedBall.FlatRedBallServices.IsLoaded<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/maintileset.png", ContentManagerName))
                {
                    registerUnload = true;
                }
                MainTileset = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/maintileset.png", ContentManagerName);
                unit_obey_fighter_4 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_obey_fighter_4", ContentManagerName);
                unit_obey_fighter_5 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_obey_fighter_5", ContentManagerName);
                unit_obey_fighter_6 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_obey_fighter_6", ContentManagerName);
                unit_obey_fighter_7 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_obey_fighter_7", ContentManagerName);
                unit_obey_fighter_8 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_obey_fighter_8", ContentManagerName);
                unit_obey_fighter_9 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_obey_fighter_9", ContentManagerName);
                unit_select_fighter_4 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_select_fighter_4", ContentManagerName);
                unit_select_fighter_5 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_select_fighter_5", ContentManagerName);
                unit_select_fighter_6 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_select_fighter_6", ContentManagerName);
                unit_select_fighter_7 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_select_fighter_7", ContentManagerName);
                unit_select_fighter_8 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_select_fighter_8", ContentManagerName);
                unit_select_fighter_9 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_select_fighter_9", ContentManagerName);
                unit_spawn_figher_4 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_spawn_figher_4", ContentManagerName);
                unit_spawn_fighter_5 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_spawn_fighter_5", ContentManagerName);
                unit_spawn_fighter_6 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_spawn_fighter_6", ContentManagerName);
                unit_obey_worker_4 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/worker/unit_obey_worker_4", ContentManagerName);
                unit_obey_worker_5 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/worker/unit_obey_worker_5", ContentManagerName);
                unit_obey_worker_6 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/worker/unit_obey_worker_6", ContentManagerName);
                unit_obey_worker_7 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/worker/unit_obey_worker_7", ContentManagerName);
                unit_obey_worker_8 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/worker/unit_obey_worker_8", ContentManagerName);
                unit_obey_worker_9 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/worker/unit_obey_worker_9", ContentManagerName);
                unit_select_worker_4 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/worker/unit_select_worker_4", ContentManagerName);
                unit_select_worker_5 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/worker/unit_select_worker_5", ContentManagerName);
                unit_select_worker_6 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/worker/unit_select_worker_6", ContentManagerName);
                unit_select_worker_7 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/worker/unit_select_worker_7", ContentManagerName);
                unit_select_worker_8 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/worker/unit_select_worker_8", ContentManagerName);
                unit_select_worker_9 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/worker/unit_select_worker_9", ContentManagerName);
                unit_spawn_worker_4 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/worker/unit_spawn_worker_4", ContentManagerName);
                unit_spawn_worker_5 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/worker/unit_spawn_worker_5", ContentManagerName);
                unit_spawn_worker_6 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/worker/unit_spawn_worker_6", ContentManagerName);
                combat_attack_club_1 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/weapons/combat_attack_club_1", ContentManagerName);
                combat_attack_club_2 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/weapons/combat_attack_club_2", ContentManagerName);
                combat_attack_club_3 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/weapons/combat_attack_club_3", ContentManagerName);
                combat_attack_club_4 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/weapons/combat_attack_club_4", ContentManagerName);
                combat_attack_club_5 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/weapons/combat_attack_club_5", ContentManagerName);
                combat_attack_club_6 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/weapons/combat_attack_club_6", ContentManagerName);
                combat_attack_club_7 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/weapons/combat_attack_club_7", ContentManagerName);
                combat_attack_club_8 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/weapons/combat_attack_club_8", ContentManagerName);
                combat_attack_club_9 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/weapons/combat_attack_club_9", ContentManagerName);
                combat_attack_club_10 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/weapons/combat_attack_club_10", ContentManagerName);
                combat_attack_club_11 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/weapons/combat_attack_club_11", ContentManagerName);
                combat_attack_club_12 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/weapons/combat_attack_club_12", ContentManagerName);
                combat_attack_magic_1 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/weapons/combat_attack_magic_1", ContentManagerName);
                combat_attack_magic_2 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/weapons/combat_attack_magic_2", ContentManagerName);
                combat_attack_magic_3 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/weapons/combat_attack_magic_3", ContentManagerName);
                combat_attack_magic_4 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/weapons/combat_attack_magic_4", ContentManagerName);
                combat_attack_magic_5 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/weapons/combat_attack_magic_5", ContentManagerName);
                combat_attack_magic_6 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/weapons/combat_attack_magic_6", ContentManagerName);
                combat_attack_magic_7 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/weapons/combat_attack_magic_7", ContentManagerName);
                combat_attack_magic_8 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/weapons/combat_attack_magic_8", ContentManagerName);
                combat_attack_magic_9 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/weapons/combat_attack_magic_9", ContentManagerName);
                combat_attack_magic_10 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/weapons/combat_attack_magic_10", ContentManagerName);
                combat_attack_magic_11 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/weapons/combat_attack_magic_11", ContentManagerName);
                combat_attack_magic_12 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/weapons/combat_attack_magic_12", ContentManagerName);
                combat_attack_sword_1 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/weapons/combat_attack_sword_1", ContentManagerName);
                combat_attack_sword_2 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/weapons/combat_attack_sword_2", ContentManagerName);
                combat_attack_sword_3 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/weapons/combat_attack_sword_3", ContentManagerName);
                combat_attack_sword_4 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/weapons/combat_attack_sword_4", ContentManagerName);
                combat_attack_sword_5 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/weapons/combat_attack_sword_5", ContentManagerName);
                combat_attack_sword_6 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/weapons/combat_attack_sword_6", ContentManagerName);
                combat_attack_sword_7 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/weapons/combat_attack_sword_7", ContentManagerName);
                combat_attack_sword_8 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/weapons/combat_attack_sword_8", ContentManagerName);
                combat_attack_sword_9 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/weapons/combat_attack_sword_9", ContentManagerName);
                combat_attack_sword_10 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/weapons/combat_attack_sword_10", ContentManagerName);
                combat_attack_sword_11 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/weapons/combat_attack_sword_11", ContentManagerName);
                combat_attack_sword_12 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/weapons/combat_attack_sword_12", ContentManagerName);
                unit_mine_stone_1 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/characteraction/unit_mine_stone_1", ContentManagerName);
                unit_mine_stone_2 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/characteraction/unit_mine_stone_2", ContentManagerName);
                unit_attack_bat_1 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/bat/unit_attack_bat_1", ContentManagerName);
                unit_attack_bat_2 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/bat/unit_attack_bat_2", ContentManagerName);
                unit_attack_bat_3 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/bat/unit_attack_bat_3", ContentManagerName);
                unit_death_bat_1 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/bat/unit_death_bat_1", ContentManagerName);
                unit_death_bat_2 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/bat/unit_death_bat_2", ContentManagerName);
                unit_death_bat_3 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/bat/unit_death_bat_3", ContentManagerName);
                unit_attack_cyclops_1 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/cyclops/unit_attack_cyclops_1", ContentManagerName);
                unit_attack_cyclops_2 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/cyclops/unit_attack_cyclops_2", ContentManagerName);
                unit_attack_cyclops_3 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/cyclops/unit_attack_cyclops_3", ContentManagerName);
                unit_death_cyclops_1 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/cyclops/unit_death_cyclops_1", ContentManagerName);
                unit_death_cyclops_2 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/cyclops/unit_death_cyclops_2", ContentManagerName);
                unit_death_cyclops_3 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/cyclops/unit_death_cyclops_3", ContentManagerName);
                unit_attack_dragon_1 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/dragon/unit_attack_dragon_1", ContentManagerName);
                unit_attack_dragon_2 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/dragon/unit_attack_dragon_2", ContentManagerName);
                unit_attack_dragon_3 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/dragon/unit_attack_dragon_3", ContentManagerName);
                unit_death_dragon_1 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/dragon/unit_death_dragon_1", ContentManagerName);
                unit_death_dragon_2 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/dragon/unit_death_dragon_2", ContentManagerName);
                unit_death_dragon_3 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/dragon/unit_death_dragon_3", ContentManagerName);
                unit_attack_goblin_1 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/goblin/unit_attack_goblin_1", ContentManagerName);
                unit_attack_goblin_2 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/goblin/unit_attack_goblin_2", ContentManagerName);
                unit_attack_goblin_3 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/goblin/unit_attack_goblin_3", ContentManagerName);
                unit_death_goblin_1 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/goblin/unit_death_goblin_1", ContentManagerName);
                unit_death_goblin_2 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/goblin/unit_death_goblin_2", ContentManagerName);
                unit_death_goblin_3 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/goblin/unit_death_goblin_3", ContentManagerName);
                unit_attack_slime_1 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/slime/unit_attack_slime_1", ContentManagerName);
                unit_attack_slime_2 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/slime/unit_attack_slime_2", ContentManagerName);
                unit_attack_slime_3 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/slime/unit_attack_slime_3", ContentManagerName);
                unit_death_slime_1 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/slime/unit_death_slime_1", ContentManagerName);
                unit_death_slime_2 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/slime/unit_death_slime_2", ContentManagerName);
                unit_death_slime_3 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/slime/unit_death_slime_3", ContentManagerName);
                unit_attack_snake_1 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/snake/unit_attack_snake_1", ContentManagerName);
                unit_attack_snake_2 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/snake/unit_attack_snake_2", ContentManagerName);
                unit_attack_snake_3 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/snake/unit_attack_snake_3", ContentManagerName);
                unit_death_snake_1 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/snake/unit_death_snake_1", ContentManagerName);
                unit_death_snake_2 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/snake/unit_death_snake_2", ContentManagerName);
                unit_death_snake_3 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/snake/unit_death_snake_3", ContentManagerName);
                unit_attack_fighter_4 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_attack_fighter_4", ContentManagerName);
                unit_attack_fighter_5 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_attack_fighter_5", ContentManagerName);
                unit_attack_fighter_6 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_attack_fighter_6", ContentManagerName);
                unit_attack_fighter_7 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_attack_fighter_7", ContentManagerName);
                unit_attack_fighter_8 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_attack_fighter_8", ContentManagerName);
                unit_attack_fighter_9 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_attack_fighter_9", ContentManagerName);
                unit_attack_fighter_10 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_attack_fighter_10", ContentManagerName);
                unit_attack_fighter_11 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_attack_fighter_11", ContentManagerName);
                unit_attack_fighter_12 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_attack_fighter_12", ContentManagerName);
                unit_attack_skeleton_1 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/skeleton/unit_attack_skeleton_1", ContentManagerName);
                unit_attack_skeleton_2 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/skeleton/unit_attack_skeleton_2", ContentManagerName);
                unit_attack_skeleton_3 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/skeleton/unit_attack_skeleton_3", ContentManagerName);
                unit_death_skeleton_1 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/skeleton/unit_death_skeleton_1", ContentManagerName);
                unit_death_skeleton_2 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/skeleton/unit_death_skeleton_2", ContentManagerName);
                unit_death_skeleton_3 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/skeleton/unit_death_skeleton_3", ContentManagerName);
                unit_spawn_fighter_7 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_spawn_fighter_7", ContentManagerName);
                unit_spawn_fighter_8 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_spawn_fighter_8", ContentManagerName);
                unit_spawn_fighter_9 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_spawn_fighter_9", ContentManagerName);
                unit_spawn_fighter_10 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_spawn_fighter_10", ContentManagerName);
                unit_spawn_fighter_11 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_spawn_fighter_11", ContentManagerName);
                unit_spawn_fighter_12 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_spawn_fighter_12", ContentManagerName);
                unit_spawn_fighter_13 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_spawn_fighter_13", ContentManagerName);
                unit_select_fighter_10 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_select_fighter_10", ContentManagerName);
                unit_select_fighter_11 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_select_fighter_11", ContentManagerName);
                unit_select_fighter_12 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_select_fighter_12", ContentManagerName);
                unit_select_fighter_13 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_select_fighter_13", ContentManagerName);
                unit_select_fighter_14 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_select_fighter_14", ContentManagerName);
                unit_select_fighter_15 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_select_fighter_15", ContentManagerName);
                unit_select_fighter_16 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_select_fighter_16", ContentManagerName);
                unit_obey_fighter_10 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_obey_fighter_10", ContentManagerName);
                unit_obey_fighter_11 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_obey_fighter_11", ContentManagerName);
                unit_obey_fighter_12 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_obey_fighter_12", ContentManagerName);
                unit_obey_fighter_13 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_obey_fighter_13", ContentManagerName);
                unit_obey_fighter_14 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_obey_fighter_14", ContentManagerName);
                unit_obey_fighter_15 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_obey_fighter_15", ContentManagerName);
                unit_obey_fighter_16 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_obey_fighter_16", ContentManagerName);
                unit_obey_fighter_17 = FlatRedBall.FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/entities/unit/sfx/fighter/unit_obey_fighter_17", ContentManagerName);
            }
            if (registerUnload && ContentManagerName != FlatRedBall.FlatRedBallServices.GlobalContentManager)
            {
                lock (mLockObject)
                {
                    if (!mRegisteredUnloads.Contains(ContentManagerName) && ContentManagerName != FlatRedBall.FlatRedBallServices.GlobalContentManager)
                    {
                        FlatRedBall.FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("UnitStaticUnload", UnloadStaticContent);
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
                if (AnimationChainListFile != null)
                {
                    AnimationChainListFile= null;
                }
                if (CharactersSheet != null)
                {
                    CharactersSheet= null;
                }
                if (unit_chop_wood_1 != null)
                {
                    unit_chop_wood_1= null;
                }
                if (unit_chop_wood_2 != null)
                {
                    unit_chop_wood_2= null;
                }
                if (unit_mine_gold_1 != null)
                {
                    unit_mine_gold_1= null;
                }
                if (unit_mine_gold_2 != null)
                {
                    unit_mine_gold_2= null;
                }
                if (unit_attack_worker_1 != null)
                {
                    unit_attack_worker_1= null;
                }
                if (unit_attack_worker_2 != null)
                {
                    unit_attack_worker_2= null;
                }
                if (unit_attack_worker_3 != null)
                {
                    unit_attack_worker_3= null;
                }
                if (unit_death_worker_1 != null)
                {
                    unit_death_worker_1= null;
                }
                if (unit_death_worker_2 != null)
                {
                    unit_death_worker_2= null;
                }
                if (unit_death_worker_3 != null)
                {
                    unit_death_worker_3= null;
                }
                if (unit_obey_worker_1 != null)
                {
                    unit_obey_worker_1= null;
                }
                if (unit_obey_worker_2 != null)
                {
                    unit_obey_worker_2= null;
                }
                if (unit_obey_worker_3 != null)
                {
                    unit_obey_worker_3= null;
                }
                if (unit_select_worker_1 != null)
                {
                    unit_select_worker_1= null;
                }
                if (unit_select_worker_2 != null)
                {
                    unit_select_worker_2= null;
                }
                if (unit_select_worker_3 != null)
                {
                    unit_select_worker_3= null;
                }
                if (unit_spawn_worker_1 != null)
                {
                    unit_spawn_worker_1= null;
                }
                if (unit_spawn_worker_2 != null)
                {
                    unit_spawn_worker_2= null;
                }
                if (unit_spawn_worker_3 != null)
                {
                    unit_spawn_worker_3= null;
                }
                if (unit_attack_fighter_1 != null)
                {
                    unit_attack_fighter_1= null;
                }
                if (unit_attack_fighter_2 != null)
                {
                    unit_attack_fighter_2= null;
                }
                if (unit_attack_fighter_3 != null)
                {
                    unit_attack_fighter_3= null;
                }
                if (unit_death_fighter_1 != null)
                {
                    unit_death_fighter_1= null;
                }
                if (unit_death_fighter_2 != null)
                {
                    unit_death_fighter_2= null;
                }
                if (unit_death_fighter_3 != null)
                {
                    unit_death_fighter_3= null;
                }
                if (unit_obey_fighter_1 != null)
                {
                    unit_obey_fighter_1= null;
                }
                if (unit_obey_fighter_2 != null)
                {
                    unit_obey_fighter_2= null;
                }
                if (unit_obey_fighter_3 != null)
                {
                    unit_obey_fighter_3= null;
                }
                if (unit_select_fighter_1 != null)
                {
                    unit_select_fighter_1= null;
                }
                if (unit_select_fighter_2 != null)
                {
                    unit_select_fighter_2= null;
                }
                if (unit_select_fighter_3 != null)
                {
                    unit_select_fighter_3= null;
                }
                if (unit_spawn_fighter_1 != null)
                {
                    unit_spawn_fighter_1= null;
                }
                if (unit_spawn_fighter_2 != null)
                {
                    unit_spawn_fighter_2= null;
                }
                if (unit_spawn_fighter_3 != null)
                {
                    unit_spawn_fighter_3= null;
                }
                if (MainTileset != null)
                {
                    MainTileset= null;
                }
                if (unit_obey_fighter_4 != null)
                {
                    unit_obey_fighter_4= null;
                }
                if (unit_obey_fighter_5 != null)
                {
                    unit_obey_fighter_5= null;
                }
                if (unit_obey_fighter_6 != null)
                {
                    unit_obey_fighter_6= null;
                }
                if (unit_obey_fighter_7 != null)
                {
                    unit_obey_fighter_7= null;
                }
                if (unit_obey_fighter_8 != null)
                {
                    unit_obey_fighter_8= null;
                }
                if (unit_obey_fighter_9 != null)
                {
                    unit_obey_fighter_9= null;
                }
                if (unit_select_fighter_4 != null)
                {
                    unit_select_fighter_4= null;
                }
                if (unit_select_fighter_5 != null)
                {
                    unit_select_fighter_5= null;
                }
                if (unit_select_fighter_6 != null)
                {
                    unit_select_fighter_6= null;
                }
                if (unit_select_fighter_7 != null)
                {
                    unit_select_fighter_7= null;
                }
                if (unit_select_fighter_8 != null)
                {
                    unit_select_fighter_8= null;
                }
                if (unit_select_fighter_9 != null)
                {
                    unit_select_fighter_9= null;
                }
                if (unit_spawn_figher_4 != null)
                {
                    unit_spawn_figher_4= null;
                }
                if (unit_spawn_fighter_5 != null)
                {
                    unit_spawn_fighter_5= null;
                }
                if (unit_spawn_fighter_6 != null)
                {
                    unit_spawn_fighter_6= null;
                }
                if (unit_obey_worker_4 != null)
                {
                    unit_obey_worker_4= null;
                }
                if (unit_obey_worker_5 != null)
                {
                    unit_obey_worker_5= null;
                }
                if (unit_obey_worker_6 != null)
                {
                    unit_obey_worker_6= null;
                }
                if (unit_obey_worker_7 != null)
                {
                    unit_obey_worker_7= null;
                }
                if (unit_obey_worker_8 != null)
                {
                    unit_obey_worker_8= null;
                }
                if (unit_obey_worker_9 != null)
                {
                    unit_obey_worker_9= null;
                }
                if (unit_select_worker_4 != null)
                {
                    unit_select_worker_4= null;
                }
                if (unit_select_worker_5 != null)
                {
                    unit_select_worker_5= null;
                }
                if (unit_select_worker_6 != null)
                {
                    unit_select_worker_6= null;
                }
                if (unit_select_worker_7 != null)
                {
                    unit_select_worker_7= null;
                }
                if (unit_select_worker_8 != null)
                {
                    unit_select_worker_8= null;
                }
                if (unit_select_worker_9 != null)
                {
                    unit_select_worker_9= null;
                }
                if (unit_spawn_worker_4 != null)
                {
                    unit_spawn_worker_4= null;
                }
                if (unit_spawn_worker_5 != null)
                {
                    unit_spawn_worker_5= null;
                }
                if (unit_spawn_worker_6 != null)
                {
                    unit_spawn_worker_6= null;
                }
                if (combat_attack_club_1 != null)
                {
                    combat_attack_club_1= null;
                }
                if (combat_attack_club_2 != null)
                {
                    combat_attack_club_2= null;
                }
                if (combat_attack_club_3 != null)
                {
                    combat_attack_club_3= null;
                }
                if (combat_attack_club_4 != null)
                {
                    combat_attack_club_4= null;
                }
                if (combat_attack_club_5 != null)
                {
                    combat_attack_club_5= null;
                }
                if (combat_attack_club_6 != null)
                {
                    combat_attack_club_6= null;
                }
                if (combat_attack_club_7 != null)
                {
                    combat_attack_club_7= null;
                }
                if (combat_attack_club_8 != null)
                {
                    combat_attack_club_8= null;
                }
                if (combat_attack_club_9 != null)
                {
                    combat_attack_club_9= null;
                }
                if (combat_attack_club_10 != null)
                {
                    combat_attack_club_10= null;
                }
                if (combat_attack_club_11 != null)
                {
                    combat_attack_club_11= null;
                }
                if (combat_attack_club_12 != null)
                {
                    combat_attack_club_12= null;
                }
                if (combat_attack_magic_1 != null)
                {
                    combat_attack_magic_1= null;
                }
                if (combat_attack_magic_2 != null)
                {
                    combat_attack_magic_2= null;
                }
                if (combat_attack_magic_3 != null)
                {
                    combat_attack_magic_3= null;
                }
                if (combat_attack_magic_4 != null)
                {
                    combat_attack_magic_4= null;
                }
                if (combat_attack_magic_5 != null)
                {
                    combat_attack_magic_5= null;
                }
                if (combat_attack_magic_6 != null)
                {
                    combat_attack_magic_6= null;
                }
                if (combat_attack_magic_7 != null)
                {
                    combat_attack_magic_7= null;
                }
                if (combat_attack_magic_8 != null)
                {
                    combat_attack_magic_8= null;
                }
                if (combat_attack_magic_9 != null)
                {
                    combat_attack_magic_9= null;
                }
                if (combat_attack_magic_10 != null)
                {
                    combat_attack_magic_10= null;
                }
                if (combat_attack_magic_11 != null)
                {
                    combat_attack_magic_11= null;
                }
                if (combat_attack_magic_12 != null)
                {
                    combat_attack_magic_12= null;
                }
                if (combat_attack_sword_1 != null)
                {
                    combat_attack_sword_1= null;
                }
                if (combat_attack_sword_2 != null)
                {
                    combat_attack_sword_2= null;
                }
                if (combat_attack_sword_3 != null)
                {
                    combat_attack_sword_3= null;
                }
                if (combat_attack_sword_4 != null)
                {
                    combat_attack_sword_4= null;
                }
                if (combat_attack_sword_5 != null)
                {
                    combat_attack_sword_5= null;
                }
                if (combat_attack_sword_6 != null)
                {
                    combat_attack_sword_6= null;
                }
                if (combat_attack_sword_7 != null)
                {
                    combat_attack_sword_7= null;
                }
                if (combat_attack_sword_8 != null)
                {
                    combat_attack_sword_8= null;
                }
                if (combat_attack_sword_9 != null)
                {
                    combat_attack_sword_9= null;
                }
                if (combat_attack_sword_10 != null)
                {
                    combat_attack_sword_10= null;
                }
                if (combat_attack_sword_11 != null)
                {
                    combat_attack_sword_11= null;
                }
                if (combat_attack_sword_12 != null)
                {
                    combat_attack_sword_12= null;
                }
                if (unit_mine_stone_1 != null)
                {
                    unit_mine_stone_1= null;
                }
                if (unit_mine_stone_2 != null)
                {
                    unit_mine_stone_2= null;
                }
                if (unit_attack_bat_1 != null)
                {
                    unit_attack_bat_1= null;
                }
                if (unit_attack_bat_2 != null)
                {
                    unit_attack_bat_2= null;
                }
                if (unit_attack_bat_3 != null)
                {
                    unit_attack_bat_3= null;
                }
                if (unit_death_bat_1 != null)
                {
                    unit_death_bat_1= null;
                }
                if (unit_death_bat_2 != null)
                {
                    unit_death_bat_2= null;
                }
                if (unit_death_bat_3 != null)
                {
                    unit_death_bat_3= null;
                }
                if (unit_attack_cyclops_1 != null)
                {
                    unit_attack_cyclops_1= null;
                }
                if (unit_attack_cyclops_2 != null)
                {
                    unit_attack_cyclops_2= null;
                }
                if (unit_attack_cyclops_3 != null)
                {
                    unit_attack_cyclops_3= null;
                }
                if (unit_death_cyclops_1 != null)
                {
                    unit_death_cyclops_1= null;
                }
                if (unit_death_cyclops_2 != null)
                {
                    unit_death_cyclops_2= null;
                }
                if (unit_death_cyclops_3 != null)
                {
                    unit_death_cyclops_3= null;
                }
                if (unit_attack_dragon_1 != null)
                {
                    unit_attack_dragon_1= null;
                }
                if (unit_attack_dragon_2 != null)
                {
                    unit_attack_dragon_2= null;
                }
                if (unit_attack_dragon_3 != null)
                {
                    unit_attack_dragon_3= null;
                }
                if (unit_death_dragon_1 != null)
                {
                    unit_death_dragon_1= null;
                }
                if (unit_death_dragon_2 != null)
                {
                    unit_death_dragon_2= null;
                }
                if (unit_death_dragon_3 != null)
                {
                    unit_death_dragon_3= null;
                }
                if (unit_attack_goblin_1 != null)
                {
                    unit_attack_goblin_1= null;
                }
                if (unit_attack_goblin_2 != null)
                {
                    unit_attack_goblin_2= null;
                }
                if (unit_attack_goblin_3 != null)
                {
                    unit_attack_goblin_3= null;
                }
                if (unit_death_goblin_1 != null)
                {
                    unit_death_goblin_1= null;
                }
                if (unit_death_goblin_2 != null)
                {
                    unit_death_goblin_2= null;
                }
                if (unit_death_goblin_3 != null)
                {
                    unit_death_goblin_3= null;
                }
                if (unit_attack_slime_1 != null)
                {
                    unit_attack_slime_1= null;
                }
                if (unit_attack_slime_2 != null)
                {
                    unit_attack_slime_2= null;
                }
                if (unit_attack_slime_3 != null)
                {
                    unit_attack_slime_3= null;
                }
                if (unit_death_slime_1 != null)
                {
                    unit_death_slime_1= null;
                }
                if (unit_death_slime_2 != null)
                {
                    unit_death_slime_2= null;
                }
                if (unit_death_slime_3 != null)
                {
                    unit_death_slime_3= null;
                }
                if (unit_attack_snake_1 != null)
                {
                    unit_attack_snake_1= null;
                }
                if (unit_attack_snake_2 != null)
                {
                    unit_attack_snake_2= null;
                }
                if (unit_attack_snake_3 != null)
                {
                    unit_attack_snake_3= null;
                }
                if (unit_death_snake_1 != null)
                {
                    unit_death_snake_1= null;
                }
                if (unit_death_snake_2 != null)
                {
                    unit_death_snake_2= null;
                }
                if (unit_death_snake_3 != null)
                {
                    unit_death_snake_3= null;
                }
                if (unit_attack_fighter_4 != null)
                {
                    unit_attack_fighter_4= null;
                }
                if (unit_attack_fighter_5 != null)
                {
                    unit_attack_fighter_5= null;
                }
                if (unit_attack_fighter_6 != null)
                {
                    unit_attack_fighter_6= null;
                }
                if (unit_attack_fighter_7 != null)
                {
                    unit_attack_fighter_7= null;
                }
                if (unit_attack_fighter_8 != null)
                {
                    unit_attack_fighter_8= null;
                }
                if (unit_attack_fighter_9 != null)
                {
                    unit_attack_fighter_9= null;
                }
                if (unit_attack_fighter_10 != null)
                {
                    unit_attack_fighter_10= null;
                }
                if (unit_attack_fighter_11 != null)
                {
                    unit_attack_fighter_11= null;
                }
                if (unit_attack_fighter_12 != null)
                {
                    unit_attack_fighter_12= null;
                }
                if (unit_attack_skeleton_1 != null)
                {
                    unit_attack_skeleton_1= null;
                }
                if (unit_attack_skeleton_2 != null)
                {
                    unit_attack_skeleton_2= null;
                }
                if (unit_attack_skeleton_3 != null)
                {
                    unit_attack_skeleton_3= null;
                }
                if (unit_death_skeleton_1 != null)
                {
                    unit_death_skeleton_1= null;
                }
                if (unit_death_skeleton_2 != null)
                {
                    unit_death_skeleton_2= null;
                }
                if (unit_death_skeleton_3 != null)
                {
                    unit_death_skeleton_3= null;
                }
                if (unit_spawn_fighter_7 != null)
                {
                    unit_spawn_fighter_7= null;
                }
                if (unit_spawn_fighter_8 != null)
                {
                    unit_spawn_fighter_8= null;
                }
                if (unit_spawn_fighter_9 != null)
                {
                    unit_spawn_fighter_9= null;
                }
                if (unit_spawn_fighter_10 != null)
                {
                    unit_spawn_fighter_10= null;
                }
                if (unit_spawn_fighter_11 != null)
                {
                    unit_spawn_fighter_11= null;
                }
                if (unit_spawn_fighter_12 != null)
                {
                    unit_spawn_fighter_12= null;
                }
                if (unit_spawn_fighter_13 != null)
                {
                    unit_spawn_fighter_13= null;
                }
                if (unit_select_fighter_10 != null)
                {
                    unit_select_fighter_10= null;
                }
                if (unit_select_fighter_11 != null)
                {
                    unit_select_fighter_11= null;
                }
                if (unit_select_fighter_12 != null)
                {
                    unit_select_fighter_12= null;
                }
                if (unit_select_fighter_13 != null)
                {
                    unit_select_fighter_13= null;
                }
                if (unit_select_fighter_14 != null)
                {
                    unit_select_fighter_14= null;
                }
                if (unit_select_fighter_15 != null)
                {
                    unit_select_fighter_15= null;
                }
                if (unit_select_fighter_16 != null)
                {
                    unit_select_fighter_16= null;
                }
                if (unit_obey_fighter_10 != null)
                {
                    unit_obey_fighter_10= null;
                }
                if (unit_obey_fighter_11 != null)
                {
                    unit_obey_fighter_11= null;
                }
                if (unit_obey_fighter_12 != null)
                {
                    unit_obey_fighter_12= null;
                }
                if (unit_obey_fighter_13 != null)
                {
                    unit_obey_fighter_13= null;
                }
                if (unit_obey_fighter_14 != null)
                {
                    unit_obey_fighter_14= null;
                }
                if (unit_obey_fighter_15 != null)
                {
                    unit_obey_fighter_15= null;
                }
                if (unit_obey_fighter_16 != null)
                {
                    unit_obey_fighter_16= null;
                }
                if (unit_obey_fighter_17 != null)
                {
                    unit_obey_fighter_17= null;
                }
            }
        }
        [System.Obsolete("Use GetFile instead")]
        public static object GetStaticMember (string memberName) 
        {
            switch(memberName)
            {
                case  "AnimationChainListFile":
                    return AnimationChainListFile;
                case  "CharactersSheet":
                    return CharactersSheet;
                case  "unit_chop_wood_1":
                    return unit_chop_wood_1;
                case  "unit_chop_wood_2":
                    return unit_chop_wood_2;
                case  "unit_mine_gold_1":
                    return unit_mine_gold_1;
                case  "unit_mine_gold_2":
                    return unit_mine_gold_2;
                case  "unit_attack_worker_1":
                    return unit_attack_worker_1;
                case  "unit_attack_worker_2":
                    return unit_attack_worker_2;
                case  "unit_attack_worker_3":
                    return unit_attack_worker_3;
                case  "unit_death_worker_1":
                    return unit_death_worker_1;
                case  "unit_death_worker_2":
                    return unit_death_worker_2;
                case  "unit_death_worker_3":
                    return unit_death_worker_3;
                case  "unit_obey_worker_1":
                    return unit_obey_worker_1;
                case  "unit_obey_worker_2":
                    return unit_obey_worker_2;
                case  "unit_obey_worker_3":
                    return unit_obey_worker_3;
                case  "unit_select_worker_1":
                    return unit_select_worker_1;
                case  "unit_select_worker_2":
                    return unit_select_worker_2;
                case  "unit_select_worker_3":
                    return unit_select_worker_3;
                case  "unit_spawn_worker_1":
                    return unit_spawn_worker_1;
                case  "unit_spawn_worker_2":
                    return unit_spawn_worker_2;
                case  "unit_spawn_worker_3":
                    return unit_spawn_worker_3;
                case  "unit_attack_fighter_1":
                    return unit_attack_fighter_1;
                case  "unit_attack_fighter_2":
                    return unit_attack_fighter_2;
                case  "unit_attack_fighter_3":
                    return unit_attack_fighter_3;
                case  "unit_death_fighter_1":
                    return unit_death_fighter_1;
                case  "unit_death_fighter_2":
                    return unit_death_fighter_2;
                case  "unit_death_fighter_3":
                    return unit_death_fighter_3;
                case  "unit_obey_fighter_1":
                    return unit_obey_fighter_1;
                case  "unit_obey_fighter_2":
                    return unit_obey_fighter_2;
                case  "unit_obey_fighter_3":
                    return unit_obey_fighter_3;
                case  "unit_select_fighter_1":
                    return unit_select_fighter_1;
                case  "unit_select_fighter_2":
                    return unit_select_fighter_2;
                case  "unit_select_fighter_3":
                    return unit_select_fighter_3;
                case  "unit_spawn_fighter_1":
                    return unit_spawn_fighter_1;
                case  "unit_spawn_fighter_2":
                    return unit_spawn_fighter_2;
                case  "unit_spawn_fighter_3":
                    return unit_spawn_fighter_3;
                case  "MainTileset":
                    return MainTileset;
                case  "unit_obey_fighter_4":
                    return unit_obey_fighter_4;
                case  "unit_obey_fighter_5":
                    return unit_obey_fighter_5;
                case  "unit_obey_fighter_6":
                    return unit_obey_fighter_6;
                case  "unit_obey_fighter_7":
                    return unit_obey_fighter_7;
                case  "unit_obey_fighter_8":
                    return unit_obey_fighter_8;
                case  "unit_obey_fighter_9":
                    return unit_obey_fighter_9;
                case  "unit_select_fighter_4":
                    return unit_select_fighter_4;
                case  "unit_select_fighter_5":
                    return unit_select_fighter_5;
                case  "unit_select_fighter_6":
                    return unit_select_fighter_6;
                case  "unit_select_fighter_7":
                    return unit_select_fighter_7;
                case  "unit_select_fighter_8":
                    return unit_select_fighter_8;
                case  "unit_select_fighter_9":
                    return unit_select_fighter_9;
                case  "unit_spawn_figher_4":
                    return unit_spawn_figher_4;
                case  "unit_spawn_fighter_5":
                    return unit_spawn_fighter_5;
                case  "unit_spawn_fighter_6":
                    return unit_spawn_fighter_6;
                case  "unit_obey_worker_4":
                    return unit_obey_worker_4;
                case  "unit_obey_worker_5":
                    return unit_obey_worker_5;
                case  "unit_obey_worker_6":
                    return unit_obey_worker_6;
                case  "unit_obey_worker_7":
                    return unit_obey_worker_7;
                case  "unit_obey_worker_8":
                    return unit_obey_worker_8;
                case  "unit_obey_worker_9":
                    return unit_obey_worker_9;
                case  "unit_select_worker_4":
                    return unit_select_worker_4;
                case  "unit_select_worker_5":
                    return unit_select_worker_5;
                case  "unit_select_worker_6":
                    return unit_select_worker_6;
                case  "unit_select_worker_7":
                    return unit_select_worker_7;
                case  "unit_select_worker_8":
                    return unit_select_worker_8;
                case  "unit_select_worker_9":
                    return unit_select_worker_9;
                case  "unit_spawn_worker_4":
                    return unit_spawn_worker_4;
                case  "unit_spawn_worker_5":
                    return unit_spawn_worker_5;
                case  "unit_spawn_worker_6":
                    return unit_spawn_worker_6;
                case  "combat_attack_club_1":
                    return combat_attack_club_1;
                case  "combat_attack_club_2":
                    return combat_attack_club_2;
                case  "combat_attack_club_3":
                    return combat_attack_club_3;
                case  "combat_attack_club_4":
                    return combat_attack_club_4;
                case  "combat_attack_club_5":
                    return combat_attack_club_5;
                case  "combat_attack_club_6":
                    return combat_attack_club_6;
                case  "combat_attack_club_7":
                    return combat_attack_club_7;
                case  "combat_attack_club_8":
                    return combat_attack_club_8;
                case  "combat_attack_club_9":
                    return combat_attack_club_9;
                case  "combat_attack_club_10":
                    return combat_attack_club_10;
                case  "combat_attack_club_11":
                    return combat_attack_club_11;
                case  "combat_attack_club_12":
                    return combat_attack_club_12;
                case  "combat_attack_magic_1":
                    return combat_attack_magic_1;
                case  "combat_attack_magic_2":
                    return combat_attack_magic_2;
                case  "combat_attack_magic_3":
                    return combat_attack_magic_3;
                case  "combat_attack_magic_4":
                    return combat_attack_magic_4;
                case  "combat_attack_magic_5":
                    return combat_attack_magic_5;
                case  "combat_attack_magic_6":
                    return combat_attack_magic_6;
                case  "combat_attack_magic_7":
                    return combat_attack_magic_7;
                case  "combat_attack_magic_8":
                    return combat_attack_magic_8;
                case  "combat_attack_magic_9":
                    return combat_attack_magic_9;
                case  "combat_attack_magic_10":
                    return combat_attack_magic_10;
                case  "combat_attack_magic_11":
                    return combat_attack_magic_11;
                case  "combat_attack_magic_12":
                    return combat_attack_magic_12;
                case  "combat_attack_sword_1":
                    return combat_attack_sword_1;
                case  "combat_attack_sword_2":
                    return combat_attack_sword_2;
                case  "combat_attack_sword_3":
                    return combat_attack_sword_3;
                case  "combat_attack_sword_4":
                    return combat_attack_sword_4;
                case  "combat_attack_sword_5":
                    return combat_attack_sword_5;
                case  "combat_attack_sword_6":
                    return combat_attack_sword_6;
                case  "combat_attack_sword_7":
                    return combat_attack_sword_7;
                case  "combat_attack_sword_8":
                    return combat_attack_sword_8;
                case  "combat_attack_sword_9":
                    return combat_attack_sword_9;
                case  "combat_attack_sword_10":
                    return combat_attack_sword_10;
                case  "combat_attack_sword_11":
                    return combat_attack_sword_11;
                case  "combat_attack_sword_12":
                    return combat_attack_sword_12;
                case  "unit_mine_stone_1":
                    return unit_mine_stone_1;
                case  "unit_mine_stone_2":
                    return unit_mine_stone_2;
                case  "unit_attack_bat_1":
                    return unit_attack_bat_1;
                case  "unit_attack_bat_2":
                    return unit_attack_bat_2;
                case  "unit_attack_bat_3":
                    return unit_attack_bat_3;
                case  "unit_death_bat_1":
                    return unit_death_bat_1;
                case  "unit_death_bat_2":
                    return unit_death_bat_2;
                case  "unit_death_bat_3":
                    return unit_death_bat_3;
                case  "unit_attack_cyclops_1":
                    return unit_attack_cyclops_1;
                case  "unit_attack_cyclops_2":
                    return unit_attack_cyclops_2;
                case  "unit_attack_cyclops_3":
                    return unit_attack_cyclops_3;
                case  "unit_death_cyclops_1":
                    return unit_death_cyclops_1;
                case  "unit_death_cyclops_2":
                    return unit_death_cyclops_2;
                case  "unit_death_cyclops_3":
                    return unit_death_cyclops_3;
                case  "unit_attack_dragon_1":
                    return unit_attack_dragon_1;
                case  "unit_attack_dragon_2":
                    return unit_attack_dragon_2;
                case  "unit_attack_dragon_3":
                    return unit_attack_dragon_3;
                case  "unit_death_dragon_1":
                    return unit_death_dragon_1;
                case  "unit_death_dragon_2":
                    return unit_death_dragon_2;
                case  "unit_death_dragon_3":
                    return unit_death_dragon_3;
                case  "unit_attack_goblin_1":
                    return unit_attack_goblin_1;
                case  "unit_attack_goblin_2":
                    return unit_attack_goblin_2;
                case  "unit_attack_goblin_3":
                    return unit_attack_goblin_3;
                case  "unit_death_goblin_1":
                    return unit_death_goblin_1;
                case  "unit_death_goblin_2":
                    return unit_death_goblin_2;
                case  "unit_death_goblin_3":
                    return unit_death_goblin_3;
                case  "unit_attack_slime_1":
                    return unit_attack_slime_1;
                case  "unit_attack_slime_2":
                    return unit_attack_slime_2;
                case  "unit_attack_slime_3":
                    return unit_attack_slime_3;
                case  "unit_death_slime_1":
                    return unit_death_slime_1;
                case  "unit_death_slime_2":
                    return unit_death_slime_2;
                case  "unit_death_slime_3":
                    return unit_death_slime_3;
                case  "unit_attack_snake_1":
                    return unit_attack_snake_1;
                case  "unit_attack_snake_2":
                    return unit_attack_snake_2;
                case  "unit_attack_snake_3":
                    return unit_attack_snake_3;
                case  "unit_death_snake_1":
                    return unit_death_snake_1;
                case  "unit_death_snake_2":
                    return unit_death_snake_2;
                case  "unit_death_snake_3":
                    return unit_death_snake_3;
                case  "unit_attack_fighter_4":
                    return unit_attack_fighter_4;
                case  "unit_attack_fighter_5":
                    return unit_attack_fighter_5;
                case  "unit_attack_fighter_6":
                    return unit_attack_fighter_6;
                case  "unit_attack_fighter_7":
                    return unit_attack_fighter_7;
                case  "unit_attack_fighter_8":
                    return unit_attack_fighter_8;
                case  "unit_attack_fighter_9":
                    return unit_attack_fighter_9;
                case  "unit_attack_fighter_10":
                    return unit_attack_fighter_10;
                case  "unit_attack_fighter_11":
                    return unit_attack_fighter_11;
                case  "unit_attack_fighter_12":
                    return unit_attack_fighter_12;
                case  "unit_attack_skeleton_1":
                    return unit_attack_skeleton_1;
                case  "unit_attack_skeleton_2":
                    return unit_attack_skeleton_2;
                case  "unit_attack_skeleton_3":
                    return unit_attack_skeleton_3;
                case  "unit_death_skeleton_1":
                    return unit_death_skeleton_1;
                case  "unit_death_skeleton_2":
                    return unit_death_skeleton_2;
                case  "unit_death_skeleton_3":
                    return unit_death_skeleton_3;
                case  "unit_spawn_fighter_7":
                    return unit_spawn_fighter_7;
                case  "unit_spawn_fighter_8":
                    return unit_spawn_fighter_8;
                case  "unit_spawn_fighter_9":
                    return unit_spawn_fighter_9;
                case  "unit_spawn_fighter_10":
                    return unit_spawn_fighter_10;
                case  "unit_spawn_fighter_11":
                    return unit_spawn_fighter_11;
                case  "unit_spawn_fighter_12":
                    return unit_spawn_fighter_12;
                case  "unit_spawn_fighter_13":
                    return unit_spawn_fighter_13;
                case  "unit_select_fighter_10":
                    return unit_select_fighter_10;
                case  "unit_select_fighter_11":
                    return unit_select_fighter_11;
                case  "unit_select_fighter_12":
                    return unit_select_fighter_12;
                case  "unit_select_fighter_13":
                    return unit_select_fighter_13;
                case  "unit_select_fighter_14":
                    return unit_select_fighter_14;
                case  "unit_select_fighter_15":
                    return unit_select_fighter_15;
                case  "unit_select_fighter_16":
                    return unit_select_fighter_16;
                case  "unit_obey_fighter_10":
                    return unit_obey_fighter_10;
                case  "unit_obey_fighter_11":
                    return unit_obey_fighter_11;
                case  "unit_obey_fighter_12":
                    return unit_obey_fighter_12;
                case  "unit_obey_fighter_13":
                    return unit_obey_fighter_13;
                case  "unit_obey_fighter_14":
                    return unit_obey_fighter_14;
                case  "unit_obey_fighter_15":
                    return unit_obey_fighter_15;
                case  "unit_obey_fighter_16":
                    return unit_obey_fighter_16;
                case  "unit_obey_fighter_17":
                    return unit_obey_fighter_17;
            }
            return null;
        }
        public static object GetFile (string memberName) 
        {
            switch(memberName)
            {
                case  "AnimationChainListFile":
                    return AnimationChainListFile;
                case  "CharactersSheet":
                    return CharactersSheet;
                case  "unit_chop_wood_1":
                    return unit_chop_wood_1;
                case  "unit_chop_wood_2":
                    return unit_chop_wood_2;
                case  "unit_mine_gold_1":
                    return unit_mine_gold_1;
                case  "unit_mine_gold_2":
                    return unit_mine_gold_2;
                case  "unit_attack_worker_1":
                    return unit_attack_worker_1;
                case  "unit_attack_worker_2":
                    return unit_attack_worker_2;
                case  "unit_attack_worker_3":
                    return unit_attack_worker_3;
                case  "unit_death_worker_1":
                    return unit_death_worker_1;
                case  "unit_death_worker_2":
                    return unit_death_worker_2;
                case  "unit_death_worker_3":
                    return unit_death_worker_3;
                case  "unit_obey_worker_1":
                    return unit_obey_worker_1;
                case  "unit_obey_worker_2":
                    return unit_obey_worker_2;
                case  "unit_obey_worker_3":
                    return unit_obey_worker_3;
                case  "unit_select_worker_1":
                    return unit_select_worker_1;
                case  "unit_select_worker_2":
                    return unit_select_worker_2;
                case  "unit_select_worker_3":
                    return unit_select_worker_3;
                case  "unit_spawn_worker_1":
                    return unit_spawn_worker_1;
                case  "unit_spawn_worker_2":
                    return unit_spawn_worker_2;
                case  "unit_spawn_worker_3":
                    return unit_spawn_worker_3;
                case  "unit_attack_fighter_1":
                    return unit_attack_fighter_1;
                case  "unit_attack_fighter_2":
                    return unit_attack_fighter_2;
                case  "unit_attack_fighter_3":
                    return unit_attack_fighter_3;
                case  "unit_death_fighter_1":
                    return unit_death_fighter_1;
                case  "unit_death_fighter_2":
                    return unit_death_fighter_2;
                case  "unit_death_fighter_3":
                    return unit_death_fighter_3;
                case  "unit_obey_fighter_1":
                    return unit_obey_fighter_1;
                case  "unit_obey_fighter_2":
                    return unit_obey_fighter_2;
                case  "unit_obey_fighter_3":
                    return unit_obey_fighter_3;
                case  "unit_select_fighter_1":
                    return unit_select_fighter_1;
                case  "unit_select_fighter_2":
                    return unit_select_fighter_2;
                case  "unit_select_fighter_3":
                    return unit_select_fighter_3;
                case  "unit_spawn_fighter_1":
                    return unit_spawn_fighter_1;
                case  "unit_spawn_fighter_2":
                    return unit_spawn_fighter_2;
                case  "unit_spawn_fighter_3":
                    return unit_spawn_fighter_3;
                case  "MainTileset":
                    return MainTileset;
                case  "unit_obey_fighter_4":
                    return unit_obey_fighter_4;
                case  "unit_obey_fighter_5":
                    return unit_obey_fighter_5;
                case  "unit_obey_fighter_6":
                    return unit_obey_fighter_6;
                case  "unit_obey_fighter_7":
                    return unit_obey_fighter_7;
                case  "unit_obey_fighter_8":
                    return unit_obey_fighter_8;
                case  "unit_obey_fighter_9":
                    return unit_obey_fighter_9;
                case  "unit_select_fighter_4":
                    return unit_select_fighter_4;
                case  "unit_select_fighter_5":
                    return unit_select_fighter_5;
                case  "unit_select_fighter_6":
                    return unit_select_fighter_6;
                case  "unit_select_fighter_7":
                    return unit_select_fighter_7;
                case  "unit_select_fighter_8":
                    return unit_select_fighter_8;
                case  "unit_select_fighter_9":
                    return unit_select_fighter_9;
                case  "unit_spawn_figher_4":
                    return unit_spawn_figher_4;
                case  "unit_spawn_fighter_5":
                    return unit_spawn_fighter_5;
                case  "unit_spawn_fighter_6":
                    return unit_spawn_fighter_6;
                case  "unit_obey_worker_4":
                    return unit_obey_worker_4;
                case  "unit_obey_worker_5":
                    return unit_obey_worker_5;
                case  "unit_obey_worker_6":
                    return unit_obey_worker_6;
                case  "unit_obey_worker_7":
                    return unit_obey_worker_7;
                case  "unit_obey_worker_8":
                    return unit_obey_worker_8;
                case  "unit_obey_worker_9":
                    return unit_obey_worker_9;
                case  "unit_select_worker_4":
                    return unit_select_worker_4;
                case  "unit_select_worker_5":
                    return unit_select_worker_5;
                case  "unit_select_worker_6":
                    return unit_select_worker_6;
                case  "unit_select_worker_7":
                    return unit_select_worker_7;
                case  "unit_select_worker_8":
                    return unit_select_worker_8;
                case  "unit_select_worker_9":
                    return unit_select_worker_9;
                case  "unit_spawn_worker_4":
                    return unit_spawn_worker_4;
                case  "unit_spawn_worker_5":
                    return unit_spawn_worker_5;
                case  "unit_spawn_worker_6":
                    return unit_spawn_worker_6;
                case  "combat_attack_club_1":
                    return combat_attack_club_1;
                case  "combat_attack_club_2":
                    return combat_attack_club_2;
                case  "combat_attack_club_3":
                    return combat_attack_club_3;
                case  "combat_attack_club_4":
                    return combat_attack_club_4;
                case  "combat_attack_club_5":
                    return combat_attack_club_5;
                case  "combat_attack_club_6":
                    return combat_attack_club_6;
                case  "combat_attack_club_7":
                    return combat_attack_club_7;
                case  "combat_attack_club_8":
                    return combat_attack_club_8;
                case  "combat_attack_club_9":
                    return combat_attack_club_9;
                case  "combat_attack_club_10":
                    return combat_attack_club_10;
                case  "combat_attack_club_11":
                    return combat_attack_club_11;
                case  "combat_attack_club_12":
                    return combat_attack_club_12;
                case  "combat_attack_magic_1":
                    return combat_attack_magic_1;
                case  "combat_attack_magic_2":
                    return combat_attack_magic_2;
                case  "combat_attack_magic_3":
                    return combat_attack_magic_3;
                case  "combat_attack_magic_4":
                    return combat_attack_magic_4;
                case  "combat_attack_magic_5":
                    return combat_attack_magic_5;
                case  "combat_attack_magic_6":
                    return combat_attack_magic_6;
                case  "combat_attack_magic_7":
                    return combat_attack_magic_7;
                case  "combat_attack_magic_8":
                    return combat_attack_magic_8;
                case  "combat_attack_magic_9":
                    return combat_attack_magic_9;
                case  "combat_attack_magic_10":
                    return combat_attack_magic_10;
                case  "combat_attack_magic_11":
                    return combat_attack_magic_11;
                case  "combat_attack_magic_12":
                    return combat_attack_magic_12;
                case  "combat_attack_sword_1":
                    return combat_attack_sword_1;
                case  "combat_attack_sword_2":
                    return combat_attack_sword_2;
                case  "combat_attack_sword_3":
                    return combat_attack_sword_3;
                case  "combat_attack_sword_4":
                    return combat_attack_sword_4;
                case  "combat_attack_sword_5":
                    return combat_attack_sword_5;
                case  "combat_attack_sword_6":
                    return combat_attack_sword_6;
                case  "combat_attack_sword_7":
                    return combat_attack_sword_7;
                case  "combat_attack_sword_8":
                    return combat_attack_sword_8;
                case  "combat_attack_sword_9":
                    return combat_attack_sword_9;
                case  "combat_attack_sword_10":
                    return combat_attack_sword_10;
                case  "combat_attack_sword_11":
                    return combat_attack_sword_11;
                case  "combat_attack_sword_12":
                    return combat_attack_sword_12;
                case  "unit_mine_stone_1":
                    return unit_mine_stone_1;
                case  "unit_mine_stone_2":
                    return unit_mine_stone_2;
                case  "unit_attack_bat_1":
                    return unit_attack_bat_1;
                case  "unit_attack_bat_2":
                    return unit_attack_bat_2;
                case  "unit_attack_bat_3":
                    return unit_attack_bat_3;
                case  "unit_death_bat_1":
                    return unit_death_bat_1;
                case  "unit_death_bat_2":
                    return unit_death_bat_2;
                case  "unit_death_bat_3":
                    return unit_death_bat_3;
                case  "unit_attack_cyclops_1":
                    return unit_attack_cyclops_1;
                case  "unit_attack_cyclops_2":
                    return unit_attack_cyclops_2;
                case  "unit_attack_cyclops_3":
                    return unit_attack_cyclops_3;
                case  "unit_death_cyclops_1":
                    return unit_death_cyclops_1;
                case  "unit_death_cyclops_2":
                    return unit_death_cyclops_2;
                case  "unit_death_cyclops_3":
                    return unit_death_cyclops_3;
                case  "unit_attack_dragon_1":
                    return unit_attack_dragon_1;
                case  "unit_attack_dragon_2":
                    return unit_attack_dragon_2;
                case  "unit_attack_dragon_3":
                    return unit_attack_dragon_3;
                case  "unit_death_dragon_1":
                    return unit_death_dragon_1;
                case  "unit_death_dragon_2":
                    return unit_death_dragon_2;
                case  "unit_death_dragon_3":
                    return unit_death_dragon_3;
                case  "unit_attack_goblin_1":
                    return unit_attack_goblin_1;
                case  "unit_attack_goblin_2":
                    return unit_attack_goblin_2;
                case  "unit_attack_goblin_3":
                    return unit_attack_goblin_3;
                case  "unit_death_goblin_1":
                    return unit_death_goblin_1;
                case  "unit_death_goblin_2":
                    return unit_death_goblin_2;
                case  "unit_death_goblin_3":
                    return unit_death_goblin_3;
                case  "unit_attack_slime_1":
                    return unit_attack_slime_1;
                case  "unit_attack_slime_2":
                    return unit_attack_slime_2;
                case  "unit_attack_slime_3":
                    return unit_attack_slime_3;
                case  "unit_death_slime_1":
                    return unit_death_slime_1;
                case  "unit_death_slime_2":
                    return unit_death_slime_2;
                case  "unit_death_slime_3":
                    return unit_death_slime_3;
                case  "unit_attack_snake_1":
                    return unit_attack_snake_1;
                case  "unit_attack_snake_2":
                    return unit_attack_snake_2;
                case  "unit_attack_snake_3":
                    return unit_attack_snake_3;
                case  "unit_death_snake_1":
                    return unit_death_snake_1;
                case  "unit_death_snake_2":
                    return unit_death_snake_2;
                case  "unit_death_snake_3":
                    return unit_death_snake_3;
                case  "unit_attack_fighter_4":
                    return unit_attack_fighter_4;
                case  "unit_attack_fighter_5":
                    return unit_attack_fighter_5;
                case  "unit_attack_fighter_6":
                    return unit_attack_fighter_6;
                case  "unit_attack_fighter_7":
                    return unit_attack_fighter_7;
                case  "unit_attack_fighter_8":
                    return unit_attack_fighter_8;
                case  "unit_attack_fighter_9":
                    return unit_attack_fighter_9;
                case  "unit_attack_fighter_10":
                    return unit_attack_fighter_10;
                case  "unit_attack_fighter_11":
                    return unit_attack_fighter_11;
                case  "unit_attack_fighter_12":
                    return unit_attack_fighter_12;
                case  "unit_attack_skeleton_1":
                    return unit_attack_skeleton_1;
                case  "unit_attack_skeleton_2":
                    return unit_attack_skeleton_2;
                case  "unit_attack_skeleton_3":
                    return unit_attack_skeleton_3;
                case  "unit_death_skeleton_1":
                    return unit_death_skeleton_1;
                case  "unit_death_skeleton_2":
                    return unit_death_skeleton_2;
                case  "unit_death_skeleton_3":
                    return unit_death_skeleton_3;
                case  "unit_spawn_fighter_7":
                    return unit_spawn_fighter_7;
                case  "unit_spawn_fighter_8":
                    return unit_spawn_fighter_8;
                case  "unit_spawn_fighter_9":
                    return unit_spawn_fighter_9;
                case  "unit_spawn_fighter_10":
                    return unit_spawn_fighter_10;
                case  "unit_spawn_fighter_11":
                    return unit_spawn_fighter_11;
                case  "unit_spawn_fighter_12":
                    return unit_spawn_fighter_12;
                case  "unit_spawn_fighter_13":
                    return unit_spawn_fighter_13;
                case  "unit_select_fighter_10":
                    return unit_select_fighter_10;
                case  "unit_select_fighter_11":
                    return unit_select_fighter_11;
                case  "unit_select_fighter_12":
                    return unit_select_fighter_12;
                case  "unit_select_fighter_13":
                    return unit_select_fighter_13;
                case  "unit_select_fighter_14":
                    return unit_select_fighter_14;
                case  "unit_select_fighter_15":
                    return unit_select_fighter_15;
                case  "unit_select_fighter_16":
                    return unit_select_fighter_16;
                case  "unit_obey_fighter_10":
                    return unit_obey_fighter_10;
                case  "unit_obey_fighter_11":
                    return unit_obey_fighter_11;
                case  "unit_obey_fighter_12":
                    return unit_obey_fighter_12;
                case  "unit_obey_fighter_13":
                    return unit_obey_fighter_13;
                case  "unit_obey_fighter_14":
                    return unit_obey_fighter_14;
                case  "unit_obey_fighter_15":
                    return unit_obey_fighter_15;
                case  "unit_obey_fighter_16":
                    return unit_obey_fighter_16;
                case  "unit_obey_fighter_17":
                    return unit_obey_fighter_17;
            }
            return null;
        }
        object GetMember (string memberName) 
        {
            switch(memberName)
            {
                case  "AnimationChainListFile":
                    return AnimationChainListFile;
                case  "CharactersSheet":
                    return CharactersSheet;
                case  "unit_chop_wood_1":
                    return unit_chop_wood_1;
                case  "unit_chop_wood_2":
                    return unit_chop_wood_2;
                case  "unit_mine_gold_1":
                    return unit_mine_gold_1;
                case  "unit_mine_gold_2":
                    return unit_mine_gold_2;
                case  "unit_attack_worker_1":
                    return unit_attack_worker_1;
                case  "unit_attack_worker_2":
                    return unit_attack_worker_2;
                case  "unit_attack_worker_3":
                    return unit_attack_worker_3;
                case  "unit_death_worker_1":
                    return unit_death_worker_1;
                case  "unit_death_worker_2":
                    return unit_death_worker_2;
                case  "unit_death_worker_3":
                    return unit_death_worker_3;
                case  "unit_obey_worker_1":
                    return unit_obey_worker_1;
                case  "unit_obey_worker_2":
                    return unit_obey_worker_2;
                case  "unit_obey_worker_3":
                    return unit_obey_worker_3;
                case  "unit_select_worker_1":
                    return unit_select_worker_1;
                case  "unit_select_worker_2":
                    return unit_select_worker_2;
                case  "unit_select_worker_3":
                    return unit_select_worker_3;
                case  "unit_spawn_worker_1":
                    return unit_spawn_worker_1;
                case  "unit_spawn_worker_2":
                    return unit_spawn_worker_2;
                case  "unit_spawn_worker_3":
                    return unit_spawn_worker_3;
                case  "unit_attack_fighter_1":
                    return unit_attack_fighter_1;
                case  "unit_attack_fighter_2":
                    return unit_attack_fighter_2;
                case  "unit_attack_fighter_3":
                    return unit_attack_fighter_3;
                case  "unit_death_fighter_1":
                    return unit_death_fighter_1;
                case  "unit_death_fighter_2":
                    return unit_death_fighter_2;
                case  "unit_death_fighter_3":
                    return unit_death_fighter_3;
                case  "unit_obey_fighter_1":
                    return unit_obey_fighter_1;
                case  "unit_obey_fighter_2":
                    return unit_obey_fighter_2;
                case  "unit_obey_fighter_3":
                    return unit_obey_fighter_3;
                case  "unit_select_fighter_1":
                    return unit_select_fighter_1;
                case  "unit_select_fighter_2":
                    return unit_select_fighter_2;
                case  "unit_select_fighter_3":
                    return unit_select_fighter_3;
                case  "unit_spawn_fighter_1":
                    return unit_spawn_fighter_1;
                case  "unit_spawn_fighter_2":
                    return unit_spawn_fighter_2;
                case  "unit_spawn_fighter_3":
                    return unit_spawn_fighter_3;
                case  "MainTileset":
                    return MainTileset;
                case  "unit_obey_fighter_4":
                    return unit_obey_fighter_4;
                case  "unit_obey_fighter_5":
                    return unit_obey_fighter_5;
                case  "unit_obey_fighter_6":
                    return unit_obey_fighter_6;
                case  "unit_obey_fighter_7":
                    return unit_obey_fighter_7;
                case  "unit_obey_fighter_8":
                    return unit_obey_fighter_8;
                case  "unit_obey_fighter_9":
                    return unit_obey_fighter_9;
                case  "unit_select_fighter_4":
                    return unit_select_fighter_4;
                case  "unit_select_fighter_5":
                    return unit_select_fighter_5;
                case  "unit_select_fighter_6":
                    return unit_select_fighter_6;
                case  "unit_select_fighter_7":
                    return unit_select_fighter_7;
                case  "unit_select_fighter_8":
                    return unit_select_fighter_8;
                case  "unit_select_fighter_9":
                    return unit_select_fighter_9;
                case  "unit_spawn_figher_4":
                    return unit_spawn_figher_4;
                case  "unit_spawn_fighter_5":
                    return unit_spawn_fighter_5;
                case  "unit_spawn_fighter_6":
                    return unit_spawn_fighter_6;
                case  "unit_obey_worker_4":
                    return unit_obey_worker_4;
                case  "unit_obey_worker_5":
                    return unit_obey_worker_5;
                case  "unit_obey_worker_6":
                    return unit_obey_worker_6;
                case  "unit_obey_worker_7":
                    return unit_obey_worker_7;
                case  "unit_obey_worker_8":
                    return unit_obey_worker_8;
                case  "unit_obey_worker_9":
                    return unit_obey_worker_9;
                case  "unit_select_worker_4":
                    return unit_select_worker_4;
                case  "unit_select_worker_5":
                    return unit_select_worker_5;
                case  "unit_select_worker_6":
                    return unit_select_worker_6;
                case  "unit_select_worker_7":
                    return unit_select_worker_7;
                case  "unit_select_worker_8":
                    return unit_select_worker_8;
                case  "unit_select_worker_9":
                    return unit_select_worker_9;
                case  "unit_spawn_worker_4":
                    return unit_spawn_worker_4;
                case  "unit_spawn_worker_5":
                    return unit_spawn_worker_5;
                case  "unit_spawn_worker_6":
                    return unit_spawn_worker_6;
                case  "combat_attack_club_1":
                    return combat_attack_club_1;
                case  "combat_attack_club_2":
                    return combat_attack_club_2;
                case  "combat_attack_club_3":
                    return combat_attack_club_3;
                case  "combat_attack_club_4":
                    return combat_attack_club_4;
                case  "combat_attack_club_5":
                    return combat_attack_club_5;
                case  "combat_attack_club_6":
                    return combat_attack_club_6;
                case  "combat_attack_club_7":
                    return combat_attack_club_7;
                case  "combat_attack_club_8":
                    return combat_attack_club_8;
                case  "combat_attack_club_9":
                    return combat_attack_club_9;
                case  "combat_attack_club_10":
                    return combat_attack_club_10;
                case  "combat_attack_club_11":
                    return combat_attack_club_11;
                case  "combat_attack_club_12":
                    return combat_attack_club_12;
                case  "combat_attack_magic_1":
                    return combat_attack_magic_1;
                case  "combat_attack_magic_2":
                    return combat_attack_magic_2;
                case  "combat_attack_magic_3":
                    return combat_attack_magic_3;
                case  "combat_attack_magic_4":
                    return combat_attack_magic_4;
                case  "combat_attack_magic_5":
                    return combat_attack_magic_5;
                case  "combat_attack_magic_6":
                    return combat_attack_magic_6;
                case  "combat_attack_magic_7":
                    return combat_attack_magic_7;
                case  "combat_attack_magic_8":
                    return combat_attack_magic_8;
                case  "combat_attack_magic_9":
                    return combat_attack_magic_9;
                case  "combat_attack_magic_10":
                    return combat_attack_magic_10;
                case  "combat_attack_magic_11":
                    return combat_attack_magic_11;
                case  "combat_attack_magic_12":
                    return combat_attack_magic_12;
                case  "combat_attack_sword_1":
                    return combat_attack_sword_1;
                case  "combat_attack_sword_2":
                    return combat_attack_sword_2;
                case  "combat_attack_sword_3":
                    return combat_attack_sword_3;
                case  "combat_attack_sword_4":
                    return combat_attack_sword_4;
                case  "combat_attack_sword_5":
                    return combat_attack_sword_5;
                case  "combat_attack_sword_6":
                    return combat_attack_sword_6;
                case  "combat_attack_sword_7":
                    return combat_attack_sword_7;
                case  "combat_attack_sword_8":
                    return combat_attack_sword_8;
                case  "combat_attack_sword_9":
                    return combat_attack_sword_9;
                case  "combat_attack_sword_10":
                    return combat_attack_sword_10;
                case  "combat_attack_sword_11":
                    return combat_attack_sword_11;
                case  "combat_attack_sword_12":
                    return combat_attack_sword_12;
                case  "unit_mine_stone_1":
                    return unit_mine_stone_1;
                case  "unit_mine_stone_2":
                    return unit_mine_stone_2;
                case  "unit_attack_bat_1":
                    return unit_attack_bat_1;
                case  "unit_attack_bat_2":
                    return unit_attack_bat_2;
                case  "unit_attack_bat_3":
                    return unit_attack_bat_3;
                case  "unit_death_bat_1":
                    return unit_death_bat_1;
                case  "unit_death_bat_2":
                    return unit_death_bat_2;
                case  "unit_death_bat_3":
                    return unit_death_bat_3;
                case  "unit_attack_cyclops_1":
                    return unit_attack_cyclops_1;
                case  "unit_attack_cyclops_2":
                    return unit_attack_cyclops_2;
                case  "unit_attack_cyclops_3":
                    return unit_attack_cyclops_3;
                case  "unit_death_cyclops_1":
                    return unit_death_cyclops_1;
                case  "unit_death_cyclops_2":
                    return unit_death_cyclops_2;
                case  "unit_death_cyclops_3":
                    return unit_death_cyclops_3;
                case  "unit_attack_dragon_1":
                    return unit_attack_dragon_1;
                case  "unit_attack_dragon_2":
                    return unit_attack_dragon_2;
                case  "unit_attack_dragon_3":
                    return unit_attack_dragon_3;
                case  "unit_death_dragon_1":
                    return unit_death_dragon_1;
                case  "unit_death_dragon_2":
                    return unit_death_dragon_2;
                case  "unit_death_dragon_3":
                    return unit_death_dragon_3;
                case  "unit_attack_goblin_1":
                    return unit_attack_goblin_1;
                case  "unit_attack_goblin_2":
                    return unit_attack_goblin_2;
                case  "unit_attack_goblin_3":
                    return unit_attack_goblin_3;
                case  "unit_death_goblin_1":
                    return unit_death_goblin_1;
                case  "unit_death_goblin_2":
                    return unit_death_goblin_2;
                case  "unit_death_goblin_3":
                    return unit_death_goblin_3;
                case  "unit_attack_slime_1":
                    return unit_attack_slime_1;
                case  "unit_attack_slime_2":
                    return unit_attack_slime_2;
                case  "unit_attack_slime_3":
                    return unit_attack_slime_3;
                case  "unit_death_slime_1":
                    return unit_death_slime_1;
                case  "unit_death_slime_2":
                    return unit_death_slime_2;
                case  "unit_death_slime_3":
                    return unit_death_slime_3;
                case  "unit_attack_snake_1":
                    return unit_attack_snake_1;
                case  "unit_attack_snake_2":
                    return unit_attack_snake_2;
                case  "unit_attack_snake_3":
                    return unit_attack_snake_3;
                case  "unit_death_snake_1":
                    return unit_death_snake_1;
                case  "unit_death_snake_2":
                    return unit_death_snake_2;
                case  "unit_death_snake_3":
                    return unit_death_snake_3;
                case  "unit_attack_fighter_4":
                    return unit_attack_fighter_4;
                case  "unit_attack_fighter_5":
                    return unit_attack_fighter_5;
                case  "unit_attack_fighter_6":
                    return unit_attack_fighter_6;
                case  "unit_attack_fighter_7":
                    return unit_attack_fighter_7;
                case  "unit_attack_fighter_8":
                    return unit_attack_fighter_8;
                case  "unit_attack_fighter_9":
                    return unit_attack_fighter_9;
                case  "unit_attack_fighter_10":
                    return unit_attack_fighter_10;
                case  "unit_attack_fighter_11":
                    return unit_attack_fighter_11;
                case  "unit_attack_fighter_12":
                    return unit_attack_fighter_12;
                case  "unit_attack_skeleton_1":
                    return unit_attack_skeleton_1;
                case  "unit_attack_skeleton_2":
                    return unit_attack_skeleton_2;
                case  "unit_attack_skeleton_3":
                    return unit_attack_skeleton_3;
                case  "unit_death_skeleton_1":
                    return unit_death_skeleton_1;
                case  "unit_death_skeleton_2":
                    return unit_death_skeleton_2;
                case  "unit_death_skeleton_3":
                    return unit_death_skeleton_3;
                case  "unit_spawn_fighter_7":
                    return unit_spawn_fighter_7;
                case  "unit_spawn_fighter_8":
                    return unit_spawn_fighter_8;
                case  "unit_spawn_fighter_9":
                    return unit_spawn_fighter_9;
                case  "unit_spawn_fighter_10":
                    return unit_spawn_fighter_10;
                case  "unit_spawn_fighter_11":
                    return unit_spawn_fighter_11;
                case  "unit_spawn_fighter_12":
                    return unit_spawn_fighter_12;
                case  "unit_spawn_fighter_13":
                    return unit_spawn_fighter_13;
                case  "unit_select_fighter_10":
                    return unit_select_fighter_10;
                case  "unit_select_fighter_11":
                    return unit_select_fighter_11;
                case  "unit_select_fighter_12":
                    return unit_select_fighter_12;
                case  "unit_select_fighter_13":
                    return unit_select_fighter_13;
                case  "unit_select_fighter_14":
                    return unit_select_fighter_14;
                case  "unit_select_fighter_15":
                    return unit_select_fighter_15;
                case  "unit_select_fighter_16":
                    return unit_select_fighter_16;
                case  "unit_obey_fighter_10":
                    return unit_obey_fighter_10;
                case  "unit_obey_fighter_11":
                    return unit_obey_fighter_11;
                case  "unit_obey_fighter_12":
                    return unit_obey_fighter_12;
                case  "unit_obey_fighter_13":
                    return unit_obey_fighter_13;
                case  "unit_obey_fighter_14":
                    return unit_obey_fighter_14;
                case  "unit_obey_fighter_15":
                    return unit_obey_fighter_15;
                case  "unit_obey_fighter_16":
                    return unit_obey_fighter_16;
                case  "unit_obey_fighter_17":
                    return unit_obey_fighter_17;
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
            if (ResourceIndicatorSpriteInstance.Alpha != 0 && ResourceIndicatorSpriteInstance.AbsoluteVisible && cursor.IsOn3D(ResourceIndicatorSpriteInstance, LayerProvidedByContainer))
            {
                return true;
            }
            if (cursor.IsOn3D(CircleInstance, LayerProvidedByContainer))
            {
                return true;
            }
            if (cursor.IsOn3D(ResourceCollectCircleInstance, LayerProvidedByContainer))
            {
                return true;
            }
            if (ShadowSprite.Alpha != 0 && ShadowSprite.AbsoluteVisible && cursor.IsOn3D(ShadowSprite, LayerProvidedByContainer))
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
            FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(ResourceIndicatorSpriteInstance);
            FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(CircleInstance);
            FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(ResourceCollectCircleInstance);
            FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(ShadowSprite);
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
                layerToRemoveFrom.Remove(ResourceIndicatorSpriteInstance);
            }
            if (layerToMoveTo != null || !SpriteManager.AutomaticallyUpdatedSprites.Contains(ResourceIndicatorSpriteInstance))
            {
                FlatRedBall.SpriteManager.AddToLayer(ResourceIndicatorSpriteInstance, layerToMoveTo);
            }
            if (layerToRemoveFrom != null)
            {
                layerToRemoveFrom.Remove(CircleInstance);
            }
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(CircleInstance, layerToMoveTo);
            if (layerToRemoveFrom != null)
            {
                layerToRemoveFrom.Remove(ResourceCollectCircleInstance);
            }
            FlatRedBall.Math.Geometry.ShapeManager.AddToLayer(ResourceCollectCircleInstance, layerToMoveTo);
            if (layerToRemoveFrom != null)
            {
                layerToRemoveFrom.Remove(ShadowSprite);
            }
            if (layerToMoveTo != null || !SpriteManager.AutomaticallyUpdatedSprites.Contains(ShadowSprite))
            {
                FlatRedBall.SpriteManager.AddToLayer(ShadowSprite, layerToMoveTo);
            }
            LayerProvidedByContainer = layerToMoveTo;
        }
    }
}
