using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour {

    private string mainMenu = "MainMenuScene";

    public void OnBackPressed()
    {
        SceneManager.LoadScene(mainMenu);
    }

}