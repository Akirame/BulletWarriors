using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {
    #region singleton
    private static MapGenerator instance;
    public static MapGenerator GetInstance() {
        return instance;
    }
    private void Awake() {
        if(!instance)
            instance = this;
        else
            Destroy(this.gameObject);
    }
    #endregion
    public int sizeX;
    public int sizeY;
    private int sizeTile = 20;
    public GameObject wall;
    public GameObject[] Tiles;
    private int[,] matrixTiles;
    private int[] randomEuler;

    private void Start() {
        randomEuler = new int[] { 0, 90, 180, 270 };
        InitMatrix();
        GenerateMap();
        GenerateWalls();
    }
    private void InitMatrix() {
        matrixTiles = new int[sizeX, sizeY];
        for(int i = 0; i < sizeX; i++) {
            for(int j = 0; j < sizeY; j++) { 
                matrixTiles[i, j] = Random.Range(0, Tiles.Length - 1);
                if(i == sizeX / 2 && j== sizeY / 2)
                {
                    matrixTiles[i, j] = Tiles.Length - 1;
                }
            }
        }
    }
    private void GenerateMap() {
        for(int i = 0; i < sizeX; i++) {
            for(int j = 0; j < sizeY; j++) {
                Vector3 position = new Vector3(sizeTile * j, 0, sizeTile * i);
                GameObject go = Instantiate(Tiles[matrixTiles[i, j]], position, Quaternion.Euler(0, randomEuler[Random.Range(0, randomEuler.Length)], 0), transform);
            }
        }
    }
    private void GenerateWalls() {
        GameObject go = Instantiate(wall, transform.position, Quaternion.identity, transform);
        go.transform.localScale = new Vector3(1, sizeTile, sizeTile * sizeX);
        go.transform.position = new Vector3(-sizeTile / 2, 0, (sizeTile * sizeX / 2) - 10);

        go = Instantiate(wall, transform.position, Quaternion.identity, transform);
        go.transform.localScale = new Vector3(1, sizeTile, sizeTile * sizeX);
        go.transform.position = new Vector3(sizeTile * sizeY - sizeTile / 2, 0, (sizeTile * sizeX / 2) - 10);

        go = Instantiate(wall, transform.position, Quaternion.identity, transform);
        go.transform.localScale = new Vector3(sizeTile * sizeY, sizeTile, 1);
        go.transform.position = new Vector3(sizeTile * sizeY / 2 - sizeTile / 2, 1, -sizeTile / 2);

        go = Instantiate(wall, transform.position, Quaternion.identity, transform);
        go.transform.localScale = new Vector3(sizeTile * sizeY, sizeTile, 1);
        go.transform.position = new Vector3(sizeTile * sizeY / 2 - sizeTile / 2, 1, sizeTile * sizeX - sizeTile / 2);
    }
    public Vector2 Size() {
        return new Vector2(sizeTile * sizeX, sizeTile * sizeY);
    }
}
