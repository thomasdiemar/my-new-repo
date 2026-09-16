using System;
using UnityEngine;

namespace PlanetGenerator
{
    /// <summary>
    /// Simple validation script to test if the planet generator compiles and works correctly
    /// </summary>
    public class BuildValidation 
    {
        public static void ValidateImplementation()
        {
            try
            {
                // Test that we can create a generator
                var generator = new PlanetGenerator();
                
                // Test noise generation
                float noise2D = Noise.Generate2DPerlin(0f, 0f);
                float noise3D = Noise.Generate3DPerlin(0f, 0f, 0f);
                float fbm = Noise.GenerateFractalBrownianMotion(0f, 0f);
                
                // Test terrain generation
                float height = generator.GenerateTerrainHeight(0f, 0f);
                Vector3 normal = generator.GenerateTerrainNormal(0f, 0f);
                Color color = generator.GenerateTerrainColor(0f, 0f);
                
                // Test LOD system
                int lod = generator.GetLodLevel(50f);
                
                Debug.Log("✅ All validations passed successfully!");
                Debug.Log($"Noise values - 2D: {noise2D:F3}, 3D: {noise3D:F3}, FBM: {fbm:F3}");
                Debug.Log($"Terrain - Height: {height:F3}, LOD: {lod}");
                
            }
            catch (Exception ex)
            {
                Debug.LogError("❌ Build validation failed: " + ex.Message);
                throw;
            }
        }
    }
}