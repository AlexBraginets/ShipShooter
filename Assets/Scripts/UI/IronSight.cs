using DG.Tweening;
using UnityEngine;

namespace UI
{
    public class IronSight : MonoBehaviour
    {
        [SerializeField] private float _animationDuration;
        [SerializeField] private CrossView[] _crossViews;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Animate();
            }
        }

        private void Animate()
        {
            var sequence = DOTween.Sequence();
            var tween = DOTween.To(() => 0, SetNormalizedOffset, 1f, _animationDuration / 2f);
            sequence.Append(tween);
            tween = DOTween.To(() => 1f, SetNormalizedOffset, 0f, _animationDuration / 2f);
            sequence.Append(tween);
            sequence.Play();
        }

        private void SetNormalizedOffset(float normalizedOffset)
        {
            foreach (var crossView in _crossViews)
            {
                crossView.SetNormalizedOffset(normalizedOffset);
            }
        }
    }
}