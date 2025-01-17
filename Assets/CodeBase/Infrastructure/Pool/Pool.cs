﻿using System.Collections.Generic;
using UnityEngine;

namespace CodeBase.Infrastructure.Pool
{
    [DisallowMultipleComponent]
    public class Pool : MonoBehaviour
    {
        public GameObject Prefab { get; private set; }
        public Transform PoolablesParent { get; private set; }
        
        public IReadOnlyList<Poolable> Poolables => pooledGameObjects;

        private readonly List<Poolable> pooledGameObjects = new List<Poolable>(64);
        
        private bool isSetup;
        
        public void Setup(GameObject prefab, Transform parent)
        {
            if (isSetup) return;

            Prefab = prefab;
            PoolablesParent = parent;
            
            isSetup = true;
        }
        
        public Poolable GetFreeObject()
        {
            if (pooledGameObjects.Count > 0)
            {
                Poolable poolable = pooledGameObjects[0];
                pooledGameObjects.RemoveAt(0);
                return poolable;
            }
            
            return InstantiateObjectInThisPool();
        }

        public void PopulatePool(int count)
        {
            for (int i = 0; i < count; i++) 
                IncludePoolable(InstantiateObjectInThisPool());
        }

        public void IncludePoolable(Poolable poolable)
        {
            if (Prefab != poolable.Prefab)
            {
                Debug.LogError("You tries to include object from other pool!");
                return;
            }

            if (pooledGameObjects.Contains(poolable) == false) 
                pooledGameObjects.Add(poolable);
        }

        private Poolable InstantiateObjectInThisPool()
        {
            Poolable newPoolable = Instantiate(Prefab, PoolablesParent).AddComponent<Poolable>();
            
            newPoolable.Setup(this, Prefab, false);

            return newPoolable;
        }
    }
}