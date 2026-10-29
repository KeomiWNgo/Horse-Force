using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Ian Phurchpean
// Heal a quarter of the player's health when used.

public class Healing : MonoBehaviour
{
    // Change as needed
    public static int healCount = 3;
    public Health maxHealth;
    [SerializeField] private float CDMax = 6f;
    [SerializeField] private float CDTime;

    void Update()
    {
        if (CDTime > 0)
        {
            CDTime -= Time.deltaTime;
        }
    }
    public void HealthUp()
    {
        if (healCount > 0 && maxHealth.currhealth != maxHealth.maxhealth && CDTime <= 0) // ONLY HEAL WHEN THE PLAYER HAS BEEN DAMAGED
        {
            maxHealth.currhealth += maxHealth.maxhealth / 4; // Add to the current health by 25% of the maximum health when used
            Debug.Log("Activated Health Powerup");
            if (maxHealth.currhealth >= maxHealth.maxhealth)
            {
                // If health overflows after use, set the health of the player back to the maximum health
                maxHealth.currhealth = maxHealth.maxhealth;
            }
            healCount--;
            CDTime = CDMax; // Reset Timer
        }
        else if (maxHealth.currhealth == maxHealth.maxhealth)
        {
            Debug.Log("Player is at full health!");
        }
        else if (CDTime >= 0)
        {
            Debug.Log("Your Powerup is on Cooldown!");
        }
        else
        {
            Debug.Log("Out of Healing Powerups");
        }
    }
}
