using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f; // Player's movement speed

    [Header("Shooting Settings")]
    [SerializeField] private GameObject bulletPrefab;  // Bullet prefab (assign via Inspector)
    [SerializeField] private Transform bulletSpawnPoint; // The spawn point for bullet firing (assign via Inspector)
    [SerializeField] private float bulletSpeed = 10f;    // Bullet movement speed

    [Header("Health Settings")]
    [SerializeField] private int maxHealth = 100; // Maximum health of the player
    private int currentHealth; // Current health of the player

    // Private variables
    private Rigidbody2D rb;      // Reference to the Rigidbody2D component
    private Vector2 movement;    // Input for movement
    private bool facingRight = true; // Whether the player is facing right

    private void Start()
    {
        // Initialize components and health
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth; // Set current health to maximum health at the start
    }

    private void Update()
    {
        // Get horizontal and vertical input (WASD or Arrow keys)
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized; // Normalize movement vector

        // Flip the player sprite based on movement direction
        if (movement.x > 0 && !facingRight)
        {
            Flip(); // Face right
        }
        else if (movement.x < 0 && facingRight)
        {
            Flip(); // Face left
        }

        // Shoot when Space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        // Move the player using Rigidbody2D
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    // Method to shoot a bullet
    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation); // Spawn bullet at the bullet spawn point
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component of the bullet

        float direction = facingRight ? 1f : -1f; // Determine bullet direction based on player orientation
        bulletRb.linearVelocity = new Vector2(direction * bulletSpeed, 0f); // Bullet moves horizontally
    }

    // Method to flip the player's sprite
    private void Flip()
    {
        facingRight = !facingRight; // Toggle the facing direction flag
        Vector3 scale = transform.localScale; // Get the current scale
        scale.x *= -1; // Reverse the X scale for flipping the sprite
        transform.localScale = scale; // Apply the new scale
    }

    // Method to take damage
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // Reduce health by the damage amount
        Debug.Log("Player Health: " + currentHealth); // Display the player's health

        if (currentHealth <= 0)
        {
            Die(); // Call Die method if health is less than or equal to zero
        }
    }

    // Method to gain health (used by NPC interaction)
    public void GainHealth(int healthIncrease)
    {
        currentHealth += healthIncrease; 
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); 

        

        Debug.Log("Player Health increased to: " + currentHealth);
    }

    // Method to handle player death
    private void Die()
    {
        Debug.Log("Player Died!"); // Log player death
        Destroy(gameObject); // Destroy the player GameObject
    }
}