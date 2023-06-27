using System;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    public event Action OnShoot;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OnShoot?.Invoke();
        }
    }
}
