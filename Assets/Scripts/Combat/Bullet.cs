using UnityEngine;

namespace Combat
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _damage;
        [SerializeField] private Transform _dustPrefab;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out Target target))
            {
                target.Damage(_damage);
            }

            if (_dustPrefab)
            {
                var contact = collision.contacts[0];
                var dust = Instantiate(_dustPrefab, contact.point, Quaternion.LookRotation(contact.normal));
                Destroy(dust.gameObject, 4f);
            }
       
            Destroy(gameObject);
        }
    }
}