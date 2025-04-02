using UnityEngine;

public class NPC : MonoBehaviour
{
    public int healthIncrease = 5; 

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController pc = collision.GetComponent<PlayerController>();
            if (pc != null)
            {
                pc.GainHealth(healthIncrease);
                Debug.Log("Player gained " + healthIncrease + " health from NPC!");
            }
            Destroy(gameObject);
        }
    }
}