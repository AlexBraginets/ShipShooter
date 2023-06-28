using Core;
using TMPro;
using UnityEngine;

namespace Views
{
    public class TextHealthView : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private TMP_Text _label;

        private void Start()
        {
            _health.OnChanged += UpdateView;

            UpdateView(_health.RelativeValue);
        }

        private void UpdateView(float relativeHealth)
        {
            int health = Mathf.RoundToInt(_health.Value);
            int maxHealth = Mathf.RoundToInt(_health.MaxValue);
            _label.text = $"{health}/{maxHealth}";
        }
    }
}