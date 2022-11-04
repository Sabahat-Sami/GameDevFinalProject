using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void Demo1()
    {
        SceneManager.LoadScene("Demo1");
    }

    public void Demo2()
    {
        SceneManager.LoadScene("Demo2");
    }
}
