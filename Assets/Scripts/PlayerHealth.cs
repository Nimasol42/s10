using UnityEngine;
public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Player Health: " + health);
        if (health <= 0)
        {
            Debug.Log("Player died!");
            EndGame();
            
        }
    }
    
    public void AddHealth(int amount)
    {
        health += amount;
        Debug.Log("Player Health increased: " + health);
    }
    void EndGame()
    {
        Time.timeScale = 0;
    }
}

