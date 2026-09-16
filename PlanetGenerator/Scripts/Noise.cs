using System;
using UnityEngine;

namespace PlanetGenerator
{
    /// <summary>
    /// Noise generation utilities for procedural planet generation
    /// </summary>
    public static class Noise
    {
        /// <summary>
        /// Generates 2D Perlin noise value at given coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <returns>Noise value between -1 and 1</returns>
        public static float Generate2DPerlin(float x, float y)
        {
            // Simple implementation of 2D Perlin noise
            // For a real implementation, we'd use a more sophisticated algorithm
            return Mathf.PerlinNoise(x, y);
        }

        /// <summary>
        /// Generates 3D Perlin noise value at given coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="z">Z coordinate</param>
        /// <returns>Noise value between -1 and 1</returns>
        public static float Generate3DPerlin(float x, float y, float z)
        {
            // Simple implementation of 3D Perlin noise
            return Mathf.PerlinNoise(x, y) * Mathf.PerlinNoise(y, z) * Mathf.PerlinNoise(z, x);
        }

        /// <summary>
        /// Generates fractal Brownian motion (fBm) noise
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="octaves">Number of noise octaves</param>
        /// <param name="persistence">Persistence factor</param>
        /// <param name="lacunarity">Lacunarity factor</param>
        /// <returns>Noise value between -1 and 1</returns>
        public static float GenerateFractalBrownianMotion(float x, float y, int octaves = 6, float persistence = 0.5f, float lacunarity = 2.0f)
        {
            float amplitude = 1.0f;
            float frequency = 1.0f;
            float noiseValue = 0.0f;

            for (int i = 0; i < octaves; i++)
            {
                float sampleX = x * frequency;
                float sampleY = y * frequency;
                
                noiseValue += Generate2DPerlin(sampleX, sampleY) * amplitude;
                
                amplitude *= persistence;
                frequency *= lacunarity;
            }

            return noiseValue;
        }
    }
}