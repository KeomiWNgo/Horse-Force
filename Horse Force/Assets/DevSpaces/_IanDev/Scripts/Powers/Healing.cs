using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

// Name: Ian Phurchpean
// Heal a quarter of the player's health when used.

public class Healing : MonoBehaviour
{
    // Change as needed
    public static int healCount;
    public Health maxHealth;
    public TMP_Text powerText;

    private void Start()
    {
        healCount = PlayerPrefs.GetInt("healthPower");
        powerText.text = "Acupuncture Therapy\nTotal: " + healCount.ToString();
    }

    void Update()
    {

    }
    public void HealthUp()
    {
        if (healCount > 0 && maxHealth.currhealth != maxHealth.maxhealth) // ONLY HEAL WHEN THE PLAYER HAS BEEN DAMAGED
        {
            maxHealth.currhealth += maxHealth.maxhealth / 4; // Add to the current health by 25% of the maximum health when used
            Debug.Log("Activated Health Powerup");
            if (maxHealth.currhealth >= maxHealth.maxhealth)
            {
                // If health overflows after use, set the health of the player back to the maximum health
                maxHealth.currhealth = maxHealth.maxhealth;
            }
            healCount--;
            powerText.text = "Acupuncture Therapy\nTotal: " + healCount.ToString();

            // Update count
            PlayerPrefs.SetInt("healthPower", healCount);
        }
        else if (maxHealth.currhealth == maxHealth.maxhealth)
        {
            Debug.Log("Player is at full health!");
        }
        else
        {
            Debug.Log("Out of Healing Powerups");
        }
    }
}
