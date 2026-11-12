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

    IEnumerator DamageOverTime()
    {
        // runs while enemy script actirv
        while (true)
        {
            yield return new WaitForSeconds(damageInterval);
            playerHealth.TakeDamage(damagePerTick);
        }
    }

    private void Update()
    {
        if (enemyHealth <= 0)
        {
            if (enemyHealth < 0) enemyHealth = 0;
            Destroy(gameObject);
        }
    }
}
