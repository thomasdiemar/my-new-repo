using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using PlanetGenerator;

namespace PlanetGenerator.Tests
{
    public class PlanetGeneratorTests
    {
        private PlanetGenerator generator;

        [SetUp]
        public void Setup()
        {
            generator = new PlanetGenerator();
        }

        [Test]
        public void NoiseGeneration_ReturnsValidValues()
        {
            // Test that noise generation returns values in expected range
            float value1 = Noise.Generate2DPerlin(0f, 0f);
            float value2 = Noise.Generate3DPerlin(0f, 0f, 0f);
            
            Assert.That(value1, Is.InRange(-1f, 1f));
            Assert.That(value2, Is.InRange(-1f, 1f));
        }

        [Test]
        public void TerrainHeightGeneration_ReturnsValidValues()
        {
            // Test terrain height generation
            float height = generator.GenerateTerrainHeight(0f, 0f);
            
            // Should return a value within reasonable range for a planet of radius 1000
            Assert.That(height, Is.InRange(-100f, 100f));
        }

        [Test]
        public void TerrainNormalGeneration_ReturnsValidVector()
        {
            // Test terrain normal generation
            Vector3 normal = generator.GenerateTerrainNormal(0f, 0f);
            
            // Should return a normalized vector
            Assert.That(normal.magnitude, Is.EqualTo(1.0f).Within(0.01f));
        }

        [Test]
        public void TerrainColorGeneration_ReturnsValidColor()
        {
            // Test terrain color generation
            Color color = generator.GenerateTerrainColor(0f, 0f);
            
            // Should return a valid color
            Assert.That(color.r, Is.InRange(0f, 1f));
            Assert.That(color.g, Is.InRange(0f, 1f));
            Assert.That(color.b, Is.InRange(0f, 1f));
            Assert.That(color.a, Is.InRange(0f, 1f));
        }

        [Test]
        public void LODLevelCalculation_ReturnsValidLevels()
        {
            // Test LOD level calculation
            int lod0 = generator.GetLodLevel(10f); // Should be 0 (highest detail)
            int lod1 = generator.GetLodLevel(25f); // Should be 1 
            int lod2 = generator.GetLodLevel(100f); // Should be 2
            int lod3 = generator.GetLodLevel(200f); // Should be 3
            int lod4 = generator.GetLodLevel(1000f); // Should be max level
            
            Assert.That(lod0, Is.EqualTo(0));
            Assert.That(lod1, Is.EqualTo(1));
            Assert.That(lod2, Is.EqualTo(2));
            Assert.That(lod3, Is.EqualTo(3));
            Assert.That(lod4, Is.LessThanOrEqualTo(generator.maxLodLevels - 1));
        }

        [Test]
        public void PlanetGeneratorProperties_AreInitializedCorrectly()
        {
            // Test that properties are initialized correctly
            Assert.That(generator.radius, Is.EqualTo(1000f));
            Assert.That(generator.noiseScale, Is.EqualTo(100f));
            Assert.That(generator.octaves, Is.EqualTo(6));
            Assert.That(generator.persistence, Is.EqualTo(0.5f));
            Assert.That(generator.lacunarity, Is.EqualTo(2.0f));
            Assert.That(generator.baseColor, Is.EqualTo(Color.green));
            Assert.That(generator.textureResolution, Is.EqualTo(512));
        }

        [Test]
        public void PlanetGeneratorParameters_ChangeCorrectly()
        {
            // Test that parameters can be changed
            generator.radius = 2000f;
            generator.noiseScale = 200f;
            
            Assert.That(generator.radius, Is.EqualTo(2000f));
            Assert.That(generator.noiseScale, Is.EqualTo(200f));
        }

        [Test]
        public void FractalBrownianMotion_ReturnsValidValues()
        {
            // Test fractal Brownian motion
            float value = Noise.GenerateFractalBrownianMotion(0f, 0f, 6, 0.5f, 2.0f);
            
            Assert.That(value, Is.InRange(-1f, 1f));
        }
    }
}