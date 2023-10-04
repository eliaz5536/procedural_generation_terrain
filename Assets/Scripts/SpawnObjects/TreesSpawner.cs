using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreesSpawner : MonoBehaviour
{
    public GameObject[] natureElements;
    public GameObject[] sandElements;
    public GameObject[] grassElements;

    int xPos;
    int yPos;
    int zPos;
    int xRot;
    int objectCount;

    public Transform player;

    void Start()
    {
        StartCoroutine(objectDrop());
    }

    IEnumerator objectDrop()
    {
        // GameObject sandSpawn = sandElements[Random.Range(0, sandElements.Length)];
        // GameObject grassSpawn = grassElements[Random.Range(0, grassElements.Length)];

        while (objectCount < 50)
        {
            GameObject natureSpawn = natureElements[Random.Range(0, natureElements.Length)];

            xPos = Random.Range(1, 70);
            zPos = Random.Range(1, 70);
            Instantiate(natureSpawn, new Vector3(player.transform.position.x + xPos, 1, player.transform.position.z + zPos), Quaternion.Euler(0, Random.Range(0, 4) * 90, 0));
            // Instantiate(sandSpawn, new Vector3(player.transform.position.x + xPos, 1, player.transform.position.z + zPos), Quaternion.Euler(0, Random.Range(0, 4) * 90, 0));
            // Instantiate(grassSpawn, new Vector3(player.transform.position.x + xPos, 1, player.transform.position.z + zPos), Quaternion.Euler(0, Random.Range(0, 4) * 90, 0));
            yield return new WaitForSeconds(0.025f);
            // objectCount += 1;
            objectCount++;
            // objectCount = 0;
        }
    }

}
