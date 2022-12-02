using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void EndlessRunner()
    {
        SceneManager.LoadScene("EndlessRunner");
    }

    public void About()
    {
        SceneManager.LoadScene("LoadingScreen");
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void AboutBack()
    {
        SceneManager.LoadScene("Menu");
    }
}
