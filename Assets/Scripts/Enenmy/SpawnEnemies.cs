using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public int enemyCount;
    public GameObject enemy;

    public PentOfSummon pent;
    bool someTrouble;

    private void Start()
    {
      
    }

    public void RandomSpawn()
    {
        enemyCount = Random.Range(8, 15);

        for(int i = 0; i < enemyCount; i++)
        {
            Instantiate(enemy, new Vector3(Random.Range(transform.position.x - 10, transform.position.x + 10), Random.Range(transform.position.y - 10, transform.position.y + 10), 0), Quaternion.identity);
        }
        someTrouble = true;
    }

    private void Update()
    {
        if(enemyCount <= 0 && someTrouble)
        {
            pent.AllBe();
            someTrouble=false;
        }
    }
}
