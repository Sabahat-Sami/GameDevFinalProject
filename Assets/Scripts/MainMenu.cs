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

    public void Demo2()
    {
        SceneManager.LoadScene("Demo2");
    }
}
