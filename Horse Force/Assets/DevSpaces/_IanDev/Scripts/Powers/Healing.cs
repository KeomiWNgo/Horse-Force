using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Ian Phurchpean
// Heal a quarter of the player's health when used.

public class Healing : MonoBehaviour
{
    public Health maxHealth;
    public void HealthUp()
    {
        maxHealth.currhealth += maxHealth.maxhealth / 4; // Add to the current health by 25% of the maximum health when used
        Debug.Log("Activated Health Powerup");
    }
}
