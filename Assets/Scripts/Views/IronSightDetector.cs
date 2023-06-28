using UnityEngine;

namespace Views
{
    public class IronSightDetector : MonoBehaviour
    {
        [SerializeField] private HealthView _healthView;
        [SerializeField] private float _highlightDuration;
        private bool _hasEntered;
        private float _exitTime;
        public void OnEnter()
        {
            _exitTime = _highlightDuration + Time.time;
            if (_hasEntered) return;
            _hasEntered = true;
            _healthView.Show();
        }

        private void Update()
        {
            if (!_hasEntered) return;
            if (Time.time < _exitTime) return;
            _hasEntered = false;
            _healthView.Hide();
        }
    }
}
