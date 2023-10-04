using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateNPC : MonoBehaviour
{
    public GameObject theNPC;
    public int xPos;
    public int yPos;
    public int zPos;
    public int NPCCount;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NPCDrop());
    }

    IEnumerator NPCDrop()
    {
        while (NPCCount < 5)
        {
            xPos = Random.Range(1, 29);
            // yPos = Random.Range(1, 29);
            zPos = Random.Range(1, 29);
            Instantiate(theNPC, new Vector3(xPos, 1, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            NPCCount += 1;
        }
    }
}
