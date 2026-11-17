using NUnit.Framework;
//using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


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
    public TextMeshProUGUI waveCounter;
    public TextMeshProUGUI enemiesRemainingText;
    private int enemiesRemaining;

    public GameObject[] enemyPrefabs;
    public GameObject bossPrefab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 3f;

    private int currentWave = 1;
    private int enemiesPerWave = 5;

    //keeps track of current enemy spawned
    private GameObject currentEnemy;

    //tracks if current enemy still allive and kickin, prevents next from spawning until certain current is defeated
    private bool waitingForEnemyDeath = false;

    //storing reference so it can be managed or stopped, keepin tracj of sequence
    private Coroutine waveCoroutine;
    private void Start()
    {
        NewGame();
    }

    //updates the enemy counter ui/hud, displays number of enemies remaining in the current wave
    void UpdateEnemiesRemaining()
    {
        //checks that has been assigned
        if (enemiesRemainingText != null)
        {
            //updates displayed text
            enemiesRemainingText.text = "Enemies Remaining: " + enemiesRemaining;
        }
    }

    //updates wave counter ui/hud, displays the current wave number
    void UpdateWaveCounter()
    {
        //checks that has been assigned
        if(waveCounter != null)
        {
            //updates displayed text
            waveCounter.text = "Wave " + currentWave;
        }
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
            UpdateWaveCounter();

            enemiesRemaining = 5;
            UpdateEnemiesRemaining();

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
                    yield break;//stop entirely if fail to spawn
                }

                //wait until the spawned enemy dies
                while (waitingForEnemyDeath)
                {
                    yield return null;//pauses coroutine until next frame so the game can keep running while we wait for it to die. helps if anim.
                }
            }
            Debug.Log("Wave " + currentWave + " Complete!");

            //next wave!
            currentWave++;

            //waiting until the next wave so that they dont happen so fast back to back bc could be overwhelmin IMO
            yield return new WaitForSeconds(timeBetweenWaves);


        }
        
        //BOSSSSS WAVEEEEE OOOOOO NEIGHHHHH RAHJRAH
        enemiesRemaining = 1;
        UpdateEnemiesRemaining();
        UpdateWaveCounter();
       
        //if the boss cant spawn, stop the wave sequence
        Debug.Log("BOSS WAVE!");
        if (!SpawnEnemy(bossPrefab))
        {
            yield break;
        }

        //waitforittodie
        //(wait until boss has been defeated before continuing)
        while (waitingForEnemyDeath)
        {
            yield return null;
        }

        //display message in console so we know it was actually defeated
        Debug.Log("BOSS DEFEATED!");
        //set coroutine ref to null bc the wave sequence is done/finished
        waveCoroutine = null;
    }

    //Spawnin of the enemy
    /// <summary>
    /// spawns an enemy prefab at designated spawn point and initializes its behavour script so it can communicated w game manager
    /// </summary>
    /// <param name="enemyPrefab">The enemy prefab that will be spawned</param>
    /// <returns>Returns true if the enemy spawns successfully or false if a required ref is missing!</returns>
    bool SpawnEnemy(GameObject enemyPrefab)
    {
        //makin sure things are spick and span (checks that required refs are assigned correctly)
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

        //checks if enemy prefab has the EnemyBehaviour script component, simple but critical!
        EnemyBehaviour enemyScript = enemyPrefab.GetComponent<EnemyBehaviour>();
        if (enemyScript == null)
        {
            Debug.LogError("Enemy prefab needs EnemyBehaviour!");
            return false;
        }

        //instantiate/spawn in the enemy! creates instance of selected prefab at designated spawn point
        currentEnemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        //gets the script component from spawned enemy
        EnemyBehaviour enemy = currentEnemy.GetComponent<EnemyBehaviour>();
        //initializes the enemy and gives it a ref to THIS GameManager
        //allows enemy to notify the manager when defeated
        enemy.Initialize(this);

        //NEXT ENEMY cannot spawn until this is false, which happens in EnemyDefeated
        waitingForEnemyDeath = true;
        Debug.Log("Enemy Spawned!");

        return true;
    }

    //ENEMY DEATH NOTIF!
    /// <summary>
    /// called by EnemyBehaviour when enemy health reaches 0
    /// keeping track of defeated enemies and allowing next 2 spawn
    /// </summary>
    /// <param name="enemy"></param>
    public void EnemyDefeated(GameObject enemy)
    {
        if (enemy == currentEnemy)
        {
            Debug.Log("Enemy Defeated!");

            //stes to false so the coroutine knows it can now spawn the next enemy
            waitingForEnemyDeath= false;
            enemiesRemaining--;
            UpdateEnemiesRemaining();
            //clears reference to defeated enemy
            currentEnemy = null;

            Debug.Log("Enemies Remaining: " + enemiesRemaining);
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
