using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Spawner Settings")]
    [SerializeField] private GameObject enemyPrefab;  // Prefab of the enemy to spawn
    [SerializeField] private float spawnInterval = 3f; // Time interval between enemy spawns
    [SerializeField] private float spawnDistance = 10f; // Distance from the player where enemies will spawn

    private float timer = 0f; // Timer for tracking spawn intervals

    [Header("Player Reference")]
    [SerializeField] private Transform player; // Reference to the player, manually assignable via Inspector

    private void Update()
    {
        // Increment the spawn timer
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnEnemy(); // Spawn an enemy
        }
    }

    private void SpawnEnemy()
    {
        // Ensure player reference exists
        if (player == null) return;

        // Random direction around the player
        Vector2 randomDirection = Random.insideUnitCircle.normalized;
        // Calculate spawn position based on player position and spawn distance
        Vector2 spawnPos = (Vector2)player.position + randomDirection * spawnDistance;

        // Instantiate the enemy at the calculated position
        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}