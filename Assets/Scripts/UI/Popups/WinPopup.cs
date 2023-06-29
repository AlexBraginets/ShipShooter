using DG.Tweening;
using UnityEngine;

namespace UI.Popups
{
    public class WinPopup : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private float _showRestartPopupDelay;
        [SerializeField] private RestartPopup _restartPopup;
        private const string SHOW = "Show";
        

        public void Show()
        {
            gameObject.SetActive(true);
            _animator.SetTrigger(SHOW);
            DOVirtual.DelayedCall(_showRestartPopupDelay, _restartPopup.Show);
        }
    }
}