using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{

    

    #region Vars

    private Health playerHealth;
    private Board board;

    private int endScore;

    public int highScore;


    private AttackButton atkButton;

    private Health[] objsWHealth;

    private DataSaverJSON datasaver;

    #endregion

    private void Start()
    {
        NewGame();
    }



    public void NewGame()
    {
        board.ClearBoard();

        board.CreateTile();
        board.CreateTile();
        atkButton.enabled = true;
        board.enabled = true;
    }

    public void GameOver()
    {

        if (endScore > highScore)
        {
            highScore = endScore;
        }

        datasaver.SaveData();
        
        Debug.Log("this does in deed fire");
        //  board.enabled = false;
        // atkButton.enabled = false;
        SceneManager.LoadScene(10);


    }


    /// <summary>
    ///Finds reference to the game board and the attack button
    /// </summary>
    private void Awake()
    {

        datasaver = FindAnyObjectByType<DataSaverJSON>();

        datasaver.LoadData();

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

}
