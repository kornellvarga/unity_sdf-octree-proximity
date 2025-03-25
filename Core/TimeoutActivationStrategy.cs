using UnityEngine;
using System.Collections.Generic;

namespace AdaptiveOctree
{
    public class TimeoutActivationStrategy : IActivationStrategy
    {
        private readonly float _threshold;
        private readonly float _timeout;
        private readonly Dictionary<IOctreeNode, float> _activationTimes;

        public TimeoutActivationStrategy(float threshold, float timeout)
        {
            _threshold = threshold;
            _timeout = timeout;
            _activationTimes = new Dictionary<IOctreeNode, float>();
        }

        public bool ShouldActivate(IOctreeNode node)
        {
            float currentTime = Time.time;
            float proximityValue = node.GetProximityValue();

            if (proximityValue >= _threshold)
            {
                _activationTimes[node] = currentTime;
                return true;
            }

            if (!_activationTimes.ContainsKey(node))
            {
                return false;
            }

            return currentTime - _activationTimes[node] <= _timeout;
        }
    }
}