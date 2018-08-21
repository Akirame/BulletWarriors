using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suicider : MonoBehaviour {


    enum STATES {CHASING, ATTACKING};
    public int speed;
    public float minDistanceAttack;

    private GameObject player;
    private Vector3 direction;
    private STATES currentState;
    public bool exploding;

	// Use this for initialization
	void Start () {
        currentState = STATES.CHASING;
        exploding = false;
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        StateController();
    }

    private void StateController()
    {
        switch (currentState)
        {
            case STATES.CHASING:
                ChasePlayer();
                break;
            case STATES.ATTACKING:
                Explode();
                break;
            default:
                break;
        }
    }

    private void Explode()
    {
        if (player)
        {
            if (!exploding)
            {
                exploding = true;
            }
        }
    }

    private void ChasePlayer()
    {
        if (player)
        {
            Vector3 positionDifference = player.transform.position - transform.position;
            direction = positionDifference.normalized;
            GetComponent<Rigidbody>().velocity = direction * Time.deltaTime * speed;
            if (Vector3.Distance(player.transform.position, transform.position) <= minDistanceAttack)
            {
                currentState = STATES.ATTACKING;
            }
        }
    }

}
