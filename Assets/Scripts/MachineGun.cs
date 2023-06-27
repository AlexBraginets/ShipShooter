using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour
{
   [SerializeField] private GameInput _gameInput;
   private void Start()
   {
      _gameInput.OnShoot += Shoot;
   }

   private void Shoot()
   {
      Debug.Log("Shoot");
   }
}
