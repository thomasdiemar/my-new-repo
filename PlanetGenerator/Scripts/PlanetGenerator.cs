using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetGenerator : MonoBehaviour
{
    [Header("Terrain Settings")]
    public int seed = 0;
    public float terrainScale = 1.0f;
    public int terrainResolution = 100;
    public float heightMultiplier = 1.0f;
    
    [Header("Texture Settings")]
    public Material terrainMaterial;
    public int textureResolution = 1024;
    
    [Header("Atmosphere Settings")]
    public bool useAtmosphere = true;
    public Color atmosphereColor = new Color(0.5f, 0.7f, 1.0f, 1.0f);
    public float atmosphereThickness = 0.1f;
    public float atmosphereDensity = 0.5f;
    
    [Header("Rendering Settings")]
    public bool useLOD = true;
    public int lodLevels = 4;
    public float[] lodDistances = new float[] { 50f, 100f, 200f, 500f };
    public bool useOcclusionCulling = true;
    
    [Header("Debug Settings")]
    public bool showWireframe = false;
    public bool generateTerrain = true;
    
    private MeshFilter meshFilter;
    private MeshRenderer meshRenderer;
    private Mesh mesh;
    private GameObject planetObject;
    
    void Start()
    {
        if (generateTerrain)
        {
            GeneratePlanet();
        }
    }