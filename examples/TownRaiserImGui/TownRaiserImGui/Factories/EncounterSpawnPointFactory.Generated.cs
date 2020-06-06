using TownRaiserImGui.Entities;
using System;
using FlatRedBall.Math;
using FlatRedBall.Graphics;
using TownRaiserImGui.Performance;

namespace TownRaiserImGui.Factories
{
    public class EncounterSpawnPointFactory : IEntityFactory
    {
        public static FlatRedBall.Math.Axis? SortAxis { get; set;}
        public static EncounterSpawnPoint CreateNew (float x = 0, float y = 0) 
        {
            return CreateNew(null, x, y);
        }
        public static EncounterSpawnPoint CreateNew (Layer layer, float x = 0, float y = 0) 
        {
            EncounterSpawnPoint instance = null;
            instance = new EncounterSpawnPoint(mContentManagerName ?? FlatRedBall.Screens.ScreenManager.CurrentScreen.ContentManagerName, false);
            instance.AddToManagers(layer);
            instance.X = x;
            instance.Y = y;
            foreach (var list in ListsToAddTo)
            {
                if (SortAxis == FlatRedBall.Math.Axis.X && list is PositionedObjectList<EncounterSpawnPoint>)
                {
                    var index = (list as PositionedObjectList<EncounterSpawnPoint>).GetFirstAfter(x, Axis.X, 0, list.Count);
                    list.Insert(index, instance);
                }
                else if (SortAxis == FlatRedBall.Math.Axis.Y && list is PositionedObjectList<EncounterSpawnPoint>)
                {
                    var index = (list as PositionedObjectList<EncounterSpawnPoint>).GetFirstAfter(y, Axis.Y, 0, list.Count);
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
                EncounterSpawnPoint instance = new EncounterSpawnPoint(mContentManagerName, false);
                mPool.AddToPool(instance);
            }
        }
        
        /// <summary>
        /// Makes the argument objectToMakeUnused marked as unused.  This method is generated to be used
        /// by generated code.  Use Destroy instead when writing custom code so that your code will behave
        /// the same whether your Entity is pooled or not.
        /// </summary>
        public static void MakeUnused (EncounterSpawnPoint objectToMakeUnused) 
        {
            MakeUnused(objectToMakeUnused, true);
        }
        
        /// <summary>
        /// Makes the argument objectToMakeUnused marked as unused.  This method is generated to be used
        /// by generated code.  Use Destroy instead when writing custom code so that your code will behave
        /// the same whether your Entity is pooled or not.
        /// </summary>
        public static void MakeUnused (EncounterSpawnPoint objectToMakeUnused, bool callDestroy) 
        {
            if (callDestroy)
            {
                objectToMakeUnused.Destroy();
            }
        }
        
        public static void AddList<T> (System.Collections.Generic.IList<T> newList) where T : EncounterSpawnPoint
        {
            ListsToAddTo.Add(newList as System.Collections.IList);
        }
        public static void RemoveList<T> (System.Collections.Generic.IList<T> listToRemove) where T : EncounterSpawnPoint
        {
            ListsToAddTo.Remove(listToRemove as System.Collections.IList);
        }
        public static void ClearListsToAddTo () 
        {
            ListsToAddTo.Clear();
        }
        
        
            static string mContentManagerName;
            static System.Collections.Generic.List<System.Collections.IList> ListsToAddTo = new System.Collections.Generic.List<System.Collections.IList>();
            static PoolList<EncounterSpawnPoint> mPool = new PoolList<EncounterSpawnPoint>();
            public static Action<EncounterSpawnPoint> EntitySpawned;
            object IEntityFactory.CreateNew () 
            {
                return EncounterSpawnPointFactory.CreateNew();
            }
            object IEntityFactory.CreateNew (Layer layer) 
            {
                return EncounterSpawnPointFactory.CreateNew(layer);
            }
            void IEntityFactory.Initialize (string contentManagerName) 
            {
                EncounterSpawnPointFactory.Initialize(contentManagerName);
            }
            void IEntityFactory.ClearListsToAddTo () 
            {
                EncounterSpawnPointFactory.ClearListsToAddTo();
            }
            static EncounterSpawnPointFactory mSelf;
            public static EncounterSpawnPointFactory Self
            {
                get
                {
                    if (mSelf == null)
                    {
                        mSelf = new EncounterSpawnPointFactory();
                    }
                    return mSelf;
                }
            }
    }
}
