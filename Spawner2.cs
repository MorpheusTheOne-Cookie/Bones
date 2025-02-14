using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2 : MonoBehaviour
{
    private float timeBtwSpawns;

    private float spawnRate;

    public GameObject[] obstaclesTemplate;

    public Transform[] spawnPoints;

    private void Start()
    {
        spawnRate = Random.Range(3f, 7f);
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

            spawnRate = Random.Range(3f, 7f);
            timeBtwSpawns = spawnRate;

        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}
