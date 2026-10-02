using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// When used, activate the multiplier to double damage.

public class Multiplying : MonoBehaviour
{
    public float multValue;
    public bool isMult;

    public void Multiplier()
    {
        isMult = true; // Render multiplier true
        Debug.Log("Activated Multiplier Powerup");
    }
}
