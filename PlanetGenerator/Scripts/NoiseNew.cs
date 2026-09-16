using System;
using UnityEngine;

namespace PlanetGenerator
{
    public static class Noise
    {
        /// <summary>
        /// Generates a value using fractal Brownian motion (fBm)
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="octaves">Number of octaves</param>
        /// <param name="persistence">Persistence value</param>
        /// <param name="lacunarity">Lacunarity value</param>
        /// <returns>Noise value</returns>
        public static float GenerateFractalBrownianMotion(float x, float y, int octaves, float persistence, float lacunarity)
        {
            float value = 0.0f;
            float amplitude = 1.0f;
            float frequency = 1.0f;

            for (int i = 0; i < octaves; i++)
            {
                value += GetNoise(x * frequency, y * frequency) * amplitude;
                amplitude *= persistence;
                frequency *= lacunarity;
            }

            return value;
        }

        /// <summary>
        /// Gets a noise value at the specified coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <returns>Noise value between -1 and 1</returns>
        private static float GetNoise(float x, float y)
        {
            // Simple implementation using sine waves
            return Mathf.Sin(x * 10f) * Mathf.Sin(y * 10f);
        }
    }
}