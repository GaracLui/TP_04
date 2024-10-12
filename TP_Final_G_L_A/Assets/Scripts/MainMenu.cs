using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
   public void PlaySpring()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlaySummer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void PlayFall()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    public void PlayWinter()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
