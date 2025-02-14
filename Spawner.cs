using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float timeBtwSpawns;

    public float spawnRate;

    public GameObject[] obstaclesTemplate;

    public Transform[] spawnPoints;

    private void Start()
    {
        timeBtwSpawns = spawnRate;
    }

    private void Update()
    {
        if (timeBtwSpawns <= 0)
        {
            int randomObstacle = Random.Range(0, obstaclesTemplate.Length);
            int randomHeight = Random.Range(0, spawnPoints.Length);
            Vector2 position = new Vector2(transform.position.x, spawnPoints[randomHeight].position.y);

            Instantiate(obstaclesTemplate[randomObstacle], position, Quaternion.identity);


            timeBtwSpawns = spawnRate;

        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}
