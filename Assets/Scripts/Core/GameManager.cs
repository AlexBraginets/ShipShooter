using DG.Tweening;
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
      [SerializeField] private float _showWinPopupDelay;
      private void Awake()
      {
         Cursor.visible = false;
         Application.targetFrameRate = 120;
         _objective.OnObjectiveCompleted += Win;
      }

      private void Win()
      {
         DOVirtual.DelayedCall(_showWinPopupDelay, _winPopup.Show);
      }

      public void Lose()
      {
         _losePopup.Show();
      }
   }
}
