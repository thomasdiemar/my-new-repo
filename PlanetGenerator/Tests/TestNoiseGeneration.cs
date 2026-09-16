using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace PlanetGenerator.Tests
{
    /// <summary>
    /// Unit tests for noise generation functionality
    /// </summary>
    public class TestNoiseGeneration
    {
        [Test]
        public void Test2DPerlinNoise_ReturnsValueInRange()
        {
            // Test that 2D Perlin noise returns values between -1 and 1
            float value = Noise.Generate2DPerlin(0.5f, 0.5f);
            Assert.That(value, Is.InRange(-1f, 1f));
        }
        
        [Test]
        public void Test3DPerlinNoise_ReturnsValueInRange()
        {
            // Test that 3D Perlin noise returns values between -1 and 1
            float value = Noise.Generate3DPerlin(0.5f, 0.5f, 0.5f);
            Assert.That(value, Is.InRange(-1f, 1f));
        }
        
        [Test]
        public void TestFractalBrownianMotion_ReturnsValueInRange()
        {
            // Test that fractal Brownian motion returns values between -1 and 1
            float value = Noise.GenerateFractalBrownianMotion(0.5f, 0.5f, 6, 0.5f, 2.0f);
            Assert.That(value, Is.InRange(-1f, 1f));
        }
        
        [Test]
        public void TestFractalBrownianMotion_WithDifferentParameters()
        {
            // Test with different parameters
            float value = Noise.GenerateFractalBrownianMotion(1.0f, 1.0f, 3, 0.2f, 1.5f);
            Assert.That(value, Is.InRange(-1f, 1f));
        }
    }
}