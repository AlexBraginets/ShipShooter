using UnityEngine;

namespace Core
{
    public abstract class BasePool
    {
        public abstract T Get<T>(T prefab) where T : MonoBehaviour;
    }
}
