using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] groundPrefabs;
    Vector3 spawnVector;
    public float spawnX = 7f;
    private float spawnY = 2.5f;
    public int x = 0;

    

    void Start()
    {
        spawnVector = new Vector3(6, 1, 0);
        InvokeRepeating("SpawnGround", .5f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnGround()
    {
        Instantiate(groundPrefabs[x], spawnVector, Quaternion.identity);
        spawnVector.x += spawnX;
        spawnVector.y += Random.Range(-spawnY, 2f);
    }
}
