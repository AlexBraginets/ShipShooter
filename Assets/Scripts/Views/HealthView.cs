using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private Image _healthBar;
        [SerializeField] private GameObject _visuals;
        [SerializeField] private bool _hideOnStart = true;

        private void Start()
        {
            _health.OnChanged += UpdateView;
            UpdateView(_health.RelativeValue);
            if (_hideOnStart)
                Hide();
        }

        private void UpdateView(float relativeHealth)
        {
            _healthBar.fillAmount = relativeHealth;
        }

        public void Show() => _visuals.SetActive(true);
        public void Hide() => _visuals.SetActive(false);
    }
}