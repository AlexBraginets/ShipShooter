using System;
using UnityEngine;

public class ShootActionWrapper : MonoBehaviour
{
    public event Action OnShoot;
    public void Shoot()
    {
        OnShoot?.Invoke();
    }
}
