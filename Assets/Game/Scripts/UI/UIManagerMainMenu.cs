using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerMainMenu : MonoBehaviour {

    public GameObject UI_MainMenu;
    public GameObject UI_Credits;
    private Animator anim;

    private void Start() {
        EnableCanvas(true, false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        anim = GetComponent<Animator>();
    }
    public void PlayPressed()
    {
        LoaderManager.Get().LoadScene("GameScene");
    }
    public void CreditsPressed()
    {
        EnableCanvas(false, true);
        anim.SetTrigger("Credits");
    }
    public void BackPressed() {
        EnableCanvas(true, false);
        anim.SetTrigger("Start");
    }
    public void ExitPressed()
    {
        Application.Quit();
    }
    private void EnableCanvas(bool mainMenu, bool credits) {
        UI_MainMenu.SetActive(mainMenu);
        UI_Credits.SetActive(credits);
    }

}
