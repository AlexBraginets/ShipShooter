using DG.Tweening;
using UnityEngine;

namespace UI.Popups
{
    public class LosePopup : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private GameObject _label;
        [SerializeField] private float _showLabelDelay;
        private const string SHOW = "Show";

        public void Show()
        {
            gameObject.SetActive(true);
            DOVirtual.DelayedCall(_showLabelDelay, ShowLabel);
        }

        private void ShowLabel()
        {
            _label.SetActive(true);
            _animator.SetTrigger(SHOW);
        }
    }
}