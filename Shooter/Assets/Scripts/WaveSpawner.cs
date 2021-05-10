using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] Transform[] spawnObjects;
    [SerializeField] Transform[] spawnPositions;
    [SerializeField] float spawnDelay;

    public void StartSpawning()
    {
        StartCoroutine("SpawnWaves");
    }

    public void StopSpawning()
    {
        StopCoroutine("SpawnWaves");
    }

    IEnumerator SpawnWaves()
    {
        while (true)
        {
            //Randomly select spawn position and spawn object
            var spawnPosIndex = Random.Range(0, spawnPositions.Length);
            var spawnObjIndex = Random.Range(0, spawnObjects.Length);
            //Spawn object at position
            Instantiate(spawnObjects[spawnObjIndex], spawnPositions[spawnPosIndex].position, Quaternion.identity);
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
