using System;
using UnityEngine;

namespace Core
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float _value = 100;
        [SerializeField] private float _maxValue = 100;
        public event Action<float> OnChanged;
        public float RelativeValue => _value / _maxValue;
        public float MaxValue => _maxValue;
        public float Value
        {
            get => _value;
            set
            {
                if (_value == value) return;
                _value = Mathf.Clamp(value, 0, _maxValue);
                OnChanged?.Invoke(RelativeValue);
            }
        }
    }
}