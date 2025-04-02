using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    public GameObject npcPrefab;        
    public float spawnInterval = 5f;     
    public float spawnRangeX = 8f;        
    public float spawnRangeY = 4f;        
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnNPC();
        }
    }

    void SpawnNPC()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-spawnRangeX, spawnRangeX), Random.Range(-spawnRangeY, spawnRangeY));
        Instantiate(npcPrefab, spawnPos, Quaternion.identity);
    }
}