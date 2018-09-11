using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    #region singleton
    private static Player instance;
    public static Player GetInstance() {
        return instance;
    }
    private void Awake() {
        if(!instance)
            instance = this;
        else
            Destroy(this.gameObject);
    }
    #endregion

    public int lives;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GetDamage()
    {
		lives--;
    }
}
