#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace PlanetGenerator
{
    /// <summary>
    /// Custom editor for PlanetGenerator to provide a better UI in Unity Editor
    /// </summary>
    [CustomEditor(typeof(PlanetGeneratorTest))]
    public class PlanetGeneratorEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            
            PlanetGeneratorTest myScript = (PlanetGeneratorTest)target;
            
            if (GUILayout.Button("Generate New Planet"))
            {
                // Create a new planet with current settings
                GameObject planet = myScript.generator.CreatePlanet(myScript.planetPosition, myScript.planetScale);
                planet.transform.parent = myScript.transform;
                planet.name = "Generated_Planet_" + Random.Range(1000, 9999);
                
                Debug.Log("New planet generated!");
            }
        }
    }
}
#endif