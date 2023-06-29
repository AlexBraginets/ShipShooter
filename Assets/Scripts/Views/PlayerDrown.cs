using DG.Tweening;
using UnityEngine;

namespace Views
{
    public class PlayerDrown : MonoBehaviour
    {
        [SerializeField] private float _duration;
        [SerializeField] private float _yOffset;
        [SerializeField] private Transform _boat;
        [SerializeField] private Transform _machineGun;
        [SerializeField] private Transform _drownParent;
        [SerializeField] private GameObject _explosionPrefab;

        public void Animate()
        {
            _boat.parent = _drownParent;
            _machineGun.parent = _drownParent;
            Vector3 endPosition = _drownParent.localPosition + Vector3.down * _yOffset;
            _drownParent.DOLocalMove(endPosition, _duration);
            DOVirtual.DelayedCall(_duration, Explode);
        }

        private void Explode()
        {
            Instantiate(_explosionPrefab, _drownParent.position, _drownParent.rotation);
            _drownParent.gameObject.SetActive(false);
        }
    }
}