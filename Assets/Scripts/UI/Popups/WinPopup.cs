using UnityEngine;

namespace UI.Popups
{
    public class WinPopup : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        private const string SHOW = "Show";

        public void Show()
        {
            gameObject.SetActive(true);
            _animator.SetTrigger(SHOW);
        }
    }
}