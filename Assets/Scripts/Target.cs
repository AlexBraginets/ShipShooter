using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Transform _explosionPrefab;
    [SerializeField] private Health _health;

    public void Damage(float amount)
    {
        Debug.Log("Target.Damage");
        _health.Value -= amount;
        if (_health.Value < .001f)
        {
            Destroy();
        }
    }
    public void Destroy()
    {
        Instantiate(_explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
