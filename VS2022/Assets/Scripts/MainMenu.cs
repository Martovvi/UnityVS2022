using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayTrainingMode()
    {
        SceneManager.LoadScene("VS2022Training");
    }

    public void PlayDemoMode()
    {
        SceneManager.LoadScene("VS2022Demo");
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
