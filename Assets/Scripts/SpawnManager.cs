using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float startDelay = 2.0f;
    public float spawnRateMin = 2.5f;
    public float spawnRateMax = 3.0f;
    public GameObject obstaclePrefab;
    public Vector3 spawnPosition = new Vector3(25.0f, 0.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        float randomRate = Random.Range(spawnRateMin, spawnRateMax);
        Debug.Log(randomRate);
        InvokeRepeating(nameof(SpawnObstacle), startDelay, randomRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
    }
}
