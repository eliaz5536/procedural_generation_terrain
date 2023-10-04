using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePassive : MonoBehaviour
{
    public GameObject thePassive;
    public int xPos;
    public int yPos;
    public int zPos;
    public int passiveCount;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PassiveDrop());
    }

    IEnumerator PassiveDrop()
    {
        while (passiveCount < 5)
        {
            xPos = Random.Range(1, 29);
            // yPos = Random.Range(1, 29);
            zPos = Random.Range(1, 29);
            Instantiate(thePassive, new Vector3(xPos, 1, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            passiveCount += 1;
        }
    }
}
