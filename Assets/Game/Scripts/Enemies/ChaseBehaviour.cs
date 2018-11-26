using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseBehaviour : Enemy {

    public Transform dummyPrefab;
    public float minDistance;
    public int speed;
    private PlayerDetector pd;
    private Vector3 direction;
    private Rigidbody rig;
    private GameObject dummy;

    // Use this for initialization
    void Start () {
        rig = GetComponent<Rigidbody>();
        dummy = Instantiate(dummyPrefab.gameObject, transform);
        dummy.name = "DummyObject";
        pd = GetComponentInChildren<PlayerDetector>();
    }
	
	// Update is called once per frame
	void Update () {
        if (pd.isPlayerInside)
        {
            Movement();
        }
    }
    private void LateUpdate()
    {
        dummy.transform.LookAt(GameManager.GetInstance().player.transform.position);
        dummy.transform.position = transform.position;
        Vector3 rotation = dummy.transform.eulerAngles;
        if (rotation.x > 25)
            rotation.x = 25;
        transform.eulerAngles = rotation;
    }

    private void Movement()
    {
        Vector3 positionDifference = GameManager.GetInstance().player.transform.position - transform.position;
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, positionDifference.x * 10, transform.eulerAngles.z);        
        direction = positionDifference.normalized;
        direction.y = 0;
        if (Vector3.Distance(transform.position, GameManager.GetInstance().player.transform.position) > minDistance)
        {
            rig.velocity = direction * speed * Time.deltaTime;
        }
        else
        {
            rig.velocity = Vector3.zero;
        }
    }
}
