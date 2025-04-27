using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float startDelay = 2.0f;
    public float spawnRateMin = 2.5f;
    public float spawnRateMax = 3.0f;
    private string _player = "Player";
    public GameObject obstaclePrefab;
    private PlayerController _playerController;
    public Vector3 spawnPosition = new Vector3(25.0f, 0.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        _playerController = GameObject.Find(_player).GetComponent<PlayerController>();
        float randomRate = Random.Range(spawnRateMin, spawnRateMax);
        InvokeRepeating(nameof(SpawnObstacle), startDelay, randomRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle()
    {
        if(obstaclePrefab != null && _playerController != null && _playerController.isGameOver == false)
            Instantiate(obstaclePrefab, spawnPosition, obstaclePrefab.transform.rotation);
    }
}
