using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseBehaviour : Enemy {

    public float minDistance;
    public int speed;
    private PlayerDetector pd;
    private Vector3 direction;
    public Rigidbody rig;
    private Player player;
    public Vector3 velocity;
    private bool hasPatrol;

    // Use this for initialization
    void Start () {
        rig = GetComponent<Rigidbody>();
        pd = GetComponentInChildren<PlayerDetector>();
        player = GameManager.GetInstance().player;
        hasPatrol = GetComponent<PatrolBehavior>() != null;
    }
	
	// Update is called once per frame
	void Update () {
        if (pd.isPlayerInside)
        {
            if (hasPatrol)
                GetComponent<PatrolBehavior>().enabled = false;
            Movement();
        }
        else
        {
            if (hasPatrol)
                GetComponent<PatrolBehavior>().enabled = true;
        }
    }

    private void Movement()
    {
        Vector3 positionDifference = player.transform.position - transform.position;
        direction = positionDifference.normalized;
        direction.y = 0;
        if (Vector3.Distance(transform.position, player.transform.position) > minDistance)
            velocity = direction * speed * Time.deltaTime;
        else
            velocity = Vector3.zero;
        rig.velocity = velocity;
        transform.LookAt(new Vector3(player.transform.position.x,transform.position.y, player.transform.position.z));
    }
}
