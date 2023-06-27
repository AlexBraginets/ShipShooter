using System;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event Action OnStartShooting;
    public event Action OnStopShooting;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnStartShooting?.Invoke();
        }

        if (Input.GetMouseButtonUp(0))
        {
            OnStopShooting?.Invoke();
        }
    }
}
