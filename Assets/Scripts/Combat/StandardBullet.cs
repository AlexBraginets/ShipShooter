using Core;
using UnityEngine;

namespace Combat
{
    public class StandardBullet : BaseBullet
    {
        [SerializeField] private float _damage = 5;
        [SerializeField] private float _radius;
        [SerializeField] private PoolObject _dustPrefab;
        [SerializeField] private LayerMask _hittableLayers;
        private Vector3 m_Velocity;
        private Vector3 m_LastPosition;

        public override void SetVelocity(Vector3 velocity)
        {
            m_Velocity = velocity;
            m_LastPosition = transform.position;
        }

        private void Update()
        {
            transform.position += m_Velocity * Time.deltaTime;
            if (IsHit(out RaycastHit hit))
            {
                OnHit(hit);
            }

            m_LastPosition = transform.position;
        }

        private bool IsHit(out RaycastHit hit)
        {
            Vector3 displacementSinceLastFrame = transform.position - m_LastPosition;
            Vector3 direction = displacementSinceLastFrame.normalized;
            float distance = displacementSinceLastFrame.magnitude;
            RaycastHit[] hits = Physics.SphereCastAll(m_LastPosition, _radius, direction, distance, _hittableLayers);
            hit = new RaycastHit();
            hit.distance = float.MaxValue;
            bool isHit = false;
            foreach (RaycastHit h in hits)
            {
                if (IsValidHit(h.collider))
                {
                    if (h.distance < hit.distance)
                    {
                        hit = h;
                        isHit = true;
                    }
                }
            }

            return isHit;
        }

        private bool IsValidHit(Collider collider)
        {
            return true;
        }

        private void OnHit(RaycastHit hit)
        {
            gameObject.SetActive(false);
            SpawnHitVFX(hit);
            if (hit.collider.TryGetComponent(out Target target))
            {
                target.Damage(_damage);
            }
        }

        private void SpawnHitVFX(RaycastHit hit)
        {
            var dust = Pool.Get(_dustPrefab);
            dust.transform.forward = hit.normal;
            dust.transform.position = hit.point;
            dust.Disable(.5f);
        }
    }
}