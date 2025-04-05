using UnityEngine;
public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject npcPrefab;
    public float spawnRange = 20f;
    public int enemyCount = 5;
    public int npcCount = 5;
    void Start()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRange, spawnRange), 0.5f, Random.Range(-spawnRange, spawnRange));
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
        for (int i = 0; i < npcCount; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRange, spawnRange), 0.5f, Random.Range(-spawnRange, spawnRange));
            Instantiate(npcPrefab, spawnPos, Quaternion.identity);
        }
    }
}