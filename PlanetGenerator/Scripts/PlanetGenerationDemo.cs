using UnityEngine;

namespace PlanetGenerator
{
    /// <summary>
    /// Demo script to show how the planet generator works
    /// </summary>
    public class PlanetGenerationDemo : MonoBehaviour
    {
        [Header("Demo Settings")]
        public Material demoMaterial;
        
        void Start()
        {
            Debug.Log("=== Planet Generation Demo ===");
            
            // Test that Noise functions work
            TestNoiseGeneration();
            
            // Test basic planet generation
            TestPlanetCreation();
            
            Debug.Log("=== Demo Complete ===");
        }
        
        void TestNoiseGeneration()
        {
            Debug.Log("Testing noise generation:");
            
            // Test 2D Perlin noise
            float noise2d = Noise.Generate2DPerlin(1.0f, 1.0f);
            Debug.Log($"2D Perlin noise (1,1): {noise2d:F4}");
            
            // Test 3D Perlin noise
            float noise3d = Noise.Generate3DPerlin(1.0f, 1.0f, 1.0f);
            Debug.Log($"3D Perlin noise (1,1,1): {noise3d:F4}");
            
            // Test fractal Brownian motion
            float fbm = Noise.GenerateFractalBrownianMotion(1.0f, 1.0f, 6, 0.5f, 2.0f);
            Debug.Log($"Fractal Brownian Motion (1,1): {fbm:F4}");
        }
        
        void TestPlanetCreation()
        {
            Debug.Log("Testing planet creation:");
            
            // Create a basic planet
            GameObject planet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            planet.name = "DemoPlanet";
            planet.transform.position = Vector3.zero;
            planet.transform.localScale = Vector3.one * 5f;
            
            Renderer renderer = planet.GetComponent<Renderer>();
            if (renderer != null)
            {
                if (demoMaterial != null)
                {
                    renderer.material = demoMaterial;
                    Debug.Log("Material assigned to demo planet");
                }
                else
                {
                    Debug.Log("Using default material for demo planet");
                }
            }
            
            Debug.Log("Demo planet created successfully");
        }
    }
}