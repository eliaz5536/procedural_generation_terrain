using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Scene2 : MonoBehaviour
{
    public MapGenerator MapGenerator;
    public GameObject FPSController;
    // private GameObject randomSpawnPoints;
    private GameObject[] randomSpawnPoints;
    public TextMeshProUGUI display_map_name;
    public TextMeshProUGUI display_seed_name;
    private static Scene1 scene1;
    private static Scene2 scene2;
    public Vector3 spawnValue;
    private Vector3 position;
    public inputDataset inputDataset;

    List<string> arr = new List<string> { };
    List<float> noiseScaleArr = new List<float> { };
    List<int> octavesArr = new List<int> { };
    List<float> persistancesArr = new List<float> { };
    List<float> lacunarityArr = new List<float> { };

    public float noiseScaleCalculation(string name, float noiseScale)
    {
        int total = 0;

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

        // Performing calculation on how to make player spawn randomly without clipping over the mesh.
        // Find the maximum height from the map itself for the player to be spawned randomly.
        // Think of the best solution to spawn rnadomly on the terrain
        // Think how to convert float to int.

        // Spawn random cubes around the map.
        /* 
        GameObject randomSpawnPoints = new GameObject("spawnPoints");
        randomSpawnPoints.hideFlags = HideFlags.HideInHierarchy;
        Instantiate(randomSpawnPoints, new Vector3(0, 0, 0), Quaternion.identity);
        // randomSpawnPoints.SetActive(false);
        */

        // ----

        float meshHeight = MapGenerator.meshHeightMultiplier;
        int randomPositionX = (int)UnityEngine.Random.Range(0, meshHeight);
        int randomPositionY = (int)UnityEngine.Random.Range(0, 100);

        // int randomPositionZ = UnityEngine.Random.Range(0, meshHeight);

        position = new Vector3(randomPositionX, randomPositionY, 0);
        Instantiate(FPSController, position, Quaternion.identity);

        // Vector3 newPlayerPosition = new Vector3(UnityEngine.Random.Range(randomPositionX, -randomPositionX), 1, UnityEngine.Random.Range(randomPositionY, -randomPositionY));
        // Here's the YouTube tutorial to fill Vector3 position 
        // https://www.youtube.com/watch?v=WGn1zvLSndk 
        // FPSController.transform.position = 0;

        // Think of how to create random spawn points!
    }

}
