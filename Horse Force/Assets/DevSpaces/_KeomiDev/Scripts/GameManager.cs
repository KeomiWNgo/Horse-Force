using System;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
  
    private Board board;

    private int endScore;

    private AttackButton AtkButton;
    

    /// <summary>
    ///Finds reference to the game board and the attack button
    /// </summary>
    private void Awake()
    {
     AtkButton =  FindAnyObjectByType<AttackButton>();
     board =   FindAnyObjectByType<Board>();
    }

    /// <summary>
    /// Subscribes to the events in game board and attack button
    /// </summary>
    private void OnEnable()
    {
        board.EAdd2Score += Add2Score;
        AtkButton.EUpdateScore += DisplayScore;

    }

    /// <summary>
    /// Unsubscribes incase something happens
    /// </summary>
    private void OnDisable()
    {
        board.EAdd2Score -= Add2Score;
        AtkButton.EUpdateScore -= DisplayScore;
    }
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




}
