using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public List<GameObject> spawnList;
    public int spawnTime = 3;
    private float timer;
    private Vector2 MapSize;

    private void Start() {
        MapSize = MapGenerator.GetInstance().Size();
        Enemy.OnDieWithBullet += EnemyKilled;
    }
    private void Update() {
        if(timer < spawnTime) {
            timer+= Time.deltaTime;
        }
        else {
            timer = 0;
            Vector3 spawnPos = new Vector3(Random.Range(0,MapSize.y), 0.3f, Random.Range(0,MapSize.x));
            GameObject e = Instantiate(spawnList[Random.Range(0, spawnList.Count)], spawnPos, Quaternion.identity, transform);            
        }
    }
    private void EnemyKilled(Enemy e) {
        Destroy(e.gameObject);
        GameManager.GetInstance().EnemyDeath();
    }
}
