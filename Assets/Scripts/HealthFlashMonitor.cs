using UnityEngine;
using UnityEngine.UI;

public class HealthFlashMonitor : MonoBehaviour
{
    [SerializeField] private Image _flashImage;
    [SerializeField] private Flash _flash;
    private float _flashDisplayTime;

    private void Awake()
    {
        _flashImage.color = Color.clear;
        gameObject.SetActive(false);
    }

    public void OnDamage()
    {
        _flashImage.color = _flash.Color;
        _flashImage.sprite = _flash.Sprite;
        _flashDisplayTime = Time.time;
        gameObject.SetActive(true);
    }

    private void Update()
    {
        var alpha =
            Mathf.Min(
                (_flash.FadeDuration - (Time.time - (_flashDisplayTime + _flash.VisibilityDuration))) /
                _flash.FadeDuration, 1) * _flash.Color.a;

        var color = _flashImage.color;
        color.a = alpha;
        _flashImage.color = color;
        if (alpha <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    [System.Serializable]
    private class Flash
    {
        public float VisibilityDuration;
        public float FadeDuration;
        public Color Color;
        public Sprite Sprite;
    }
}