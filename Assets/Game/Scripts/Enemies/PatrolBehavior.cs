using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehavior : MonoBehaviour {

    public Transform[] patrolPoints;
    public Transform nextPoint;
    public int idxPoint = -1;
    public float minDistance = 1;
    private ChaseBehaviour cb;
    public float rotationSpeed = 5;

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
                float step = rotationSpeed * Time.deltaTime;
                Vector3 rotDir = Vector3.RotateTowards(transform.forward, direction, step, 0.0f);
                transform.rotation = Quaternion.LookRotation(new Vector3(rotDir.x, 0, rotDir.z));
            }
            else
            {
                GetNextPoint();
            }
        }
	}

    private bool PointReached()
    {
        return Vector3.Distance(transform.position, nextPoint.position) < minDistance;
    }

    private void GetNextPoint()
    {
        if (patrolPoints.Length > 0)
        {
            idxPoint++;
            idxPoint = idxPoint % patrolPoints.Length;
            nextPoint = patrolPoints[idxPoint];
        }
    }
}
