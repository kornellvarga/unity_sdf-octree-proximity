using UnityEngine;
using System.Collections.Generic;

namespace AdaptiveOctree
{
    public class HysteresisActivationStrategy : IActivationStrategy
    {
        private readonly float _activationThreshold;
        private readonly float _deactivationThreshold;
        private readonly float _hysteresis;
        private readonly Dictionary<IOctreeNode, bool> _nodeStates;

        public HysteresisActivationStrategy(float activationThreshold, float hysteresis)
        {
            _activationThreshold = activationThreshold;
            _hysteresis = hysteresis;
            _deactivationThreshold = activationThreshold - hysteresis;
            _nodeStates = new Dictionary<IOctreeNode, bool>();
        }

        public bool ShouldActivate(IOctreeNode node)
        {
            if (!_nodeStates.ContainsKey(node))
            {
                _nodeStates[node] = false;
            }

            bool isActive = _nodeStates[node];
            float threshold = isActive ? _deactivationThreshold : _activationThreshold;

            bool shouldBeActive = node.GetProximityValue() >= threshold;

            if (shouldBeActive != isActive)
            {
                _nodeStates[node] = shouldBeActive;
            }

            return shouldBeActive;
        }
    }
}