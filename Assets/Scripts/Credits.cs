using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

    private string menuScene = "MainMenuScene";

    public void OnBackPressed()
    {
        SceneManager.LoadScene(menuScene);
    }

}
