using UnityEngine;
using System.Collections;


public class EnemyBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Health playerHealth; // assign game object inspectoor
    public int damagePerTick = 10;
    public float damageInterval = 3f;
    public int enemyHealth;
    public int enemyMax;
    public int healthMod;
    public int attackMod;
    public Shielding manager;

    private GameManager waveManager;
    private bool isDead = false;

    public void Initialize(GameManager gameManager)
    {
        waveManager = gameManager;
    }

    private void Awake()
    {
        playerHealth = FindAnyObjectByType<Health>();

        enemyMax += healthMod; // Add any additional modifiers
        damagePerTick += attackMod; // Add any additional modifiers
    }





    void Start()
    {
        enemyHealth = enemyMax; // Set Enemy health to maximum possible health
        if (playerHealth != null)
        {
            StartCoroutine(DamageOverTime());
        }
        else
        {
            Debug.LogError("Enemy is missing a reference to the PlayerHealth script!");
        }
    }

    /// <summary>
    /// repeatedly damages the player at set tiem intervals whiel enemy is actiev
    /// </summary>
    /// <returns></returns>
    IEnumerator DamageOverTime()
    {
        // runs while enemy script actirv
        while (true)
        {
            yield return new WaitForSeconds(damageInterval);

            //checks shielding
            if (manager.isShielded == true)
            {
                manager.isShielded = false;
                Debug.Log("Damage Negated!");
            }
            else
            {
                playerHealth.TakeDamage(damagePerTick);
            }
        }
    }

    private void Update()
    {
        if (enemyHealth <= 0 && !isDead)
        {
            // if (enemyHealth < 0) enemyHealth = 0;
            // Destroy(gameObject);
            Die();
        }
    }
    /// <summary>
    /// 
    /// </summary>
    void Die()
    {
        isDead = true;
        enemyHealth = 0;

        //notifying game manager
        if (waveManager != null)
        {
            waveManager.EnemyDefeated(gameObject);
            //clear the health bar when enemy is defeated^^^^VVVV
            waveManager.ClearEnemyHealthBar();
        }

        Destroy(gameObject);
    }
}
