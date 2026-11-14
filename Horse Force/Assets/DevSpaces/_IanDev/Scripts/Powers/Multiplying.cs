using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

// When used, activate the multiplier to double damage.

public class Multiplying : MonoBehaviour
{
    // Change as needed
    public static int multCount;
    public float multValue;
    public bool isMult;
    public TMP_Text multText;

    private void Start()
    {
        multCount = PlayerPrefs.GetInt("multiplierPower");
        multText.text = "Rally!\nTotal: " + multCount.ToString();
    }

    public void Multiplier()
    {
        if (isMult == false && multCount > 0)
        {
            isMult = true; // Render multiplier true
            Debug.Log("Activated Multiplier Powerup");
            multCount--;

            PlayerPrefs.SetInt("multPower", multCount);
            multText.text = "Rally!\nTotal: " + multCount.ToString();
        }
        else
        {
            Debug.Log("Multiplier Already Active");
        }    
    }
}
