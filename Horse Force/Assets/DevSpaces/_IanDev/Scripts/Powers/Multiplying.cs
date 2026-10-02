using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// When used, activate the multiplier to double damage.

public class Multiplying : MonoBehaviour
{
    public int multCount = 3;
    public float multValue;
    public bool isMult;

    public void Multiplier()
    {
        if (isMult == false && multCount > 0)
        {
            isMult = true; // Render multiplier true
            Debug.Log("Activated Multiplier Powerup");
            multCount--;
        }
        else
        {
            Debug.Log("Multiplier Already Active");
        }    
    }
}
