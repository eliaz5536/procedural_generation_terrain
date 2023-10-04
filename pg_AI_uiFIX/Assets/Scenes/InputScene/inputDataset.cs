using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class inputDataset : MonoBehaviour
{
    public MapGenerator MapGenerator;

    List<float> noiseScaleArr = new List<float> { };
    List<int> octavesArr = new List<int> { };
    List<float> persistancesArr = new List<float> { };
    List<float> lacunarityArr = new List<float> { };

    public float noiseScaleCalculation(string name, float noiseScale)
    {
        if (name.Contains("openworld"))
        {
            noiseScaleArr.Add(48.68f);
        }

        if (name.Contains("rpg"))
        {
            noiseScaleArr.Add(0.5f);
        }

        if (name.Contains("flat"))
        {
            noiseScaleArr.Add(48.68f);
        }

        if (name.Contains("hills"))
        {
            noiseScaleArr.Add(48.68f);
        }

        Debug.Log("noiseScaleArr: " + noiseScaleArr);

        int total = 0;
        int sum = 0;

        for (int i = 0; i <= total; i++)
        {
            sum = total++;
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
        if (name.Contains("openworld"))
        {
            octavesArr.Add(8);
        }

        if (name.Contains("rpg"))
        {
            octavesArr.Add(1);
        }

        if (name.Contains("flat"))
        {
            octavesArr.Add(8);
        }

        if (name.Contains("hills"))
        {
            octavesArr.Add(8);
        }
        Debug.Log(octavesArr);

        int total = 0;
        int sum = 0;
        for (int i = 0; i <= total; i++)
        {
            sum = total++;
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
        if (name.Contains("openworld"))
        {
            persistancesArr.Add(0.5f);
        }

        if (name.Contains("rpg"))
        {
            persistancesArr.Add(0.5f);
        }

        if (name.Contains("flat"))
        {
            persistancesArr.Add(0.976f);
        }

        if (name.Contains("hills"))
        {
            persistancesArr.Add(0.066f);
        }
        Debug.Log(persistancesArr);

        int total = 0;
        int sum = 0;
        for (int i = 0; i <= total; i++)
        {
            sum = total++;
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
        if (name.Contains("openworld"))
        {
            lacunarityArr.Add(2);
        }

        if (name.Contains("rpg"))
        {
            lacunarityArr.Add(0.5f);
        }

        if (name.Contains("flat"))
        {
            lacunarityArr.Add(2f);
        }

        if (name.Contains("hills"))
        {
            lacunarityArr.Add(2f);
        }
        Debug.Log(lacunarityArr);
        
        int total = 0;
        int sum = 0;
        for (int i = 0; i <= total; i++)
        {
            sum = total++;
        }
        Debug.Log("Quantity of words: " + sum);

        float lacunaritySum = lacunarityArr.Sum();
        Debug.Log("Lacunarity Sum: " + lacunaritySum);

        float lacunarityAverage = (lacunaritySum / sum);
        Debug.Log("Lacunarity Average" + lacunarityAverage);

        lacunarity = lacunarityAverage;
        return lacunarity;
    }

}
