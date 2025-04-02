using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;       // Movement speed of the enemy
    public int damage = 10;       // Damage dealt to the player
    public int health = 20;       // Health of the enemy

    private Transform player;

    void Start()
    {
        // Find the player object by its tag
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;
    }

    void Update()
    {
        // Move towards the player
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the enemy collides with the player
        if (collision.CompareTag("Player"))
        {
            PlayerController pc = collision.GetComponent<PlayerController>();
            if (pc != null)
            {
                pc.TakeDamage(damage); // Deal damage to the player
            }

            // Destroy the enemy after dealing damage to the player
            Destroy(gameObject);
        }

        // Check if the enemy collides with a bullet
        if (collision.CompareTag("Bullet"))
        {
            Bullet bullet = collision.GetComponent<Bullet>();
            if (bullet != null)
            {
                TakeDamage(bullet.damage); // Reduce health by the damage amount
                Destroy(collision.gameObject); // Destroy the bullet
            }
        }
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount; // Reduce the enemy's health
        if (health <= 0)
        {
            Destroy(gameObject); // Destroy the enemy if health drops to zero or below
        }
    }
}