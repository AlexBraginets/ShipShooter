using Core;
using UnityEngine;

namespace Combat
{
    public class Bullet : BaseBullet
    {
        [SerializeField] private float _damage;
        [SerializeField] private PoolObject _dustPrefab;
        [SerializeField] private Rigidbody _rb;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.TryGetComponent(out Target target))
            {
                target.Damage(_damage);
            }

            if (_dustPrefab)
            {
                var contact = collision.contacts[0];
                var dust = Pool.Get(_dustPrefab);
                var dustTransform = dust.transform;
                dustTransform.position = contact.point;
                dustTransform.forward = contact.normal;
                dust.Disable(.5f);
            }

            gameObject.SetActive(false);
        }

        public override void SetVelocity(Vector3 velocity)
        {
            _rb.velocity = velocity;
        }
    }
}