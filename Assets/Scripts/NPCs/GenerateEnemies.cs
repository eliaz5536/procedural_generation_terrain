using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos;
    public int yPos;
    public int zPos;
    public int enemyCount;

    void Start()
    {
        StartCoroutine(EnemyDrop());
    }

    IEnumerator EnemyDrop()
    {
        while (enemyCount < 5)
        {

            xPos = Random.Range(1, 29);
            // yPos = Random.Range(1, 29);
            zPos = Random.Range(1, 29);
            Instantiate(theEnemy, new Vector3(xPos, 1, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
    }
}
