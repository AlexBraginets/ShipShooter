using UnityEngine;

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
    private float _yaw;
    private float _pitch;
    private float _shootingBlockedTime;
    
    private void Update()
    {
       FollowTarget();
       TryShoot();

    }

    private void TryShoot()
    {
        if (Time.time < _shootingBlockedTime) return;
        Ray ray = new Ray(transform.position, transform.forward);
        var raycastDistance = 1000f;
        if (Physics.Raycast(ray, out RaycastHit hit, raycastDistance))
        {
            if (hit.transform.CompareTag("Player"))
            {
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        var bullet = Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation);
        Vector3 shootDirection = (_target.position - _shootPoint.position).normalized;
        bullet.GetComponent<Rigidbody>().velocity = _bulletSpeed * shootDirection;

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
        _yaw = Mathf.Clamp(_yaw, _yawLimit.x, _yawLimit.y);
        _pitch = Mathf.Clamp(_pitch, _pitchLimit.x, _pitchLimit.y);
        transform.localRotation = Quaternion.AngleAxis(_yaw, Vector3.up) * Quaternion.AngleAxis(_pitch, Vector3.right);
    }
}
