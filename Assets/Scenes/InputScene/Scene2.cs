using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Scene2 : MonoBehaviour
{
    // IMPORTANT (as suggestions):
    // 1/ Change the skybox of the scene to make it look real as possible as a challenge
    // 2/ Try to expand the project by enabling "Universal Render Pipeline" to make it look visually pleasing

    // 2ND IMPORTANT (as another suggestion):
    // Try to build this project to be also ported into Mobile section
    // -->  This is so that anyone who wants to try the game without using the laptop can perform this action using their Mobile from the QR code.
    // -->  --> Add this function before the project fair (on Friday if that is absolutely possible)

    // 3rd IMPORTANT SUGGESTION:
    // --> Generate the world with its given input to also match the expected color.
    // --> How to generate a world that is purely green (nature), by which, you should call method from struct Colour method to perform this action

    // public MapGenerator mapGenerator;
    public MapGenerator MapGenerator;
    public GameObject FPSController;
    public TextMeshProUGUI display_map_name;
    public TextMeshProUGUI display_seed_name;
    private static Scene1 scene1;
    private static Scene2 scene2;
    public Vector3 spawnValue;
    private Vector3 position;

    // new line of code
    public Vector2 centre;
   
    // New line of code written over here! - come back to this one 
    // make use of this one
    private MapData newMapData;
    private MapDisplay newMapDisplay;
    public TerrainType[] newRegions;

    public const int newMapChunkSize = 239;

    // List<TerrainType> newRegions = new List<TerrainType> { };

    // TerrainType[] newRegions;
    // TerrainType newTerrain = new TerrainType();
    // newTerrain.name = "ground";
    // newTerrain.height = 0.50f;
    // newTerrain.colour = new Color(256f, 256f, 256f);

    // MapData newMapData = new MapData();
    // MapDisplay newDisplay = new MapDisplay();
    // newDisplay.DrawMesh(MeshGenerator.GenerateTerrainMesh(newMapData.heightMap, MapGenerator.meshHeightMultiplier, MapGenerator.meshHeightCurve, MapGenerator.editorPreviewLOD), TextureGenerator.TextureFromColourMap(newMapData.colourMap, MapGenerator.mapChunkSize, MapGenerator.mapChunkSize));

    List<string> arr = new List<string> { };
    List<float> noiseScaleArr = new List<float> { };
    List<int> octavesArr = new List<int> { };
    List<float> persistancesArr = new List<float> { };
    List<float> lacunarityArr = new List<float> { };

    public float noiseScaleCalculation(string name, float noiseScale)
    {
        int total = 0;

        if(name.Contains("small"))
        {
            noiseScaleArr.Add(200);
            total++;
        }
        if(name.Contains("medium"))
        {
            noiseScaleArr.Add(48);
            total++;
        }
        if(name.Contains("large"))
        {
            noiseScaleArr.Add(30);
            total++;
        }
        if (name.Contains("openworld"))
        {
            noiseScaleArr.Add(48.68f);
            total++;
        }

        if (name.Contains("rpg"))
        {
            noiseScaleArr.Add(0.5f);
            total++;
        }
        if (name.Contains("flat"))
        {
            noiseScaleArr.Add(48.68f);
            total++;
        }
        if (name.Contains("hills"))
        {
            noiseScaleArr.Add(48.68f);
            total++;
        }
        else
        {
            noiseScaleArr.Add(48.68f);
            total++;
        }

        Debug.Log("noiseScaleArr: " + noiseScaleArr);

        int sum = 0;
        for (int i = 0; i <= total; i++)
        {
            // sum = total++;
            sum++;

            if(sum == total)
            {
                break;
            }
        }

        float noiseScaleSum = noiseScaleArr.Sum();
        Debug.Log("noiseScaleSum: " + noiseScaleSum);

        float noiseScaleAverage = (noiseScaleSum / sum);
        Debug.Log("noisescale Average: " + noiseScaleAverage);

        noiseScale = noiseScaleAverage;
        return noiseScale;
    }

    public int octavesCalculation(string name, int octaves)
    {
        int total = 0;
        if(name.Contains("small"))
        {
            octavesArr.Add(12);
            total++;
        }
        if(name.Contains("medium"))
        {
            octavesArr.Add(8);
            total++;
        }
        if(name.Contains("large"))
        {
            octavesArr.Add(6);
            total++;
        }
        if (name.Contains("openworld"))
        {
            octavesArr.Add(8);
            total++;
        }
        if (name.Contains("rpg"))
        {
            octavesArr.Add(1);
            total++;
        }
        if (name.Contains("flat"))
        {
            octavesArr.Add(8);
            total++;
        }
        if (name.Contains("hills"))
        {
            octavesArr.Add(8);
            total++;
        }
        else
        {
            octavesArr.Add(8);
            total++;
        }
        Debug.Log(octavesArr);

        int sum = 0;
        for (int i = 0; i <= total; i++)
        {
            sum++;

            if(sum == total)
            {
                break;
            }
        }
        Debug.Log("Quantity of words: " + sum);

        int octavesSum = octavesArr.Sum();
        Debug.Log("octaves Sum: " + octavesSum);

        int octavesAverage = (octavesSum / sum);
        Debug.Log("OctavesAverage: " + octavesAverage);

        octaves = octavesAverage;
        return octaves;
    }

    public float persistanceCalculation(string name, float persistance)
    {
        int total = 0;

        if(name.Contains("small"))
        {
            persistancesArr.Add(0.635f);
            total++;
        }
        if(name.Contains("medium"))
        {
            persistancesArr.Add(0.446f);
            total++;
        }
        if(name.Contains("large"))
        {
            persistancesArr.Add(0.5f);
            total++;
        }
        if (name.Contains("openworld"))
        {
            persistancesArr.Add(0.5f);
            total++;
        }
        if (name.Contains("rpg"))
        {
            persistancesArr.Add(0.5f);
            total++;
        }
        if (name.Contains("flat"))
        {
            persistancesArr.Add(0.976f);
            total++;
        }
        if (name.Contains("hills"))
        {
            persistancesArr.Add(0.066f);
            total++;
        }
        else
        {
            persistancesArr.Add(0.5f);
            total++;
        }
        Debug.Log(persistancesArr);

        int sum = 0;
        for (int i = 0; i <= total; i++)
        {
            sum++;

            if(sum == total)
            {
                break;
            }
        }
        Debug.Log("Quantity of words: " + sum);

        float persistancesSum = persistancesArr.Sum();
        Debug.Log("persistances Sum: " + persistancesSum);

        float persistanceAverage = (persistancesSum / sum);
        Debug.Log("Persistance Average" + persistanceAverage);

        persistance = persistanceAverage;
        return persistance;
    }

    public float lacunarityCalculation(string name, float lacunarity)
    {
        int total = 0;

        if(name.Contains("small"))
        {
            lacunarityArr.Add(2);
            total++;
        }
        if(name.Contains("medium"))
        {
            lacunarityArr.Add(2);
            total++;
        }
        if(name.Contains("large"))
        {
            lacunarityArr.Add(1);
            total++;
        }
        if (name.Contains("openworld"))
        {
            lacunarityArr.Add(2);
            total++;
        }
        if (name.Contains("rpg"))
        {
            lacunarityArr.Add(0.5f);
            total++;
        }
        if (name.Contains("flat"))
        {
            lacunarityArr.Add(2f);
            total++;
        }
        if (name.Contains("hills"))
        {
            lacunarityArr.Add(2f);
            total++;
        }
        else
        {
            lacunarityArr.Add(2);
            total++;
        }
        Debug.Log(lacunarityArr);

        int sum = 0;
        for (int i = 0; i <= total; i++)
        {
            sum++;

            if(sum == total)
            {
                break;
            }
        }
        Debug.Log("Quantity of words: " + sum);

        float lacunaritySum = lacunarityArr.Sum();
        Debug.Log("Lacunarity Sum: " + lacunaritySum);

        float lacunarityAverage = (lacunaritySum / sum);
        Debug.Log("Lacunarity Average" + lacunarityAverage);

        lacunarity = lacunarityAverage;
        return lacunarity;
    }

    public void Awake()
    {
        if (scene2 == null)
        {
            scene2 = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        string map_name = Scene1.scene1.map_name;

        MapGenerator.noiseScale = noiseScaleCalculation(map_name, MapGenerator.noiseScale);
        MapGenerator.octaves = octavesCalculation(map_name, MapGenerator.octaves);
        MapGenerator.persistance = persistanceCalculation(map_name, MapGenerator.persistance);
        MapGenerator.lacunarity = lacunarityCalculation(map_name, MapGenerator.lacunarity);

        Debug.Log("noiseScale: " + MapGenerator.noiseScale);
        Debug.Log("Octaves: " + MapGenerator.octaves);
        Debug.Log("Persistance: " + MapGenerator.persistance);
        Debug.Log("Lacunarity: " + MapGenerator.lacunarity);

        Debug.Log("Initializing the world..");

        display_map_name.text = Scene1.scene1.map_name;
        display_seed_name.text = Scene1.scene1.seed_name;

        System.Random rnd = new System.Random();

        int offsetX = rnd.Next(500);
        int offsetY = rnd.Next(500);
        MapGenerator.offset.x = offsetX;
        MapGenerator.offset.y = offsetY;

        int seed_name_int = int.Parse(Scene1.scene1.seed_name);
        MapGenerator.seed = seed_name_int;
        Debug.Log("mapGenerator.seed: " + MapGenerator.seed);

        float meshHeight = MapGenerator.meshHeightMultiplier;
        int randomPositionX = (int)UnityEngine.Random.Range(0, meshHeight);
        int randomPositionY = (int)UnityEngine.Random.Range(0, 100);

        /*
        // new terrain
        // insert those new commands to newMapData
        MapDisplay newDisplay = FindObjectOfType<MapDisplay>();

        // checks map name for suitable region color
        regionColor(map_name);

		newMapData = GenerateMapData(Vector2.zero);
        Debug.Log("NewMapData: " + newMapData);

		// newDisplay.DrawMesh (MeshGenerator.GenerateTerrainMesh (newMapData.heightMap, mapGenerator.meshHeightMultiplier, mapGenerator.meshHeightCurve, mapGenerator.editorPreviewLOD), TextureGenerator.TextureFromColourMap (newMapData.colourMap, mapGenerator.mapChunkSize, mapGenerator.mapChunkSize));
		newDisplay.DrawMesh (MeshGenerator.GenerateTerrainMesh (newMapData.heightMap, mapGenerator.meshHeightMultiplier, mapGenerator.meshHeightCurve, mapGenerator.editorPreviewLOD), TextureGenerator.TextureFromColourMap (newMapData.colourMap, newMapChunkSize, newMapChunkSize));
        */

        /*
        TerrainType newTerrain = new TerrainType();
        newTerrain.name = "ground";
        newTerrain.height = 0.70f;
        newTerrain.colour = new Color(120f, 256f, 256f);
        */

        // IMPORTANT: build comparison over here with all terraintypes!
        // we need to figure it out mathematically on measuring the height properly with this one.

        // newDisplay.DrawMesh(MeshGenerator.GenerateTerrainMesh(newMapData.heightMap, MapGenerator.meshHeightMultiplier, MapGenerator.meshHeightCurve, MapGenerator.editorPreviewLOD), TextureGenerator.TextureFromColourMap(newMapData.colourMap, MapGenerator.mapChunkSize, MapGenerator.mapChunkSize));

        // -----------------------------------------------------------
        /*
         * IMPORTANT: Replace color mesh over here!
         */
        // STARTED
        // Generate new terrain type for it to be rendered through MapData and MapDisplay when loading the map
        // 1/ Create new terrain type
        /*
        TerrainType[] newRegions;
        TerrainType newTerrain = new TerrainType();
        newTerrain.name = "ground";
        newTerrain.height = 0.50f;
        newTerrain.colour = new Color(256f, 256f, 256f);

        // FOCUS ON REDNERING THE MAP DATA WITH THE TERRAIN LINKED TOGETHER
        // ALSO MAKE SURE THAT THE NEWTERRAIN TYPE IS ADDED TO NEWREGIONS ARRAY FOR IT TO BE SEEN
        // Renders the map from the Map Data 
        MapData newMapData = new MapData();
        MapDisplay newDisplay = new MapDisplay();
        newDisplay.DrawMesh(MeshGenerator.GenerateTerrainMesh(newMapData.heightMap, MapGenerator.meshHeightMultiplier, MapGenerator.meshHeightCurve, MapGenerator.editorPreviewLOD), TextureGenerator.TextureFromColourMap(newMapData.colourMap, MapGenerator.mapChunkSize, MapGenerator.mapChunkSize));
        */
        // -----------------------------------------------------------

        position = new Vector3(randomPositionX, randomPositionY, 0);
        Instantiate(FPSController, position, Quaternion.identity);

        // Vector3 newPlayerPosition = new Vector3(UnityEngine.Random.Range(randomPositionX, -randomPositionX), 1, UnityEngine.Random.Range(randomPositionY, -randomPositionY));
        // Here's the YouTube tutorial to fill Vector3 position 
        // https://www.youtube.com/watch?v=WGn1zvLSndk 
        // FPSController.transform.position = 0;

    }

}
