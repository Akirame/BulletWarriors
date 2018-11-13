using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public List<GameObject> spawnList;
    public float spawnTime = 3;
    private float timer;

    private void Start() {
        Enemy.OnDieWithBullet += EnemyKilled;
    }

    private void Update() {
        if(timer < spawnTime) {
            timer += Time.deltaTime;
        }
        else {
            timer = 0;
            Instantiate(spawnList[Random.Range(0, spawnList.Count)], transform.position, Quaternion.identity, transform.parent);
            Vector3 newPos = transform.position;
        }
    }
    private void EnemyKilled(Enemy e) {
        Destroy(e.gameObject);
    }
}
