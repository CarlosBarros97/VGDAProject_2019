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

    public void goPrototypeScene()
    {
        SceneManager.LoadScene("PrototypeScene");
    }

    public void goSampleScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void goDemoSecene()
    {
        SceneManager.LoadScene("DemoLevel");
    }
}
