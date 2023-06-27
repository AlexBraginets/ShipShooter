using System;
using DG.Tweening;
using UnityEngine;

namespace UI
{
    public class IronSight : MonoBehaviour
    {
        [SerializeField] private float _animationDuration;
        [SerializeField] private RectTransform _upCross;
        [SerializeField] private RectTransform _downCross;
        [SerializeField] private RectTransform _leftCross;
        [SerializeField] private RectTransform _rightCross;
        [SerializeField] private float _crossDelta;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Animate();
            }
        }

        private void Animate()
        {
            var ds = _crossDelta;
            Animate(_upCross, ds * Vector2.up);
            Animate(_downCross, ds * Vector2.down);
            Animate(_leftCross, ds * Vector2.left);
            Animate(_rightCross, ds * Vector2.right);
        }

        private void Animate(RectTransform cross, Vector2 offset)
        {
            var pos = cross.anchoredPosition;
            var sequence = DOTween.Sequence();
            var tween = cross.DOAnchorPos(pos + offset, _animationDuration / 2f);
            sequence.Append(tween);
            tween = cross.DOAnchorPos(pos, _animationDuration / 2f);
            sequence.Append(tween);
            sequence.Play();
        }
    }
}