using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using PlanetGenerator;

namespace PlanetGenerator.Tests
{
    /// <summary>
    /// Simple test runner to verify the planet generator functionality
    /// </summary>
    public class PlanetGeneratorTestRunner : MonoBehaviour
    {
        private PlanetGenerator generator;

        void Start()
        {
            generator = new PlanetGenerator();
            RunAllTests();
        }

        void RunAllTests()
        {
            Debug.Log("Starting Planet Generator Tests...");
            
            // Test noise generation
            TestNoiseGeneration();
            
            // Test terrain generation
            TestTerrainGeneration();
            
            // Test LOD system
            TestLODSystem();
            
            Debug.Log("All tests completed successfully!");
        }

        void TestNoiseGeneration()
        {
            float value1 = Noise.Generate2DPerlin(0f, 0f);
            float value2 = Noise.Generate3DPerlin(0f, 0f, 0f);
            float fbmValue = Noise.GenerateFractalBrownianMotion(0f, 0f);
            
            Debug.Assert(value1 >= -1f && value1 <= 1f, "2D Perlin noise out of range");
            Debug.Assert(value2 >= -1f && value2 <= 1f, "3D Perlin noise out of range");
            Debug.Assert(fbmValue >= -1f && fbmValue <= 1f, "Fractal Brownian Motion out of range");
            
            Debug.Log("Noise generation tests passed");
        }

        void TestTerrainGeneration()
        {
            float height = generator.GenerateTerrainHeight(0f, 0f);
            Vector3 normal = generator.GenerateTerrainNormal(0f, 0f);
            Color color = generator.GenerateTerrainColor(0f, 0f);
            
            Debug.Assert(height >= -100f && height <= 100f, "Terrain height out of range");
            Debug.Assert(normal.magnitude > 0.99f && normal.magnitude < 1.01f, "Terrain normal not normalized");
            Debug.Assert(color.r >= 0f && color.r <= 1f, "Color R component out of range");
            Debug.Assert(color.g >= 0f && color.g <= 1f, "Color G component out of range");
            Debug.Assert(color.b >= 0f && color.b <= 1f, "Color B component out of range");
            
            Debug.Log("Terrain generation tests passed");
        }

        void TestLODSystem()
        {
            int lod0 = generator.GetLodLevel(10f);
            int lod1 = generator.GetLodLevel(25f);
            int lod2 = generator.GetLodLevel(100f);
            
            Debug.Assert(lod0 == 0, "LOD level 0 incorrect");
            Debug.Assert(lod1 == 1, "LOD level 1 incorrect");
            Debug.Assert(lod2 <= generator.maxLodLevels - 1, "LOD level exceeds max");
            
            Debug.Log("LOD system tests passed");
        }
    }
}