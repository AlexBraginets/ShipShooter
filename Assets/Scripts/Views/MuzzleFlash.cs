using UnityEngine;

namespace Views
{
    public class MuzzleFlash : MonoBehaviour
    {
        [Range(0, 1)] [SerializeField] private float _startAlpha = 0.5f;

        [SerializeField] private float _minFadeSpeed = 3;

        [SerializeField] private float _maxFadeSpeed = 4;

        private GameObject m_GameObject;
        private Material m_Material;
        private Light m_Light;
        private ParticleSystem m_Particles;

        private int m_TintColorPropertyID;
        private Color m_Color;
        private float m_StartLightIntensity;
        private float m_FadeSpeed;
        private float m_TimeScale = 1;

        private void Awake()
        {
            m_GameObject = gameObject;
            m_TintColorPropertyID = Shader.PropertyToID("_TintColor");

            var muzzleRenderer = GetComponent<Renderer>();
            if (muzzleRenderer != null)
            {
                m_Material = muzzleRenderer.sharedMaterial;
            }

            m_Light = GetComponent<Light>();
            m_Particles = GetComponent<ParticleSystem>();
            if (m_Light != null)
            {
                m_StartLightIntensity = m_Light.intensity;
            }
        }

        private void OnEnable()
        {
            m_Color.a = 0;
            if (m_Material != null)
            {
                m_Material.SetColor(m_TintColorPropertyID, m_Color);
            }

            if (m_Light != null)
            {
                m_Light.intensity = 0;
            }

            if (m_Particles != null)
            {
                m_Particles.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
            }
        }

        public void Show()
        {
            m_GameObject.SetActive(true);

            m_Color = Color.white;
            m_Color.a = _startAlpha;
            if (m_Material != null)
            {
                m_Material.SetColor(m_TintColorPropertyID, m_Color);
            }

            m_FadeSpeed = Random.Range(_minFadeSpeed, _maxFadeSpeed);
            if (m_Light != null)
            {
                m_Light.intensity = m_StartLightIntensity;
            }

            if (m_Particles != null)
            {
                m_Particles.Play(true);
            }

            m_GameObject.SetActive(true);
        }

        private void Update()
        {
            if (m_Color.a > 0)
            {
                m_Color.a = Mathf.Max(m_Color.a - (m_FadeSpeed * Time.deltaTime), 0);
                if (m_Material != null)
                {
                    m_Material.SetColor(m_TintColorPropertyID, m_Color);
                }

                if (m_Light != null)
                {
                    m_Light.intensity = m_StartLightIntensity * (m_Color.a / _startAlpha);
                }
            }
            else
            {
                m_GameObject.SetActive(false);
            }
        }
    }
}