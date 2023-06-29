using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core
{
    public class GenericPool<T> : BasePool where T : MonoBehaviour
    {
        private Dictionary<T, List<T>> _instancesMap = new Dictionary<T, List<T>>();

        private T GetInstance(T prefab)
        {
            List<T> instances;
            if (_instancesMap.ContainsKey(prefab))
            {
                instances = _instancesMap[prefab];
            }
            else
            {
                instances = new List<T>();
                _instancesMap.Add(prefab, instances);
            }

            var instance = instances.FirstOrDefault(x => !x.gameObject.activeSelf);
            if (!instance)
            {
                instance = Object.Instantiate(prefab);
                instances.Add(instance);
            }

            instance.gameObject.SetActive(true);
            return instance;
        }

        public override T1 Get<T1>(T1 prefab)
        {
            return GetInstance(prefab as T) as T1;
        }
    }
}