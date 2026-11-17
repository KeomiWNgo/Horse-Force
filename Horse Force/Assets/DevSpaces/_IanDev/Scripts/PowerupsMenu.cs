using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Ability to use powerups through the press of a button

public class PowerupsMenu : MonoBehaviour
{
    public GameObject powerupsMenu;
    [SerializeField] private bool isOpen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        powerupsMenu.SetActive(false);
        Time.timeScale = 1; // Set the scale of time to standard on level startup
        isOpen = false;
    }

    public void openMenu()
    {
        if (isOpen == false)
        {
            powerupsMenu.SetActive(true);
            isOpen = true;
        }
        else if (isOpen == true)
        {
            powerupsMenu.SetActive(false);
            isOpen = false;
        }
    }
}
