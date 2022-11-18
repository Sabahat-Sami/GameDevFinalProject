using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    public TextMeshProUGUI maxScore;
    public TextMeshProUGUI currScore;
    // Start is called before the first frame update
    void Start()
    {
        maxScore.text = "High Score: " + PublicVars.maxScore;
        currScore.text = "Score: " + PublicVars.currScore;
    }

    public void EndlessRunner() {
        SceneManager.LoadScene("EndlessRunner");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
