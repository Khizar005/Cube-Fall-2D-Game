using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab , RotatingPlatformPrefab;
    public GameObject spikePlatformPrefab;
    public GameObject[] movingPlatforms;
    public GameObject breakablePlatformPrefab;
    public GameObject BossPlatformPrefab;

    public float platformSpawnTimer = 1f;
    private float currentPlatformSpawnTimer;

    private int platformSpawnCount;

    public float minX = -2.16f, maxX = 2.16f;

    private bool gameOver;

    private void Start()
    {
        currentPlatformSpawnTimer = platformSpawnTimer;
        gameOver = false;
    }

    private void Update()
    {
        if (!gameOver)
        {
            SpawnPlatform();
        }
    }

    private void SpawnPlatform()
    {
        currentPlatformSpawnTimer += Time.deltaTime;
        if (currentPlatformSpawnTimer >= platformSpawnTimer)
        {
            platformSpawnCount++;

            Vector3 temp = transform.position;
            temp.x = Random.Range(minX, maxX);

            GameObject newPlatform = null;

            if (platformSpawnCount < 2)
            {
                newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
            }
            else if (platformSpawnCount == 2)
            {
                int random = Random.Range(0, 3);

                if (random == 0)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else if (random == 1)
                {
                    int randomIndex = Random.Range(0, movingPlatforms.Length);
                    newPlatform = Instantiate(movingPlatforms[randomIndex], temp, Quaternion.identity);
                }
                else if (random == 2)
                {
                    newPlatform = Instantiate(RotatingPlatformPrefab, temp, Quaternion.identity);
                }
            }
            else if (platformSpawnCount == 3)
            {
                int random = Random.Range(0, 3);

                if (random == 0)
                {
                    newPlatform = Instantiate(platformPrefab , temp, Quaternion.identity);
                }
                else if (random == 1)
                {
                    newPlatform = Instantiate(spikePlatformPrefab, temp, Quaternion.identity);
                }
                else if (random == 2)
                {
                    newPlatform = Instantiate(RotatingPlatformPrefab, temp, Quaternion.identity);
                }
            }
            else if (platformSpawnCount == 4)
            {
                int random = Random.Range(0, 3);

                if (random == 0)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else if (random == 1)
                {
                    newPlatform = Instantiate(BossPlatformPrefab, temp, Quaternion.identity);
                }
                else if (random == 2)
                {
                    newPlatform = Instantiate(RotatingPlatformPrefab, temp, Quaternion.identity);
                }
            }
            else if (platformSpawnCount == 6)
            {
                int random = Random.Range(0, 3);

                if (random == 0)
                {
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else if (random == 1)
                {
                    newPlatform = Instantiate(breakablePlatformPrefab, temp, Quaternion.identity);
                }
                else if (random == 2)
                {
                    newPlatform = Instantiate(RotatingPlatformPrefab, temp, Quaternion.identity);
                }

                platformSpawnCount = 0;
            }

            if (newPlatform != null)
            {
                newPlatform.transform.parent = transform;
            }

            currentPlatformSpawnTimer = 0;
        }
    }
}
