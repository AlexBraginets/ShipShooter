using System;
using System.Collections;
using UnityEngine;

namespace Utils
{
    public class DisableTimer : MonoBehaviour
    {
        [SerializeField] private float _disableDelay = 1;
        private Coroutine _disableCoroutine;
        private void OnEnable()
        {
            _disableCoroutine = StartCoroutine(Disable());
        }

        private IEnumerator Disable()
        {
            yield return new WaitForSeconds(_disableDelay);
            gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            if (_disableCoroutine != null)
            {
                StopCoroutine(_disableCoroutine);
            }

            _disableCoroutine = null;
        }
    }
}
