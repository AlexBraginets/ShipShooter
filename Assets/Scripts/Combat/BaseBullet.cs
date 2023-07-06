using UnityEngine;

namespace Combat
{
    public abstract class BaseBullet : MonoBehaviour
    {
        public abstract void SetVelocity(Vector3 velocity);
    }
}
