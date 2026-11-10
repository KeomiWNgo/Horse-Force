using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

// Ian Phurchpean
// Shop Manager Script used to manage the different items the player can purchase in the game

public class ShopManager : MonoBehaviour
{
    // Initialize Variables for Money
    public int money;
    public int healthItem;
    public int multiplierItem;
    public int shieldItem;

    // Print the Text to the Screen
    public TMP_Text money_Text;
    public TMP_Text healthItem_Text;
    public TMP_Text multiplierItem_Text;
    public TMP_Text shieldItem_Text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get the current amount of items saved
        money = PlayerPrefs.GetInt("money");
        healthItem = PlayerPrefs.GetInt("healthPower");
        multiplierItem = PlayerPrefs.GetInt("multiplierPower");
        shieldItem = PlayerPrefs.GetInt("shieldPower");

        money_Text.text = "Money: " + money.ToString();
        healthItem_Text.text = "Quantity: " + healthItem.ToString();
        multiplierItem_Text.text = "Quantity: " + multiplierItem.ToString();
        shieldItem_Text.text = "Quantity: " + shieldItem.ToString();
    }

    /// <summary>
    /// Purchase the health item powerup
    /// </summary>
    public void buyHealth()
    {
        if (money >= 100)
        {
            money -= 100;
            money_Text.text = money.ToString(); // Update Money

            healthItem += 1;
            healthItem_Text.text = healthItem.ToString(); // Update Item

            // Update the player items
            PlayerPrefs.SetInt("money", money);
            PlayerPrefs.SetInt("healthPower", healthItem);
        }
        else
        {
            Debug.Log("You Don't have enough money!");
        }
    }

    /// <summary>
    /// Purchase the multiplier item powerup
    /// </summary>
    public void buyMultiplier()
    {
        if (money >= 200)
        {
            money -= 200;
            money_Text.text = money.ToString(); // Update Money

            multiplierItem += 1;
            multiplierItem_Text.text = multiplierItem.ToString(); // Update Item

            // Update the player items
            PlayerPrefs.SetInt("money", money);
            PlayerPrefs.SetInt("multPower", multiplierItem);
        }
        else
        {
            Debug.Log("You Don't have enough money!");
        }
    }

    /// <summary>
    /// Purchase the shield item powerup
    /// </summary>
    public void buyShield()
    {
        if (money >= 100)
        {
            money -= 100;
            money_Text.text = money.ToString(); // Update Money

            shieldItem += 1;
            shieldItem_Text.text = shieldItem.ToString(); // Update Item

            // Update the player items
            PlayerPrefs.SetInt("money", money);
            PlayerPrefs.SetInt("shieldPower", shieldItem);
        }
        else
        {
            Debug.Log("You Don't have enough money!");
        }
    }
}

// Bingus