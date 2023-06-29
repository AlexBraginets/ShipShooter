using Combat;
using UnityEngine;

namespace Views
{
    public class TargetDestruction : MonoBehaviour
    {
        [SerializeField] private GameObject _explosionPrefab;
        [SerializeField] private Target _target;
        private void Start()
        {
            _target.OnDestroyed += Destroy;
        }

        private void Destroy()
        {
            Instantiate(_explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
