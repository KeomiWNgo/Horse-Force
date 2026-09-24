using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Author: Jasmine Guzeldere
 * Date Created: 09/22/26
 * Last Updated:09/24/26
 * Description: This will handle the buttons and whatnot of the main menu
 */
public class MainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame()
    {
      //  Application.quit();
    }

    public void SwitchScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
