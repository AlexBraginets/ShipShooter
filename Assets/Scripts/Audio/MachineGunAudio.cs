using Combat;
using UnityEngine;

namespace Audio
{
    public class MachineGunAudio : MonoBehaviour
    {
        [SerializeField] private MachineGun _machineGun;
        [SerializeField] private AudioSource _audioSource;

        private void Start()
        {
            _machineGun.OnShoot += _audioSource.Play;
        }
    }
}