using Core;
using UnityEngine;

namespace Test
{
    public class FixedPlayer : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Transform _refLocation;

        private void Awake()
        {
           BlockMovement();
           UpdateLocation();
        }

        private void BlockMovement()
        {
            _player.GetComponent<PlayerMovement>().enabled = false;
            _player.GetComponentInChildren<MachineGunNavigation>().enabled = false;
        }

        private void UpdateLocation()
        {
            ApplyLocation(_refLocation, _player.transform);
            ApplyLocation(_refLocation.GetChild(0), _player.transform.GetChild(0));
        }

        private void ApplyLocation(Transform from, Transform to)
        {
            to.position = from.position;
            to.rotation = from.rotation;
        }
    }
}
