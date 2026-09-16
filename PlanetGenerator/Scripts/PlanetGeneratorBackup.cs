using System;
using UnityEngine;

namespace PlanetGenerator
{
    /// <summary>
    /// Core procedural planet generation system
    /// </summary>
    [Serializable]
    public class PlanetGenerator
    {
        [Header("Terrain Settings")]
        public float radius = 1000f;
        public float noiseScale = 100f;
        public int octaves = 6;
        public float persistence = 0.5f;
        public float lacunarity = 2.0f;
        
        [Header("Texture Settings")]
        public Color baseColor = Color.green;
        public int textureResolution = 512;
        public float blendFactor = 0.5f;
        public float normalMapIntensity = 1.0f;
        
        [Header("Rendering Settings")]
        public Material planetMaterial;
        public bool useOcclusionCulling = true;

        /// <summary>
        /// Generates terrain height at given coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <returns>Height value</returns>
        public float GenerateTerrainHeight(float x, float y)
        {
            // Normalize coordinates to noise space
            float normalizedX = x / noiseScale;
            float normalizedY = y / noiseScale;
            
            // Generate fractal Brownian motion noise
            float noiseValue = Noise.GenerateFractalBrownianMotion(normalizedX, normalizedY, octaves, persistence, lacunarity);
            
            // Scale and offset the noise to get desired height range
            return noiseValue * radius * 0.1f;
        }

        /// <summary>
        /// Generates terrain normal at given coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <returns>Normal vector</returns>
        public Vector3 GenerateTerrainNormal(float x, float y)
        {
            // Calculate gradient using small offsets
            float eps = 0.01f;
            float heightLeft = GenerateTerrainHeight(x - eps, y);
            float heightRight = GenerateTerrainHeight(x + eps, y);
            float heightDown = GenerateTerrainHeight(x, y - eps);
            float heightUp = GenerateTerrainHeight(x, y + eps);
            
            // Create normal vector from gradient
            Vector3 normal = new Vector3(heightLeft - heightRight, 2 * eps, heightDown - heightUp);
            normal.Normalize();
            
            return normal;
        }

        /// <summary>
        /// Generates terrain color at given coordinates
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <returns>Color value</returns>
        public Color GenerateTerrainColor(float x, float y)
        {
            // Simple color generation based on height and noise
            float height = GenerateTerrainHeight(x, y);
            float noiseValue = Noise.Generate2DPerlin(x / noiseScale, y / noiseScale);
            
            // Blend base color with variations based on height
            Color color = baseColor;
            
            // Modify color based on terrain features
            if (height > 50f)
                color = Color.white; // Snow caps
            else if (height > 20f)
                color = Color.gray; // Mountainous areas
            else if (height > 0f)
                color = Color.green; // Plains
            else if (height > -20f)
                color = Color.blue; // Shallow water
            else
                color = Color.cyan; // Deep water
            
            // Apply noise to add variation
            float variation = (noiseValue + 1f) / 2f;
            color.r += (variation - 0.5f) * 0.2f;
            color.g += (variation - 0.5f) * 0.2f;
            color.b += (variation - 0.5f) * 0.2f;
            
            return color;
        }

        /// <summary>
        /// Gets LOD level based on distance from camera
        /// </summary>
        /// <param name="distance">Distance from camera</param>
        /// <returns>LOD level (0-4)</returns>
        public int GetLodLevel(float distance)
        {
            if (distance < lodThreshold * 0.25f) return 0; // Highest detail
            if (distance < lodThreshold * 0.5f) return 1;
            if (distance < lodThreshold) return 2;
            if (distance < lodThreshold * 2f) return 3;
            return maxLodLevels - 1; // Lowest detail
        }

        /// <summary>
        /// Generates a mesh for the planet at specified LOD level
        /// </summary>
        /// <param name="lodLevel">LOD level to generate</param>
        /// <returns>Generated mesh</returns>
        public Mesh GeneratePlanetMesh(int lodLevel = 0)
        {
            // This is a simplified implementation - in a real system we would create
            // a proper spherical mesh with dynamic subdivision based on LOD
            
            Mesh mesh = new Mesh();
            
            // For now, just return a basic sphere
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            mesh = sphere.GetComponent<MeshFilter>().sharedMesh;
            UnityEngine.Object.DestroyImmediate(sphere);
            
            return mesh;
        }

        /// <summary>
        /// Creates a planet GameObject with the generated terrain
        /// </summary>
        /// <param name="position">Position of the planet</param>
        /// <param name="scale">Scale of the planet</param>
        /// <returns>Planet GameObject</returns>
        public GameObject CreatePlanet(Vector3 position, Vector3 scale)
        {
            GameObject planet = new GameObject("Planet");
            planet.transform.position = position;
            planet.transform.localScale = scale;

            MeshFilter meshFilter = planet.AddComponent<MeshFilter>();
            MeshRenderer meshRenderer = planet.AddComponent<MeshRenderer>();

            // Set the material
            if (planetMaterial != null)
            {
                meshRenderer.material = planetMaterial;
            }
            else
            {
                // Create a default material if none provided
                Material defaultMaterial = new Material(Shader.Find("Custom/MultiLayeredTerrainShader"));
                meshRenderer.material = defaultMaterial;
            }

            // Generate and assign the mesh
            int lodLevel = 0; // Default to highest LOD for simplicity
            Mesh planetMesh = GeneratePlanetMesh(lodLevel);
            meshFilter.mesh = planetMesh;

            return planet;
        }
    }
}