using Core;
using UnityEngine;

namespace Views
{
    public class CameraLostAnimator : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Player _player;
        [SerializeField] private Animator _animator;
        [SerializeField] private float _detachCameraDelay;
        private const string LOST = "Lost";

        public void Animate()
        {
            _camera.transform.parent = _player.transform;
            _animator.SetTrigger(LOST);
            Invoke("DetachCamera", _detachCameraDelay);
        }

        private void DetachCamera()
        {
            _animator.enabled = false;
            _camera.transform.parent = null;
        }
    }
}