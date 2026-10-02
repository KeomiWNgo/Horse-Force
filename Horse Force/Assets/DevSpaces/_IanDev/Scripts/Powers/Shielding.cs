using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Shield powerup
// Allows the player to withstand a single hit of any strength!

public class Shielding : MonoBehaviour
{
    public int shieldCount = 3;
    public bool isShielded = false; // Shield is off by default

    public void ShieldUp()
    {
        if (isShielded == false && shieldCount > 3)
        {
            isShielded = true; // When used, set shielded to true
            Debug.Log("Activated Shield Powerup");
            shieldCount--;
        }
        else
        {
            Debug.Log("Player already Shielded");
        }
    }
}
