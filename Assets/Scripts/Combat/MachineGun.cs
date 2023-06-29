using System;
using Core;
using UI;
using UnityEngine;
using UserInput;
using Views;

namespace Combat
{
    public class MachineGun : MonoBehaviour
    {
        [SerializeField] private GameInput _gameInput;
        [SerializeField] private ShootActionWrapper _shootActionWrapper;
        [SerializeField] private Camera _camera;
        public event Action OnStartShooting;
        public event Action OnStopShooting;
        public event Action OnShoot;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _shootingPoint;
        [SerializeField] private float _bulletSpeed;
        [SerializeField] private MuzzleFlash[] _muzzleFlashes;
        [SerializeField] private IronSight _ironSight;
        private int _muzzleFlashIndex;

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
            var bullet = Pool.Get(_bulletPrefab);
            var bulletTransform = bullet.transform;
            bulletTransform.position = _shootingPoint.position;
            bulletTransform.rotation = _shootingPoint.rotation;

            Target target = null;
            Ray ray = _camera.ViewportPointToRay(Vector3.one * .5f);
            var raycastDistance = 1000f;

            if (Physics.Raycast(ray, out RaycastHit hit, raycastDistance))
            {
                hit.transform.TryGetComponent(out target);
            }

            Vector3 shootDirection = _camera.transform.forward;
            if (target)
            {
                shootDirection = (hit.point - _shootingPoint.position).normalized;
            }

            bullet.SetVelocity(shootDirection * _bulletSpeed);
            _muzzleFlashes[_muzzleFlashIndex].Show();
            _muzzleFlashIndex++;
            _muzzleFlashIndex %= _muzzleFlashes.Length;
            OnShoot?.Invoke();
        }

        private void Update()
        {
            Ray ray = _camera.ViewportPointToRay(Vector3.one * .5f);
            var raycastDistance = 1000f;
            bool isTargetInView = false;
            if (Physics.Raycast(ray, out RaycastHit hit, raycastDistance))
            {
                if (hit.transform.TryGetComponent(out IronSightDetector ironSightDetector))
                {
                    ironSightDetector.OnEnter();
                }

                isTargetInView = hit.transform.TryGetComponent(out Target target);
            }

            if (isTargetInView)
            {
                _ironSight.SetOnTarget();
            }
            else
            {
                _ironSight.ResetOnTarget();
            }
        }
    }
}