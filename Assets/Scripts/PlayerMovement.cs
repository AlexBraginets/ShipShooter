using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _period;
    [SerializeField] private Transform _rotationPoint;

    private void Update()
    {
        float dAngle = Time.deltaTime / _period * 360f;
        transform.RotateAround(_rotationPoint.position, Vector3.up, dAngle);
    }
}