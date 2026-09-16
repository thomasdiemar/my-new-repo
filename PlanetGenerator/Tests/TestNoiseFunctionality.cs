using UnityEngine;
using NUnit.Framework;

namespace PlanetGenerator.Tests
{
    /// <summary>
    /// Test to verify that noise generation functionality works properly
    /// </summary>
    public class TestNoiseFunctionality
    {
        [Test]
        public void Test2DPerlinNoiseGeneration()
        {
            // Test that we can generate 2D Perlin noise
            float value = Noise.Generate2DPerlin(0.5f, 0.5f);
            
            // Should return a value between -1 and 1
            Assert.That(value, Is.InRange(-1f, 1f));
        }
        
        [Test]
        public void Test3DPerlinNoiseGeneration()
        {
            // Test that we can generate 3D Perlin noise
            float value = Noise.Generate3DPerlin(0.5f, 0.5f, 0.5f);
            
            // Should return a value between -1 and 1
            Assert.That(value, Is.InRange(-1f, 1f));
        }
        
        [Test]
        public void TestFractalBrownianMotionGeneration()
        {
            // Test that we can generate fractal Brownian motion noise
            float value = Noise.GenerateFractalBrownianMotion(0.5f, 0.5f, 6, 0.5f, 2.0f);
            
            // Should return a value between -1 and 1
            Assert.That(value, Is.InRange(-1f, 1f));
        }
        
        [Test]
        public void TestNoiseValuesAreConsistent()
        {
            // Test that the same input produces consistent output
            float value1 = Noise.Generate2DPerlin(1.0f, 1.0f);
            float value2 = Noise.Generate2DPerlin(1.0f, 1.0f);
            
            Assert.AreEqual(value1, value2);
        }
    }
}