using System;
using UnityEngine;

public class MachineGunNavigation : MonoBehaviour
{
    [SerializeField] private float _lookSpeed;
    [SerializeField] private Vector2 _yawLimit;
    [SerializeField] private Vector2 _pitchLimit;
    private float _yaw;
    private float _pitch;

    private void Awake()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        _yaw += _lookSpeed * Time.deltaTime * Input.GetAxis("Mouse X");
        _pitch -= _lookSpeed * Time.deltaTime * Input.GetAxis("Mouse Y");
        _yaw = Mathf.Clamp(_yaw, _yawLimit.x, _yawLimit.y);
        _pitch = Mathf.Clamp(_pitch, _pitchLimit.x, _pitchLimit.y);
        transform.localRotation = Quaternion.AngleAxis(_yaw, Vector3.up) * Quaternion.AngleAxis(_pitch, Vector3.right);
    }
}