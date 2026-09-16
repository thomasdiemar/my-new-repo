using UnityEngine;
using System.Collections;

namespace PlanetGenerator
{
    /// <summary>
    /// Test script to verify the PlanetGenerator functionality
    /// </summary>
    public class PlanetGeneratorTest : MonoBehaviour
    {
        [Header("Generator Settings")]
        public PlanetGenerator generator;
        
        [Header("Planet Settings")]
        public Vector3 planetPosition = Vector3.zero;
        public Vector3 planetScale = Vector3.one;
        
        void Start()
        {
            // Initialize the generator if not assigned
            if (generator == null)
            {
                generator = new PlanetGenerator();
            }
            
            // Test basic generation functions
            TestGeneration();
            
            // Create a planet
            GameObject planet = generator.CreatePlanet(planetPosition, planetScale);
            planet.transform.parent = transform;
            
            Debug.Log("Planet created successfully with MultiLayeredTerrainShader!");
        }
        
        void TestGeneration()
        {
            // Test terrain height generation
            float height = generator.GenerateTerrainHeight(100f, 200f);
            Debug.Log($"Generated terrain height at (100, 200): {height}");
            
            // Test terrain normal generation
            Vector3 normal = generator.GenerateTerrainNormal(100f, 200f);
            Debug.Log($"Generated terrain normal at (100, 200): {normal}");
            
            // Test terrain color generation
            Color color = generator.GenerateTerrainColor(100f, 200f);
            Debug.Log($"Generated terrain color at (100, 200): {color}");
            
            // Test LOD level calculation
            int lodLevel = generator.GetLodLevel(100f);
            Debug.Log($"LOD level for distance 100: {lodLevel}");
        }
    }
}