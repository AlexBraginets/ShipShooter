using System;
using UnityEngine;

namespace Objectives
{
    public abstract class Objective : MonoBehaviour
    {
        public event Action OnObjectiveCompleted;

        protected void CompleteObjective()
        {
            OnObjectiveCompleted?.Invoke();
        }
    }
}
