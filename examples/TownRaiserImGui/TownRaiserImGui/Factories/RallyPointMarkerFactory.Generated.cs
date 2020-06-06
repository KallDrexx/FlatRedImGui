using TownRaiserImGui.Entities;
using System;
using FlatRedBall.Math;
using FlatRedBall.Graphics;
using TownRaiserImGui.Performance;

namespace TownRaiserImGui.Factories
{
    public class RallyPointMarkerFactory : IEntityFactory
    {
        public static FlatRedBall.Math.Axis? SortAxis { get; set;}
        public static RallyPointMarker CreateNew (float x = 0, float y = 0) 
        {
            return CreateNew(null, x, y);
        }
        public static RallyPointMarker CreateNew (Layer layer, float x = 0, float y = 0) 
        {
            RallyPointMarker instance = null;
            instance = new RallyPointMarker(mContentManagerName ?? FlatRedBall.Screens.ScreenManager.CurrentScreen.ContentManagerName, false);
            instance.AddToManagers(layer);
            instance.X = x;
            instance.Y = y;
            foreach (var list in ListsToAddTo)
            {
                if (SortAxis == FlatRedBall.Math.Axis.X && list is PositionedObjectList<RallyPointMarker>)
                {
                    var index = (list as PositionedObjectList<RallyPointMarker>).GetFirstAfter(x, Axis.X, 0, list.Count);
                    list.Insert(index, instance);
                }
                else if (SortAxis == FlatRedBall.Math.Axis.Y && list is PositionedObjectList<RallyPointMarker>)
                {
                    var index = (list as PositionedObjectList<RallyPointMarker>).GetFirstAfter(y, Axis.Y, 0, list.Count);
                    list.Insert(index, instance);
                }
                else
                {
                    // Sort Z not supported
                    list.Add(instance);
                }
            }
            if (EntitySpawned != null)
            {
                EntitySpawned(instance);
            }
            return instance;
        }
        
        public static void Initialize (string contentManager) 
        {
            mContentManagerName = contentManager;
        }
        
        public static void Destroy () 
        {
            mContentManagerName = null;
            ListsToAddTo.Clear();
            SortAxis = null;
            mPool.Clear();
            EntitySpawned = null;
        }
        
        private static void FactoryInitialize () 
        {
            const int numberToPreAllocate = 20;
            for (int i = 0; i < numberToPreAllocate; i++)
            {
                RallyPointMarker instance = new RallyPointMarker(mContentManagerName, false);
                mPool.AddToPool(instance);
            }
        }
        
        /// <summary>
        /// Makes the argument objectToMakeUnused marked as unused.  This method is generated to be used
        /// by generated code.  Use Destroy instead when writing custom code so that your code will behave
        /// the same whether your Entity is pooled or not.
        /// </summary>
        public static void MakeUnused (RallyPointMarker objectToMakeUnused) 
        {
            MakeUnused(objectToMakeUnused, true);
        }
        
        /// <summary>
        /// Makes the argument objectToMakeUnused marked as unused.  This method is generated to be used
        /// by generated code.  Use Destroy instead when writing custom code so that your code will behave
        /// the same whether your Entity is pooled or not.
        /// </summary>
        public static void MakeUnused (RallyPointMarker objectToMakeUnused, bool callDestroy) 
        {
            if (callDestroy)
            {
                objectToMakeUnused.Destroy();
            }
        }
        
        public static void AddList<T> (System.Collections.Generic.IList<T> newList) where T : RallyPointMarker
        {
            ListsToAddTo.Add(newList as System.Collections.IList);
        }
        public static void RemoveList<T> (System.Collections.Generic.IList<T> listToRemove) where T : RallyPointMarker
        {
            ListsToAddTo.Remove(listToRemove as System.Collections.IList);
        }
        public static void ClearListsToAddTo () 
        {
            ListsToAddTo.Clear();
        }
        
        
            static string mContentManagerName;
            static System.Collections.Generic.List<System.Collections.IList> ListsToAddTo = new System.Collections.Generic.List<System.Collections.IList>();
            static PoolList<RallyPointMarker> mPool = new PoolList<RallyPointMarker>();
            public static Action<RallyPointMarker> EntitySpawned;
            object IEntityFactory.CreateNew () 
            {
                return RallyPointMarkerFactory.CreateNew();
            }
            object IEntityFactory.CreateNew (Layer layer) 
            {
                return RallyPointMarkerFactory.CreateNew(layer);
            }
            void IEntityFactory.Initialize (string contentManagerName) 
            {
                RallyPointMarkerFactory.Initialize(contentManagerName);
            }
            void IEntityFactory.ClearListsToAddTo () 
            {
                RallyPointMarkerFactory.ClearListsToAddTo();
            }
            static RallyPointMarkerFactory mSelf;
            public static RallyPointMarkerFactory Self
            {
                get
                {
                    if (mSelf == null)
                    {
                        mSelf = new RallyPointMarkerFactory();
                    }
                    return mSelf;
                }
            }
    }
}
