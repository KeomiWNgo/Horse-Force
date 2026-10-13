using System;
using UnityEngine;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
  
    private Board board;

    private int endScore;

    private AttackButton AtkButton;
    


    private void Awake()
    {
     AtkButton =  FindAnyObjectByType<AttackButton>();
     board =   FindAnyObjectByType<Board>();
    }


    private void OnEnable()
    {
        board.EAdd2Score += Add2Score;
        AtkButton.EUpdateScore += DisplayScore;

    }
    private void OnDisable()
    {
        board.EAdd2Score -= Add2Score;
        AtkButton.EUpdateScore -= DisplayScore;
    }

    private void Add2Score(int Calc) 
    {

        endScore = endScore + Calc;
    
    }

    private void DisplayScore() 
    {
        Debug.Log("Score update =" + endScore);
    
    
    
    }




}
