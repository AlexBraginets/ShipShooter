using UnityEngine;

public class MachineGunAnimator : MonoBehaviour
{
    [SerializeField] private MachineGun _machineGun;
    [SerializeField] private Animator _animator;
    private const string IS_SHOOTING = "IsShooting";
    private int _isShootingHash;
    private void Start()
    {
        _isShootingHash = Animator.StringToHash(IS_SHOOTING);
        _machineGun.OnStartShooting += StartShooting;
        _machineGun.OnStopShooting += StopShooting;
    }
    private void StartShooting()
    {
        _animator.SetBool(_isShootingHash, true);
    }
    private void StopShooting()
    {
        _animator.SetBool(_isShootingHash, false);
    }

   
}
