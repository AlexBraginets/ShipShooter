using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _damage;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Target target))
        {
            target.Damage(_damage);
        }

        Destroy(gameObject);
    }
}
