using UnityEngine;

public class Health : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created



    #region Events

    public delegate void Playerdied();

    public event Playerdied EPlayerDied;

    #endregion

    #region Vars
    [SerializeField]
    public int maxhealth;
    public int currhealth { get;  set; }

    #endregion
    public DamageFlash damageFlash;
    void Start()
    {
        currhealth = maxhealth;

        
    }

    // Update is called once per frame
    void Update()
    {
       
    }




    public void TakeDamage(int damageAmount)
    {
        currhealth -= damageAmount;
        Debug.Log("Player took damage! Current health: " + currhealth);
        if (damageFlash != null )
        {
            damageFlash.TriggerFlash();
        }

        if (currhealth <= 0)
        {
            if (gameObject.CompareTag("Player"))
            {
                EPlayerDied();
            }
        }
    }


}
