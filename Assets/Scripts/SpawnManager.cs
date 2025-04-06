using UnityEngine;
public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject npcPrefab;
    public int maxEnemies = 10;
    public int maxNPC = 5;
    public float enemySpawnRange = 20f;
    public float npcSpawnRange = 20f;
    public float spawnInterval = 1f;
    private float enemyTimer;
    private float npcTimer;
    void Update()
    {
        enemyTimer += Time.deltaTime;
        npcTimer += Time.deltaTime;
        if (enemyTimer >= spawnInterval)
        {
            SpawnEnemies();
            enemyTimer = 0f;
        }
        if (npcTimer >= spawnInterval)
        {
            SpawnNPCs();
            npcTimer = 0f;
        }
    }
    void SpawnEnemies()
    {
        int currentEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        while (currentEnemies < maxEnemies)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-enemySpawnRange, enemySpawnRange), 0f, Random.Range(-enemySpawnRange, enemySpawnRange));
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            currentEnemies++;
        }
    }
    void SpawnNPCs()
    {
        int currentNPCs = GameObject.FindGameObjectsWithTag("NPC").Length;
        while (currentNPCs < maxNPC)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-npcSpawnRange, npcSpawnRange), 0f, Random.Range(-npcSpawnRange, npcSpawnRange));
            Instantiate(npcPrefab, spawnPos, Quaternion.identity);
            currentNPCs++;
        }
    }
}