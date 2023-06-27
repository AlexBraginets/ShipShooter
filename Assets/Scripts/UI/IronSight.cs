using UnityEngine;

namespace UI
{
    public class IronSight : MonoBehaviour
    {
        [SerializeField] private CrossView[] _crossViews;

        public void SetNormalizedOffset(float normalizedOffset)
        {
            foreach (var crossView in _crossViews)
            {
                crossView.SetNormalizedOffset(normalizedOffset);
            }
        }
    }
}