using System;
using Core;
using UnityEngine;

namespace Combat
{
    public class Target : MonoBehaviour
    {
        [SerializeField] private Health _health;
        public event Action OnDamage;
        public event Action OnDestroyed;
        private bool _isDestroyed = false;

        public void Damage(float amount)
        {
            OnDamage?.Invoke();
            _health.Value -= amount;
            if (_health.Value < .001f && !_isDestroyed)
            {
                Destroy();
            }
        }

        private void Destroy()
        {
            _isDestroyed = true;
            OnDestroyed?.Invoke();
        }
    }
}