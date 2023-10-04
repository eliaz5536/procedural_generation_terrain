using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class inputCheck : MonoBehaviour
{
    public static Scene1 scene1;
    public static Scene2 scene2;
    public TMP_InputField inputField;
    public TMP_InputField seedField;

    public string map_name;
    public string seed_name;

    public void processLevelName()
    {
        System.Random rnd = new System.Random();

        map_name = inputField.text;
        seed_name = seedField.text;

        // Insert processing code for processing seed over here!

    }

}
