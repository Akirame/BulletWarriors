using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public List<GameObject> spawnList;
    public int spawnTime = 3;
    private float timer;

    private void Start() {
        Enemy.OnDieWithBullet += EnemyKilled;
    }
    private void Update() {
        if(timer < spawnTime) {
            timer+= Time.deltaTime;
        }
        else {
            timer = 0;
            GameObject objectSpawned = spawnList[Random.Range(0, spawnList.Count)];
            Vector3 newPos = transform.position;
            newPos.y = objectSpawned.transform.position.y;
            Instantiate(objectSpawned, newPos, Quaternion.identity, transform.parent);
        }
    }
    private void EnemyKilled(Enemy e) {
        Destroy(e.gameObject);
    }
}
