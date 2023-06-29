using System.Collections;
using UnityEngine;

namespace Core
{
    public class PoolObject : MonoBehaviour
    {
        public void Disable()
        {
            gameObject.SetActive(false);
        }

        public void Disable(float delay)
        {
            StartCoroutine(DisableCoroutine(delay));
        }

        private IEnumerator DisableCoroutine(float delay)
        {
            yield return new WaitForSeconds(delay);
            Disable();
        }
    }
}
