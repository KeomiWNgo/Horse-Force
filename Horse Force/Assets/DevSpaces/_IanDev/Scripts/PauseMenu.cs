using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Pause Menu Functionality for in-game purposes
// Press a button to bring up this menu and bring up a number of selections.
/* EXTRA NOTES
 * - Attach an "!PauseMenu.isPaused" to certain conditions that may need it after getting a reference to this script.
 * - EX: (if *Condition* && !PauseMenu.isPaused){}
 * - This may not be required, as the attack button, swipe, and enemy are all disabled as long as the game is paused.
 */

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;
    public bool isPaused;

    // Get reference to scripts to prevent certain inputs

    // Uncomment the SerializeFields when implemented into the game

    //[SerializeField] private AttackButton attack;
    //[SerializeField] private Board swipe;
    //[SerializeField] private EnemyBehaviour enemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
        Time.timeScale = 1; // Set the scale of time to standard on level startup
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Pause the Game
    public void Pause()
    {
        // Disable all of these functions

        // Uncomment these calls when implementing into the game
        //attack.enabled = false;
        //swipe.enabled = false;
        //enemy.enabled = false;

        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        isPaused = true;

        Debug.Log("Game Paused");
    }

    // Unpause the Game
    public void Unpause()
    {
        // Uncomment these calls when implementing into the game
        //attack.enabled = true;
        //swipe.enabled = true;
        //enemy.enabled = true;

        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;

        Debug.Log("Game Unpaused");
    }
}
