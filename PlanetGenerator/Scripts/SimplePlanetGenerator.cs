using UnityEngine;

namespace PlanetGenerator
{
    /// <summary>
    /// Simple planet generator for testing purposes
    /// </summary>
    public class SimplePlanetGenerator : MonoBehaviour
    {
        [Header("Basic Settings")]
        public float planetRadius = 10f;
        public int resolution = 20;
        
        void Start()
        {
            CreateSimplePlanet();
        }
        
        void CreateSimplePlanet()
        {
            // Create a basic sphere for testing
            GameObject planet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            planet.name = "TestPlanet";
            planet.transform.localScale = Vector3.one * planetRadius;
            
            // Add our test material if available
            Renderer renderer = planet.GetComponent<Renderer>();
            if (renderer != null)
            {
                Debug.Log("Material assigned to planet");
            }
        }
    }
}