using System.Linq;
using TMPro;
using UnityEngine;

namespace Utils
{
    public class FPSCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text fpsLabel;
        private int _lastFrameIndex;
        private float[] _floatDeltaTimeArray;

        private void Awake()
        {
            _floatDeltaTimeArray = new float[50];
        }

        private void Update()
        {
            _floatDeltaTimeArray[_lastFrameIndex] = Time.deltaTime;
            _lastFrameIndex = (_lastFrameIndex + 1) % _floatDeltaTimeArray.Length;
            fpsLabel.text = $"FPS: {CalculateFPS().ToString("N0")}";
        }

        private float CalculateFPS()
        {
            float total = _floatDeltaTimeArray.Sum();
            return _floatDeltaTimeArray.Length / total;
        }
    }
}