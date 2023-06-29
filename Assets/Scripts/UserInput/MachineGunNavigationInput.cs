using UnityEngine;

namespace UserInput
{
    [DefaultExecutionOrder(-1)]
    public class MachineGunNavigationInput : MonoBehaviour
    {
        [SerializeField] private float _buildLookSpeed;
        [SerializeField] private float _editorLookSpeed;
        public bool IsBlocked { get; set; }

        public float dYaw
        {
            get
            {
                if (IsBlocked) return 0f;
                return LookSpeed * Time.deltaTime * Input.GetAxis("Mouse X");
            }
        }
        public float dPitch
        {
            get
            {
                if (IsBlocked) return 0f;
                return LookSpeed * Time.deltaTime * Input.GetAxis("Mouse Y");
            }
        }
        public bool IsMoving => new Vector2(dYaw, dPitch).magnitude > MOVING_THRESHOLD;
        private const float MOVING_THRESHOLD = .0001f;

        private float LookSpeed
        {
            get
            {
#if UNITY_EDITOR
                return _editorLookSpeed;
#endif
                return _buildLookSpeed;
            }
        }
    }
}