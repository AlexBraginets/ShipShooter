using System;
using UnityEngine;

public class MachineGunNavigation : MonoBehaviour
{
    [SerializeField] private float _buildSpeed;
    [SerializeField] private float _editorSpeed;
    [SerializeField] private Vector2 _yawLimit;
    [SerializeField] private Vector2 _pitchLimit;
    [SerializeField] private IronSightHandler _ironSightHandler;
    private float _yaw;
    private float _pitch;
    private const float MOVING_THRESHOLD = .0001f;

    private float _lookSpeed
    {
        get
        {
#if UNITY_EDITOR
            return _editorSpeed;
#endif
            return _buildSpeed;
        }
    }

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        float dYaw = _lookSpeed * Time.deltaTime * Input.GetAxis("Mouse X");
        float dPitch = _lookSpeed * Time.deltaTime * Input.GetAxis("Mouse Y");
        _yaw += dYaw;
        _pitch -= dPitch;
        _yaw = Mathf.Clamp(_yaw, _yawLimit.x, _yawLimit.y);
        _pitch = Mathf.Clamp(_pitch, _pitchLimit.x, _pitchLimit.y);
        transform.localRotation = Quaternion.AngleAxis(_yaw, Vector3.up) * Quaternion.AngleAxis(_pitch, Vector3.right);
        if (new Vector2(dYaw, dPitch).magnitude > MOVING_THRESHOLD)
        {
            _ironSightHandler.IsMoving = true;
        }
        else
        {
            _ironSightHandler.IsMoving = false;
        }
    }
}