using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacteriaSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRange;
    [SerializeField] private Vector2 minMaxSpawnRate;
    [SerializeField] GameObject[] bacteriaPrefabs;
    private float nextSpawnTime;
    void Start()
    {
        nextSpawnTime = Random.Range(minMaxSpawnRate.x, minMaxSpawnRate.y);
    }

    void Update()
    {
        nextSpawnTime -= Time.deltaTime;

        if(nextSpawnTime <= 0)
        {
            nextSpawnTime = Random.Range(minMaxSpawnRate.x, minMaxSpawnRate.y);
            int randomBacteriaIndex = Random.Range(0, bacteriaPrefabs.Length);
            Instantiate(bacteriaPrefabs[randomBacteriaIndex], transform).transform.position = new Vector3(Random.Range(-spawnRange, spawnRange), transform.position.y, transform.position.z);
        }
    }
}
