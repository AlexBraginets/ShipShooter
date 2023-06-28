using UnityEngine;

namespace Utils
{
    public static class LayerMaskUtils
    {
        public static bool IsOnLayerMask(this GameObject gameObject, LayerMask layerMask)
        {
            int targetLayer = gameObject.layer;
            int targetLayerMask = gameObject.layer;
            return targetLayerMask == (targetLayerMask | (1 << targetLayer));
        }

        public static bool IsOnLayerMask(this Collision collision, LayerMask layerMask)
        {
            return IsOnLayerMask(collision.gameObject, layerMask);
        }
    }
}
