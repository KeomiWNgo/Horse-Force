using UnityEngine;
/*
 * Author: Jasmine Guzeldere
 * Date Created:9/-/2026
 * Last Edited: 10/29/2026
 * Last Edited By: Jasmine
 * Description: This script is intendted to handle the player helath in conjunctionw ith the EnemyBehaviour.cs script
 */
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
            //Add death logic here TBdone
        }
    }
}
