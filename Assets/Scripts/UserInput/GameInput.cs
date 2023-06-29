using System;
using UnityEngine;

namespace UserInput
{
    public class GameInput : MonoBehaviour
    {
        public event Action OnStartShooting;
        public event Action OnStopShooting;
        public bool IsBlocked { get; set; }
        private void Update()
        {
            if (IsBlocked) return;
            if (Input.GetMouseButtonDown(0))
            {
                OnStartShooting?.Invoke();
            }

            if (Input.GetMouseButtonUp(0))
            {
                StopShooting();
            }
        }

        public void StopShooting()
        {
            OnStopShooting?.Invoke();
        }
    }
}
