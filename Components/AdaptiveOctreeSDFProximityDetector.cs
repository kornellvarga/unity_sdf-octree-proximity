using UnityEngine;
using System.Collections.Generic;

namespace AdaptiveOctree
{
    [AddComponentMenu("Physics/Adaptive Octree SDF Proximity Detector")]
    public class AdaptiveOctreeSDFProximityDetector : MonoBehaviour
    {
        [Header("Octree Settings")]
        [SerializeField] private Vector3 _center;
        [SerializeField] private float _size = 10f;
        [SerializeField] private int _maxDepth = 5;

        [Header("Activation Strategy")]
        [SerializeField] private float _activationThreshold = 0.5f;
        [SerializeField] private float _hysteresis = 0.1f;

        private OctreeNode _root;
        private IActivationStrategy _activationStrategy;
        private List<AdaptiveOctreeLeafTrigger> _triggers;

        private void Awake()
        {
            InitializeOctree();
            _triggers = new List<AdaptiveOctreeLeafTrigger>();
            _activationStrategy = new HysteresisActivationStrategy(_activationThreshold, _hysteresis);
        }

        private void InitializeOctree()
        {
            _root = new OctreeNode(_center, _size);
        }

        public void RegisterTrigger(AdaptiveOctreeLeafTrigger trigger)
        {
            if (!_triggers.Contains(trigger))
            {
                _triggers.Add(trigger);
            }
        }

        public void UnregisterTrigger(AdaptiveOctreeLeafTrigger trigger)
        {
            _triggers.Remove(trigger);
        }

        private void Update()
        {
            UpdateOctree();
        }

        private void UpdateOctree()
        {
            UpdateProximityValues(_root);
            UpdateSubdivision(_root, 0);
        }

        private void UpdateProximityValues(OctreeNode node)
        {
            float maxProximity = 0f;

            foreach (var trigger in _triggers)
            {
                float proximity = CalculateProximity(node, trigger.transform.position);
                maxProximity = Mathf.Max(maxProximity, proximity);
            }

            node.SetProximityValue(maxProximity);

            if (!node.IsLeaf)
            {
                foreach (var child in node.GetChildren())
                {
                    UpdateProximityValues(child);
                }
            }
        }

        private float CalculateProximity(OctreeNode node, Vector3 point)
        {
            float distance = Vector3.Distance(node.Center, point);
            return Mathf.Max(0f, 1f - distance / node.Size);
        }

        private void UpdateSubdivision(OctreeNode node, int depth)
        {
            if (depth >= _maxDepth)
            {
                if (!node.IsLeaf)
                {
                    node.Merge();
                }
                return;
            }

            bool shouldActivate = _activationStrategy.ShouldActivate(node);

            if (shouldActivate && node.IsLeaf)
            {
                node.Subdivide();
            }
            else if (!shouldActivate && !node.IsLeaf)
            {
                node.Merge();
            }

            if (!node.IsLeaf)
            {
                foreach (var child in node.GetChildren())
                {
                    UpdateSubdivision(child, depth + 1);
                }
            }
        }

        private void OnDrawGizmos()
        {
            if (_root != null)
            {
                DrawOctreeGizmos(_root);
            }
        }

        private void DrawOctreeGizmos(OctreeNode node)
        {
            Gizmos.color = Color.Lerp(Color.blue, Color.red, node.GetProximityValue());
            Gizmos.DrawWireCube(node.Center, Vector3.one * node.Size);

            if (!node.IsLeaf)
            {
                foreach (var child in node.GetChildren())
                {
                    DrawOctreeGizmos(child);
                }
            }
        }
    }
}