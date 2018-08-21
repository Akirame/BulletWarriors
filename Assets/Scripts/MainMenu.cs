using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    private string creditsScene = "CreditsScene";

    public void OnPlayPressed()
    {
        //SceneManager.LoadScene();
    }

    public void OnCreditsPressed()
    {
        SceneManager.LoadScene(creditsScene);
    }

    public void OnOptionsPressed()
    {
        //SceneManager.LoadScene();
    }

    public void OnExitPressed()
    {
        Application.Quit();
    }

}
