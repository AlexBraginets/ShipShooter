using Combat;
using UnityEngine;
using UserInput;

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
            _playerMovement.SlowlyStop(5f);
            _gameManager.Lose();
        }
    }
}
