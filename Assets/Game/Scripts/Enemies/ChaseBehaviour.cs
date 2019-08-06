using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseBehaviour : MonoBehaviour {

    public float minDistance;
    public int speed;
    private PlayerDetector pd;
    private Vector3 direction;
    public Rigidbody rig;
    private Player player;
    public Vector3 velocity;
    private bool hasPatrol;
    private Enemy enem;

    // Use this for initialization
    void Start () {
        rig = GetComponent<Rigidbody>();
        pd = GetComponentInChildren<PlayerDetector>();
        player = GameManager.GetInstance().player;
        hasPatrol = GetComponent<PatrolBehavior>() != null;
        enem = GetComponent<Enemy>();
    }
	
	// Update is called once per frame
	void Update () {
        if (enem.alive)
        {
            if (pd.isPlayerInside || enem.receivingDamage)
            {
                if (hasPatrol)
                    GetComponent<PatrolBehavior>().enabled = false;
                Movement();
            }
            else
            {
                velocity = Vector3.zero;
                if (hasPatrol)
                    GetComponent<PatrolBehavior>().enabled = true;
            }
        }
        else
        {
            if (hasPatrol)
            {
                GetComponent<PatrolBehavior>().enabled = false;
            }
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
