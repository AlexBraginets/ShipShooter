using UnityEngine;

namespace Views
{
    public class BulletTrail : MonoBehaviour
    {
        [SerializeField] private TrailRenderer _trail;

        private void OnDisable()
        {
            _trail.Clear();
        }
    }
}
