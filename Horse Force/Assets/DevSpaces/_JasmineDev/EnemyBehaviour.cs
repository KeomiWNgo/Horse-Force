using UnityEngine;
using System.Collections;
using System;

public class EnemyBehaviour : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public PlayerHealth playerHealth; // assign game object inspectoor
    public int damagePerTick = 10;
    public float damageInterval = 3f;
    public static event Action OnEnemyDestroyed;

    void Start()
    {
        if (playerHealth != null)
        {
            StartCoroutine(DamageOverTime());
        }
        else
        {
            Debug.LogError("Enemy is missing a reference to the PlayerHealth script!");
        }
    }

    //so wave spawner can inssert player ref right after instantiation
    public void Initialize(PlayerHealth targetPlayer)
    {
        playerHealth = targetPlayer;
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

    public void Die()
    {
        OnEnemyDestroyed?.Invoke();

        Destroy(gameObject);
    }
}
