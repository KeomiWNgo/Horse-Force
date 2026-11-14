using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

// Shield powerup
// Allows the player to withstand a single hit of any strength!

public class Shielding : MonoBehaviour
{
    // Change as needed
    public static int shieldCount;
    public TMP_Text shieldText;
    public bool isShielded = false; // Shield is off by default

    private void Start()
    {
        shieldCount = PlayerPrefs.GetInt("shieldPower");
        shieldText.text = "Stable Shield\nTotal: " + shieldCount.ToString();
    }

    public void ShieldUp()
    {
        if (isShielded == false && shieldCount > 0)
        {
            isShielded = true; // When used, set shielded to true
            Debug.Log("Activated Shield Powerup");

            shieldCount--;
            shieldText.text = "Stable Shield\nTotal: " + shieldCount.ToString();

            PlayerPrefs.SetInt("shieldPower", shieldCount);
        }
        else
        {
            Debug.Log("Player already Shielded");
        }
    }
}
