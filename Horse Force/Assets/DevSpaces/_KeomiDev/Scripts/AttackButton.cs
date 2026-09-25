using UnityEngine;

public class AttackButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public SwipeDetection swipeDetection;
    public Board board;
    
    private int atkTotal;

    private void Awake()
    {
      
        board = FindAnyObjectByType<Board>();
    }

    private void OnEnable()
    {
        swipeDetection.EAtkButton += Atk;
    }

    private void Atk() 
    {

        atkTotal = 0;
        for (int i = 0; i < board.tiles.Count; i++)
        {
         atkTotal = atkTotal +board.tiles[i].number;

        }
        Debug.Log(atkTotal);

        board.ClearBoard();
        board.CreateTile();

    }

}
