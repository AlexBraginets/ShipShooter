using System;
using DG.Tweening;
using UnityEngine;

namespace Core
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _period;
        [SerializeField] private Transform _rotationPoint;
        private float _periodCopy;

        private void Awake()
        {
            _periodCopy = _period;
        }

        private void Update()
        {
            float dAngle = Time.deltaTime / _period * 360f;
            transform.RotateAround(_rotationPoint.position, Vector3.up, dAngle);
            Debug.Log($"period: {_period}");
        }

        public void SlowlyStop(float duration)
        {
            DOTween.To(() => 0, LerpStop, 1f, duration);
        }

        private void LerpStop(float t)
        {
            _period = _periodCopy * Mathf.Pow(2, (3 * t));
        }
    }
}