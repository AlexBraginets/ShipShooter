using System;
using UnityEngine;

namespace Utils
{
   public class OnDestroyActionWrapper : MonoBehaviour
   {
      public event Action OnDestoryAction;
      private void OnDestroy()
      {
         OnDestoryAction?.Invoke();
      }
   }
}
