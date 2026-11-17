using NUnit.Framework;
//using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    

    #region Vars

    private Health playerHealth;
    private Board board;

    private int endScore ;

    public int highScore;


    private AttackButton atkButton;

    public Health[] objsWHealth;

    // private DataSaverJSON datasaver;

    #endregion

    //wavesystem vars
    public GameObject[] enemyPrefabs;
    public GameObject bossPrefab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 3f;

    private int currentWave = 1;
    private int enemiesPerWave = 5;

    private GameObject currentEnemy;

    private bool waitingForEnemyDeath = false;

    private Coroutine waveCoroutine;
    private void Start()
    {
        NewGame();
    }



    public void NewGame()
    {
        board.ClearBoard();

        highScore = PlayerPrefs.GetInt("HighScore");


        board.CreateTile();
        board.CreateTile();
        atkButton.enabled = true;
        board.enabled = true;

        StartWaveSystem();
    }

    public void StartWaveSystem()
    {
        if (waveCoroutine != null)
        {
            StopCoroutine(waveCoroutine);
        }

        currentWave = 1;
        currentEnemy = null;
        waitingForEnemyDeath =false;

        waveCoroutine = StartCoroutine(WaveSequence());
    }

    IEnumerator WaveSequence()
    {
        //waves 1-4
        while (currentWave <= 4)
        {
            Debug.Log("Starting Wave " + currentWave);
            //5enemies in each wave
            for (int i = 0; i < enemiesPerWave; i++)
            {
                if(enemyPrefabs == null || enemyPrefabs.Length == 0)
                {
                    Debug.LogError("No enemy prefabs assigned!");
                    yield break;
                }

                GameObject enemyPrefab = enemyPrefabs[
                    Random.Range(0, enemyPrefabs.Length)
                    ];

                //spawning enemy
                if (!SpawnEnemy(enemyPrefab))
                {
                    yield break;
                }

                //wait until the spawned enemy dies
                while (waitingForEnemyDeath)
                {
                    yield return null;
                }
            }
            Debug.Log("Wave " + currentWave + " Complete!");

            //next wave!
            currentWave++;

            //waiting until the next wave so that they dont happen so fast back to back bc could be overwhelmin IMO
            yield return new WaitForSeconds(timeBetweenWaves);


        }

        //BOSSSSS WAVEEEEE OOOOOO NEIGHHHHH
        Debug.Log("BOSS WAVE!");
        if (!SpawnEnemy(bossPrefab))
        {
            yield break;
        }

        //waitforittodie
        while (waitingForEnemyDeath)
        {
            yield return null;
        }

        Debug.Log("BOSS DEFEATED!");
        waveCoroutine = null;
    }

    //Spawnin of the enemy
    bool SpawnEnemy(GameObject enemyPrefab)
    {
        //makin sure things are spick and span (making sure things are assigned correctly)
        if(enemyPrefab == null)
        {
            Debug.LogError("Enemy prefab is missing!");
            return false;
        }
        if(spawnPoint == null)
        {
            Debug.LogError("Spawn Point is missing!");
            return false;
        }

        EnemyBehaviour enemyScript =
            enemyPrefab.GetComponent<EnemyBehaviour>();
        if (enemyScript != null)
        {
            Debug.LogError("Enemy prefab needs EnemyBehaviour!");
            return false;
        }

        //instantiate/spawn in the enemy!
        currentEnemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        EnemyBehaviour enemy = currentEnemy.GetComponent<EnemyBehaviour>();
        enemy.Initialize(this);

        waitingForEnemyDeath = true;
        Debug.Log("Enemy Spawned!");

        return true;
    }

    //ENEMY DEATH NOTIF
    public void EnemyDefeated(GameObject enemy)
    {
        if (enemy == currentEnemy)
        {
            Debug.Log("Enemy Defeated!");
            waitingForEnemyDeath= false;
            currentEnemy = null;
        }
    }


    public void GameOver()
    {

        if (endScore > highScore)
        {
            highScore = endScore;
        }

        PlayerPrefs.SetInt("Highscore", highScore);


    //  datasaver.SaveData();
        
        Debug.Log("this does in deed fire");
//          board.enabled = false;
        // atkButton.enabled = false;
        SceneManager.LoadScene(10);


    }


    /// <summary>
    ///Finds reference to the game board and the attack button
    /// </summary>
    private void Awake()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }



        if (highScore == -1) {

        //    datasaver.SaveData();
        }


       // datasaver = FindAnyObjectByType<DataSaverJSON>();


        atkButton = FindAnyObjectByType<AttackButton>();

        board = FindAnyObjectByType<Board>();

        objsWHealth = FindObjectsByType<Health>();

        for (int i = 0; i < objsWHealth.Length; i++)
        {
            if (objsWHealth[i].gameObject.CompareTag("Player"))
            {
                playerHealth = objsWHealth[i];
            }
        }

    }


    #region EvenEn/Dis
    /// <summary>
    /// Subscribes to the events in game board and attack button
    /// </summary>
    private void OnEnable()
    {
        board.EAdd2Score += Add2Score;
        atkButton.EUpdateScore += DisplayScore;
        playerHealth.EPlayerDied += GameOver;
    }





    /// <summary>
    /// Unsubscribes incase something happens
    /// </summary>
    /// 
    private void OnDisable()
    {
        board.EAdd2Score -= Add2Score;
        atkButton.EUpdateScore -= DisplayScore;
        playerHealth.EPlayerDied -= GameOver;
    }

    #endregion



    /// <summary>
    /// adds the score this is called from the board 
    /// </summary>
    /// <param name="Calc"> Calc is the score that the board tallied and is sending over</param>
    private void Add2Score(int Calc)
    {

        endScore = endScore + Calc;

    }






    /// <summary>
    /// Displays score
    /// </summary>
    private void DisplayScore()
    {
        Debug.Log("Score update =" + endScore);



    }


    public void setHighscore(int newval)
        {
        highScore = newval;
    
    }


    public int getCurrScore() 
    {
        return endScore;
    }

}
