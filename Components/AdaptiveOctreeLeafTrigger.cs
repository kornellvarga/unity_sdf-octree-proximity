using UnityEngine;

namespace AdaptiveOctree
{
    [AddComponentMenu("Physics/Adaptive Octree Leaf Trigger")]
    public class AdaptiveOctreeLeafTrigger : MonoBehaviour
    {
        private AdaptiveOctreeSDFProximityDetector _detector;

        private void Start()
        {
            _detector = FindObjectOfType<AdaptiveOctreeSDFProximityDetector>();
            if (_detector != null)
            {
                _detector.RegisterTrigger(this);
            }
        }

        private void OnDestroy()
        {
            if (_detector != null)
            {
                _detector.UnregisterTrigger(this);
            }
        }
    }
}