using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateNPC : MonoBehaviour
{
    // public GameObject theNPC;
    public GameObject[] npcElements;
    public int xPos;
    public int yPos;
    public int zPos;
    public int NPCCount;

    public Transform player;

    void Start()
    {
        StartCoroutine(NPCDrop());
    }

    IEnumerator NPCDrop()
    {

        while (NPCCount < 50)
        {
            GameObject npcSpawn = npcElements[Random.Range(0, npcElements.Length)];

            xPos = Random.Range(1, 29);
            // yPos = Random.Range(1, 29);
            zPos = Random.Range(1, 29);
            // Instantiate(npcSpawn, new Vector3(xPos, 1, zPos), Quaternion.identity);
            Instantiate(npcSpawn, new Vector3(player.transform.position.x + xPos, 1, player.transform.position.z + zPos), Quaternion.Euler(0, Random.Range(0, 4) * 90, 0));
            // yield return new WaitForSeconds(0.1f);
            yield return new WaitForSeconds(0.025f);
            NPCCount += 1;
        }
    }
}
