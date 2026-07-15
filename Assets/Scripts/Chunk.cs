using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{

    [SerializeField] GameObject objectPrefab;
    [SerializeField] float[] lanes = {-2.5f, 0f, 2.5f};
    [SerializeField] GameObject[] powerUpPrefabs;
    [SerializeField] float powerUpSpawnChance = 0.25f;
    float powerUpHeight = 0.5f;

    void Start()
    {
        List<int> availableLanes = new List<int> {0,1,2};
        spawnObstacle(availableLanes);
        spawnPowerUp(availableLanes);
    }

    void spawnObstacle(List<int> availableLanes)
    {
        
        int obstaclesToSpawn = Random.Range(0, lanes.Length);

        for (int i =  0; i < obstaclesToSpawn; ++i)
        {
            int randLaneIdx = Random.Range(0 ,availableLanes.Count);
            int selectedLane = availableLanes[randLaneIdx];
            availableLanes.RemoveAt(randLaneIdx);

            Vector3 spawnPos = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate(objectPrefab, spawnPos, Quaternion.identity, transform);
        }
    }

    void spawnPowerUp(List<int> availableLanes)
    {

        if (availableLanes.Count == 0 || powerUpPrefabs.Length == 0)
        {
            return;
        }

        if (Random.value > powerUpSpawnChance)
        {
            return;
        }

        int randLaneIndex = Random.Range(0, availableLanes.Count);
        int selectedLane = availableLanes[randLaneIndex];

        int randomPowerUpIndex = Random.Range(0, powerUpPrefabs.Length);
        GameObject selectedPowerUp = powerUpPrefabs[randomPowerUpIndex];

        Vector3 spawnPosition = new Vector3(
        1.4f * lanes[selectedLane] , transform.position.y + powerUpHeight, transform.position.z);

        Instantiate(selectedPowerUp, spawnPosition, Quaternion.identity, transform);
        availableLanes.RemoveAt(randLaneIndex);
    }

}
