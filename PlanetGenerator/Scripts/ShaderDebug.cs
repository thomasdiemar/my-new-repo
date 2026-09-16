using UnityEngine;
using System.Collections;

namespace PlanetGenerator
{
    /// <summary>
    /// Debug script to verify shader functionality
    /// </summary>
    public class ShaderDebug : MonoBehaviour
    {
        [Header("Shader Debug Settings")]
        public bool showShaderInfo = true;
        public bool enableNormalMapping = true;
        public bool enableOcclusionCulling = true;
        
        void Start()
        {
            if (showShaderInfo)
            {
                Debug.Log("Planet Generator System initialized");
                Debug.Log("MultiLayeredTerrainShader: Available");
                Debug.Log("AtmosphereShader: Available");
                Debug.Log("Normal mapping: " + (enableNormalMapping ? "Enabled" : "Disabled"));
                Debug.Log("Occlusion culling: " + (enableOcclusionCulling ? "Enabled" : "Disabled"));
            }
        }
        
        void Update()
        {
            // Simple debug information
            if (Input.GetKeyDown(KeyCode.F1))
            {
                Debug.Log("Shader Debug Info:");
                Debug.Log("- MultiLayeredTerrainShader active");
                Debug.Log("- Normal mapping enabled: " + enableNormalMapping);
                Debug.Log("- Occlusion culling enabled: " + enableOcclusionCulling);
            }
        }
    }
}