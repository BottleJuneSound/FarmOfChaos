using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> SpawnPrefab;
    public List<GameObject> EnemyPrefab;


    //public GameObject foodPrefab;
    //public GameObject weaponPrefab;
    //public GameObject enemyPrefab;
    //public float foodSpawnTerm = 8;
    //public float weaponSpawnTerm = 2;
    public float spawnTerm = 5;
    public float insideSpawnTerm = 8;
    public float enemySpawnTerm = 3;


    float spawnTimer;
    float enemySpawnTimer;
    float insideSpawnTimer;

    void Start()
    {
        //List<GameObject> SpawnPrefab = new List<GameObject>();

        //SpawnPrefab.Add(foodPrefab);
        //SpawnPrefab.Add(weaponPrefab);
        //SpawnPrefab.Add(enemyPrefab);



        spawnTimer = 0;
        insideSpawnTimer = 0;
        enemySpawnTimer = 0;
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        insideSpawnTimer += Time.deltaTime;
        enemySpawnTimer += Time.deltaTime;


        if (spawnTimer > spawnTerm)
        {
            spawnTimer -= spawnTerm;

            int randomListIndex = Random.Range(0, SpawnPrefab.Count);
            GameObject spawnObj = Instantiate(SpawnPrefab[randomListIndex]);
            spawnObj.transform.position = new Vector2(Random.Range(-2, 2), Random.Range(-6, -12));

        }

        if (insideSpawnTimer > insideSpawnTerm)
        {
            insideSpawnTimer -= insideSpawnTerm;

            GameObject spawnObj = Instantiate(SpawnPrefab[1]);
            spawnObj.transform.position = new Vector2(Random.Range(-2, 2), Random.Range(-4, -2.25f));

        }



        if (enemySpawnTimer > enemySpawnTerm)
        {
            enemySpawnTimer -= enemySpawnTerm;

            int randomListIndex = Random.Range(0, EnemyPrefab.Count);
            GameObject spawnObj = Instantiate(EnemyPrefab[randomListIndex]);
            spawnObj.transform.position = new Vector2(Random.Range(-8, 6.8f), Random.Range(-9, -12));
        }

    }
}
