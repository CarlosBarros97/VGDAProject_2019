using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void goToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void goLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void goHowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }
}
