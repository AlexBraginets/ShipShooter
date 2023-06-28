using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Target _target;
    [SerializeField] private HealthFlashMonitor _healthFlashMonitor;
    private void Start()
    {
        _target.OnDamage += OnDamage;
    }

    private void OnDamage()
    {
        _healthFlashMonitor.OnDamage();
    }
}
