using UnityEngine;
using System.Collections;

namespace PlanetGenerator
{
    /// <summary>
    /// Test script to verify material assignment works correctly
    /// </summary>
    public class TestPlanetGenerator : MonoBehaviour
    {
        [Header("Test Settings")]
        public Material testMaterial;
        
        private void Start()
        {
            // Create a simple test planet
            CreateTestPlanet();
        }
        
        private void CreateTestPlanet()
        {
            // Create a basic sphere for testing
            GameObject planet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            planet.name = "TestPlanet";
            
            // Apply our test material if provided
            if (testMaterial != null)
            {
                Renderer renderer = planet.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.material = testMaterial;
                    Debug.Log("Material assigned successfully!");
                }
            }
            else
            {
                Debug.Log("No test material provided");
            }
            
            // Position the planet
            planet.transform.position = Vector3.zero;
            planet.transform.localScale = Vector3.one * 5f;
        }
    }
}