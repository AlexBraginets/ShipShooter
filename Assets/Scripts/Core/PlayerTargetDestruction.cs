using Combat;
using DG.Tweening;
using UnityEngine;
using UserInput;
using Views;

namespace Core
{
    public class PlayerTargetDestruction : MonoBehaviour
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private GameInput _gameInput;
        [SerializeField] private MachineGunNavigationInput _machineGunNavigationInput;
        [SerializeField] private Target _target;
        [SerializeField] private BoxCollider _playerCollider;
        [SerializeField] private PlayerMovement _playerMovement;
        [SerializeField] private MachineGunNavigation _machineGunNavigation;
        [SerializeField] private CameraLostAnimator _cameraLostAnimator;
        [SerializeField] private IronSightHandler _ironSightHandler;

        private void Start()
        {
            _target.OnDestroyed += OnPlayerDestroyed;
        }

        private void OnPlayerDestroyed()
        {
            _gameInput.IsBlocked = true;
            _machineGunNavigationInput.IsBlocked = true;
            _gameInput.StopShooting();
            _playerCollider.enabled = false;
            _playerMovement.SlowlyStop(2f);
            _ironSightHandler.SlowlyHide(.5f);
            float resetDuration = .5f;
            _machineGunNavigation.SlowlyReset(resetDuration);
            DOVirtual.DelayedCall(resetDuration, _cameraLostAnimator.Animate);
            _gameManager.Lose();
        }
    }
}