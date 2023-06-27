using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Transform _explosionPrefab;

    public void Destroy()
    {
        Instantiate(_explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
