using System.Reflection.Metadata.Ecma335;
using UnityEngine;

public class AttackButton : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    #region Events
    public delegate void updatescore();
    public event updatescore EUpdateScore;

    #endregion


    private SwipeDetection swipeDetection;
    public Board board;
    public Projectile ProjPrefab;
    public Health health;
    private int atkTotal;
    private int cooldown;
    public int healAmount;
    public int coolThresh;

    private void Awake()
    {
        swipeDetection = FindAnyObjectByType<SwipeDetection>();
        board = FindAnyObjectByType<Board>();
        cooldown = 0;
    }

    public int GetCooldown() 
    {


        return cooldown;
    
    }

    /// <summary>
    /// subscribes to events from swipe detection
    /// </summary>
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
            healAmount = atkTotal / 4;

            Debug.Log(atkTotal);

            board.ClearBoard();
            board.CreateTile();
            Projectile proj = Instantiate(ProjPrefab, transform);
            proj.SetDamage(atkTotal);
            health.currhealth += healAmount; // Heal health according to damage dealt
            cooldown = 0;
        }
        EUpdateScore();
    }


    private int CoolDown() {

        return cooldown++;
    
    
    }

   
  
}

