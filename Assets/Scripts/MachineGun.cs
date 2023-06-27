using System;
using UnityEngine;

public class MachineGun : MonoBehaviour
{
   [SerializeField] private GameInput _gameInput;
   [SerializeField] private ShootActionWrapper _shootActionWrapper;
   [SerializeField] private LayerMask _targetLayerMask;
   [SerializeField] private Camera _camera;
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

   private void Shoot()
   {
      Ray ray = _camera.ViewportPointToRay(Vector3.one * .5f);
      var raycastDistance = 1000f;
      if (Physics.Raycast(ray, out RaycastHit hit, raycastDistance, _targetLayerMask))
      {
         if (hit.transform.TryGetComponent(out Target target))
         {
            target.Destroy();
         }
      }
   }
}
