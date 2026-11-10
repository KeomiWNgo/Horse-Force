using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

// Ian Phurchpean
// Separate Upgrade Manager used for the player to buy upgrades

public class UpgradeManager : MonoBehaviour
{
    // Initialize Variables for Money
    public int money;
    public int healthUp;
    public int atkUp;
    public int defUp;

    public int healthCost;
    public int atkCost;
    public int defCost;

    // Print the Text to the Screen
    public TMP_Text money_Text;
    public TMP_Text healthUp_Text;
    public TMP_Text atkUp_Text;
    public TMP_Text defUp_Text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get the current amount of items saved
        money = PlayerPrefs.GetInt("money");
        healthUp = PlayerPrefs.GetInt("health");
        atkUp = PlayerPrefs.GetInt("atk");
        defUp = PlayerPrefs.GetInt("def");

        // Get quantity and total money
        money_Text.text = "Money: " + money.ToString();
        healthUp_Text.text = "Level: " + healthUp.ToString();
        atkUp_Text.text = "Level: " + atkUp.ToString();
        defUp_Text.text = "Level: " + defUp.ToString();
    }

    /// <summary>
    /// Purchase the Health Upgrade
    /// </summary>
    public void purchaseHealth()
    {
        if (money >= healthCost)
        {
            money -= healthCost;
            money_Text.text = "Money: " + money.ToString(); // Update Money

            healthUp += 1;
            healthUp_Text.text = "Level: " +  healthUp.ToString(); // Update Item

            // Update the player items
            PlayerPrefs.SetInt("money", money);
            PlayerPrefs.SetInt("health", healthUp);
        }
        else
        {
            Debug.Log("You don't have enough money!");
        }
    }

    /// <summary>
    /// Purchase the Attack Upgrade
    /// </summary>
    public void purchaseAtk()
    {
        if (money >= atkCost)
        {
            money -= atkCost;
            money_Text.text = "Money: " + money.ToString(); // Update Money

            atkUp += 1;
            atkUp_Text.text = "Level: " + atkUp.ToString(); // Update Item

            // Update the player items
            PlayerPrefs.SetInt("money", money);
            PlayerPrefs.SetInt("atk", atkUp);
        }
        else
        {
            Debug.Log("You don't have enough money!");
        }
    }

    /// <summary>
    /// Purchase the Defence Upgrade
    /// </summary>
    public void purchaseDef()
    {
        if (money >= defCost)
        {
            money -= defCost;
            money_Text.text = "Money: " + money.ToString(); // Update Money

            defUp += 1;
            defUp_Text.text = "Level: " + defUp.ToString(); // Update Item

            // Update the player items
            PlayerPrefs.SetInt("money", money);
            PlayerPrefs.SetInt("def", defUp);
        }
        else
        {
            Debug.Log("You don't have enough money!");
        }
    }
}

// Bingus
