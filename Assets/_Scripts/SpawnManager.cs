using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public GameObject[] obstaclePrefabs;
    public float startDelay;
    public float repeatRate;
    private Vector3 spawnPos;
    private PlayerController _playerController;

    // Start is called before the first frame update
    void Start()
    {
        spawnPos = this.transform.position;
        InvokeRepeating("SpawnObtacle", startDelay, repeatRate);
        _playerController = GameObject.Find("player").GetComponent<PlayerController>();
    }

    void SpawnObtacle()
    {
        if (!_playerController.GameOver)
        {
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            //Instantiate(obstaclePrefab, obstaclePrefab.transform.position, obstaclePrefab.transform.rotation);
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }


    }

}
