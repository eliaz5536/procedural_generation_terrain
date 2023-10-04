using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Scene1 : MonoBehaviour
{
    public static Scene1 scene1;
    public static Scene2 scene2;
    public TMP_InputField worldField;
    public TMP_InputField seedField;
    public TMP_InputField inputField;

    public string world_name;
    public string map_name;
    public string seed_name;

    private void Awake()
    {
        if(scene1 == null)
        {
            scene1 = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetLevelName()
    {
        System.Random rnd = new System.Random();

        world_name = inputField.text;
        map_name = inputField.text;
        seed_name = seedField.text;

        if(map_name.Length == 0)
        {
            if(seed_name.Length == 0)
            {
                int seedNumber = rnd.Next(999999999);
                Debug.Log("Generating random level...");
                Debug.Log("Seed number: " + seedNumber);

                seed_name = seedNumber.ToString();
                int seed_number = int.Parse(seed_name);

                Debug.Log(seed_number);
                Debug.Log("Seed number (After parsing): " + seed_number);
            }
            else
            {
                Debug.Log("Seed number: " + seed_name);
                Debug.Log("World name: " + world_name);
                Debug.Log("Map name: " + map_name);

                int seed_number = int.Parse(seed_name);
                Debug.Log(seed_number);
                Debug.Log("Seed number (After parsing): " + seed_number);

            }
        }
        else
        {
            if(seed_name.Length == 0)
            {
                int seedNumber = rnd.Next(999999999);
                Debug.Log("Generating random level...");
                Debug.Log("Seed number: " + seedNumber);

            }
            else
            {
                map_name = map_name.ToLower();
                Debug.Log("Map name (lower case): " + map_name);

                int seed_number = int.Parse(seed_name);
                Debug.Log("Map name: " + map_name);
                Debug.Log("World name: " + world_name);
                Debug.Log("Seed number: " + seed_number);
            }
        }
    }

}
