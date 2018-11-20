using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public List<GameObject> spawnList;
    public float maxSpawnTime = 3;
    public float minSpawnTime = 6;
    private PlayerDetector pd;
    private float spawnTime;
    private float timer;
    private bool canSpawn = false;

    private void Start() {
        Enemy.OnDieWithBullet += EnemyKilled;
        pd = GetComponentInChildren<PlayerDetector>();
        GetNewSpawnTime();
    }

    private void GetNewSpawnTime()
    {
        spawnTime = UnityEngine.Random.Range(minSpawnTime, maxSpawnTime);
    }

    private void Update() {
        CheckCanSpawn();
        if (canSpawn)
        {
            if (timer < spawnTime)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer = 0;
                Instantiate(spawnList[UnityEngine.Random.Range(0, spawnList.Count)], transform.position, Quaternion.identity, transform.parent);
                Vector3 newPos = transform.position;
                GetNewSpawnTime();
            }
        }
    }

    private void CheckCanSpawn()
    {
        if (pd.isPlayerInside && !canSpawn)
        {
            canSpawn = true;
        }
    }

    private void EnemyKilled(Enemy e) {
        Destroy(e.gameObject);
    }

}
