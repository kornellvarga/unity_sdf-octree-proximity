using UnityEngine;

namespace AdaptiveOctree
{
    public class OctreeStructureValidator : MonoBehaviour
    {
        private OctreeNode _root;

        public bool ValidateStructure(OctreeNode root)
        {
            _root = root;
            return ValidateNode(_root);
        }

        private bool ValidateNode(OctreeNode node)
        {
            if (node == null) return false;

            if (!node.IsLeaf)
            {
                var children = node.GetChildren();
                if (children.Length != 8)
                {
                    Debug.LogError("Invalid number of children in octree node");
                    return false;
                }

                foreach (var child in children)
                {
                    if (!ValidateNode(child))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}