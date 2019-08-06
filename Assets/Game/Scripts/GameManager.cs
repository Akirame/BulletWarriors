using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    #region singleton
    private static GameManager instance;
    public static GameManager GetInstance()
    {
        return instance;
    }
    private void Awake()
    {
        if (!instance)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    #endregion
    public Player player;
    public float totalTime = 480;
    public bool gameStarted = false;
    public bool gameOver = false;
    public bool win = false;
    private float winTimer;
    public AudioClip gameMusic;
    public AudioClip bossMusic;
    public bool gamePaused = false;
    public GameObject pausePanelMobile;
    public GameObject pausePanel;

    private void Start()
    {
        player = Player.GetInstance();
    }

    // Update is called once per frame
    void Update () {
        if (gameStarted)
        {
            if (totalTime > 0)
            {
                totalTime -= Time.deltaTime;
            }

            if (totalTime <= 0 || gameOver)
            {
                LoaderManager.Get().LoadScene("MainMenuScene");
            }
            if (win)
            {
                winTimer += Time.deltaTime;
                if (winTimer > 5)
                {
                    LoaderManager.Get().LoadScene("MainMenuScene");
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.F1))
        {

            BossMode();
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {

            WinGame();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SetPause();
        }
    }

    public void QuitGame()
    {
        SetPause();
        LoaderManager.Get().LoadScene("MainMenuScene");
    }

    public void SetPause()
    {
        gamePaused = !gamePaused;
#if UNITY_ANDROID
        pausePanelMobile.SetActive(gamePaused);
#else
        pausePanel.SetActive(gamePaused);
#endif
        Time.timeScale = gamePaused ? 0 : 1;
    }

    public void WinGame()
    {
        win = true;
        UI_Game.GetInstance().WinState();
    }

    public void BossMode()
    {
        GetComponent<AudioSource>().clip = bossMusic;
        GetComponent<AudioSource>().Play();
    }

}
