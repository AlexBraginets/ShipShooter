using UnityEngine;

namespace Views
{
    public class LookAtTarget : MonoBehaviour
    {
        [SerializeField] private Transform _target;

        private void LateUpdate()
        {
            Vector3 lookDirection = (_target.position - transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(lookDirection, Vector3.up);
        }
    }
}