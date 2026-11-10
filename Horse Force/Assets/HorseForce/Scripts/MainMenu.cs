using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Author: Jasmine Guzeldere
 * Date Created: 09/22/26
 * Last Updated:09/30/26
 * Last Updated by:
 * Description: This will handle the buttons and whatnot of the main menu
 */
public class MainMenu : MonoBehaviour
{
    private AudioSource clickSound;

    void Awake()
    {
        clickSound = GetComponent<AudioSource>();
    }
    public void QuitGame()
    {
      //  Application.quit();
    }

    public void SwitchScene(int sceneIndex)
    {
        StartCoroutine(ButtonDelay(sceneIndex));
    }

    private IEnumerator ButtonDelay(int sceneIndex)
    {
        clickSound.Play();
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(sceneIndex);

    }
}
