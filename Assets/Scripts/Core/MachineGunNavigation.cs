using DG.Tweening;
using UnityEngine;
using UserInput;
using Views;

namespace Core
{
    public class MachineGunNavigation : MonoBehaviour
    {
        [SerializeField] private MachineGunNavigationInput _input;
        [SerializeField] private Vector2 _yawLimit;
        [SerializeField] private Vector2 _pitchLimit;
        [SerializeField] private IronSightHandler _ironSightHandler;
        private float _yaw;
        private float _pitch;
        private void Awake()
        {
            // Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            if (_input.IsBlocked) return;
            _yaw += _input.dYaw;
            _pitch -= _input.dPitch;
            _yaw = Mathf.Clamp(_yaw, _yawLimit.x, _yawLimit.y);
            _pitch = Mathf.Clamp(_pitch, _pitchLimit.x, _pitchLimit.y);
            transform.localRotation = Quaternion.AngleAxis(_yaw, Vector3.up) * Quaternion.AngleAxis(_pitch, Vector3.right);
            _ironSightHandler.IsMoving = _input.IsMoving;
        }

        public void SlowlyReset(float duration)
        {
            transform.DOLocalRotate(Vector3.zero, duration);
        }
    }
}