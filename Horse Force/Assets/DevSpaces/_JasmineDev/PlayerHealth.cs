using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int health = 100;

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        Debug.Log("Player took damage! Current health: " + health);

        if (health <= 0)
        {
            Debug.Log("Player has died!");
            // Add death logic here
        }
    }
}
