using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> SpawnPrefab;
    public List<GameObject> EnemyPrefab;
    public GameObject GameOverCanvas;
    public TMP_Text TimeLimitLabel;
    public float TimeLimit = 60;

    public GameObject CinemachineInstance;


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

    private static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
    }

    public void Awake()
    {
        instance = this;
    }

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
        TimeLimit -= Time.deltaTime;
        TimeLimitLabel.text = "Time: " + ((int)TimeLimit);

        if(TimeLimit <0 )
        {
            GameOver();
        }



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

    public void GameOver()
    {
        CinemachineInstance.SetActive(false);
        GameOverCanvas.SetActive(true);
    }

    public void GameClear()
    {
        CinemachineInstance.SetActive(false);
        GameOverCanvas.SetActive(true);

    }
}
