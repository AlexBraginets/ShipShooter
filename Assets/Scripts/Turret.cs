using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector2 _yawLimit;
    [SerializeField] private Vector2 _pitchLimit;
    [SerializeField] private float _rotationSpeed;
    private float _yaw;
    private float _pitch;
    
    
    private void Update()
    {
        Vector3 direction2Target = (_target.position - transform.position).normalized;
        direction2Target = transform.InverseTransformDirection(direction2Target);
        var rotation2Target = Quaternion.LookRotation(direction2Target, Vector3.up);
        var currentRotation = transform.localRotation;
        var lerpRotation = Quaternion.Lerp(currentRotation, rotation2Target, _rotationSpeed * Time.deltaTime);
        _yaw = lerpRotation.eulerAngles.y;
        _pitch = lerpRotation.eulerAngles.z;
        _yaw = Mathf.Clamp(_yaw, _yawLimit.x, _yawLimit.y);
        _pitch = Mathf.Clamp(_pitch, _pitchLimit.x, _pitchLimit.y);
        transform.rotation = Quaternion.AngleAxis(_yaw, Vector3.up) * Quaternion.AngleAxis(_pitch, Vector3.right);
    }
}
