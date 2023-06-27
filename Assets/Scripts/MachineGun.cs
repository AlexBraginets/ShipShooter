using System;
using UnityEngine;

public class MachineGun : MonoBehaviour
{
   [SerializeField] private GameInput _gameInput;
   public event Action OnStartShooting;
   public event Action OnStopShooting;
   private void Start()
   {
      _gameInput.OnStartShooting += StartShooting;
      _gameInput.OnStopShooting += StopShooting;
   }

   private void StartShooting()
   {
      OnStartShooting?.Invoke();
   }

   private void StopShooting()
   {
      OnStopShooting?.Invoke();
   }
}
