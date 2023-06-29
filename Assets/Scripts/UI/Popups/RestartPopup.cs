using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UserInput;

namespace UI.Popups
{
    public class RestartPopup : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private Vector2 _animationOffset;
        [SerializeField] private float _animationDuration;
        [SerializeField] private GameInput _gameInput;
        public void Show()
        {
            gameObject.SetActive(true);
            _gameInput.IsBlocked = true;
            _gameInput.StopShooting();
            var buttonRect = (_button.transform as RectTransform);
            Vector2 anchoredPosition = buttonRect.anchoredPosition;
            buttonRect.anchoredPosition = anchoredPosition + _animationOffset;
            buttonRect.DOAnchorPos(anchoredPosition, _animationDuration);
        }
        private void Start()
        {
            _button.onClick.AddListener(Restart);
        }

        private void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
