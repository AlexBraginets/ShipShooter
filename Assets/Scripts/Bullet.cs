using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Target target))
        {
            target.Destroy();
        }

        Destroy(gameObject);
    }
}
