using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

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

    private bool stuned = false;
    private float stunedTime;
    private float timer;
    public int life;
    public int maxLife;

    private void Start()
    {
        GameManager.GetInstance().player = this;
        life = maxLife;
    }

    internal void RestoreLife(int v)
    {
        life += v;
        life = Mathf.Clamp(life, 0, maxLife);
    }

    private void Update()
    {
        StunControl();
    }

    private void StunControl()
    {
        if (stuned)
        {
            timer += Time.deltaTime;
            if (timer >= stunedTime)
            {
                stuned = false;
                stunedTime = 0;
                timer = 0;
                GetComponent<FirstPersonController>().m_WalkSpeed = 5;
                GetComponent<FirstPersonController>().m_RunSpeed = 10;
            }
        }
    }


    public void Stun(float stunTime)
    {
        if (!stuned)
        {
            stuned = true;
            stunedTime = stunTime;
            GetComponent<FirstPersonController>().m_WalkSpeed = 0;
            GetComponent<FirstPersonController>().m_RunSpeed = 0;
        }
    }


    public void TakeDamage(int val)
    {
        life -= val;
        if (life <= 0)
        {
            GameManager.GetInstance().gameOver = true;
        }
    }
}
