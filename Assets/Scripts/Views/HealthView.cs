using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private Image _healthBar;

        private void Start()
        {
            _health.OnChanged += UpdateView;
            UpdateView(_health.RelativeValue);
        }

        private void UpdateView(float relativeHealth)
        {
            _healthBar.fillAmount = relativeHealth;
        }
    }
}
