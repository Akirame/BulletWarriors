using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    #region singleton
    public delegate void PlayerActions(Player p);
    public static PlayerActions OnHit;

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

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Enemy") {
            OnHit(this);
        }
    }
    public void GetDamage()
    {
		lives--;
    }
}
