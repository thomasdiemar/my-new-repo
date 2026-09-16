using UnityEngine;
using System.Collections;

namespace PlanetGenerator
{
    /// <summary>
    /// Test script to verify material assignment works correctly
    /// </summary>
    public class TestMaterialAssignment : MonoBehaviour
    {
        [Header("Test Settings")]
        public Material testMaterial;
        
        private void Start()
        {
            // Test that we can access the PlanetGenerator functionality
            Debug.Log("Testing Planet Generator Material Assignment");
            
            // Create a simple test sphere to verify material works
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.name = "MaterialTestSphere";
            sphere.transform.position = Vector3.zero;
            
            Renderer renderer = sphere.GetComponent<Renderer>();
            if (renderer != null)
            {
                if (testMaterial != null)
                {
                    renderer.material = testMaterial;
                    Debug.Log("Material assigned successfully to test sphere!");
                }
                else
                {
                    Debug.Log("No test material provided - using default material");
                }
            }
        }
    }
}