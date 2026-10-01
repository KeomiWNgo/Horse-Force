using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Author: Jasmine Guzeldere
 * Date Created: 09/22/26
 * Last Updated:09/30/26
 * Description: This will handle the buttons and whatnot of the main menu
 */
public class MainMenu : MonoBehaviour
{
    public void QuitGame()
    {
      //  Application.quit();
    }

    public void SwitchScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
