using System.Collections.Generic;
using Audio;
using Core;
using UnityEngine;
using Views;

namespace Combat
{
    public class Turret : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Vector2 _yawLimit;
        [SerializeField] private Vector2 _pitchLimit;
        [SerializeField] private float _rotationSpeed;
        [Header("Shooting")] [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private float _bulletSpeed;
        [SerializeField] private float _shootingRate;
        [SerializeField] private MuzzleFlash _muzzleFlash;
        [SerializeField] private LayerMask _shootingMask;
        [SerializeField] private bool _adjustYaw;
        [SerializeField] private LoopAudioPlayer _shootAudioPlayer;
        private float _yaw;
        private float _pitch;
        private float _shootingBlockedTime;
        public List<float> yaws = new List<float>();
        private bool _isShooting;

        private void Update()
        {
            FollowTarget();
            TryShoot();
        }

        private void TryShoot()
        {
            _isShooting = false;
            if (Time.time < _shootingBlockedTime) return;
            Ray ray = new Ray(transform.position, transform.forward);
            var raycastDistance = 1000f;
            if (Physics.Raycast(ray, out RaycastHit hit, raycastDistance, _shootingMask))
            {
                if (hit.transform.CompareTag("Player"))
                {
                    Shoot();
                }
            }

            if (_isShooting)
            {
                _shootAudioPlayer.Play();
            }
            else
            {
                _shootAudioPlayer.Stop();
            }
        }

        private void Shoot()
        {
            _isShooting = true;
            var bullet = Pool.Get(_bulletPrefab);
            var bulletTransform = bullet.transform;
            bulletTransform.position = _shootPoint.position;
            bulletTransform.rotation = _shootPoint.rotation;

            Vector3 shootDirection = (_target.position - _shootPoint.position).normalized;
            bullet.SetVelocity(_bulletSpeed * shootDirection);

            _shootingBlockedTime = Time.time + 1f / _shootingRate;
            _muzzleFlash.Show();
        }

        private void FollowTarget()
        {
            Vector3 direction2Target = (_target.position - transform.position).normalized;
            var rotation2Target = Quaternion.LookRotation(direction2Target, Vector3.up);
            var currentRotation = transform.rotation;
            var lerpRotation = Quaternion.Slerp(currentRotation, rotation2Target, _rotationSpeed * Time.deltaTime);
            lerpRotation = Quaternion.Inverse(transform.parent.rotation) * lerpRotation;
            _yaw = lerpRotation.eulerAngles.y;
            _pitch = lerpRotation.eulerAngles.x;
            yaws.Add(_yaw);
            if (_adjustYaw)
            {
                if (_yaw >= 180f)
                {
                    _yaw -= 360f;
                }
            }

            _yaw = Mathf.Clamp(_yaw, _yawLimit.x, _yawLimit.y);


            _pitch = Mathf.Clamp(_pitch, _pitchLimit.x, _pitchLimit.y);
            transform.localRotation =
                Quaternion.AngleAxis(_yaw, Vector3.up) * Quaternion.AngleAxis(_pitch, Vector3.right);
        }
    }
}