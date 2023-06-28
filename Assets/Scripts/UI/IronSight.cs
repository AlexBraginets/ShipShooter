using UnityEngine;

namespace UI
{
    public class IronSight : MonoBehaviour
    {
        [SerializeField] private CrossView _dot;
        [SerializeField] private CrossView[] _crossViews;

        public void SetNormalizedOffset(float normalizedOffset)
        {
            foreach (var crossView in _crossViews)
            {
                crossView.SetNormalizedOffset(normalizedOffset);
            }
        }

        public void SetOnTarget()
        {
            foreach (var crossView in _crossViews)
            {
                crossView.SetOnTarget();
            }
            _dot.SetOnTarget();
        }

        public void ResetOnTarget()
        {
            foreach (var crossView in _crossViews)
            {
                crossView.ResetOnTarget();
            }

            _dot.ResetOnTarget();
        }
    }
}