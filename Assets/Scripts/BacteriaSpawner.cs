using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacteriaSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRange;
    [SerializeField] private Vector2 minMaxSpawnRate;
    [SerializeField] GameObject[] bacteriaPrefabsGood;
    [SerializeField] GameObject bacteriaPrefabBadSmall;
    [SerializeField] GameObject bacteriaPrefabBadBig;
    private float nextSpawnTime;

    [Header("Spawn chances")]
    [SerializeField, Range(0, 100f)] float chanceOfGoodToBadSpawn;
    [SerializeField, Range(0, 100f)] float chanceOfBigBadSpawnToSmall;

    void Start()
    {
        nextSpawnTime = Random.Range(minMaxSpawnRate.x, minMaxSpawnRate.y);

        chanceOfGoodToBadSpawn = float.Parse(SettingsLoader.Instance.Settings.SpawnChanceOfGoodToBad);
        chanceOfBigBadSpawnToSmall = float.Parse(SettingsLoader.Instance.Settings.SpawnChanceOfBigBad);
    }

    void Update()
    {
        nextSpawnTime -= Time.deltaTime;

        if(nextSpawnTime <= 0)
        {
            nextSpawnTime = Random.Range(minMaxSpawnRate.x, minMaxSpawnRate.y);


            float random = Random.Range(0f, 100.0f);

            if (random <= chanceOfGoodToBadSpawn)
            {
                int randomBacteriaIndex = Random.Range(0, bacteriaPrefabsGood.Length);
                Instantiate(bacteriaPrefabsGood[randomBacteriaIndex], transform).transform.position = new Vector3(Random.Range(-spawnRange, spawnRange), transform.position.y, transform.position.z);
            }
            else
            {
                random = Random.Range(0f, 100.0f);

                if (random <= chanceOfBigBadSpawnToSmall)
                {
                    Instantiate(bacteriaPrefabBadBig, transform).transform.position = new Vector3(Random.Range(-spawnRange, spawnRange), transform.position.y, transform.position.z);
                }
                else
                {
                    Instantiate(bacteriaPrefabBadSmall, transform).transform.position = new Vector3(Random.Range(-spawnRange, spawnRange), transform.position.y, transform.position.z);
                }
            }
        }
    }
}
