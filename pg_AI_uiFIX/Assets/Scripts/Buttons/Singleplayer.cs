using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Singleplayer : MonoBehaviour
{
    public void singlePlayer()
    {
        Debug.Log("Loading single player...");
        SceneManager.LoadScene("Scene1");
    }   
}
