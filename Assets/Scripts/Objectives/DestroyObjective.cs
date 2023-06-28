using UnityEngine;
using Utils;

namespace Objectives
{
    public class DestroyObjective : Objective
    {
        [SerializeField] private OnDestroyActionWrapper[] _objects2Destroy;
        private int _destroyedObjectCount;
        private int _targetDestroyedObjectCount;
        private void Start()
        {
            _targetDestroyedObjectCount = _objects2Destroy.Length;
            foreach (var object2Destroy in _objects2Destroy)
            {
                object2Destroy.OnDestoryAction += OnObjectDestroyed;
            }
        }

        private void OnObjectDestroyed()
        {
            _destroyedObjectCount++;
            if (_destroyedObjectCount == _targetDestroyedObjectCount)
            {
                CompleteObjective();
            }
        }
    }
}
