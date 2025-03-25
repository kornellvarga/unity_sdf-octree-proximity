using UnityEngine;

namespace AdaptiveOctree
{
    public interface IOctreeNode
    {
        Vector3 Center { get; }
        float Size { get; }
        float GetProximityValue();
        void Subdivide();
        void Merge();
        bool IsLeaf { get; }
    }
}