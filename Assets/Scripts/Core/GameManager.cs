using UnityEngine;

namespace Core
{
   public class GameManager : MonoBehaviour
   {
      private void Awake()
      {
         Application.targetFrameRate = 120;
      }
   }
}
