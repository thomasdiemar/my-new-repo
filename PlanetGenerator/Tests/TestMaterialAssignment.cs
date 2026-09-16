using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

namespace PlanetGenerator.Tests
{
    public class TestMaterialAssignment
    {
        [Test]
        public void MaterialAssignmentTest()
        {
            // Create a test GameObject
            GameObject testObject = new GameObject("TestPlanet");
            
            // Add the PlanetGenerator component
            PlanetGenerator generator = testObject.AddComponent<PlanetGenerator>();
            
            // Create a simple material for testing
            Material testMaterial = new Material(Shader.Find("Standard"));
            testMaterial.name = "TestMaterial";
            
            // Assign the material to the generator
            generator.planetMaterial = testMaterial;
            
            // Verify that the material was assigned
            Assert.IsNotNull(generator.planetMaterial);
            Assert.AreEqual(testMaterial, generator.planetMaterial);
            
            // Cleanup
            Object.DestroyImmediate(testObject);
        }
    }
}