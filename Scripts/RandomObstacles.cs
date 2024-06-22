using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RandomObstacles : MonoBehaviour
{
    public GameObject rockPrefab;
    private int numberOfRocks = 30;
    private Vector3[] randomPathPoints;
    //public Vector3 spawnBounds = new Vector3(5f, 1f, 5f); // Adjust the bounds as needed

    void Start()
    {
        GenerateRandomPath();
        SpawnRocks();
    }

    void GenerateRandomPath()
    {
        randomPathPoints = new Vector3[numberOfRocks];
        Rect movementArea = new Rect(-9.5f, -9.5f, 20, 20);

        for (int i = 0; i < numberOfRocks; i++)
        {
            float randomX = Random.Range(movementArea.xMin, movementArea.xMax);
            float randomZ = Random.Range(movementArea.yMin, movementArea.yMax);
            randomPathPoints[i] = new Vector3(randomX, 2, randomZ);
        }
    }

    void SpawnRocks()
    {
        for (int i = 0; i < numberOfRocks; i++)
        {
            Vector3 randomPosition = randomPathPoints[i];
            GameObject rock = Instantiate(rockPrefab, randomPosition, Quaternion.identity, transform);

            // Random scale for the rock
            float randomScaleX = Random.Range(1f, 3f);
            float randomScaleY = Random.Range(1f, 3f);
            float randomScaleZ = Random.Range(1f, 3f);
            Vector3 randomScale = new Vector3(randomScaleX, randomScaleY, randomScaleZ);
            rock.transform.localScale = randomScale;

            // Add a BoxCollider to the rock
            BoxCollider rockCollider = rock.AddComponent<BoxCollider>();
            // You might need to adjust the size of the collider according to your rock's size
            rockCollider.size = new Vector3(0.32f, 0.4f, 0.4f); // Adjust as needed

            // Add NavMeshObstacle component to the rock
            NavMeshObstacle obstacle = rock.AddComponent<NavMeshObstacle>();
            obstacle.shape = NavMeshObstacleShape.Box;
            obstacle.center = Vector3.zero;
            obstacle.size = rockCollider.size;

            // Enable carving
            obstacle.carving = true;
            //obstacle.carveOnlyStationary = true;
        }
    }

    Vector3 GetRandomPosition()
    {
        Vector3 center = transform.position;
        Vector3 randomPos = center + new Vector3(Random.Range(-9.5f, 10.5f),
                                                0,
                                                 Random.Range(-9.5f, 10.5f));
        return randomPos;
    }
}
