using UnityEngine;

namespace AdaptiveOctree
{
    public class OctreeNode : IOctreeNode
    {
        private Vector3 _center;
        private float _size;
        private OctreeNode[] _children;
        private float _proximityValue;

        public Vector3 Center => _center;
        public float Size => _size;
        public bool IsLeaf => _children == null;

        public OctreeNode(Vector3 center, float size)
        {
            _center = center;
            _size = size;
            _proximityValue = 0f;
        }

        public float GetProximityValue()
        {
            return _proximityValue;
        }

        public void SetProximityValue(float value)
        {
            _proximityValue = value;
        }

        public void Subdivide()
        {
            if (!IsLeaf) return;

            _children = new OctreeNode[8];
            float halfSize = _size * 0.5f;

            for (int i = 0; i < 8; i++)
            {
                Vector3 offset = new Vector3(
                    ((i & 1) != 0) ? halfSize : -halfSize,
                    ((i & 2) != 0) ? halfSize : -halfSize,
                    ((i & 4) != 0) ? halfSize : -halfSize
                ) * 0.5f;

                _children[i] = new OctreeNode(_center + offset, halfSize);
            }
        }

        public void Merge()
        {
            if (IsLeaf) return;
            _children = null;
        }

        public OctreeNode[] GetChildren()
        {
            return _children;
        }
    }
}