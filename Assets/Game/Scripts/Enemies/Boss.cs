using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy {

    public Transform[] positionsList;
    private Transform nextPoint;
    public float minDistance = 1;
    private int idxPoint = -1;
    private float ascendTime = 3;
    private float ascendTimer = 0;
    private bool ascended = false;
    public float speed = 100; 
    private Rigidbody rig;
    private PlayerDetector pd;

    private void Start()
    {
        rig = GetComponent<Rigidbody>();
        pd = GetComponentInChildren<PlayerDetector>();
        GetNextPosition();
    }

    private void Update()
    {
        base.Update();
        if (pd.isPlayerInside)
        {
            if (alive)
            {
                if (!ascended)
                {
                    AscendOnAir();
                }
                else
                {
                    MoveToNextPosition();
                }
                transform.LookAt(GameManager.GetInstance().player.transform.position);
            }
            else
            {
                GameManager.GetInstance().WinGame();
            }
        }
    }

    private void MoveToNextPosition()
    {
        if (!PositionReached())
        {
            Vector3 direction = (nextPoint.position - transform.position).normalized;
            rig.velocity = direction * speed * Time.deltaTime;
        }
        else
        {
            GetRandomPos();
        }
    }

    private void AscendOnAir()
    {
        rig.velocity = Vector3.up * Time.deltaTime * speed * 0.5f;
        ascendTimer += Time.deltaTime;
        if (ascendTimer >= ascendTime)
        {
            ascended = true;
            ascendTimer = 0;
        }
    }

    private bool PositionReached()
    {
        return Vector3.Distance(transform.position, nextPoint.position) < minDistance;
    }

    private void GetRandomPos()
    {
        if (positionsList.Length > 0)
        {
            idxPoint = UnityEngine.Random.Range(0, positionsList.Length);
            nextPoint = positionsList[idxPoint];
        }
    }

    private void GetNextPosition()
    {
        if (positionsList.Length > 0)
        {
            idxPoint++;
            idxPoint = idxPoint % positionsList.Length;
            nextPoint = positionsList[idxPoint];
        }
    }

}
