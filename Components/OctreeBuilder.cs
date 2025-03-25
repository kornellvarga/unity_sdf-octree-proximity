using UnityEngine;

namespace AdaptiveOctree
{
    public class OctreeBuilder : MonoBehaviour
    {
        [SerializeField] private Vector3 _center;
        [SerializeField] private float _size = 10f;
        [SerializeField] private int _maxDepth = 5;

        private OctreeNode _root;

        private void Awake()
        {
            BuildOctree();
        }

        private void BuildOctree()
        {
            _root = new OctreeNode(_center, _size);
            SubdivideToDepth(_root, 0);
        }

        private void SubdivideToDepth(OctreeNode node, int depth)
        {
            if (depth >= _maxDepth) return;

            node.Subdivide();

            foreach (var child in node.GetChildren())
            {
                SubdivideToDepth(child, depth + 1);
            }
        }
    }
}