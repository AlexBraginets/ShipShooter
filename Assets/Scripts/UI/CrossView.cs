using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CrossView : MonoBehaviour
    {
        [SerializeField] private Color _defaultColor;
        [SerializeField] private Color _onTargetColor;
        [SerializeField] private Image _graphics;
        
        [SerializeField] private Vector2 _maxOffset;
        public void SetNormalizedOffset(float normalizedOffset)
        {
            var rectTransform = transform as RectTransform;
            rectTransform.anchoredPosition = _maxOffset * normalizedOffset;
        }

        public void SetOnTarget()
        {
            _graphics.color = _onTargetColor;
        }

        public void ResetOnTarget()
        {
            _graphics.color = _defaultColor;
        }
    }
}
