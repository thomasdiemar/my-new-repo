using UnityEngine;
using System.Collections;

namespace PlanetGenerator
{
    /// <summary>
    /// Demo script to showcase the planet generation system
    /// </summary>
    public class PlanetDemo : MonoBehaviour
    {
        [Header("Planet Settings")]
        public PlanetGenerator generator;
        public Vector3 planetPosition = Vector3.zero;
        public Vector3 planetScale = Vector3.one;
        
        [Header("Atmosphere Settings")]
        public bool enableAtmosphere = true;
        public Color atmosphereColor = Color.blue;
        public float atmosphereThickness = 0.1f;
        
        void Start()
        {
            // Initialize the generator if not assigned
            if (generator == null)
            {
                generator = new PlanetGenerator();
            }
            
            // Create a planet with our multi-layered terrain shader
            GameObject planet = generator.CreatePlanet(planetPosition, planetScale);
            planet.transform.parent = transform;
            
            Debug.Log("Planet generation complete!");
            
            // Add atmosphere effect if enabled
            if (enableAtmosphere)
            {
                AddAtmosphere(planet);
            }
        }
        
        void AddAtmosphere(GameObject planet)
        {
            // Create a slightly larger sphere to represent the atmosphere
            GameObject atmosphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            atmosphere.transform.parent = planet.transform;
            atmosphere.transform.localScale = new Vector3(1.05f, 1.05f, 1.05f); // 5% larger than planet
            
            // Create atmosphere material with appropriate shader
            Material atmosphereMaterial = new Material(Shader.Find("Custom/AtmosphereShader"));
            atmosphereMaterial.SetColor("_AtmosphereColor", atmosphereColor);
            atmosphereMaterial.SetFloat("_Thickness", atmosphereThickness);
            
            // Apply material to atmosphere
            MeshRenderer atmosphereRenderer = atmosphere.GetComponent<MeshRenderer>();
            atmosphereRenderer.material = atmosphereMaterial;
            
            // Set the atmosphere to be semi-transparent
            atmosphereMaterial.SetFloat("_Transparency", 0.3f);
            
            Debug.Log("Atmosphere added to planet!");
        }
    }
}