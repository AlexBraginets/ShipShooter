using UI;
using UnityEngine;

namespace Views
{
    public class IronSightHandler : MonoBehaviour
    {
        [SerializeField] private IronSight _ironSight;
        [SerializeField] private float _offsetSpeed;
        private float _normalizedOffset;

        public bool IsMoving;

        private void LateUpdate()
        {
            float deltaOffset = Time.deltaTime * _offsetSpeed;
            _normalizedOffset += IsMoving ? deltaOffset : -deltaOffset;
            _normalizedOffset = Mathf.Clamp01(_normalizedOffset);
            _ironSight.SetNormalizedOffset(_normalizedOffset);
        }
    }
}