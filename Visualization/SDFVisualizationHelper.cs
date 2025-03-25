using UnityEngine;

namespace AdaptiveOctree
{
    public class SDFVisualizationHelper : MonoBehaviour
    {
        [SerializeField] private Color _positiveColor = Color.green;
        [SerializeField] private Color _negativeColor = Color.red;
        [SerializeField] private float _maxDistance = 1f;

        public void VisualizeSDFValue(Vector3 position, float sdfValue)
        {
            Color color = sdfValue >= 0 ? 
                Color.Lerp(Color.white, _positiveColor, sdfValue / _maxDistance) :
                Color.Lerp(Color.white, _negativeColor, -sdfValue / _maxDistance);

            Debug.DrawLine(
                position - Vector3.right * 0.1f,
                position + Vector3.right * 0.1f,
                color,
                0f,
                false
            );
        }

        public void VisualizeSDF(Vector3[] positions, float[] sdfValues)
        {
            for (int i = 0; i < positions.Length; i++)
            {
                VisualizeSDFValue(positions[i], sdfValues[i]);
            }
        }
    }
}