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
    [SerializeField] private Transform _bulletPrefab;
    [SerializeField] private Transform _shootingPoint;
    [SerializeField] private float _bulletSpeed;

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
        var bullet = Instantiate(_bulletPrefab);
        bullet.position = _shootingPoint.position;
        bullet.rotation = _shootingPoint.rotation;
        
        Target target = null;
        Ray ray = _camera.ViewportPointToRay(Vector3.one * .5f);
        var raycastDistance = 1000f;
        if (Physics.Raycast(ray, out RaycastHit hit, raycastDistance, _targetLayerMask))
        {
            hit.transform.TryGetComponent(out target);
        }

        Vector3 shootDirection = _camera.transform.forward;
        if (target)
        {
            shootDirection = (hit.point - _shootingPoint.position).normalized;
        }
        bullet.GetComponent<Rigidbody>().velocity = shootDirection * _bulletSpeed;
    }
}