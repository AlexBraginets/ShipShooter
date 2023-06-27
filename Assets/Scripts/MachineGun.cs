using System;
using UnityEngine;

public class MachineGun : MonoBehaviour
{
   [SerializeField] private GameInput _gameInput;
   [SerializeField] private ShootActionWrapper _shootActionWrapper;
   public event Action OnStartShooting;
   public event Action OnStopShooting;
   private void Start()
   {
      _gameInput.OnStartShooting += StartShooting;
      _gameInput.OnStopShooting += StopShooting;
      _shootActionWrapper.OnShoot += Shoot;
   }

   private void StartShooting()
   {
      OnStartShooting?.Invoke();
   }

   private void StopShooting()
   {
      OnStopShooting?.Invoke();
   }

   public void Shoot()
   {
      Debug.Log("MachineGun.Shoot");
   }
}
