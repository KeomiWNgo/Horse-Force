using System.Reflection.Metadata.Ecma335;
using UnityEngine;

public class AttackButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    #region Events


    #endregion


    public SwipeDetection swipeDetection;
    public Board board;
    public Projectile ProjPrefab;
    private int atkTotal;
    private int cooldown;


    public int coolThresh;

    private void Awake()
    {
      
        board = FindAnyObjectByType<Board>();
        cooldown = 0;


    }

    private void OnEnable()
    {
        swipeDetection.EAtkButton += Atk;
        swipeDetection.ECoolDown += CoolDown;
    }

    private void Atk() 
    {


        if (cooldown >= coolThresh)
        {

            atkTotal = 0;
            /* for (int i = 0; i < board.tiles.Count; i++)
             {
              atkTotal = atkTotal +board.tiles[i].number;

             }*/
            atkTotal = board.ScoreCalc();

            Debug.Log(atkTotal);

            board.ClearBoard();
            board.CreateTile();
            Projectile proj = Instantiate(ProjPrefab, transform);
            proj.SetDamage(atkTotal);
            cooldown = 0;
        }
    }

    private int CoolDown() {

        return cooldown++;
    
    
    }

    
  
}

