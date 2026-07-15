using System.Collections.Generic;
using UnityEngine;

public class LeverGenerator : MonoBehaviour
{
    [SerializeField] GameObject chunkPrefab;
    [SerializeField] int chunkAmt = 12;
    [SerializeField] Transform chunkParent;
    [SerializeField] float chunkLen = 10f;
    [SerializeField] float moveSpeed = 8f;
    

    List<GameObject> chunks = new List<GameObject>();
    float speedMultiplier = 1f;

    void Start()
    {
        SpawnStartingChunks();
    }

    void Update()
    {
        MoveChunks();
    }

    private void SpawnStartingChunks()
    {
        for (int i = 0; i < chunkAmt; ++i)
        {
            SpawnChunk();
        }
    }

    private void SpawnChunk()
    {
        // calc z value for chunk spawning (last chunk in list)
        //check if first chunk
        float spawnPos;
        if (chunks.Count == 0)
        {
            spawnPos = transform.position.z;
        }
        else
        {
            spawnPos = chunks[chunks.Count - 1].transform.position.z + chunkLen;

        }

        Vector3 chunkSpawnPos = new Vector3(transform.position.x, transform.position.y, spawnPos);
        GameObject newChunk = Instantiate(chunkPrefab, chunkSpawnPos, Quaternion.identity, chunkParent);
        chunks.Add(newChunk);
    }

    //move chunks backwards
    private void MoveChunks()
    {
        for (int i = 0; i < chunks.Count; ++i)
        {
            GameObject chunk = chunks[i];

            //mult floats first
            chunk.transform.Translate(-transform.forward * (moveSpeed * Time.deltaTime * speedMultiplier));

            if (chunk.transform.position.z <= Camera.main.transform.position.z - chunkLen)
            {
                chunks.Remove(chunk);
                Destroy(chunk);
                SpawnChunk();
            }
        }
    }

    public void SetSpeedMultiplier(float multiplier)
    {
        speedMultiplier = multiplier;
        Debug.Log("mult: " + speedMultiplier);
    }
}
