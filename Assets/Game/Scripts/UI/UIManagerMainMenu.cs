﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerMainMenu : MonoBehaviour {

    public GameObject UI_MainMenu;
    public GameObject UI_Options;
    public GameObject UI_Credits;

    private void Start() {
        EnableCanvas(true, false, false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void PlayPressed()
    {
        LoaderManager.Get().LoadScene("GameScene");
    }
    public void CreditsPressed()
    {
        EnableCanvas(false, false, true);
    }

    public void OptionsPressed()
    {
        EnableCanvas(false, true, false);
    }
    public void BackPressed() {
        EnableCanvas(true, false, false);
    }
    public void ExitPressed()
    {
        Application.Quit();
    }
    private void EnableCanvas(bool mainMenu, bool options, bool credits) {
        UI_MainMenu.SetActive(mainMenu);
        UI_Options.SetActive(options);
        UI_Credits.SetActive(credits);
    }

}
