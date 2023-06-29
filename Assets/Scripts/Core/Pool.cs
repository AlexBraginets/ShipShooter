using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class Pool : MonoBehaviour
    {
        private Dictionary<Type, BasePool> _pools = new Dictionary<Type, BasePool>();
        public static Pool Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        public static T Get<T>(T prefab) where T : MonoBehaviour
        {
            return Instance.GetInstance(prefab);
        }

        private T GetInstance<T>(T prefab) where T : MonoBehaviour
        {
            BasePool pool;
            if (_pools.ContainsKey(typeof(T)))
            {
                pool = _pools[typeof(T)];
            }
            else
            {
                pool = new GenericPool<T>();
                _pools.Add(typeof(T), pool);
            }

            return pool.Get<T>(prefab);
        }
    }
}