using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 2f;  // Lifetime of the bullet before it gets destroyed
    public int damage = 10;      // Damage dealt by the bullet

    void Start()
    {
        // Destroy the bullet after a certain lifetime
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) // Check if the bullet collides with an enemy
        {
            Debug.Log("Collision with: " + collision.name);
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage); // Apply damage to the enemy
            }

            // Destroy the bullet after impact
            Destroy(gameObject);
        }

    }
}