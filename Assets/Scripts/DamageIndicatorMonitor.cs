using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageIndicatorMonitor : MonoBehaviour
{
    // [SerializeField] private GameObject[] _storedIndicators;
    // private DamageIndicator[] _activeDamageIndicators;
    // private int _activeDamageIndicatorCount;
    // private void Awake()
    // {
    //     _activeDamageIndicators = new DamageIndicator[_storedIndicators.Length];
    // }
    //
    // private void Start()
    // {
    //     gameObject.SetActive(false);
    // }
    //
    // private void OnDamage(float amount, Vector3 position, Vector3 force, GameObject attacker, Collider hitCollider)
    // {
    //     // Don't show a hit indicator if the force is 0 or there is no attacker. This prevents damage such as fall damage from showing the damage indicator.
    //     if ((!m_AlwaysShowIndicator && force.sqrMagnitude == 0) || attacker == null ||
    //         m_ActiveDamageIndicatorCount == m_ActiveDamageIndicators.Length)
    //     {
    //         return;
    //     }
    //
    //     var attackerPosition = (m_FollowAttacker && m_CharacterTransform != attacker.transform)
    //         ? attacker.transform.position
    //         : position;
    //
    //     // Adjust the hit position.
    //     var localHitPosition = attacker.transform.InverseTransformPoint(position);
    //     localHitPosition.x = localHitPosition.z = 0;
    //     attackerPosition += attacker.transform.TransformDirection(localHitPosition);
    //
    //     var screenPoint = m_Camera.WorldToScreenPoint(attackerPosition);
    //     var centerScreenPoint =
    //         ((new Vector2(screenPoint.x, screenPoint.y) -
    //           (new Vector2(m_Camera.pixelWidth, m_Camera.pixelHeight) / 2)) * Mathf.Sign(screenPoint.z)).normalized;
    //
    //     // Determine the angle of the damage position to determine if a new damage indicator should be shown.
    //     var angle = Vector2.SignedAngle(centerScreenPoint, Vector2.right);
    //
    //     // Do not show a new damage indicator if the angle is less than a threshold compared to the already displayed indicators.
    //     DamageIndicator damageIndicator;
    //     for (int i = 0; i < m_ActiveDamageIndicatorCount; ++i)
    //     {
    //         damageIndicator = m_ActiveDamageIndicators[i];
    //         if (Mathf.Abs(angle - damageIndicator.Angle) < m_IndicatorAngleThreshold)
    //         {
    //             damageIndicator.DisplayTime = Time.time;
    //             m_ActiveDamageIndicators[i] = damageIndicator;
    //             return;
    //         }
    //     }
    //
    //     // Add the indicator to the active hit indicators list and enable the component.
    //     damageIndicator = GenericObjectPool.Get<DamageIndicator>();
    //     damageIndicator.Initialize(attacker.transform, position, m_StoredIndicators[m_DamageIndicatorIndex]);
    //     m_ActiveDamageIndicators[m_ActiveDamageIndicatorCount] = damageIndicator;
    //     m_ActiveDamageIndicatorCount++;
    //     m_DamageIndicatorIndex = (m_DamageIndicatorIndex + 1) % m_StoredIndicators.Length;
    //
    //     // Allow the indicators to move/fade.
    //     m_GameObject.SetActive(true);
    // }
    //
    // [System.Serializable]
    // private class DamageIndicator
    // {
    // }
}