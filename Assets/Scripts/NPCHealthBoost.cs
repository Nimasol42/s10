using UnityEngine;
public class NPCHealthBoost : MonoBehaviour
{
    public int healthBoost = 10;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth ph = other.GetComponent<PlayerHealth>();
            if (ph != null)
            {
                ph.AddHealth(healthBoost);
            }
        }
    }
}