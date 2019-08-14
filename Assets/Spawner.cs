using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public GameObject hexagonPrefab;
    public float spawnRate = 0f;
    public float minSpawnRate = 0.5f;
    public float maxSpawnRate = 1f;
    private float nextTimeToSpawn = 0;
    public float accelerationTime = 10f;
    float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
        spawnRate = minSpawnRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextTimeToSpawn)
        {
            spawnRate = Mathf.Lerp(minSpawnRate, maxSpawnRate, (Time.time - startTime)/accelerationTime);
            Instantiate(hexagonPrefab, Vector3.zero, Quaternion.identity);
            nextTimeToSpawn = Time.time + (maxSpawnRate + 1f) / spawnRate;
        }
    }
 
}
