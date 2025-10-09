using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public float spawnRate = 2f;
    public float heightOffset = 1.5f;

    public void StartSpawning()
    {
        InvokeRepeating(nameof(SpawnPipe), 0, spawnRate);
    }
    
    void SpawnPipe()
    {
        float randomHeight = Random.Range(-heightOffset, heightOffset);
        Vector3 spawnPos = transform.position + new Vector3(7.5f, randomHeight, 0);
        Instantiate(pipePrefab, spawnPos, Quaternion.identity);
    }
}