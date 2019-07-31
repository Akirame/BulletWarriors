using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy {

    private ShootBehaviour sb;
    private ChaseBehaviour cb;
    private Animator anim;
    private bool attackAnim = false;
    private bool deadAnim = false;

	// Use this for initialization
	void Start () {
        sb = GetComponent<ShootBehaviour>();
        cb = GetComponent<ChaseBehaviour>();
        anim = GetComponentInChildren<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        base.Update();
        OnAttackPlayAnimation();
        OnDeadPlayAnimation();
        anim.SetFloat("Walk", Mathf.Abs(cb.velocity.magnitude));
    }

    private void OnAttackPlayAnimation()
    {
        if (!sb.canShoot)
        {
            if (!attackAnim)
            {
                attackAnim = true;
                anim.SetTrigger("Attack");
            }
        }
        else
        {
            attackAnim = false;
        }
    }

    private void OnDeadPlayAnimation()
    {
        if (!alive)
        {
            if (!deadAnim)
            {
                deadAnim = true;
                anim.SetTrigger("Dead");
            }
        }
        else
        {
            deadAnim = false;
        }
    }
}
