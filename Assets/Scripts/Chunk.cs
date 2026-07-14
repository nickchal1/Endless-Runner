using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{

    [SerializeField] GameObject objectPrefab;
    [SerializeField] float[] lanes = {-2.5f, 0f, 2.5f};

    void Start()
    {
        spawnObstacle();
    }

    void spawnObstacle()
    {
        List<int> availLanes = new List<int> {0,1,2};
        int obstaclesToSpawn = Random.Range(0, lanes.Length);

        for (int i =  0; i < obstaclesToSpawn; ++i)
        {
            int randLaneIdx = Random.Range(0 ,availLanes.Count);
            int selectedLane = availLanes[randLaneIdx];
            availLanes.RemoveAt(randLaneIdx);

            Vector3 spawnPos = new Vector3(lanes[selectedLane], transform.position.y, transform.position.z);
            Instantiate(objectPrefab, spawnPos, Quaternion.identity, transform);
        }
    }


}
