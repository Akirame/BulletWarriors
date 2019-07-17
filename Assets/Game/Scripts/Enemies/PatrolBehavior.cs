using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehavior : MonoBehaviour {

    public Transform[] patrolPoints;
    public Transform nextPoint;
    public int idxPoint = -1;
    private ChaseBehaviour cb;

    private void Start()
    {
        GetNextPoint();
        cb = GetComponent<ChaseBehaviour>();
    }

    // Update is called once per frame
    void Update () {
        if (patrolPoints.Length > 0)
        {
            if (!PointReached())
            {
                Vector3 direction = (nextPoint.position - transform.position).normalized;
                cb.velocity = direction * cb.speed * Time.deltaTime;
                cb.rig.velocity = cb.velocity;
            }
            else
            {
                GetNextPoint();
            }
        }
	}

    private bool PointReached()
    {
        return Vector3.Distance(transform.position, nextPoint.position) < 1;
    }

    private void GetNextPoint()
    {
        if (patrolPoints.Length > 0)
        {
            idxPoint++;
            if (idxPoint > patrolPoints.Length)
                idxPoint = 0;
            nextPoint = patrolPoints[idxPoint];
            transform.LookAt(new Vector3(nextPoint.position.x, transform.position.y, nextPoint.position.z));
        }
    }
}
