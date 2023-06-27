using UnityEngine;

namespace UI
{
    public class CrossView : MonoBehaviour
    {
        [SerializeField] private Vector2 _maxOffset;
        public void SetNormalizedOffset(float normalizedOffset)
        {
            var rectTransform = transform as RectTransform;
            rectTransform.anchoredPosition = _maxOffset * normalizedOffset;
        }
    }
}
