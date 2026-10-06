using UnityEngine;

public class GameManager : MonoBehaviour
{
  
    private Board board;

    private int endScore;

    
    


    private void Awake()
    {
        FindAnyObjectByType<AttackButton>();
        FindAnyObjectByType<Board>();
    }


    private void OnEnable()
    {
        board.EAdd2Score += Add2Score;
        

    }

    private void Add2Score(int Calc) 
    { 
    


            
    
    
    }



}
