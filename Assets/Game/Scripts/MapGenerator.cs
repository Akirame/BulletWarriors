using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {
    public int sizeX;
    public int sizeY;
    private int sizeTile = 20;
    public GameObject wall;
    public GameObject[] Tiles;
    private int[,] matrixTiles;

    private void Start() {
        InitMatrix();
        GenerateMap();
        GenerateWalls();
    }
    private void InitMatrix() {
        matrixTiles = new int[sizeX, sizeY];
        for(int i = 0; i < sizeX; i++) {
            for(int j = 0; j < sizeY; j++) {
                matrixTiles[i, j] = Random.Range(0, Tiles.Length);
            }
        }
    }
    private void GenerateMap() {
        for(int i = 0; i < sizeX; i++) {
            for(int j = 0; j < sizeY; j++) {
                Vector3 position = new Vector3(sizeTile * j , 0, sizeTile * i);
                GameObject go = Instantiate(Tiles[matrixTiles[i, j]], position, Quaternion.identity, transform);
            }
        }
    }
    private void GenerateWalls() {
        GameObject go = Instantiate(wall, transform.position, Quaternion.identity,transform);
        go.transform.localScale = new Vector3(1, sizeTile, sizeTile * sizeX);
        go.transform.position = new Vector3(-sizeTile/2, 0, (sizeTile*sizeX/2)-10);

        go = Instantiate(wall, transform.position, Quaternion.identity, transform);
        go.transform.localScale = new Vector3(1, sizeTile, sizeTile * sizeX);
        go.transform.position = new Vector3(sizeTile * sizeY - sizeTile/2, 0, (sizeTile * sizeX / 2) - 10);

        go = Instantiate(wall, transform.position, Quaternion.identity, transform);
        go.transform.localScale = new Vector3(sizeTile*sizeY, sizeTile, 1);
        go.transform.position = new Vector3( sizeTile * sizeY/2 - sizeTile/2, 1, -sizeTile / 2);

        go = Instantiate(wall, transform.position, Quaternion.identity, transform);
        go.transform.localScale = new Vector3(sizeTile * sizeY, sizeTile, 1);
        go.transform.position = new Vector3(sizeTile * sizeY / 2 - sizeTile / 2, 1, sizeTile * sizeX - sizeTile/ 2);
    }
}
