using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<GameObject> SpawnPrefab;
    public List<GameObject> EnemyPrefab;
    public GameObject GameOverCanvas;
    public TMP_Text TimeLimitLabel;
    public TMP_Text TimeCountDown;
    public TMP_Text TitlePanel;


    public float TimeLimit = 60;
    public GameObject CountDownCanvas;
    public GameObject HalfTimeAlarm;
    public GameObject CinemachineInstance;
    public GameObject StartCanvas;


    //public GameObject foodPrefab;
    //public GameObject weaponPrefab;
    //public GameObject enemyPrefab;
    //public float foodSpawnTerm = 8;
    //public float weaponSpawnTerm = 2;
    public float spawnTerm = 5;
    public float insideSpawnTerm = 8;
    public float enemySpawnTerm = 3;
    private bool hasPlayingCountDownSFX = false;
    private bool hasPlayingClockSFX = false;



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

        TimeLimit = 60;
        HalfTimeAlarm.SetActive(false);
        hasPlayingCountDownSFX = false;
        hasPlayingClockSFX = false;
        //SoundManager.Instance.StopSound(3);


    }


    void Start()
    {
        SoundManager.Instance.BGMPlayer();

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
        TimeCountDown.text = "" + ((int)TimeLimit);


        if (TimeLimit < 10)
        {
            CountDownCanvas.SetActive(true);

            if (!hasPlayingCountDownSFX)
            {
                SoundManager.Instance.CountDownSFX();
                hasPlayingCountDownSFX = true;
            }

            if (TimeLimit < 0)
            {
                SoundManager.Instance.CountDownSFX();
                SoundManager.Instance.StopSound(2);
                CountDownCanvas.SetActive(false);
                hasPlayingCountDownSFX = false;
                GameOver();
            }
        }

        if (TimeLimit < 30)
        {
            HalfTimeAlarm.SetActive(true);
            if (!hasPlayingClockSFX)
            {
                SoundManager.Instance.ClockSFX();
                hasPlayingClockSFX = true;

            }

            if (TimeLimit < 25)
            {
                HalfTimeAlarm.SetActive(false);
                hasPlayingClockSFX = false;
                SoundManager.Instance.StopSound(3);

            }
        }


        if (TimeLimit < 59)
        {
            StartCanvas.SetActive(false);
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
        TitlePanel.text = ("GameOver" + "");
        CinemachineInstance.SetActive(false);
        GameOverCanvas.SetActive(true);
    }

    public void GameClear()
    {
        TitlePanel.text = ("Clear!" + "");
        CinemachineInstance.SetActive(false);
        GameOverCanvas.SetActive(true);

    }

    public void AgainPressed()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");

    }

    public void QuitPressed()
    {
        SceneManager.LoadScene("GameStartScene");
    }

    //public void ClockSFXPlay()
    //{
    //    SoundManager.Instance.ClockSFX();
    //}

    //public void CountDownSFXPlay()
    //{
    //    SoundManager.Instance.CountDownSFX();
    //}

}
