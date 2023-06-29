using Objectives;
using UI.Popups;
using UnityEngine;

namespace Core
{
   public class GameManager : MonoBehaviour
   {
      [SerializeField] private Objective _objective;
      [SerializeField] private WinPopup _winPopup;
      [SerializeField] private LosePopup _losePopup;
      private void Awake()
      {
         Application.targetFrameRate = 120;
         _objective.OnObjectiveCompleted += Win;
      }

      private void Win()
      {
         _winPopup.Show();
      }

      public void Lose()
      {
         _losePopup.Show();
      }
   }
}
