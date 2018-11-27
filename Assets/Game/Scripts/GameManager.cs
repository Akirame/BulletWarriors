using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public float totalTime = 300;
    public bool gameStarted = false;
    public bool gameOver = false;
    public bool win = false;


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

            if (totalTime <= 0)
            {
                LoaderManager.Get().LoadScene("MainMenuScene");
            }
        }
	}
}
