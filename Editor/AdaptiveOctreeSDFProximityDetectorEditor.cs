using UnityEditor;
using UnityEngine;

namespace AdaptiveOctree
{
    [CustomEditor(typeof(AdaptiveOctreeSDFProximityDetector))]
    public class AdaptiveOctreeSDFProximityDetectorEditor : Editor
    {
        private SerializedProperty _centerProperty;
        private SerializedProperty _sizeProperty;
        private SerializedProperty _maxDepthProperty;
        private SerializedProperty _activationThresholdProperty;
        private SerializedProperty _hysteresisProperty;

        private void OnEnable()
        {
            _centerProperty = serializedObject.FindProperty("_center");
            _sizeProperty = serializedObject.FindProperty("_size");
            _maxDepthProperty = serializedObject.FindProperty("_maxDepth");
            _activationThresholdProperty = serializedObject.FindProperty("_activationThreshold");
            _hysteresisProperty = serializedObject.FindProperty("_hysteresis");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.LabelField("Octree Settings", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(_centerProperty);
            EditorGUILayout.PropertyField(_sizeProperty);
            EditorGUILayout.PropertyField(_maxDepthProperty);

            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Activation Strategy", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(_activationThresholdProperty);
            EditorGUILayout.PropertyField(_hysteresisProperty);

            serializedObject.ApplyModifiedProperties();
        }
    }
}